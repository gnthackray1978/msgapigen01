using Api.DB;
using Api.Types.Diagrams;
using AzureContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace Api.Services
{
    public class AncestorGraphBuilder
    {
        private readonly DNAContext _azureDbContext;
        private List<FTMPersonView> _persons;
        private List<GraphMarriage> _graphMarriages;

        public AncestorGraphBuilder(DNAContext azureDbContext)
        {
            _azureDbContext = azureDbContext;
        }
        
        public List<AncestorNode> GenerateAncestorGraph(int personId)
        {
            List<List<AncestorNode>> results = new List<List<AncestorNode>>();
            List<AncestorNode> flattenedResults = new List<AncestorNode>();

            //Console.WriteLine("GenerateDescendantGraph");ToSingleInt

            Serilog.Log.Information("Generate Ancestor Graph");

            var originRecord = _azureDbContext.FTMPersonView.FirstOrDefault(fd => fd.PersonId == personId);

            if (originRecord == null)
                return flattenedResults;

            string origin = originRecord?.Origin ?? "";

            

          //  var tree = _azureDbContext.TreeRecord
           //     .FirstOrDefault(f => f.ID == origin.ToSingleInt())?.Name ?? "";

            _persons = _azureDbContext.FTMPersonView.Where(w=>w.Origin == origin).ToList();

            _graphMarriages = new List<GraphMarriage>();

            var g = _persons.GroupBy(d => new { d.FatherId, d.MotherId })
                .Select(m => new { m.Key.FatherId, m.Key.MotherId });

            foreach (var group in g)
            {
                _graphMarriages.Add(new GraphMarriage() { FatherId = group.FatherId.GetValueOrDefault(), MotherId = group.MotherId.GetValueOrDefault() });
            }

            var startPerson = _persons.FirstOrDefault(fd => fd.PersonId == personId);
            int currentGeneration = 0;

            results.Add(new List<AncestorNode>());

            if (startPerson != null)
            {
                results.Last().Add(new AncestorNode()
                    {
                        PersonId = startPerson.PersonId.GetValueOrDefault(),
                        BirthLocation = startPerson.Location ?? "",
                        ChristianName = startPerson.FirstName,
                        Surname = startPerson.Surname,
                        DOB = startPerson.YearFrom.ToString(),
                        FatherId = startPerson.FatherId.GetValueOrDefault(),
                        MotherId = startPerson.MotherId.GetValueOrDefault(),
                        ChildIdxLst = new List<int>(),
                        ChildLst = new List<int>(),
                        SpouseIdxLst = new List<int>(),
                        SpouseIdLst = new List<int>(),
                        GenerationIdx = 0
                    }
                );


                fillParents(results.Last().Last(), ref results, ref currentGeneration);
            }
            else
            {
                Serilog.Log.Information("No Records found for person:" + personId);
            }
            //add to array

            //look up this persons parents.

            //

            
            int id = 0;
            foreach (var gp in results)
            {
                var idx = 0;
                foreach (var p in gp)
                {
                    p.Index = idx;
                    p.Id = id;
                    //populate children indexs
                     

                    idx++;
                    id++;
                    flattenedResults.Add(p);
                }
            }


            foreach(var f in flattenedResults)
            {
                
                foreach(var c in f.ChildLst)
                {
                    var child = flattenedResults.FirstOrDefault(child => child.PersonId == c);

                    if (child != null)
                        f.ChildIdxLst.Add(child.Index);
                }

                if (f.ChildIdxLst.Count > 0)
                {
                    f.ChildIdx = f.ChildIdxLst.First();
                }

                var father = flattenedResults.FirstOrDefault(pf => pf.PersonId == f.FatherId);

                if(father != null)
                {
                    f.FatherIdx = father.Index;
                }

                var mother = flattenedResults.FirstOrDefault(pf => pf.PersonId == f.MotherId);

                if (mother != null)
                {
                    f.MotherIdx = mother.Index;
                }

            }

            return flattenedResults;
        }

        //private int findIndex(List<AncestorNode> results) { 
        
        //}


        private void fillParents(AncestorNode child,
            ref List<List<AncestorNode>> results, ref int currentGeneration)
        {
            if (child == null) return;

            if (child.PersonId == 3219)
            {
                Console.WriteLine("test");
            }

            int fatherId = child.FatherId;
            int motherId = child.MotherId;


            var father = _persons.FirstOrDefault(fd => fd.PersonId == fatherId);
            var mother = _persons.FirstOrDefault(fd => fd.PersonId == motherId);

            if (father == null && mother == null)
                return;
            //    results.Add(new List<GraphPerson>());

            currentGeneration = child.GenerationIdx + 1;

            if (currentGeneration >= results.Count)
            {
                results.Add(new List<AncestorNode>());
            }

            AncestorNode newFather = null;
            AncestorNode newMother = null;

            if (father != null)
            {
                newFather = new AncestorNode()
                {
                    PersonId = father.PersonId.GetValueOrDefault(),
                    BirthLocation = father.Location ??"",
                    ChristianName = father.FirstName,
                    Surname = father.Surname,
                    DOB = father.YearFrom.ToString(),
                    FatherId = father.FatherId.GetValueOrDefault(),
                    MotherId = father.MotherId.GetValueOrDefault(),
                    ChildIdxLst = new List<int>(),
                    ChildLst = new List<int>() { child.PersonId },
                    Children = new List<int>(),
                    SpouseIdxLst = new List<int>(),
                    SpouseIdLst = new List<int>(),
                    GenerationIdx = currentGeneration,
                    IsDisplayed = true,
                    IsHtmlLink = true
                };

                results[currentGeneration].Add(newFather);
            }

            if (mother != null)
            {
                newMother = new AncestorNode()
                {
                    PersonId = mother.PersonId.GetValueOrDefault(),
                    BirthLocation = mother.Location ??"",
                    ChristianName = mother.FirstName,
                    Surname = mother.Surname,
                    DOB = mother.YearFrom.ToString(),
                    FatherId = mother.FatherId.GetValueOrDefault(),
                    MotherId = mother.MotherId.GetValueOrDefault(),
                    ChildIdxLst = new List<int>(),
                    ChildLst = new List<int>() { child.PersonId },
                    Children = new List<int>(),
                    SpouseIdxLst = new List<int>(),
                    SpouseIdLst = new List<int>(),
                    GenerationIdx = currentGeneration,
                    IsDisplayed = true,
                    IsHtmlLink = true
                };

                results[currentGeneration].Add(newMother);
            }

            fillParents(newFather, ref results, ref currentGeneration);
            fillParents(newMother, ref results, ref currentGeneration);
        }
    }
}
