using FTMContextNet.Domain.Entities.Persistent.Cache;
using MSGSharedData.Data.Services.interfaces.domain;

namespace MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;

public class GroupingsObj : DNASearchParamObj, IHeatMapSearch
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
            if (int.TryParse(Origin, out int num))
                treeIds.Add(num);
        }


        if (Mappings != null && Mappings.Any())
        {
            foreach (var treeId in treeIds)
            {
                foreach (var group in Mappings.Where(w => w.TreeId == treeId))
                {
                    if (!results.Contains(group.TreeName))
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