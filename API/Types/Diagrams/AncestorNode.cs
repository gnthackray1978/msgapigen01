﻿using Api.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.Diagrams
{
    //todo subqueries
    public class AncestorNodeType : ObjectType<AncestorNode>
    {
        protected override void Configure(IObjectTypeDescriptor<AncestorNode> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.GenerationIdx);
           descriptor.Field(m => m.Index);
           descriptor.Field(m => m.ChildCount);
          // descriptor.Field<ListGraphType<IntGraphType>>("ChildIdxLst", "Child Idx List");

        //   descriptor.Field<ListGraphType<IntGraphType>>("ChildLst", "Child List");
        //   descriptor.Field<ListGraphType<IntGraphType>>("Children", "Child List2");

           descriptor.Field(m => m.DescendantCount);
           descriptor.Field(m => m.FatherId);
           descriptor.Field(m => m.FatherIdx);
           descriptor.Field(m => m.IsDisplayed);
           descriptor.Field(m => m.IsFamilyEnd);
           descriptor.Field(m => m.IsFamilyStart);
           descriptor.Field(m => m.IsHtmlLink);
           descriptor.Field(m => m.IsParentalLink);
           descriptor.Field(m => m.MotherId);
           descriptor.Field(m => m.MotherIdx);
           descriptor.Field(m => m.PersonId);
           descriptor.Field(m => m.RelationType);

       //    descriptor.Field<ListGraphType<IntGraphType>>("SpouseIdxLst", "Spouse Idx Lst");

       //    descriptor.Field<ListGraphType<IntGraphType>>("SpouseIdLst", "Spouse Id Lst");

           descriptor.Field(m => m.ChristianName);
           descriptor.Field(m => m.Surname);
           descriptor.Field(m => m.BirthLocation);
           descriptor.Field(m => m.DOB);
           descriptor.Field(m => m.ChildIdx);
        }
    }

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
