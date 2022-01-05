using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.DNAAnalyse
{


    public class FTMLatLngType : ObjectGraphType<FTMLatLng>
    {
        public FTMLatLngType()
        {
            Field(m => m.Id);
            Field(m => m.Lat);
            Field(m => m.Long);
            Field(m => m.Weight);     
        }
    }


    public class FTMLatLng
    {
        public int Id { get; set; }         
        public double Lat { get; set; }
        public double Long { get; set; }  
        public int Weight { get; set; }
    }
}
