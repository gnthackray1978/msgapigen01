using MSGSharedData.Domain.Entities.NonPersistent.Diagrams;
using MSGSharedData.Domain.Entities.Persistent.DNA;
using System.Diagnostics;
using FTMContextNet.Domain.Entities.Persistent.Cache;

namespace MSGSharedData.Data.Services
{
    public class DescendantGraphBuilder
    {
        private readonly DNAContext _azureDbContext;
        private List<FTMPersonView> _persons;
        private List<Relationships> _relationships;

        public DescendantGraphBuilder(DNAContext azureDbContext)
        {
            _azureDbContext = azureDbContext;
            _persons = new List<FTMPersonView>();
            _relationships = new List<Relationships>();
        }

        public List<DescendantNode> GenerateDescendantGraph(int personId)
        {
            List<List<DescendantNode>> results = new List<List<DescendantNode>>();
            List<DescendantNode> flattenedResults = new List<DescendantNode>();

            Console.WriteLine("GenerateDescendantGraph");

            var originRecord = _azureDbContext.FTMPersonView.FirstOrDefault(p => p.PersonId == personId);

            if (originRecord == null)
                return flattenedResults;


            string origin = originRecord?.Origin ?? "";

            // var tree = _azureDbContext.TreeRecord
            //    .FirstOrDefault(f => f.ID == origin.ToSingleInt())?.Name ?? "";

            _persons = _azureDbContext
                            .FTMPersonView
                            .Where(w => w.Origin == origin).ToList();

            if (_persons.Count == 0)
            {
                return flattenedResults;
            }

            //todo make import routine set origin of tree relationship is from
            _relationships = _azureDbContext.Relationships.ToList();//.Where(w => w.Origin == origin).ToList();

            if (_relationships.Count == 0)
            {
                return flattenedResults;
            }


            var missingFathers = _persons.Where(w => w.FatherId == 0 && w.MotherId != 0).ToList();

            var missingMothers = _persons.Where(w => w.FatherId != 0 && w.MotherId == 0).ToList();

            var newPersonId = _persons.Max(p => p.PersonId) + 1;
            var newId = _persons.Count + 1;

            foreach (var person in missingFathers)
            {
                //create father 

                var fidx = _persons.FindIndex(a => a.Id == person.Id);
                _persons[fidx].FatherId = newPersonId;

                _persons.Add(FTMPersonView.CreateUnknownPerson(newId, newPersonId, origin));

                _relationships.Add(new Relationships() { BrideId = _persons[fidx].MotherId, GroomId = _persons[fidx].FatherId });

                newPersonId++;
                newId++;
            }

            foreach (var person in missingMothers)
            {
                //create father 
                var midx = _persons.FindIndex(a => a.Id == person.Id);
                _persons[midx].MotherId = newPersonId;
                _persons.Add(FTMPersonView.CreateUnknownPerson(newId, newPersonId, origin));

                _relationships.Add(new Relationships()
                {
                    BrideId = _persons[midx].FatherId,
                    GroomId = _persons[midx].MotherId
                });

                newPersonId++;
                newId++;
            }



            //_graphMarriages = new List<GraphMarriage>();

            //var g = _persons.GroupBy(d => new { d.FatherId, d.MotherId })
            //    .Select(m => new { m.Key.FatherId, m.Key.MotherId });

            //foreach (var group in g)
            //{
            //    _graphMarriages.Add(new GraphMarriage() { FatherId = group.FatherId.GetValueOrDefault(), MotherId = group.MotherId.GetValueOrDefault() });
            //}


            var startPerson = _persons.FirstOrDefault(fd => fd.PersonId == personId);

            var result = 0;

            if (startPerson != null)
                result = GetNextAncestor(startPerson.FatherId);

            //the start person is the furthest ancestor
            if (result == 0)
                result = personId;

            var child = _persons.FirstOrDefault(r => r.PersonId == result);



            var spouseList = new List<DescendantNode>();

            if (child != null)
                spouseList = makeSpouse(child.PersonId, 0);
            else
                return flattenedResults;


            results.Add(new List<DescendantNode>());
            results.Last().Add(new DescendantNode()
            {
                PersonId = child.PersonId,
                BirthLocation = child.Location ?? "",
                ChristianName = child.FirstName,
                Surname = child.Surname,
                DOB = child.YearStart.ToString(),
                FatherId = child.FatherId,
                MotherId = child.MotherId,
                ChildIdxLst = new List<int>(),
                ChildLst = new List<int>(),
                SpouseIdxLst = new List<int>(),
                SpouseIdLst = new List<int>(),
                Id = child.Id
            }
            );

            results.Last().AddRange(spouseList);

            int currentGeneration = 0;

            fillChildGenerations(result, ref results, ref currentGeneration);

            var idx = 0;
            foreach (var gp in results)
            {
                Debug.WriteLine("");
                foreach (var p in gp)
                {
                    if (p.PersonId == 3066 || p.PersonId == 386)
                    {
                        Debug.WriteLine("");
                    }

                    var groomSpouses = _relationships.Where(w => w.GroomId == p.PersonId).Select(s => s.BrideId).ToList();
                    var brideSpouses = _relationships.Where(w => w.BrideId == p.PersonId).Select(s => s.GroomId).ToList();

                    var spouseIdxList = new List<int>();

                    int personIdx = 0;

                    if (groomSpouses.Count > 0)
                    {
                        foreach (var person in results[idx])
                        {
                            if (groomSpouses.Exists(a => a == person.PersonId))
                            {
                                spouseIdxList.Add(personIdx);
                                break;
                            }

                            personIdx++;
                        }

                        p.SpouseIdLst.AddRange(groomSpouses);
                    }

                    if (brideSpouses.Count > 0)
                    {
                        foreach (var person in results[idx])
                        {
                            if (brideSpouses.Exists(a => a == person.PersonId))
                            {
                                spouseIdxList.Add(personIdx);
                                break;
                            }

                            personIdx++;
                        }

                        p.SpouseIdLst.AddRange(brideSpouses);
                    }
                    p.SpouseIdxLst.AddRange(spouseIdxList);

                }
                idx++;
            }

            int id = 0;

            foreach (var gp in results)
            {
                idx = 0;
                foreach (var p in gp)
                {
                    p.Index = idx;
                    p.Id = p.Id;
                    idx++;
                    id++;
                    flattenedResults.Add(p);
                }
            }


            return flattenedResults;
        }

