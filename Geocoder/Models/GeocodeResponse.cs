﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Xml.Serialization;
using Geocoder;
using Newtonsoft.Json;

namespace GoogleMapsGeocoding.Common
{
#if !PORTABLE
    [Serializable]
#endif
    [XmlRoot(ElementName = "GeocodeResponse", IsNullable = false)]
    public class GeocodeResponse
    {
        [JsonProperty("results")]
        [XmlElement("result")]
        public Result[] Results { get; set; }

        [JsonProperty("status")]
        [XmlElement("status")]
        public string Status { get; set; }

        public string Error { get; set; } = "";

        public bool IsValid()
        {
            if (Error != "") return false;

            if (Results == null) return false;

            if (Results.Count() == 0) return false;

            return true;


        }

        public Location GetFirstLocation()
        {
            if (Results is { Length: > 0 } && Results.First().Geometry != null)
                return Results.First().Geometry.Location;

            return new Location();
        }
        
        public static string GetLocationComponent(GeocodeResponse root, string type, string subType)
        {
            foreach (var result in root.Results)
            {
                foreach (var ac in result.AddressComponents)
                {

                    bool isMissing = false;

                    foreach (var comp in ac.Types)
                    {
                        if (type != "administrative_area_level_2")
                        {
                            if (comp == type)
                            {
                                return ac.LongName;
                            }
                        }
                        else
                        {
                            if (comp == type)
                            {

                                if (subType == "England")
                                {
                                    if (EnglishHistoricCounties.Get.Contains(ac.LongName))
                                    {
                                        return ac.LongName;
                                    }
                                    else
                                    {

                                        if (ac.LongName.Contains("Yorkshire"))
                                        {
                                            return "Yorkshire";
                                        }

                                        if (ac.LongName.Contains("Cumbria"))
                                        {
                                            return "Cumbria";
                                        }

                                        if (ac.LongName.Contains("Chesire"))
                                        {
                                            return "Chesire";
                                        }

                                        if (ac.LongName.Contains("Sussex"))
                                        {
                                            return "Sussex";
                                        }

                                        if (ac.LongName.Contains("Durham"))
                                        {
                                            return "Durham";
                                        }

                                        if (ac.LongName.Contains("London"))
                                        {
                                            return "London";
                                        }

                                        if (ac.LongName.Contains("Peterborough"))
                                        {
                                            return "Northamptonshire";
                                        }
                                    }
                                }
                                else
                                {
                                    return ac.LongName;
                                }
                            }
                        }
                    }
                }
            }

            return "";
        }

        public static LocationInfo GetLocationInfo(GeocodeResponse locationData)
        {
            // GoogleLocation locationData = deserializeServiceResult(jsonResult);

            var locationInfo = new LocationInfo() { IsValid = false };

            Location loc = locationData.GetFirstLocation();

            locationInfo.lat = loc.Lat;
            locationInfo.lng = loc.Lng;

            if (!locationData.IsValid() || locationInfo.lat == 0 || locationInfo.lng == 0)
            {
                locationInfo.Error = string.IsNullOrEmpty(locationData.Error) ? "lat and long missing" : locationData.Error;
                return locationInfo;
            }


            locationInfo.IsValid = true;
            locationInfo.Country = GetLocationComponent(locationData, "country", "");
            locationInfo.PostalTown = GetLocationComponent(locationData, "postal_town", "");
            locationInfo.Political = GetLocationComponent(locationData, "political", "");
            locationInfo.State = GetLocationComponent(locationData, "administrative_area_level_1", "");

            var googleCounty = GetLocationComponent(locationData, "administrative_area_level_2", locationInfo.State);

            if (EnglishHistoricCounties.GetLowerCase.Contains(googleCounty.ToLower()))
            {
                locationInfo.County = googleCounty;
                locationInfo.Country = "England";
            }

            return locationInfo;
        }
    }
}