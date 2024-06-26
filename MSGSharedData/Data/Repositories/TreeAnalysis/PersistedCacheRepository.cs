﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FTMContext;
using FTMContextNet.Domain.Collections;
using FTMContextNet.Domain.Entities.NonPersistent;
using FTMContextNet.Domain.Entities.NonPersistent.Person;
using FTMContextNet.Domain.Entities.Persistent.Cache;
using FTMContextNet.Domain.ExtensionMethods;
using GoogleMapsHelpers;
using LoggingLib;
using Microsoft.EntityFrameworkCore;
using PlaceLibNet.Domain.Entities;
using QuickGed.Types;

namespace FTMContextNet.Data.Repositories.TreeAnalysis
{
    //todo sort this out, but do we really need 10 extra files(with interfaces) 1 for each table?
    public class PersistedCacheRepository : IPersistedCacheRepository
    {
        private readonly IPersistedCacheContext _persistedCacheContext;
        private readonly Ilog _iLog;

        public PersistedCacheRepository(IPersistedCacheContext persistedCacheContext, Ilog iLog)
        {
            _persistedCacheContext = persistedCacheContext;
            _iLog = iLog;
        }

        public List<string> DumpCount()
        {

            List<string> results = new List<string>();

            DumpRecordCount(results, _persistedCacheContext.FTMPersonView, "FTMPersonView");
            //  DumpRecordCount(results, _persistedCacheContext.FTMPlaceCache, "FTMPlaceCache");
            DumpRecordCount(results, _persistedCacheContext.DupeEntries, "DupeEntries");

            return results;
        }

        private void DumpRecordCount<T>(List<string> results, DbSet<T> set, string name) where T : class
        {
            string result = "";

            var count = set.Count();

            if (count > 0)
                result = name + " " + set.Count();

            if (result != "")
                results.Add(result);
        }

        #region deletes

        public void DeleteDupes(int importId)
        {
            _persistedCacheContext.DeleteDupes(importId);
        }

        public void DeleteDupes()
        {
            _persistedCacheContext.DeleteDupes();
        }

        public void DeletePersons(int importId)
        {
            _persistedCacheContext.DeletePersons(importId);
        }

        public void DeleteTreeRecord(int importId)
        {
            _persistedCacheContext.DeleteTreeRecord(importId);
        }

        public void DeleteRelationships(int importId)
        {
            _persistedCacheContext.DeleteMarriages(importId);
        }

        public void DeleteTreeGroups(int importId)
        {
            _persistedCacheContext.DeleteTreeGroups(importId);
        }

        public void DeleteRecordMapGroups(int importId)
        {
            _persistedCacheContext.DeleteRecordMapGroups(importId);
        }

        public void DeleteOrigins(int importId)
        {
            _persistedCacheContext.DeleteOrigins(importId);
        }

        public bool ImportPresent(int importId)
        {
            //throw new NotImplementedException();
            return _persistedCacheContext.FTMPersonView.Any(a => a.ImportId == importId);
        }

        #endregion


        #region Valid Data
        private static Expression<Func<FTMPersonView, bool>> ValidData(int importId)
        {
            if (importId != 0)
            {
                return w =>
                    !string.IsNullOrEmpty(w.FirstName)
                    && !w.FirstName.ToLower().Contains("group")
                    && !string.IsNullOrEmpty(w.Surname)
                    && !string.IsNullOrEmpty(w.Origin)
                    && w.Origin != "Thackray"
                    && w.ImportId == importId;
            }

            return w =>
                !string.IsNullOrEmpty(w.FirstName)
                && !w.FirstName.ToLower().Contains("group")
                && !string.IsNullOrEmpty(w.Surname)
                && !string.IsNullOrEmpty(w.Origin)
                && w.Origin != "Thackray";
        }

        #endregion

        public List<string> MakePlaceRecordCache(int importId)
        {
            var comparisonPersons = _persistedCacheContext
                .FTMPersonView.Where(w => !w.LocationsCached && w.Location != null && w.ImportId == importId).Select(s => s.Location).ToList();

            comparisonPersons.AddRange(_persistedCacheContext.FTMPersonView.Where(w => !w.LocationsCached
                && w.AltLocation != null && w.ImportId == importId).Select(s => s.AltLocation).ToList());


            return comparisonPersons;
        }

        public void CreatePersonOriginEntries(int importId, int userId)
        {
            DeleteOrigins(userId);

            var recordsToSave = _persistedCacheContext
                .FTMPersonView
                .Where(w => w.Origin != "" && w.UserId == userId)
                .Select(s => new PersonOrigins()
                {
                    Id = s.Id,
                    Origin = s.Surname.ToLower().Contains("group") ? s.Surname : s.Origin,
                    DirectAncestor = s.DirectAncestor,
                    ImportId = s.ImportId
                }).ToList();

            _persistedCacheContext.BulkInsertPersonOrigins( userId, recordsToSave.OrderBy(o => o.Origin).ToList());

        }

