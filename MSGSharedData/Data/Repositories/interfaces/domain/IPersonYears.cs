namespace MSGSharedData.Data.Services.interfaces.domain
{
    public interface IPersonYears
    {
        public int BirthInt { get; set; }
        public int BapInt { get; set; }
        public int DeathInt { get; set; }

        public int EstBirthYearInt { get; set; }
    }
}