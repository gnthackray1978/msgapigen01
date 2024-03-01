using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.ADB;

namespace Api.Types.ADB;

public class ADBPersonType : ObjectType<ADBPerson>
{
    protected override void Configure(IObjectTypeDescriptor<ADBPerson> descriptor)
    {
        descriptor.Field(m => m.Id);
        descriptor.Field(m => m.MotherId);
        descriptor.Field(m => m.FatherId);
        descriptor.Field(m => m.IsMale);
        descriptor.Field(m => m.ChristianName);
        descriptor.Field(m => m.Surname);
        descriptor.Field(m => m.BirthLocation);
        descriptor.Field(m => m.BirthDateStr);
        descriptor.Field(m => m.BaptismDateStr);
        descriptor.Field(m => m.DeathDateStr);
        descriptor.Field(m => m.DeathLocation);
        descriptor.Field(m => m.FatherChristianName);
        descriptor.Field(m => m.FatherSurname);
        descriptor.Field(m => m.MotherChristianName);
        descriptor.Field(m => m.MotherSurname);
        descriptor.Field(m => m.Notes);
        descriptor.Field(m => m.Source);
        descriptor.Field(m => m.BirthInt);
        descriptor.Field(m => m.BapInt);
        descriptor.Field(m => m.DeathInt);
        descriptor.Field(m => m.DeathCounty);
        descriptor.Field(m => m.BirthCounty);
        descriptor.Field(m => m.DateAdded);
        descriptor.Field(m => m.DateLastEdit);
        descriptor.Field(m => m.OrigSurname);
        descriptor.Field(m => m.OrigFatherSurname);
        descriptor.Field(m => m.OrigMotherSurname);
        descriptor.Field(m => m.Occupation);
        descriptor.Field(m => m.ReferenceLocation);
        descriptor.Field(m => m.ReferenceDateStr);
        descriptor.Field(m => m.ReferenceDateInt);
        descriptor.Field(m => m.SpouseName);
        descriptor.Field(m => m.SpouseSurname);
        descriptor.Field(m => m.FatherOccupation);
        descriptor.Field(m => m.UniqueRef);
        descriptor.Field(m => m.TotalEvents);
        descriptor.Field(m => m.EventPriority);
        descriptor.Field(m => m.EstBirthYearInt);
        descriptor.Field(m => m.EstDeathYearInt);
        descriptor.Field(m => m.IsEstBirth);
        descriptor.Field(m => m.IsEstDeath);
        descriptor.Field(m => m.IsDeleted);

    }
}