        public DuplicateIgnoreList GetIgnoreList()
        {
            return new DuplicateIgnoreList(_persistedCacheContext.IgnoreList.ToList());
        }

        public List<PersonIdentifier> GetComparisonPersons(int importId)
        {

            var comparisonPersons = _persistedCacheContext.FTMPersonView
                .Where(ValidData(importId))
             .Select(s => PersonIdentifier.Create(s.Id,
                 s.YearStart, s.YearEnd, s.Origin, EnglishHistoricCounties.Match(string.IsNullOrEmpty(s.Location) ? s.AltLocation : s.Location), s.Lng, s.Lat,
                 s.Surname, s.FirstName)).ToList();

            return comparisonPersons;
        }

        public List<PersonLocation> GetPersonMapLocations()
        {

            var comparisonPersons = 
                _persistedCacheContext.FTMPersonView.Where(ValidData(0))
                .Select(s => new PersonLocation()
                {
                    Id = s.PersonId,
                    Location = s.Location,
                    Lat = s.Lat.ToString(),
                    Lng = s.Lng.ToString(),
                    AltLocation = s.AltLocation,
                    AltLat = s.AltLat.ToString(),
                    AltLng = s.AltLong.ToString()
                }).ToList();

            return comparisonPersons;
        }



        public void AddDupeEntrys(List<KeyValuePair<int, string>> dupes, int userId)
        {
            var dupeId = (_persistedCacheContext.DupeEntries.Max(a => (int?)a.Id) ?? 1) + 1;


            foreach (var pair in dupes)
            {

                var personId = pair.Key;
                var ident = pair.Value;
                var fpvPerson = _persistedCacheContext.FTMPersonView.First(f => f.Id == personId);

                var dupeEntry = new DupeEntry
                {
                    Id = dupeId,
                    Ident = ident,
                    PersonId = fpvPerson.Id,
                    YearStart = fpvPerson.YearStart,
                    YearEnd = fpvPerson.YearEnd,
                    Origin = fpvPerson.Origin,
                    Location = Location.FormatPlace(fpvPerson.Location),
                    FirstName = fpvPerson.FirstName,
                    Surname = fpvPerson.Surname,
                    UserId = userId,
                    ImportId = fpvPerson.ImportId
                };

                _persistedCacheContext.DupeEntries.Add(dupeEntry);

                dupeId++;
            }

            _persistedCacheContext.SaveChanges();

        }

        public int OriginPersonCount()
        {
            return _persistedCacheContext.PersonOrigins.Count() + 1;
        }

        public void BulkUpdatePersons(List<PlaceLocationDto> dataset)
        {
            _persistedCacheContext.BulkUpdatePersonLocations(dataset);
        }

        public void UpdatePersons(int personId, string lat, string lng, string altLat, string altLng)
        {
            _persistedCacheContext.UpdatePersonLocations(personId, lng, lat, altLng, altLat);
        }

        #region debug data

        public Info GetInfo(int userId)
        {

            var pCount = _persistedCacheContext.FTMPersonView.Count();
            var mcount = _persistedCacheContext.Relationships.Count();
            var originsCount = _persistedCacheContext.PersonOrigins.Count();

            return new Info()
            {
                MarriagesCount = mcount,
                PersonViewCount = pCount,
                OriginMappingCount = originsCount,
                DupeEntryCount = _persistedCacheContext.DupeEntries.Count(),
                TreeRecordCount = _persistedCacheContext.TreeRecord.Count()
            };
        }

        #endregion

        /// <summary>
        /// Updates treerecords table in cache. 
        /// stores number of people in tree.
        /// tree name etc
        /// </summary>
        public void PopulateTreeRecordFromCache(int userId, int importId)
        {
            var treeRecords = new List<TreeRecord>();

            var locationsMapOrigin = _persistedCacheContext.FTMPersonView.Where(w=>w.ImportId == importId).Select(s => new { s.Origin, s.LinkedLocations }).ToList();

            foreach (var tree in GetRootNameDictionary(importId).Values)
            {
                var treeLocations = locationsMapOrigin.Where(c => c.Origin == tree)
                    .Select(s => s.LinkedLocations).ToArray();

                treeRecords.Add(TreeRecord.CreateFromOrigin(tree.Trim(),
                    string.Join(",", EnglishHistoricCounties.FromPlaceList(treeLocations)),
                    treeLocations.Length, importId));

            }

            _iLog.WriteLine("Created " + _persistedCacheContext.BulkInsertTreeRecord(userId, treeRecords) + " tree records",2);
        }

