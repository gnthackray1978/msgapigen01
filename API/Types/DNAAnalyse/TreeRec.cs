using Api.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.DNAAnalyse
{
    public class TreeRecType : ObjectType<TreeRec>
    {
        protected override void Configure(IObjectTypeDescriptor<TreeRec> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.Name);
           descriptor.Field(m => m.Origin);
           descriptor.Field(m => m.PersonCount);
           descriptor.Field(m => m.CM);
           descriptor.Field(m => m.Located);
           descriptor.Field(m => m.GroupNumber);
        }
    }

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
