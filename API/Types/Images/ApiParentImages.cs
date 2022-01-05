using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.Images
{
    public class ApiParentImagesType : ObjectGraphType<ApiParentImages>
    {
        public ApiParentImagesType()
        {
            Field(m => m.Id);
      
            Field(m => m.Title);
            Field(m => m.Info);
            Field(m => m.From);
            Field(m => m.To);
            Field(m => m.Page);
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
