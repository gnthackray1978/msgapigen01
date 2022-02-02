using Api.Models;
using Api.Types.Diagrams;
using AzureContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class AncestorGraphBuilder
    {
        private readonly AzureDBContext _azureDbContext;
        private List<FTMPersonView> _persons;
        private List<GraphMarriage> _graphMarriages;

        public AncestorGraphBuilder(AzureDBContext azureDbContext)
        {
            _azureDbContext = azureDbContext;

            


        }



        public List<AncestorNode> GenerateAncestorGraph(string origin, int personId)
        {
            List<List<AncestorNode>> results = new List<List<AncestorNode>>();

            Console.WriteLine("GenerateDescendantGraph");

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
            results.Last().Add(new AncestorNode()
            {
                PersonId = startPerson.PersonId.GetValueOrDefault(),
                BirthLocation = startPerson.Location,
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

            //add to array

            //look up this persons parents.

            //

            List<AncestorNode> flattenedResults = new List<AncestorNode>();

            foreach (var gp in results)
            {
                var idx = 0;
                foreach (var p in gp)
                {
                    p.Index = idx;
                    idx++;
                    flattenedResults.Add(p);
                }
            }


            return flattenedResults;
        }




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
                    BirthLocation = father.Location,
                    ChristianName = father.FirstName,
                    Surname = father.Surname,
                    DOB = father.YearFrom.ToString(),
                    FatherId = father.FatherId.GetValueOrDefault(),
                    MotherId = father.MotherId.GetValueOrDefault(),
                    ChildIdxLst = new List<int>(),
                    ChildLst = new List<int>() { child.PersonId },
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
                    BirthLocation = mother.Location,
                    ChristianName = mother.FirstName,
                    Surname = mother.Surname,
                    DOB = mother.YearFrom.ToString(),
                    FatherId = mother.FatherId.GetValueOrDefault(),
                    MotherId = mother.MotherId.GetValueOrDefault(),
                    ChildIdxLst = new List<int>(),
                    ChildLst = new List<int>() { child.PersonId },
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
