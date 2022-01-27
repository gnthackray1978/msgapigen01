using GqlMovies.Api.Models;
using GqlMovies.Api.Types;
using GraphQL.Types;
using System.Collections.Generic;
using GraphQL;
using System.Security.Claims;
using System;
using Api.Services.interfaces;
using Api.Types;
using GqlMovies.Api.Services;
using System.Threading.Tasks;
using GqlMovies.Api.Schemas;
using Api.Types.Diagrams;

namespace Api.Schema
{
	public class DiagramQuery : ObjectGraphType
	{
		public DiagramQuery(IDiagramService service, IClaimService claimService)
		{

			Name = "Diagram";

			FieldAsync<AncestorResult, Results<AncestorNode>>(
				   "ancestorsearch",
				   arguments: new QueryArguments(
					   new QueryArgument<StringGraphType> { Name = "args" }
				   ),
				   resolve: context =>
				   {
					   ClaimsPrincipal currentUser = null;
					   Exception ce = null;

					   try
					   {
						   currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];
					   }
					   catch (Exception e)
					   {
						   ce = e;
					   }

					   var obj = new Dictionary<string, string>();

					   var query = context.GetArgument<string>("args");
					 
					
					   if (!claimService.UserValid(currentUser, MSGApplications.Diagrams))
					   {
						   return ErrorHandler.Error<AncestorNode>(ce, claimService.GetClaimDebugString(currentUser));
					   }

					   var pobj = new DiagramParamObj();

					   return service.GetAncestors(pobj);
				   }
			   );

			FieldAsync<DescendantResult, Results<DescendantNode>>(
			   "descendantsearch",
			   arguments: new QueryArguments(
				   new QueryArgument<StringGraphType> { Name = "args" }
			   ),
			   resolve: context =>
			   {
				   ClaimsPrincipal currentUser = null;
				   Exception ce = null;

				   try
				   {
					   currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];
				   }
				   catch (Exception e)
				   {
					   ce = e;
				   }

				   var obj = new Dictionary<string, string>();

				   var query = context.GetArgument<string>("args");


				   if (!claimService.UserValid(currentUser, MSGApplications.Diagrams))
				   {
					   return ErrorHandler.Error<DescendantNode>(ce, claimService.GetClaimDebugString(currentUser));
				   }

				   var pobj = new DiagramParamObj();

				   return service.GetDescendants(pobj);
			   }
		   );
		}
	}
}