        private DescendantNode getAncestorFromGraph(List<List<DescendantNode>> destination, int personId)
        {
            return destination.SelectMany(gen => gen).FirstOrDefault(person => person.PersonId == personId);
        }

        private void fillChildGenerations(int personId, ref List<List<DescendantNode>> destination, ref int currentGeneration)
        {
            //look up the children for this father.
            //add them to generation.

            //search through generations to find the current the generation we need

            string description = "";

            var person1 = getAncestorFromGraph(destination, personId);

            if (person1 != null)
            {
                description = person1.DOB + " " + person1.ChristianName + " " + person1.Surname;

                Console.WriteLine(description);
            }


            var children = _persons.Where(fd => fd.FatherId == personId || fd.MotherId == personId).ToList();

            if (children.Count == 0)
            {
                // currentGeneration--;
                return;
            }
            // does tree already contain this person somewhere? if so what generation.

            currentGeneration = person1.GenerationIdx + 1;

            if (currentGeneration >= destination.Count)
            {
                destination.Add(new List<DescendantNode>());
            }


            var workingCopy = destination[currentGeneration];

            List<int> newlyAdded = new List<int>();
            int childIdx = 0;
            int spouseCount = 0;

            int firstIndex = workingCopy.Count == 0 ? 0 : workingCopy.Count - 1;

            foreach (var child in children)
            {
                int fatherIdx = -2;
                int motherIdx = -2;

                if (currentGeneration > 0)
                {
                    fatherIdx = GetIndexFromGeneration(destination[currentGeneration - 1], child.FatherId);
                    motherIdx = GetIndexFromGeneration(destination[currentGeneration - 1], child.MotherId);
                }

                if (child.Surname == "Lutton")
                {
                    Debug.WriteLine("");
                }

                workingCopy.Add(new DescendantNode()
                {
                    IsFamilyStart = childIdx == 0,
                    PersonId = child.PersonId,
                    BirthLocation = child.Location ?? "",
                    ChristianName = child.FirstName,
                    Surname = child.Surname,
                    DOB = child.YearStart.ToString(),
                    FatherId = child.FatherId,
                    FatherIdx = fatherIdx,
                    MotherId = child.MotherId,
                    MotherIdx = motherIdx,
                    GenerationIdx = currentGeneration,
                    ChildIdxLst = new List<int>(),
                    ChildLst = new List<int>(),
                    SpouseIdxLst = new List<int>(),
                    SpouseIdLst = new List<int>(),
                    Id = child.Id
                }
                            );


                var spouseList = makeSpouse(child.PersonId, currentGeneration);

                //if (workingCopy.Count > 0)
                //{
                //    var lastAdded = workingCopy.Last();

                //    var lastIdx = workingCopy.Count;

                //    var spouseIdx = 0;

                //    //populate spouseIdxList
                //    while (spouseIdx < spouseList.Count)
                //    {
                //        lastAdded.SpouseIdxLst.Add(lastIdx);
                //        lastAdded.SpouseIdLst.Add(spouseList[spouseIdx].PersonId);
                //        lastIdx++;
                //        spouseIdx++;
                //    }
                //}



                if (currentGeneration > 0)
                {
                    if (fatherIdx >= 0)
                    {
                        destination[currentGeneration - 1][fatherIdx].ChildIdxLst.Add(workingCopy.Count - 1);
                        destination[currentGeneration - 1][fatherIdx].ChildLst.Add(child.PersonId);
                        destination[currentGeneration - 1][fatherIdx].ChildCount = children.Count;
                    }
                    if (motherIdx >= 0)
                    {
                        destination[currentGeneration - 1][motherIdx].ChildIdxLst.Add(workingCopy.Count - 1);
                        destination[currentGeneration - 1][motherIdx].ChildLst.Add(child.PersonId);
                        destination[currentGeneration - 1][motherIdx].ChildCount = children.Count;
                    }
                }

                workingCopy.AddRange(spouseList);

                newlyAdded.Add(child.PersonId);

                spouseCount += spouseList.Count;

                //the last child
                //if (childIdx == (children.Count - 1))
                //{
                //    //family length 
                //    var familyLength = childIdx + spouseCount;
                //    var midPoint = familyLength / 2;

                //    if (workingCopy[midPoint].IsHtmlLink)
                //    {
                //        while (midPoint > 0)
                //        {
                //            midPoint--;
                //            if (!workingCopy[midPoint].IsHtmlLink)
                //            {
                //                workingCopy[midPoint].IsParentalLink = true;
                //                break;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        workingCopy[midPoint].IsParentalLink = true;
                //    }

                //    workingCopy[familyLength].IsFamilyEnd = true;
                //}


                childIdx++;


            }
            //the last entry should be the end of the last family added.
            if (workingCopy.Count > 0)
            {
                workingCopy[^1].IsFamilyEnd = true;
                var familyLen = workingCopy.Count - firstIndex;

                if (workingCopy.Count == 1 || familyLen == 1)
                {
                    workingCopy[^1].IsParentalLink = true;
                }
                else
                {
                    var midPoint = familyLen / 2;

                    while (midPoint >= 0)
                    {
                        if (!workingCopy[firstIndex + midPoint].IsHtmlLink)
                        {
                            workingCopy[firstIndex + midPoint].IsParentalLink = true;
                            break;
                        }

                        midPoint--;
                    }

                }
            }



            //gen 1
            foreach (var person in newlyAdded)
            {
                fillChildGenerations(person, ref destination, ref currentGeneration);
            }

            //foreach child 


        }

