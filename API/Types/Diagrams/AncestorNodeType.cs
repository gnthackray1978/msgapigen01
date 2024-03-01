using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.Diagrams;

namespace Api.Types.Diagrams;

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