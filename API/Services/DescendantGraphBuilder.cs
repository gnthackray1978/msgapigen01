﻿using Api.Models;
using Api.Types.Diagrams;
using AzureContext.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Services
{
    public class GraphMarriage
    {
        public int FatherId { get; set; }
        public int MotherId { get; set; }
    }
    public partial class DiagramService
    {
        public class DescendantGraphBuilder
        {
            private readonly AzureDBContext _azureDbContext;
            private List<FTMPersonView> _persons;
            private List<GraphMarriage> _graphMarriages;

            public DescendantGraphBuilder(AzureDBContext azureDbContext)
            {
                _azureDbContext = azureDbContext;

               

            }



            public List<DescendantNode> GenerateDescendantGraph(int personId, string origin)
            {
                List<List<DescendantNode>> results = new List<List<DescendantNode>>();

                Console.WriteLine("GenerateDescendantGraph");


                _persons = _azureDbContext.FTMPersonView.Where(w => w.Origin == origin).ToList();

                _graphMarriages = new List<GraphMarriage>();

                var g = _persons.GroupBy(d => new { d.FatherId, d.MotherId })
                    .Select(m => new { m.Key.FatherId, m.Key.MotherId });

                foreach (var group in g)
                {
                    _graphMarriages.Add(new GraphMarriage() { FatherId = group.FatherId.GetValueOrDefault(), MotherId = group.MotherId.GetValueOrDefault() });
                }


                var startPerson = _persons.FirstOrDefault(fd => fd.PersonId == personId);

                var result = GetNextAncestor(startPerson.FatherId);

                var child = _persons.FirstOrDefault(r => r.PersonId == result);

                results.Add(new List<DescendantNode>());
                results.Last().Add(new DescendantNode()
                {
                    PersonId = child.PersonId.GetValueOrDefault(),
                    BirthLocation = child.Location,
                    ChristianName = child.FirstName,
                    Surname = child.Surname,
                    DOB = child.YearFrom.ToString(),
                    FatherId = child.FatherId.GetValueOrDefault(),
                    MotherId = child.MotherId.GetValueOrDefault(),
                    ChildIdxLst = new List<int>(),
                    ChildLst = new List<int>(),
                    SpouseIdxLst = new List<int>(),
                    SpouseIdLst = new List<int>(),
                    Id = 0
                }
                );

                int currentGeneration = 0;

                fillChildGenerations(result, ref results, ref currentGeneration);

                List<DescendantNode> flattenedResults = new List<DescendantNode>();

                int id = 0;

                foreach (var gp in results)
                {
                    var idx = 0;
                    foreach (var p in gp)
                    {
                        p.Index = idx;
                        p.Id = id;
                        idx++;
                        id++;
                        flattenedResults.Add(p);
                    }
                }


                return flattenedResults;
            }



            private DescendantNode getAncestorFromGraph(List<List<DescendantNode>> destination, int personId)
            {
                return destination.SelectMany(gen => gen).FirstOrDefault(person => person.PersonId == personId);
            }

            private void fillChildGenerations(int personId, ref List<List<DescendantNode>> destination, ref int currentGeneration)
            {
                //look up the children for this father.
                //add them to generation.

                //search through generations to find the current the generation we need

                string description = "";

                var person1 = getAncestorFromGraph(destination, personId);

                if (person1 != null)
                {
                    description = person1.DOB + " " + person1.ChristianName + " " + person1.Surname;

                    Console.WriteLine(description);
                }


                var children = _persons.Where(fd => (fd.FatherId == personId) || fd.MotherId == personId).ToList();

                if (children.Count == 0)
                {
                    // currentGeneration--;
                    return;
                }
                // does tree already contain this person somewhere? if so what generation.

                currentGeneration = person1.GenerationIdx + 1;

                if (currentGeneration >= destination.Count)
                {
                    destination.Add(new List<DescendantNode>());
                }


                var workingCopy = destination[currentGeneration];

                List<int> newlyAdded = new List<int>();
                int childIdx = 0;
                int spouseCount = 0;

                foreach (var child in children)
                {


                    int fatherIdx = -1;
                    int motherIdx = -1;

                    if (currentGeneration > 0)
                    {
                        fatherIdx = GetIndexFromGeneration(destination[currentGeneration - 1], child.FatherId.GetValueOrDefault());
                        motherIdx = GetIndexFromGeneration(destination[currentGeneration - 1], child.MotherId.GetValueOrDefault());
                    }



                    workingCopy.Add(new DescendantNode()
                    {

                        IsFamilyStart = childIdx == 0,
                        PersonId = child.PersonId.GetValueOrDefault(),
                        BirthLocation = child.Location,
                        ChristianName = child.FirstName,
                        Surname = child.Surname,
                        DOB = child.YearFrom.ToString(),
                        FatherId = child.FatherId.GetValueOrDefault(),
                        FatherIdx = fatherIdx,
                        MotherId = child.MotherId.GetValueOrDefault(),
                        MotherIdx = motherIdx,
                        GenerationIdx = currentGeneration,
                        ChildIdxLst = new List<int>(),
                        ChildLst = new List<int>(),
                        SpouseIdxLst = new List<int>(),
                        SpouseIdLst = new List<int>()
                    }
                );


                    var spouseList = makeSpouse(child.PersonId.GetValueOrDefault(), currentGeneration);

                    if (workingCopy.Count > 0)
                    {
                        var lastAdded = workingCopy.Last();

                        var lastIdx = workingCopy.Count;

                        var spouseIdx = 0;

                        //populate spouseIdxList
                        while (spouseIdx < spouseList.Count)
                        {
                            lastAdded.SpouseIdxLst.Add(lastIdx);
                            lastAdded.SpouseIdLst.Add(spouseList[spouseIdx].PersonId);
                            lastIdx++;
                            spouseIdx++;
                        }
                    }



                    if (currentGeneration > 0)
                    {
                        if (fatherIdx >= 0)
                        {
                            destination[currentGeneration - 1][fatherIdx].ChildIdxLst.Add(workingCopy.Count - 1);
                            destination[currentGeneration - 1][fatherIdx].ChildLst.Add(child.PersonId.GetValueOrDefault());
                            destination[currentGeneration - 1][fatherIdx].ChildCount = children.Count;
                        }
                        if (motherIdx >= 0)
                        {
                            destination[currentGeneration - 1][motherIdx].ChildIdxLst.Add(workingCopy.Count - 1);
                            destination[currentGeneration - 1][motherIdx].ChildLst.Add(child.PersonId.GetValueOrDefault());
                            destination[currentGeneration - 1][motherIdx].ChildCount = children.Count;
                        }
                    }

                    workingCopy.AddRange(spouseList);

                    newlyAdded.Add(child.PersonId.GetValueOrDefault());

                    spouseCount += spouseList.Count;

                    //the last child
                    if (childIdx == (children.Count - 1))
                    {
                        //family length 
                        var familyLength = childIdx + spouseCount;

                        var midPoint = (int)Math.Floor((decimal)familyLength / 2);

                        workingCopy[midPoint].IsParentalLink = true;
                        workingCopy[familyLength].IsFamilyEnd = true;
                    }

                    childIdx++;


                }

                //gen 1
                foreach (var person in newlyAdded)
                {
                    fillChildGenerations(person, ref destination, ref currentGeneration);
                }

                //foreach child 


            }

            private int GetIndexFromGeneration(List<DescendantNode> generation, int searchId)
            {
                int idx = 0;

                foreach (var person in generation)
                {
                    if (searchId == person.PersonId)
                        return idx;
                    idx++;
                }

                return -1;
            }

            private List<DescendantNode> makeSpouse(int personId, int generationNumber)
            {
                var marriages = _graphMarriages.Where(w => w.FatherId == personId || w.MotherId == personId).ToList();
                List<int> spouseIdList = new List<int>();
                List<DescendantNode> spouses = new List<DescendantNode>();

                foreach (var m in marriages)
                {
                    if (m.FatherId == personId) spouseIdList.Add(m.MotherId);
                    if (m.MotherId == personId) spouseIdList.Add(m.FatherId);
                }

                var persons = _persons.Where(w => spouseIdList.Contains(w.PersonId.GetValueOrDefault()));

                foreach (var person in persons)
                {
                    spouses.Add(new DescendantNode()
                    {
                        BirthLocation = person.Location,
                        ChristianName = person.FirstName,
                        DOB = person.YearFrom.ToString(),
                        FatherId = person.FatherId.GetValueOrDefault(),
                        MotherId = person.MotherId.GetValueOrDefault(),
                        GenerationIdx = generationNumber,
                        PersonId = person.PersonId.GetValueOrDefault(),
                        Surname = person.Surname,
                        ChildIdxLst = new List<int>(),
                        ChildLst = new List<int>(),
                        SpouseIdxLst = new List<int>(),
                        SpouseIdLst = new List<int>()
                    });
                }

                return spouses;
            }

            private int GetNextAncestor(int? personId)
            {
                var startPerson = _persons.FirstOrDefault(fd => fd.PersonId == personId);

                if (startPerson == null) return 0;

                return startPerson.FatherId == 0 ? startPerson.PersonId.GetValueOrDefault() : GetNextAncestor(startPerson.FatherId);
            }
        }
    }
}