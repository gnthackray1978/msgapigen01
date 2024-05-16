//using GoogleMapsGeocoding;
//using GoogleMapsGeocoding.Common;

//namespace Geocoder
//{
//    //public class Geocoder
//    //{

//    //    public static string Test()
//    //    {

//    //        // Create new Geocoder and pass GOOGLE_MAPS_API_KEY(in this example it's stored in .config)
//    //        IGeocoder geocoder = new GoogleMapsGeocoding.Geocoder("AIzaSyC4xE7VpfxqbdKcH19lze4LDxHX4e5nqLU");

//    //        // Get GeocodeResponse C# object from address or from Latitude Longitude(reverse geocoding) 
//    //        GeocodeResponse response = geocoder.Geocode("1984 west armitage ave chicago il");
//    //        GeocodeResponse reversGeocoderesponse = geocoder.ReverseGeocode(40.714224, -73.961452);

//    //        // You can then query the response to get what you need
//    //        double latitude = response.Results[0].Geometry.Location.Lat;
//    //        string address = reversGeocoderesponse.Results[1].FormattedAddress;

//    //        // ..or you can get a response in JSON, XML string foramt(for whatever reason) and "play" with it
//    //        string responseJson = geocoder.Geocode("1984 west armitage ave chicago il", ResponseFormat.JSON);
//    //        string reverseResponseXml = geocoder.ReverseGeocode(40.714224, -73.961452, ResponseFormat.XML);

//    //        // Then you can deserialize it to C# object again
//    //        GeocodeResponse geocodeFromJson = geocoder.FromJson(responseJson);
//    //        GeocodeResponse reverseGeocodeFromXml = geocoder.FromXml(reverseResponseXml);

//    //        return "hello";
//    //    }

//    //    public static string GetLocationComponent(GeocodeResponse root, string type, string subType)
//    //    {
//    //        foreach (var result in root.Results)
//    //        {
//    //            foreach (var ac in result.AddressComponents)
//    //            {

//    //                bool isMissing = false;

//    //                foreach (var comp in ac.Types)
//    //                {
//    //                    if (type != "administrative_area_level_2")
//    //                    {
//    //                        if (comp == type)
//    //                        {
//    //                            return ac.LongName;
//    //                        }
//    //                    }
//    //                    else
//    //                    {
//    //                        if (comp == type)
//    //                        {

//    //                            if (subType == "England")
//    //                            {
//    //                                if (EnglishHistoricCounties.Get.Contains(ac.LongName))
//    //                                {
//    //                                    return ac.LongName;
//    //                                }
//    //                                else
//    //                                {

//    //                                    if (ac.LongName.Contains("Yorkshire"))
//    //                                    {
//    //                                        return "Yorkshire";
//    //                                    }

//    //                                    if (ac.LongName.Contains("Cumbria"))
//    //                                    {
//    //                                        return "Cumbria";
//    //                                    }

//    //                                    if (ac.LongName.Contains("Chesire"))
//    //                                    {
//    //                                        return "Chesire";
//    //                                    }

//    //                                    if (ac.LongName.Contains("Sussex"))
//    //                                    {
//    //                                        return "Sussex";
//    //                                    }

//    //                                    if (ac.LongName.Contains("Durham"))
//    //                                    {
//    //                                        return "Durham";
//    //                                    }

//    //                                    if (ac.LongName.Contains("London"))
//    //                                    {
//    //                                        return "London";
//    //                                    }

//    //                                    if (ac.LongName.Contains("Peterborough"))
//    //                                    {
//    //                                        return "Northamptonshire";
//    //                                    }
//    //                                }
//    //                            }
//    //                            else
//    //                            {
//    //                                return ac.LongName;
//    //                            }
//    //                        }
//    //                    }
//    //                }
//    //            }
//    //        }

//    //        return "";
//    //    }

//    //    public static LocationInfo GetLocationInfo(GeocodeResponse locationData)
//    //    {
//    //       // GoogleLocation locationData = deserializeServiceResult(jsonResult);

//    //        var locationInfo = new LocationInfo() { IsValid = false };

//    //        Location loc = locationData.GetFirstLocation();

//    //        locationInfo.lat = loc.Lat;
//    //        locationInfo.lng = loc.Lng;

//    //        if (!locationData.IsValid() || locationInfo.lat == 0 || locationInfo.lng == 0)
//    //        {
//    //            locationInfo.Error = string.IsNullOrEmpty(locationData.Error) ? "lat and long missing" : locationData.Error;
//    //            return locationInfo;
//    //        }


//    //        locationInfo.IsValid = true;
//    //        locationInfo.Country = GetLocationComponent(locationData, "country", "");
//    //        locationInfo.PostalTown = GetLocationComponent(locationData, "postal_town", "");
//    //        locationInfo.Political = GetLocationComponent(locationData, "political", "");
//    //        locationInfo.State = GetLocationComponent(locationData, "administrative_area_level_1", "");

//    //        var googleCounty = GetLocationComponent(locationData, "administrative_area_level_2", locationInfo.State);

//    //        if (EnglishHistoricCounties.GetLowerCase.Contains(googleCounty))
//    //        {
//    //            locationInfo.County = googleCounty;
//    //        }

//    //        return locationInfo;
//    //    }
//    //}
//}