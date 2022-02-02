
using Api.Schemas;
using GraphQL;
using GraphQL.Types;
using System;

namespace Api.Schema
{
    public class MainSchema : GraphQL.Types.Schema
    {
        public MainSchema(IServiceProvider resolver) : base(resolver)
        {
            Query = new Query();
        }
    }
}