using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.ADB
{
    public class SourceSearchResultType : ObjectGraphType<SourceSearchResult>
    {
        public SourceSearchResultType()
        {
            Field(m => m.Id);
            Field(m => m.SourceRef);
            Field(m => m.SourceDate);
            Field(m => m.SourceDateTo);
            Field(m => m.SourceDateStr);
            Field(m => m.SourceDateStrTo);
            Field(m => m.SourceDescription);
            Field(m => m.OriginalLocation);
            Field(m => m.IsCopyHeld);
            Field(m => m.IsViewed);
            Field(m => m.IsThackrayFound);
            Field(m => m.DateAdded);
            Field(m => m.UserId);
            Field(m => m.SourceNotes);
            Field(m => m.SourceFileCount);
        }
    }


    public class SourceSearchResult
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
