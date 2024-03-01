using ConfigHelper;
using MSGSharedData.Data.Services.Helpers;
using MSGSharedData.Data.Services.interfaces.services;
using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.Wills;
using MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;

namespace MSGSharedData.Data.Services
{
    //
    public class WillListRepository: IWillListRepository
    {

        private readonly IMSGConfigHelper _imsConfigHelper;
        //      private readonly HttpClient _client;
        private readonly string _apiKey;

        public WillListRepository(IMSGConfigHelper imsConfigHelper)
        {
            // _client = client;
            _imsConfigHelper = imsConfigHelper;
        }

        public async Task<Will> GetAsync(int id)
        {
            var will = new Will();

            try
            {
                var a = new WillsContext(_imsConfigHelper.MSGGenDB01);

                var app = a.LincsWills.FirstOrDefault(fi => fi.Id == id);

                will = new Will()
                {
                    Id = app.Id,
                    Aliases = app.Aliases,
                    Collection = app.Collection,
                    DateString = app.DateString,
                    Description = app.Description,
                    FirstName = app.FirstName,
                    Occupation = app.Occupation,
                    Place = app.Place,
                    Reference = app.Reference,
                    Surname = app.Surname,
                    Typ = app.Typ.GetValueOrDefault(),
                    Url = app.Url,
                    Year = app.Year
                };

            }
            catch (Exception e)
            {
                will.Error = e.Message;
            }
            return will;
        }


        public async Task<Results<Will>> LincolnshireWillsList(WillSearchParamObj searchParams)
        {
            var _wills = new List<Will>();

            var results = new Results<Will>();

            int totalRecs = 0;

            try
            {
                var a = new WillsContext(_imsConfigHelper.MSGGenDB01);

                //searchParams.First

                Func<int, int, bool> validDates = (start, end) =>
                {
                    if (start <= 0 && end <= 0) return false;
                    if (start > end) return false;

                    return true;
                };

                var unpaged = a.LincsWills
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Surname), w => w.Surname.ToLower().Contains(searchParams.Surname))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Desc), w => w.Description.ToLower().Contains(searchParams.Desc))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.RefArg), w => w.Reference.ToLower().Contains(searchParams.RefArg))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Place), w => w.Place.ToLower().Contains(searchParams.Place))
                    .WhereIf(validDates(searchParams.YearFrom, searchParams.YearTo),
                            w => w.Year >= searchParams.YearFrom && w.Year <= searchParams.YearTo)
                    .SortIf(searchParams.SortColumn, searchParams.SortOrder);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {
                    _wills.Add(new Will()
                    {
                        Id = app.Id,
                        Aliases = app.Aliases ?? "",
                        Collection = app.Collection ?? "",
                        DateString = app.DateString ?? "",
                        Description = app.Description ?? "",
                        FirstName = app.FirstName ?? "",
                        Occupation = app.Occupation ?? "",
                        Place = app.Place ?? "",
                        Reference = app.Reference ?? "",
                        Surname = app.Surname ?? "",
                        Typ = app.Typ.GetValueOrDefault(),
                        Url = app.Url ?? "",
                        Year = app.Year
                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }


          //  results.LoginInfo = searchParams.LoginInfo;
            //results.Error += (Environment.NewLine + searchParams.Error).Trim(); ;
            results.rows = _wills;
            results.Page = searchParams.Offset == 0 ? 0 : searchParams.Offset / searchParams.Limit;
            results.total_pages = totalRecs / searchParams.Limit;
            results.total_rows = totalRecs;

            return results;
        }



        public async Task<Results<Will>> NorfolkWillsList(WillSearchParamObj searchParams)
        {
            var _wills = new List<Will>();

            var results = new Results<Will>();

            int totalRecs = 0;

            results.Error = "";

            try
            {
                var a = new WillsContext(_imsConfigHelper.MSGGenDB01);

                //searchParams.First

                Func<int, int, bool> validDates = (start, end) =>
                {
                    if (start <= 0 && end <= 0) return false;
                    if (start > end) return false;

                    return true;
                };

                totalRecs = a.NorfolkWills
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Surname), w => w.Surname.ToLower().Contains(searchParams.Surname))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Desc), w => w.Description.ToLower().Contains(searchParams.Desc))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.RefArg), w => w.Reference.ToLower().Contains(searchParams.RefArg))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Place), w => w.Place.ToLower().Contains(searchParams.Place))
                    .WhereIf(validDates(searchParams.YearFrom, searchParams.YearTo),
                        w => w.Year >= searchParams.YearFrom && w.Year <= searchParams.YearTo).Count();

                var unpaged = a.NorfolkWills
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Surname), w => w.Surname.ToLower().Contains(searchParams.Surname))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Desc), w => w.Description.ToLower().Contains(searchParams.Desc))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.RefArg), w => w.Reference.ToLower().Contains(searchParams.RefArg))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Place), w => w.Place.ToLower().Contains(searchParams.Place))
                    .WhereIf(validDates(searchParams.YearFrom, searchParams.YearTo),
                            w => w.Year >= searchParams.YearFrom && w.Year <= searchParams.YearTo)
                    .SortIf(searchParams.SortColumn, searchParams.SortOrder);

                var paged = unpaged.Skip(searchParams.Offset).Take(searchParams.Limit).ToList();

                foreach (var app in paged)
                {
                    _wills.Add(new Will()
                    {
                        Id = app.Id,
                        Aliases = app.Aliases ?? "",
                        Collection = app.Collection ?? "",
                        DateString = app.DateString ?? "",
                        Description = app.Description ?? "",
                        FirstName = app.FirstName ?? "",
                        Occupation = app.Occupation ?? "",
                        Place = app.Place ?? "",
                        Reference = app.Reference ?? "",
                        Surname = app.Surname ?? "",
                        Typ = app.Typ.GetValueOrDefault(),
                        Url = app.Url ?? "",
                        Year = app.Year
                    });
                }


            }
            catch (Exception e)
            {
                results.Error = e.Message;
            }



            results.rows = _wills;
            //results.LoginInfo = searchParams.LoginInfo;
           // results.Error += (Environment.NewLine + searchParams.Error).Trim();
            results.Page = searchParams.Offset == 0 ? 0 : searchParams.Offset / searchParams.Limit;
            results.total_pages = totalRecs / searchParams.Limit;
            results.total_rows = totalRecs;

            return results;
        }


    }
}