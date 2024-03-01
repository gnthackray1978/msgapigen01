namespace MSGSharedData.Data.Services.interfaces.domain
{
    public interface ISortable
    {
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
    }
}