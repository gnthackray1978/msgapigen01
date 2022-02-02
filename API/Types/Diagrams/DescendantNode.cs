using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.Diagrams
{

    public class DescendantNodeType : ObjectGraphType<DescendantNode>
    {
        public DescendantNodeType()
        {
            Field(m => m.Id);
            Field(m => m.GenerationIdx);
            Field(m => m.Index);
            Field(m => m.ChildCount);
            Field<ListGraphType<IntGraphType>>("ChildIdxLst", "Child Idx List");

            Field<ListGraphType<IntGraphType>>("ChildLst", "Child List");

          
            Field(m => m.DescendantCount); 
            Field(m => m.FatherId);
            Field(m => m.FatherIdx);
            Field(m => m.IsDisplayed);
            Field(m => m.IsFamilyEnd);
            Field(m => m.IsFamilyStart);
            Field(m => m.IsHtmlLink);
            Field(m => m.IsParentalLink);
            Field(m => m.MotherId);
            Field(m => m.MotherIdx);
            Field(m => m.PersonId);

            Field<ListGraphType<IntGraphType>>("SpouseIdxLst", "Spouse Idx Lst");

            Field<ListGraphType<IntGraphType>>("SpouseIdLst", "Spouse Id Lst");
    
            Field(m => m.ChristianName);
            Field(m => m.Surname);
            Field(m => m.BirthLocation);
            Field(m => m.DOB);

        }
    }


    public class DescendantNode
    {
   
        public int Id { get; set; }
        public int ChildCount { get; set; }
        public List<int> ChildIdxLst { get; set; }
        public List<int> ChildLst { get; set; }
        public List<object> Children { get; set; }
        public int DescendantCount { get; set; }
        public object Father { get; set; }
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
        public List<int> SpouseIdxLst { get; set; }
        public List<int> SpouseIdLst { get; set; }
        public string ChristianName { get; set; }
        public string Surname { get; set; }
        public string BirthLocation { get; set; }
        public string DOB { get; set; }        
    }
}
