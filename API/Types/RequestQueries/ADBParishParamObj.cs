namespace Api.Types.RequestQueries
{
    public class ADBParishParamObj
    {

        public MetaData Meta { get; set; } = new MetaData();


        public string ParishName { get; set; }

        public string County { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public int Limit { get; set; }
        public int Offset { get; set; }


    }
}