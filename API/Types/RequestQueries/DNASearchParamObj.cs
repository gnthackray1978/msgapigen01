using System.Collections.Generic;
using System.Linq;
using Api.Services.interfaces.domain;

namespace Api.Types.RequestQueries
{
    public class DNASearchParamObj : ISurname, IYearRange, ISortable, Ilocation
    {
        public MetaData Meta { get; set; } = new MetaData();
        public string Location { get; set; }
        public string Surname { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
        public int MinCM { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Origin { private get; set; }

        public List<TreeRecordMapGroup> Groupings { get; set; }

        

        public List<int> GetOrigins()
        {
            var results = new List<int>();
            

            var origins = Origin.Split(',')
                .Select(m => { int.TryParse(m, out int mos); return mos; })
                .Where(m => m != 0)
                .ToList();

            if (Groupings != null && Groupings.Any() )
            {
                foreach (var origin in origins)
                {
                    foreach (var group in Groupings.Where(w=>w.GroupId == origin))
                    { 
                        results.Add(group.TreeId);
                    }
                }
            }

            foreach (var origin in origins)
            {
                if(!results.Contains(origin))
                    results.Add(origin);
            }

            return results;
        }

    }
}