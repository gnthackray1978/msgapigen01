using HotChocolate.Types;
using System;

namespace Api.Types.ADB
{


    public class ADBPersonType : ObjectType<ADBPerson>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBPerson> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.MotherId);
           descriptor.Field(m => m.FatherId);
           descriptor.Field(m => m.IsMale);
           descriptor.Field(m => m.ChristianName);
           descriptor.Field(m => m.Surname);
           descriptor.Field(m => m.BirthLocation);
           descriptor.Field(m => m.BirthDateStr);
           descriptor.Field(m => m.BaptismDateStr);
           descriptor.Field(m => m.DeathDateStr);
           descriptor.Field(m => m.DeathLocation);
           descriptor.Field(m => m.FatherChristianName);
           descriptor.Field(m => m.FatherSurname);
           descriptor.Field(m => m.MotherChristianName);
           descriptor.Field(m => m.MotherSurname);
           descriptor.Field(m => m.Notes);
           descriptor.Field(m => m.Source);
           descriptor.Field(m => m.BirthInt);
           descriptor.Field(m => m.BapInt);
           descriptor.Field(m => m.DeathInt);
           descriptor.Field(m => m.DeathCounty);
           descriptor.Field(m => m.BirthCounty);
           descriptor.Field(m => m.DateAdded);
           descriptor.Field(m => m.DateLastEdit);
           descriptor.Field(m => m.OrigSurname);
           descriptor.Field(m => m.OrigFatherSurname);
           descriptor.Field(m => m.OrigMotherSurname);
           descriptor.Field(m => m.Occupation);
           descriptor.Field(m => m.ReferenceLocation);
           descriptor.Field(m => m.ReferenceDateStr);
           descriptor.Field(m => m.ReferenceDateInt);
           descriptor.Field(m => m.SpouseName);
           descriptor.Field(m => m.SpouseSurname);
           descriptor.Field(m => m.FatherOccupation);
           descriptor.Field(m => m.UniqueRef);
           descriptor.Field(m => m.TotalEvents);
           descriptor.Field(m => m.EventPriority);
           descriptor.Field(m => m.EstBirthYearInt);
           descriptor.Field(m => m.EstDeathYearInt);
           descriptor.Field(m => m.IsEstBirth);
           descriptor.Field(m => m.IsEstDeath);
           descriptor.Field(m => m.IsDeleted);

        }
    }

    public class ADBPerson
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
