using Api.Services.interfaces.domain;

namespace Api.Types.RequestQueries
{
    public class ADBPersonParamObj : ISurname, IYearRange, ISortable
    {

        public MetaData Meta { get; set; } = new MetaData();

        public string Location { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string BirthLocation { get; set; }
        public string DeathLocation { get; set; }
        public string FatherChristianName { get; set; }
        public string FatherSurname { get; set; }
        public string MotherChristianName { get; set; }
        public string MotherSurname { get; set; }
        public string Source { get; set; }
        public string DeathCounty { get; set; }
        public string BirthCounty { get; set; }
        public string Occupation { get; set; }
        public string SpouseName { get; set; }
        public string SpouseSurname { get; set; }
        public string FatherOccupation { get; set; }



        public int Limit { get; set; }
        public int Offset { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
    }
}