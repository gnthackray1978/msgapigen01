using Api.Models;
using ConfigHelper;
using System;
using System.Linq;
using Api.DB;
using static Api.Services.DiagramService;

namespace TestBed
{
    class Program
    {
  
        static void Main(string[] args)
        {
            var az = new AzureDBContext(Secrets.ConnectionString);
           // var msgConfigHelper = new MSGConfigHelper();
            var b = new DescendantGraphBuilder(az);

            var tree = az.TreeRecord.FirstOrDefault(f => f.Name == "_34_Kennington");

            if(tree!=null)
                b.GenerateDescendantGraph(3217, tree.ID);
            
            Console.WriteLine("Hello World!");
            Console.ReadKey();


        }
    }
}
