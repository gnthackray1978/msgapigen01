using ConfigHelper;
using MSGSharedData.Data.Services.interfaces.services;
using MSGSharedData.Domain.Entities.NonPersistent.Diagrams;
using MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;

namespace MSGSharedData.Data.Services
{
    public class DiagramRepository: IDiagramRepository
    {
        private readonly IMSGConfigHelper _imsConfigHelper;

        public DiagramRepository(IMSGConfigHelper imsConfigHelper)
        {
            _imsConfigHelper = imsConfigHelper;
        }

        public async Task<DiagramResults<AncestorNode>> GetAncestors(DiagramParamObj searchParams)
        {
            var _wills = new List<AncestorNode>();

            var results = new DiagramResults<AncestorNode>();



            results.Error = "";


            results.LoginInfo = searchParams.PersonId.ToString();

            List<AncestorNode> gag = new List<AncestorNode>();
            try
            {
                var c = new DNAContext(_imsConfigHelper.MSGGenDB01);

                var person = c.FTMPersonView.FirstOrDefault(f => f.Id == searchParams.PersonId.ToSingleInt());

                if (person != null)
                {
                    results.Title = person.FirstName + " " + person.Surname;
                }

                var a = new AncestorGraphBuilder(c);

                gag = a.GenerateAncestorGraph(searchParams.PersonId.ToSingleInt());
            }
            catch (Exception e)
            {
                results.Error = e.Message;
            }

            results.rows = gag;

            if (gag.Count > 0)
            {
                results.TotalRows = gag.Count;
                int genNumber = 0;
                int genNodeNumber = 0;
                foreach (var n in gag)
                {
                    if (n.GenerationIdx > genNumber)
                        genNumber = n.GenerationIdx;

                    if (n.Index > genNodeNumber)
                        genNodeNumber = n.Index;
                }

                results.GenerationsCount = genNumber + 1;
                results.MaxGenerationLength = genNodeNumber + 1;
            }

            return results;
        }

        public async Task<DiagramResults<DescendantNode>> GetDescendants(DiagramParamObj searchParams)
        {
            var _wills = new List<DescendantNode>();

            var results = new DiagramResults<DescendantNode>();

            results.Error = "";
            results.Title = "Descendants for ID: " + searchParams.PersonId.ToString();

            results.LoginInfo = searchParams.PersonId.ToString();

            List<DescendantNode> gag = new List<DescendantNode>();

            try
            {

                var a = new DNAContext(_imsConfigHelper.MSGGenDB01);

                var person = a.FTMPersonView.FirstOrDefault(f => f.Id == searchParams.PersonId.ToSingleInt());

                if (person != null)
                {
                    results.Title = person.FirstName + " " + person.Surname;
                }
                else
                {
                    results.Title = "No record found for : " + searchParams.PersonId;
                }

                var d = new DescendantGraphBuilder(a);


                gag = d.GenerateDescendantGraph(searchParams.PersonId.ToSingleInt());

            }
            catch (Exception e)
            {
                results.Error = e.Message;
            }

            results.rows = gag;

            if (gag.Count > 0)
            {
                results.TotalRows = gag.Count;
                int genNumber = 0;
                int genNodeNumber = 0;
                foreach (var n in gag)
                {
                    if (n.GenerationIdx > genNumber)
                        genNumber = n.GenerationIdx;

                    if (n.Index > genNodeNumber)
                        genNodeNumber = n.Index;
                }

                results.GenerationsCount = genNumber + 1;
                results.MaxGenerationLength = genNodeNumber + 1;
            }

            return results;
        }


    }
}
