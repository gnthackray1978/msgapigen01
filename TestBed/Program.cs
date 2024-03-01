using ConfigHelper;
using System;
using System.Diagnostics;
using System.Linq;
using MSGSharedData.Data.Services;
using MSGSharedData.Data;
using MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;

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
                b.GenerateDescendantGraph(3217);
        }

        private async static void TestFTMLatLngList(DNAContext az)
        {
            var c = new config() { };


            var b = new DNAAnalyseRepository(c);

            // var tree = az.TreeRecord.FirstOrDefault(f => f.Name == "_34_Kennington");

           
            var treeDictionary = az.TreeRecord.ToDictionary(p => p.Id, p => p.Name);

            treeDictionary.Add(0, "Unknown");

            var p = new DNASearchParamObj
            {
            //    Groupings = az.TreeRecordMapGroup.ToList(),
                YearStart = 1500,
                YearEnd = 1900,
                Origin = "",
                Location = "wiltshire"

            };


            var tp =  b.FTMLatLngList(p);


        }

        private async static void TestFtmlocsearch(DNAContext az)
        {
            var c = new config() { };


            var b = new DNAAnalyseRepository(c);

            // var tree = az.TreeRecord.FirstOrDefault(f => f.Name == "_34_Kennington");


            var treeDictionary = az.TreeRecord.ToDictionary(p => p.Id, p => p.Name);

            treeDictionary.Add(0, "Unknown");

            var p = new DNASearchParamObj
            {
             //   Groupings = az.TreeRecordMapGroup.ToList(),
                YearStart = 1500,
                YearEnd = 1900,
                Origin = "",
                Location = "wiltshire"

            };


            var tp = b.FTMLocSearch(p);


            foreach (var x in tp.Result.rows)
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
