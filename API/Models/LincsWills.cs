using Api.Services;
using System;
using System.Collections.Generic;

namespace AzureContext.Models
{


    public interface IWill: ISingleYear {
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

    public partial class NorfolkWills : IWill
    {
        public int Id { get; set; }
        public string DateString { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Collection { get; set; }
        public string Reference { get; set; }
        public string Place { get; set; }
        public int Year { get; set; }
        public int? Typ { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Occupation { get; set; }
        public string Aliases { get; set; }
    }

    public partial class LincsWills : IWill
    {
        public int Id { get; set; }
        public string DateString { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Collection { get; set; }
        public string Reference { get; set; }
        public string Place { get; set; }
        public int Year { get; set; }
        public int? Typ { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Occupation { get; set; }
        public string Aliases { get; set; }
    }
}
