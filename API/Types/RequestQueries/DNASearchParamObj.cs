using System.Collections.Generic;
using System.Linq;
using Api.Services.interfaces.domain;

namespace Api.Types.RequestQueries
{
    public class GroupingsObj : DNASearchParamObj,  IHeatMapSearch
    {
        public List<TreeRecordMapGroup> Mappings { private get; set; }
        
        public List<string> GetOrigins()
        {
            var results = new List<string>();

            Origin = Origin.Trim(',');


            List<int> treeIds = new List<int>();

            if (Origin.Contains(','))
            {
                treeIds = Origin.Split(',')
                    .Select(m =>
                    {
                        int.TryParse(m, out int mos);
                        return mos;
                    })
                    //.Where(m => !string.IsNullOrEmpty(m))
                    .ToList();

                treeIds.RemoveAll(r => r == 0);
            }
            else
            {
                if(int.TryParse(Origin, out int num))
                    treeIds.Add(num);
            }


            if (Mappings != null && Mappings.Any())
            {
                foreach (var treeId in treeIds)
                {
                    foreach (var group in Mappings.Where(w => w.TreeId == treeId))
                    {
                        results.Add(group.TreeName);
                    }
                }
            }



            //foreach (var origin in origins)
            //{
            //    if (!results.Contains(origin))
            //        results.Add(origin);
            //}

            return results;
        }

    }

    public class DNASearchParamObj : ISurname, IYearRange, ISortable, Ilocation, ITesterName
    {
     //   public MetaData Meta { get; set; } = new MetaData();
        public string Location { get; set; }
        public string Surname { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; } 
        public int MinCM { get; set; }
        public string TreeName { get; set; }
        public string Country { get; set; }
        public string Origin { get; set; }

        public string Name { get; set; }
    }
}