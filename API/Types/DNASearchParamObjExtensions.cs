////using GraphQL;
////using GraphQL.SystemTextJson;

//using Api.Types.RequestQueries;

//static class DNASearchParamObjExtensions
//{

//    public static GroupingsObj ToGroupingsObj(this DNASearchParamObj dnaSearchParamObj)
//    {
//        return new GroupingsObj()
//        {
//            Location = dnaSearchParamObj.Location,
//            Surname = dnaSearchParamObj.Surname,
//            Limit = dnaSearchParamObj.Limit,
//            Offset = dnaSearchParamObj.Offset,
//            SortColumn = dnaSearchParamObj.SortColumn,
//            SortOrder = dnaSearchParamObj.SortOrder,
//            YearFrom = dnaSearchParamObj.YearFrom,
//            YearTo = dnaSearchParamObj.YearTo,
//            MinCM = dnaSearchParamObj.MinCM,
//            TreeName = dnaSearchParamObj.TreeName,
//            Country = dnaSearchParamObj.Country,
//            Origin = dnaSearchParamObj.Origin,
//        };
//    }

//    public static int ToSingleInt(this string csv)
//    {
//        if(string.IsNullOrEmpty(csv)) return 0;

//        if (csv.Contains(','))
//        {
//            var parts = csv.Split(',');

//            if (parts.Length > 0)
//            {
//                csv = parts[0];
//            }

//        }

//        if (int.TryParse(csv, out int singleId))
//            return singleId;

//        return 0;
//    }
//}