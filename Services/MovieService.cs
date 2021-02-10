using System.Linq;
using System;
using System.Net.Http;
using System.Collections.Generic;
using GqlMovies.Api.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.WebUtilities;
using GqlMovies.Api.Types;

namespace GqlMovies.Api.Services
{
    public class MovieService : IMovieService
    {
        private List<Movie> _movies = new List<Movie>();

        private readonly HttpClient _client;
        private readonly string _apiKey;

        public MovieService(HttpClient client, IConfiguration config)
        {
            _client = client;

            _movies.Add(new Movie()
            {
                Adult = true,
                Budget = 0,
                Id = 1,
                Popularity = 100,
                Tagline = "taglie",
                Title = "title",
                imdb_id = "imdb id",
                poster_path = "poster path",
                release_date = "1 jan 2020",
                FilmType = "acrapone",
                vote_average = 95
                
            });

            _movies.Add(new Movie()
            {
                Adult = true,
                Budget = 1,
                Id = 2,
                Popularity = 222,
                Tagline = "tertg",
                Title = "ertge",
                imdb_id = "ertgertg",
                poster_path = "poster path",
                release_date = "1 jan 2021",
                FilmType = "whatever",
                vote_average = 95

            });
        }

        public async Task<Movie> GetAsync(int id)
        {

            return _movies.First(w => w.Id == id);

        }

        public async Task<Results<Movie>> ListAsync(GetTypesEnum type)
        {
            //var query = new Dictionary<string, string>
            //{
            //    { "api_key", _apiKey }
            //};

         //   string uri = QueryHelpers.AddQueryString($"https://api.themoviedb.org/3/movie/{type.ToString().ToLower()}", query);

            //Console.WriteLine($"Requesting {uri}");

            //var resp = await _client.GetAsync(uri);

            var results = new Results<Movie>();

            results.results = _movies.Where(w => w.FilmType == type.ToString().ToLower());

            results.Page = 0;
            results.total_pages = 1;
            results.total_results = results.results.Count();

            return results;
            // return JsonConvert.DeserializeObject<Results<Movie>>(await resp.Content.ReadAsStringAsync());
        }

        public async Task<Results<Movie>> ListAsync(Dictionary<string, string> query)
        {
            var results = new Results<Movie>();

            results.results = _movies;

            results.Page = 0;
            results.total_pages = 1;
            results.total_results = results.results.Count();

            return results;
        }
    }
}