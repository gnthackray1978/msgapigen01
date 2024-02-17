using HotChocolate.Types;

namespace Api.Models
{

    public class WillType : ObjectType<Will>
    {
        protected override void Configure(IObjectTypeDescriptor<Will> descriptor)
        {
            descriptor.Field(m => m.Id);
            descriptor.Field(m => m.DateString);
            descriptor.Field(m => m.Url);
            descriptor.Field(m => m.Description);
            descriptor.Field(m => m.Collection);
            descriptor.Field(m => m.Reference);
            descriptor.Field(m => m.Place);
            descriptor.Field(m => m.Year);

            descriptor.Field(m => m.Typ);
            descriptor.Field(m => m.FirstName);
            descriptor.Field(m => m.Surname);
            descriptor.Field(m => m.Occupation);

            descriptor.Field(m => m.Aliases);
            descriptor.Field(m => m.Error);

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

