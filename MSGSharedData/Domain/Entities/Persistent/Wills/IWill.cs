using MSGSharedData.Data.Services.interfaces.domain;

namespace MSGSharedData.Domain.Entities.Persistent.Wills;

public interface IWill : ISingleYear
{
    int Id { get; set; }
    string DateString { get; set; }
    string Url { get; set; }
    string Description { get; set; }
    string Collection { get; set; }
    string Reference { get; set; }
    string Place { get; set; }
    int Year { get; set; }
    int? Typ { get; set; }
    string FirstName { get; set; }
    string Surname { get; set; }
    string Occupation { get; set; }
    string Aliases { get; set; }
}