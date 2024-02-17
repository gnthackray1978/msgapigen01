using HotChocolate.Types;
using System;

namespace Api.Types.ADB
{
    public class ADBSourceType : ObjectType<ADBSource>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBSource> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.SourceRef);
           descriptor.Field(m => m.SourceDate);
           descriptor.Field(m => m.SourceDateTo);
           descriptor.Field(m => m.SourceDateStr);
           descriptor.Field(m => m.SourceDateStrTo);
           descriptor.Field(m => m.SourceDescription);
           descriptor.Field(m => m.OriginalLocation);
           descriptor.Field(m => m.IsCopyHeld);
           descriptor.Field(m => m.IsViewed);
           descriptor.Field(m => m.IsThackrayFound);
           descriptor.Field(m => m.DateAdded);
           descriptor.Field(m => m.UserId);
           descriptor.Field(m => m.SourceNotes);
           descriptor.Field(m => m.SourceFileCount);
        }
    }

    public class ADBSource
    {
        public int Id { get; set; }
        public string SourceRef { get; set; }
        public int SourceDate { get; set; }
        public int SourceDateTo { get; set; }
        public string SourceDateStr { get; set; }
        public string SourceDateStrTo { get; set; }
        public string SourceDescription { get; set; }
        public string OriginalLocation { get; set; }
        public bool IsCopyHeld { get; set; }
        public bool IsViewed { get; set; }
        public bool IsThackrayFound { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserId { get; set; }
        public string SourceNotes { get; set; }
        public int SourceFileCount { get; set; }
    }
 }
