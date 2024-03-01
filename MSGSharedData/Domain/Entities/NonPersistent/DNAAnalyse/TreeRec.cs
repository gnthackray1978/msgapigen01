namespace MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse
{
    public class TreeRec
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public int PersonCount { get; set; }

        public string GroupNumber { get; set; }

        public int CM { get; set; }
        public bool Located { get; set; }
    }
}