        #region inserts

        public int InsertTreeGroups(int id, string treeGroup, int importId, int userId)
        {
            return _persistedCacheContext.InsertGroups(id, treeGroup.Trim(), importId, userId);
        }

        public void InsertTreeGroups(Dictionary<int, string> treeGroups, int importId, int userId)
        {
            foreach (var group in treeGroups)
            {
                InsertTreeGroups(group.Key, group.Value, importId, userId);
            }
        }

        public int InsertTreeRecordMapGroup(string treeGroup, string treeName, int importId, int userId)
        {
            return _persistedCacheContext.InsertRecordMapGroup(treeGroup.Trim(), treeName.Trim(), importId, userId);
        }

        public void InsertTreeRecordMapGroup(Dictionary<string, List<string>> recordMapGroups, int importId, int userId)
        {
            foreach (var grp in recordMapGroups)
            {
                foreach (var mapping in grp.Value)
                {
                    InsertTreeRecordMapGroup(mapping, grp.Key, importId, userId);
                }
            }

            _persistedCacheContext.UpdateRecordMapGroupIds();
        }

        public int LastId()
        {
            return _persistedCacheContext.FTMPersonView.Max(m => m.Id);
        }

        public void InsertPersons(int importId, int userId, List<Person> persons)
        {
            //int nextId = 1;
            
            //if(_persistedCacheContext.FTMPersonView.Any())
            //    nextId= _persistedCacheContext.FTMPersonView.Max(m => m.Id) + 1;

            var ftmPersons = persons.Select(person => FTMPersonView.Create(person)).ToList();

            _persistedCacheContext.BulkInsertFTMPersonView( importId, userId, ftmPersons);
        }

        public void InsertRelationships(int importId, int userId, List<RelationSubSet> marriages)
        {
            //int nextId = 1;

            //if(_persistedCacheContext.Relationships.Any()) 
            //    nextId = _persistedCacheContext.Relationships.Max(m => m.Id) + 1;

            var ftmPersons = marriages.Select(person => Relationships.Create(person)).ToList();

            _persistedCacheContext.BulkInsertMarriages( importId, userId, ftmPersons);
        }

        #endregion

        public Dictionary<string, List<string>> GetGroups(int importId)
        {
            var results = new Dictionary<string, List<string>>();

            var treeIds = GetTreeIds(importId);

            var tp = GetRelationships(importId);

            var nameDict = GetRootNameDictionary(importId);

            var groupNames = GetGroupNamesDictionary(importId);

            foreach (var treeId in treeIds)
            {
                var groupMembers = tp.Where(t => t.MatchEither(treeId)).Select(s => s.GetOtherSide(treeId)).Distinct().ToList();

                results.Add(nameDict[treeId], (from gm in groupMembers where groupNames.ContainsKey(gm) select groupNames[gm]).ToList());
            }

           

            return results;
        }
        public Dictionary<int, string> GetGroupPerson(int importId)
        {

            var gps = _persistedCacheContext
                .FTMPersonView
                .Where(x => x.LinkNode && x.ImportId == importId)
                .ToDictionary(s => s.PersonId, x => x.FirstName + " " + x.Surname);


            return gps;
        }

        private Dictionary<int, string> GetRootNameDictionary(int importId)
        {
            var nameDict = _persistedCacheContext
                .FTMPersonView
                .Where(w => w.RootPerson && w.ImportId == importId)
                .ToDictionary(i => i.Id, i => (i.FirstName + " " + i.Surname).Trim());
            return nameDict;
        }
        private List<int> GetTreeIds(int importId)
        {
            var treeIds = _persistedCacheContext
                .FTMPersonView
                .Where(w => w.RootPerson && w.ImportId == importId)
                .Select(s => s.Id).ToList();
            return treeIds;
        }
        private Dictionary<int, string> GetGroupNamesDictionary(int importId)
        {
            var groupNames = _persistedCacheContext
                .FTMPersonView
                .Where(p => p.LinkNode && p.ImportId == importId)
                .ToDictionary(i => i.Id, i => i.FirstName + " " + i.Surname);
            return groupNames;
        }
        private List<RelationSubSet> GetRelationships(int importId)
        {
            var tp = _persistedCacheContext.Relationships.Where(w => w.ImportId == importId)
                .Select(s => new RelationSubSet() { Person1Id = s.GroomId, Person2Id = s.BrideId }).ToList();
            return tp;
        }


    }
}
