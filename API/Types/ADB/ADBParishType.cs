using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.ADB
{
    public class ADBParishType : ObjectGraphType<ADBParish>
    {
        public ADBParishType() {
            
            Field(m => m.Id);

            Field(m => m.ParishName);
            Field(m => m.ParishRegistersDeposited);
            Field(m => m.ParishNotes);
            Field(m => m.ParentParish);
            Field(m => m.ParishStartYear);
            Field(m => m.ParishEndYear);
            Field(m => m.ParishCounty);
            Field(m => m.ParishX);
            Field(m => m.ParishY);
        }

    }

    public class ADBParish
    {
        public int Id { get; set; }
        public string ParishName { get; set; }
        public string ParishRegistersDeposited { get; set; }
        public string ParishNotes { get; set; }
        public string ParentParish { get; set; }
        public int ParishStartYear { get; set; }
        public int ParishEndYear { get; set; }
        public string ParishCounty { get; set; }
        public decimal ParishX { get; set; }
        public decimal ParishY { get; set; }
    }
}