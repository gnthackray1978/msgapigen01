using HotChocolate.Types;

namespace Api.Types.DNAAnalyse
{
    public class DupeType : ObjectType<Dupe>
    {
        protected override void Configure(IObjectTypeDescriptor<Dupe> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.PersonId);
           descriptor.Field(m => m.FirstName);
           descriptor.Field(m => m.Surname);

           descriptor.Field(m => m.Ident);
           descriptor.Field(m => m.Origin);
           descriptor.Field(m => m.Location);

           descriptor.Field(m => m.YearFrom);
           descriptor.Field(m => m.YearTo);


        }
    }
    public class Dupe
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Ident { get; set; }
        public string Origin { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
        public string Location { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
