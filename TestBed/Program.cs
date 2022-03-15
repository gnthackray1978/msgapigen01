using Api.Models;
using System;
using static Api.Services.DiagramService;

namespace TestBed
{
    class Program
    {
  
        static void Main(string[] args)
        {
            var az = new AzureDBContext(ConnectionString);
         //   var msgConfigHelper = new MSGConfigHelper();
           var b = new DescendantGraphBuilder(az);

            b.GenerateDescendantGraph(3217, "_34_Kennington");
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
