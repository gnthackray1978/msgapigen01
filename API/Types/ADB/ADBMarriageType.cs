using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.ADB
{
 
    public class ADBMarriageType : ObjectGraphType<ADBMarriage>
    {
        public ADBMarriageType()
        {
            Field(m => m.Id);
            Field(m => m.MaleCname);
            Field(m => m.MaleSname);
            Field(m => m.MaleLocation);
            Field(m => m.MaleInfo);
            Field(m => m.FemaleCname);
            Field(m => m.FemaleSname);
            Field(m => m.FemaleLocation);
            Field(m => m.FemaleInfo);
            Field(m => m.Date);
            Field(m => m.MarriageLocation);
            Field(m => m.YearIntVal);
            Field(m => m.MarriageCounty);
            Field(m => m.Source);
            Field(m => m.Witness1);
            Field(m => m.Witness2);
            Field(m => m.Witness3);
            Field(m => m.Witness4);
            Field(m => m.DateAdded);
            Field(m => m.DateLastEdit);
            Field(m => m.MaleOccupation);
            Field(m => m.FemaleOccupation);
            Field(m => m.FemaleIsKnownWidow);
            Field(m => m.MaleIsKnownWidower);
            Field(m => m.IsBanns);
            Field(m => m.IsLicence);
            Field(m => m.MaleBirthYear);
            Field(m => m.FemaleBirthYear);
            Field(m => m.UniqueRef);
            Field(m => m.TotalEvents);
            Field(m => m.EventPriority);

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
