using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.ADB
{
 
    public class MarriageSearchResultType : ObjectGraphType<MarriageSearchResult>
    {
        public MarriageSearchResultType()
        {
            //Field(m => m.Id);
            //Field(m => m.PersonId);
            //Field(m => m.FirstName);
            //Field(m => m.Surname);
            //Field(m => m.Origin);
            //Field(m => m.YearFrom);
            //Field(m => m.YearTo);

            //Field(m => m.Location);
            //Field(m => m.BirthLat);
            //Field(m => m.BirthLong);

            //Field(m => m.AltLocationDesc);
            //Field(m => m.AltLocation);

            //Field(m => m.AltLat);
            //Field(m => m.AltLong);

        }
    }

    public class MarriageSearchResult
    {
        public Guid MarriageId { get; set; }
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
        public int? YearIntVal { get; set; }
        public string MarriageCounty { get; set; }
        public string Source { get; set; }
        public string Witness1 { get; set; }
        public string Witness2 { get; set; }
        public string Witness3 { get; set; }
        public string Witness4 { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateLastEdit { get; set; }
        public string OrigMaleSurname { get; set; }
        public string OrigFemaleSurname { get; set; }
        public string MaleOccupation { get; set; }
        public string FemaleOccupation { get; set; }
        public bool? FemaleIsKnownWidow { get; set; }
        public bool? MaleIsKnownWidower { get; set; }
        public bool? IsBanns { get; set; }
        public bool? IsLicence { get; set; }
        public Guid? MarriageLocationId { get; set; }
        public Guid? MaleLocationId { get; set; }
        public Guid? FemaleLocationId { get; set; }
        public int? MaleBirthYear { get; set; }
        public int? FemaleBirthYear { get; set; }
        public string UniqueRef { get; set; }
        public int? TotalEvents { get; set; }
        public int? EventPriority { get; set; }
        public Guid? MaleId { get; set; }
        public Guid? FemaleId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
