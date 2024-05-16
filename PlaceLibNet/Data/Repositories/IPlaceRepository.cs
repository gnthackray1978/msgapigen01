using System.Collections.Generic;
using PlaceLibNet.Domain.Entities;
using PlaceLibNet.Domain.Entities.Persistent;

namespace PlaceLibNet.Data.Repositories;

public interface IPlaceRepository
{
    List<CountyDto> GetCounties(bool toLower = false);
    List<PlaceSearchCoordSubset> GetPlaceLibCoords();
    int GetGeoCodeCacheSize();
    int GetUnsearchedCount();
    void InsertPlacesIntoCache(IEnumerable<PlaceCache> placeCaches);

    void InsertPlaceIntoCache(PlaceCache place);

    void UpdateCacheEntry(int id, string name);

    void UpdateCacheEntries(IEnumerable<PlaceCache> cacheEntries);

    void SetPlaceGeoData(int id, string results);

    /// <summary>
    /// Deserialise JSON result of google geolocate and use it to 
    /// fill out place cache fields
    /// </summary>
    void SetGeolocatedResult();


    void SetCounties();
    List<PlaceLookup> GetCachedPlaces();

    /// <summary>
    /// count of un geolocated cached places
    /// </summary>
    /// <returns></returns>
    int GetUnknownPlacesCount();

    List<PlaceLookup> GetUnknownPlacesIgnoreSearchedAlready();
}