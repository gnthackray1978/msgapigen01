namespace MSGSharedData.Domain.Entities.NonPersistent.Diagrams
{
    public class DiagramResults<T>
    {
        public IEnumerable<T> rows { get; set; }

        public int TotalRows { get; set; }

        public int GenerationsCount { get; set; }

        public int MaxGenerationLength { get; set; }

        public string Error { get; set; }

        public string LoginInfo { get; set; }

        public string Title { get; set; }

    }
}
