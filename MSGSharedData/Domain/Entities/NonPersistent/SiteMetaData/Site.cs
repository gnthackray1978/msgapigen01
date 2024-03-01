namespace MSGSharedData.Domain.Entities.NonPersistent.SiteMetaData
{
    public class Site
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string DefaultPageName { get; set; }

        public string DefaultPageTitle { get; set; }

        public string Error { get; set; }

    }


}