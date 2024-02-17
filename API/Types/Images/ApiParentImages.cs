using Api.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.Images
{
    public class ApiParentImagesType : ObjectType<ApiParentImages>
    {
        protected override void Configure(IObjectTypeDescriptor<ApiParentImages> descriptor)
        {
            descriptor.Field(m => m.Id);

            descriptor.Field(m => m.Title);
            descriptor.Field(m => m.Info);
            descriptor.Field(m => m.From);
            descriptor.Field(m => m.To);
            descriptor.Field(m => m.Page);
        }
    }

    public class ApiParentImages
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Page { get; set; }

    }
}
