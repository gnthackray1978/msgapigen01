using Api.Models;
using ConfigHelper;
using System;
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

            b.GenerateDescendantGraph(3217, "_34_Kennington");
            
            Console.WriteLine("Hello World!");
            Console.ReadKey();


        }
    }
}
