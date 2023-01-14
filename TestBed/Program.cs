using Api.Models;
using ConfigHelper;
using System;
using System.Diagnostics;
using System.Linq;
using Api.DB;
using Api.Services;
using Api.Types.RequestQueries;
using static Api.Services.DiagramService;

namespace TestBed
{
    public class config : IMSGConfigHelper
    {
        public string ClientURLs { get; set; }
        public string AuthServerUrl { get; set; }
        public string MSGApiGenUrl { get; set; }
        public string MSGGenDB01 { get; set; } = Secrets.ConnectionString;
    }

    class Program
    {
  
        static void Main(string[] args)
        {
            var az = new DNAContext(Secrets.ConnectionString);
            // var msgConfigHelper = new MSGConfigHelper();


            TestFtmlocsearch(az);



            Console.WriteLine("Hello World!");
            Console.ReadKey();


        }

        private static void TestGenerateDescendantGraph(DNAContext az)
        {
            var b = new DescendantGraphBuilder(az);

            var tree = az.TreeRecord.FirstOrDefault(f => f.Name == "_34_Kennington");

            if (tree != null)
                b.GenerateDescendantGraph(3217, tree.ID);
        }

        private async static void TestFTMLatLngList(DNAContext az)
        {
            var c = new config() { };


            var b = new DNAAnalyseService(null,null,c);

            // var tree = az.TreeRecord.FirstOrDefault(f => f.Name == "_34_Kennington");

           
            var treeDictionary = az.TreeRecord.ToDictionary(p => p.ID, p => p.Name);

            treeDictionary.Add(0, "Unknown");

            var p = new DNASearchParamObj
            {
                Groupings = az.TreeRecordMapGroup.ToList(),
                YearFrom = 1500,
                YearTo = 1900,
                Origin = "",
                Location = "wiltshire"

            };


            var tp =  b.FTMLatLngList(p);


        }

        private async static void TestFtmlocsearch(DNAContext az)
        {
            var c = new config() { };


            var b = new DNAAnalyseService(null, null, c);

            // var tree = az.TreeRecord.FirstOrDefault(f => f.Name == "_34_Kennington");


            var treeDictionary = az.TreeRecord.ToDictionary(p => p.ID, p => p.Name);

            treeDictionary.Add(0, "Unknown");

            var p = new DNASearchParamObj
            {
                Groupings = az.TreeRecordMapGroup.ToList(),
                YearFrom = 1500,
                YearTo = 1900,
                Origin = "",
                Location = "wiltshire"

            };


            var tp = b.FTMLocSearch(p);


            foreach (var x in tp.Result.results)
            {
                

                foreach (var xp in x.FTMPersonSummary)
                {
                    if (xp.Surname == "Sumpsion")
                    {
                        Debug.WriteLine(xp.Surname);
                        Debug.WriteLine(x.BirthLat + "," + x.BirthLong);
                    }
                }
            }
        }
    }
}
