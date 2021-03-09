using GraphQL.Types;

namespace GqlMovies.Api.Models
{
    public class WillType : ObjectGraphType<Will>
    {
        public WillType()
        {
            Field(m => m.Id);
            Field(m => m.DateString);
            Field(m => m.Url);
            Field(m => m.Description);
            Field(m => m.Collection);
            Field(m => m.Reference);
            Field(m => m.Place);
            Field(m => m.Year);

            Field(m => m.Typ);
            Field(m => m.FirstName);
            Field(m => m.Surname);
            Field(m => m.Occupation);

            Field(m => m.Aliases);
            Field(m => m.Error);

        }
    }
    public class Will
    {
        public int Id { get; set; }

        public string DateString { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string Collection { get; set; }

        public string Reference { get; set; }

        public string Place { get; set; }

        public int Year { get; set; }

        public int Typ { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Occupation { get; set; }

        public string Aliases { get; set; }

        public string Error { get; set; }

    }
        
   

}

