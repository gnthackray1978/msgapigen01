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
        public string AzureDB { get; set; }
        public string ClientURLs { get; set; }
        public string AuthServerUrl { get; set; }
        public string MSGApiGenUrl { get; set; }
        public string GedPath { get; set; }
        public string MSGGenDB01 { get; set; }
        public string MSGGenDB01Local { get; set; }
        public string DNA_Match_File_FileName { get; set; }
        public string DNA_Match_File_Path { get; set; }
        public bool DNA_Match_File_IsEncrypted { get; set; }
        public string FTMConString { get; set; }
        public string PlaceConString { get; set; }
        public string CacheData_FileName { get; set; }
        public string CacheData_Path { get; set; }
        public bool CacheData_IsEncrypted { get; set; }
    }

    class Program
    {
  
        static void Main(string[] args)
        {
            var c = new MSGConfigHelper();
            
            var az = new DNAContext(c.AzureDB);
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
