using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using HotChocolate.Types;

namespace Api.Types.ADB
{
 
    public class ADBMarriageType : ObjectType<ADBMarriage>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBMarriage> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.MaleCname);
           descriptor.Field(m => m.MaleSname);
           descriptor.Field(m => m.MaleLocation);
           descriptor.Field(m => m.MaleInfo);
           descriptor.Field(m => m.FemaleCname);
           descriptor.Field(m => m.FemaleSname);
           descriptor.Field(m => m.FemaleLocation);
           descriptor.Field(m => m.FemaleInfo);
           descriptor.Field(m => m.Date);
           descriptor.Field(m => m.MarriageLocation);
           descriptor.Field(m => m.YearIntVal);
           descriptor.Field(m => m.MarriageCounty);
           descriptor.Field(m => m.Source);
           descriptor.Field(m => m.Witness1);
           descriptor.Field(m => m.Witness2);
           descriptor.Field(m => m.Witness3);
           descriptor.Field(m => m.Witness4);
           descriptor.Field(m => m.DateAdded);
           descriptor.Field(m => m.DateLastEdit);
           descriptor.Field(m => m.MaleOccupation);
           descriptor.Field(m => m.FemaleOccupation);
           descriptor.Field(m => m.FemaleIsKnownWidow);
           descriptor.Field(m => m.MaleIsKnownWidower);
           descriptor.Field(m => m.IsBanns);
           descriptor.Field(m => m.IsLicence);
           descriptor.Field(m => m.MaleBirthYear);
           descriptor.Field(m => m.FemaleBirthYear);
           descriptor.Field(m => m.UniqueRef);
           descriptor.Field(m => m.TotalEvents);
           descriptor.Field(m => m.EventPriority);

        }
    }

    public class ADBMarriage
    {
        public int Id { get; set; }
        public string MaleCname { get; set; }
        public string MaleSname { get; set; }
        public string MaleLocation { get; set; }
        public string MaleInfo { get; set; }
        public string FemaleCname { get; set; }
        public string FemaleSname { get; set; }
        public string FemaleLocation { get; set; }
        public string FemaleInfo { get; set; }
        public string Date { get; set; }
        public string MarriageLocation { get; set; }
        public int YearIntVal { get; set; }
        public string MarriageCounty { get; set; }
        public string Source { get; set; }
        public string Witness1 { get; set; }
        public string Witness2 { get; set; }
        public string Witness3 { get; set; }
        public string Witness4 { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateLastEdit { get; set; }
        public string MaleOccupation { get; set; }
        public string FemaleOccupation { get; set; }
        public bool FemaleIsKnownWidow { get; set; }
        public bool MaleIsKnownWidower { get; set; }
        public bool IsBanns { get; set; }
        public bool IsLicence { get; set; }
        public int MaleBirthYear { get; set; }
        public int FemaleBirthYear { get; set; }
        public string UniqueRef { get; set; }
        public int TotalEvents { get; set; }
        public int EventPriority { get; set; }
    }
}
