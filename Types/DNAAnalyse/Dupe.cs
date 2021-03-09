using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.DNAAnalyse
{
    public class DupeType : ObjectGraphType<Dupe>
    {
        public DupeType()
        {
            Field(m => m.Id);
            Field(m => m.PersonId);
            Field(m => m.FirstName);
            Field(m => m.Surname);

            Field(m => m.Ident);
            Field(m => m.Origin);
            Field(m => m.Location);

            Field(m => m.YearFrom);
            Field(m => m.YearTo);


        }
    }
    public class Dupe
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Ident { get; set; }
        public string Origin { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
        public string Location { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
