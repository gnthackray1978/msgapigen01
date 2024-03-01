using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using HotChocolate.Types;
using MSGSharedData.Domain.Entities.NonPersistent.ADB;

namespace Api.Types.ADB
{

    public class ADBMarriageType : ObjectType<ADBMarriage>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBMarriage> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.MaleCname);
           descriptor.Field(m => m.MaleSname);
           descriptor.Field(m => m.MaleLocation);
           descriptor.Field(m => m.MaleInfo);
           descriptor.Field(m => m.FemaleCname);
           descriptor.Field(m => m.FemaleSname);
           descriptor.Field(m => m.FemaleLocation);
           descriptor.Field(m => m.FemaleInfo);
           descriptor.Field(m => m.Date);
           descriptor.Field(m => m.MarriageLocation);
           descriptor.Field(m => m.YearIntVal);
           descriptor.Field(m => m.MarriageCounty);
           descriptor.Field(m => m.Source);
           descriptor.Field(m => m.Witness1);
           descriptor.Field(m => m.Witness2);
           descriptor.Field(m => m.Witness3);
           descriptor.Field(m => m.Witness4);
           descriptor.Field(m => m.DateAdded);
           descriptor.Field(m => m.DateLastEdit);
           descriptor.Field(m => m.MaleOccupation);
           descriptor.Field(m => m.FemaleOccupation);
           descriptor.Field(m => m.FemaleIsKnownWidow);
           descriptor.Field(m => m.MaleIsKnownWidower);
           descriptor.Field(m => m.IsBanns);
           descriptor.Field(m => m.IsLicence);
           descriptor.Field(m => m.MaleBirthYear);
           descriptor.Field(m => m.FemaleBirthYear);
           descriptor.Field(m => m.UniqueRef);
           descriptor.Field(m => m.TotalEvents);
           descriptor.Field(m => m.EventPriority);

        }
    }
}