        private int GetIndexFromGeneration(List<DescendantNode> generation, int searchId)
        {
            int idx = 0;

            foreach (var person in generation)
            {
                if (searchId == person.PersonId)
                    return idx;
                idx++;
            }

            return -1;
        }

        private List<DescendantNode> makeSpouse(int personId, int generationNumber)
        {
            var marriages = _relationships.Where(w => w.GroomId == personId || w.BrideId == personId).ToList();
            List<int> spouseIdList = new List<int>();
            List<DescendantNode> spouses = new List<DescendantNode>();

            foreach (var m in marriages)
            {

                if (m.GroomId == personId)
                {
                    if (_persons.Exists(e => e.PersonId == m.BrideId))
                        spouseIdList.Add(m.BrideId);
                }

                if (m.BrideId == personId)
                {
                    if (_persons.Exists(e => e.PersonId == m.GroomId))
                        spouseIdList.Add(m.GroomId);
                }
            }

            var persons = _persons.Where(w => spouseIdList.Contains(w.PersonId));

            foreach (var person in persons)
            {
                spouses.Add(new DescendantNode()
                {
                    BirthLocation = person.Location ?? "",
                    ChristianName = person.FirstName,
                    DOB = person.YearStart.ToString(),
                    FatherId = person.FatherId,
                    MotherId = person.MotherId,
                    GenerationIdx = generationNumber,
                    PersonId = person.PersonId,
                    Surname = person.Surname,
                    ChildIdxLst = new List<int>(),
                    ChildLst = new List<int>(),
                    SpouseIdxLst = new List<int>(),
                    SpouseIdLst = new List<int>(),
                    IsHtmlLink = true,
                    Id = person.Id
                });
            }

            return spouses;
        }

        private int GetNextAncestor(int? personId)
        {
            var startPerson = _persons.FirstOrDefault(fd => fd.PersonId == personId);

            if (startPerson == null) return 0;

            return startPerson.FatherId == 0 ? startPerson.PersonId : GetNextAncestor(startPerson.FatherId);
        }
    }

}
