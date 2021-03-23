using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.ADB
{


    public class PersonSearchResultType : ObjectGraphType<PersonSearchResult>
    {
        public PersonSearchResultType()
        {
            Field(m => m.Id);
            Field(m => m.MotherId);
            Field(m => m.FatherId);
            Field(m => m.IsMale);
            Field(m => m.ChristianName);
            Field(m => m.Surname);
            Field(m => m.BirthLocation);
            Field(m => m.BirthDateStr);
            Field(m => m.BaptismDateStr);
            Field(m => m.DeathDateStr);
            Field(m => m.DeathLocation);
            Field(m => m.FatherChristianName);
            Field(m => m.FatherSurname);
            Field(m => m.MotherChristianName);
            Field(m => m.MotherSurname);
            Field(m => m.Notes);
            Field(m => m.Source);
            Field(m => m.BirthInt);
            Field(m => m.BapInt);
            Field(m => m.DeathInt);
            Field(m => m.DeathCounty);
            Field(m => m.BirthCounty);
            Field(m => m.DateAdded);
            Field(m => m.DateLastEdit);
            Field(m => m.OrigSurname);
            Field(m => m.OrigFatherSurname);
            Field(m => m.OrigMotherSurname);
            Field(m => m.Occupation);
            Field(m => m.ReferenceLocation);
            Field(m => m.ReferenceDateStr);
            Field(m => m.ReferenceDateInt);
            Field(m => m.SpouseName);
            Field(m => m.SpouseSurname);
            Field(m => m.FatherOccupation);
            Field(m => m.UniqueRef);
            Field(m => m.TotalEvents);
            Field(m => m.EventPriority);
            Field(m => m.EstBirthYearInt);
            Field(m => m.EstDeathYearInt);
            Field(m => m.IsEstBirth);
            Field(m => m.IsEstDeath);
            Field(m => m.IsDeleted);

        }
    }

    public class PersonSearchResult
    {
        public int Id { get; set; }
        public int MotherId { get; set; }
        public int FatherId { get; set; }
        public bool IsMale { get; set; }
        public string ChristianName { get; set; }
        public string Surname { get; set; }
        public string BirthLocation { get; set; }
        public string BirthDateStr { get; set; }
        public string BaptismDateStr { get; set; }
        public string DeathDateStr { get; set; }
        public string DeathLocation { get; set; }
        public string FatherChristianName { get; set; }
        public string FatherSurname { get; set; }
        public string MotherChristianName { get; set; }
        public string MotherSurname { get; set; }
        public string Notes { get; set; }
        public string Source { get; set; }
        public int BirthInt { get; set; }
        public int BapInt { get; set; }
        public int DeathInt { get; set; }
        public string DeathCounty { get; set; }
        public string BirthCounty { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateLastEdit { get; set; }
        public string OrigSurname { get; set; }
        public string OrigFatherSurname { get; set; }
        public string OrigMotherSurname { get; set; }
        public string Occupation { get; set; }
        public string ReferenceLocation { get; set; }
        public string ReferenceDateStr { get; set; }
        public int ReferenceDateInt { get; set; }
        public string SpouseName { get; set; }
        public string SpouseSurname { get; set; }
        public string FatherOccupation { get; set; }
        public string UniqueRef { get; set; }
        public int TotalEvents { get; set; }
        public int EventPriority { get; set; }
        public int EstBirthYearInt { get; set; }
        public int EstDeathYearInt { get; set; }
        public bool IsEstBirth { get; set; }
        public bool IsEstDeath { get; set; }
        public bool IsDeleted { get; set; }
    }
}
