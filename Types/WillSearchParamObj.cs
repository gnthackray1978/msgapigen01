using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Types
{
    public class DNASearchParamObj
    {
        public string Location { get; set; }

        public string Surname { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public ClaimsPrincipal User { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public int YearStart { get; set; }
        public int YearEnd { get; set; }

        public int MinCM { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }

        public string Origin { get; set; }
    }
    public class WillSearchParamObj
    {
        public string RefArg { get; set; }

        public string Desc { get; set; }

        public string Place { get; set; }

        public string Surname { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public ClaimsPrincipal User { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public int YearStart { get; set; }
        public int YearEnd { get; set; }

    }

    public class ADBPersonParamObj {
        public string Location { get; set; }
          
        public string FirstName { get; set; }
        public string Surname { get; set; }



        public string BirthLocation { get; set; }
   
        public string DeathLocation { get; set; }
        public string FatherChristianName { get; set; }
        public string FatherSurname { get; set; }
        public string MotherChristianName { get; set; }
        public string MotherSurname { get; set; }
    
        public string Source { get; set; }

        public string DeathCounty { get; set; }
        public string BirthCounty { get; set; }

        public string Occupation { get; set; }

        public string SpouseName { get; set; }
        public string SpouseSurname { get; set; }
        public string FatherOccupation { get; set; }



        public int Limit { get; set; }
        public int Offset { get; set; }
        public ClaimsPrincipal User { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public int YearStart { get; set; }
        public int YearEnd { get; set; }
         

    }

    public class ADBSourceParamObj {
        public string SourceRef { get; set; }

        public string Location { get; set; }


        public int Limit { get; set; }
        public int Offset { get; set; }
        public ClaimsPrincipal User { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public int YearStart { get; set; }
        public int YearEnd { get; set; }
    }

    public class ADBMarriageParamObj {
      
        public int Limit { get; set; }
        public int Offset { get; set; }
        public ClaimsPrincipal User { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public int YearStart { get; set; }
        public int YearEnd { get; set; }


        public string MaleSurname { get; set; }

        public string FemaleSurname { get; set; }

        public string Location { get; set; }


    }

    public class ADBParishParamObj
    {
        public string ParishName { get; set; }

        public string County { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public int Limit { get; set; }
        public int Offset { get; set; }
        public ClaimsPrincipal User { get; set; }
 
         
    }
}
