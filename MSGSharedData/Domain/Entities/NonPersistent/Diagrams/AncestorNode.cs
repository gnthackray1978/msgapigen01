namespace MSGSharedData.Domain.Entities.NonPersistent.Diagrams
{
    //todo subqueries

    //todo lots of this isn't used. need to work out which bits are and arent used.
    //then delete accordingly.
    public class AncestorNode
    {
        public int Id { get; set; }
        public int ChildCount { get; set; }
        public int ChildIdx { get; set; }
        public List<int> ChildIdxLst { get; set; }
        public List<int> ChildLst { get; set; }
        public List<int> Children { get; set; }
        public int DescendantCount { get; set; }
        public int FatherId { get; set; }
        public int FatherIdx { get; set; }
        public int GenerationIdx { get; set; }
        public int Index { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsFamilyEnd { get; set; }
        public bool IsFamilyStart { get; set; }
        public bool IsHtmlLink { get; set; }
        public bool IsParentalLink { get; set; }
        public int MotherId { get; set; }
        public int MotherIdx { get; set; }
        public int PersonId { get; set; }
        public int RelationType { get; set; }
        public List<int> SpouseIdxLst { get; set; }
        public List<int> SpouseIdLst { get; set; }
        public string ChristianName { get; set; }
        public string Surname { get; set; }
        public string BirthLocation { get; set; }
        public string DOB { get; set; }
    }
}
