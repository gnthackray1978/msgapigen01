using System.Text.RegularExpressions;

namespace Geocoder;

public class EnglishHistoricCounties
{
    //todo move
    public static string Capitalize(string str)
    {

        if (string.IsNullOrEmpty(str)) return "";


        if (str.Length == 1)
            return str[0].ToString().ToUpper();


        return char.ToUpper(str[0]).ToString() + str.Substring(1);
    }

    public static List<string> GetLowerCase { get; set; }
        = new List<string>() {
            "bedfordshire",
            "berkshire",
            "buckinghamshire",
            "cambridgeshire",
            "cheshire",
            "cornwall",
            "cumberland",
            "derbyshire",
            "devon",
            "dorset",
            "durham",
            "essex",
            "gloucestershire",
            "hampshire",
            "herefordshire",
            "hertfordshire",
            "huntingdonshire",
            "kent",
            "lancashire",
            "leicestershire",
            "lincolnshire",
            "middlesex",
            "norfolk",
            "northamptonshire",
            "northumberland",
            "nottinghamshire",
            "oxfordshire",
            "rutland",
            "shropshire",
            "somerset",
            "staffordshire",
            "suffolk",
            "surrey",
            "sussex",
            "warwickshire",
            "westmorland",
            "wiltshire",
            "worcestershire",
            "yorkshire"
        };
    public static List<string> Get { get; set; }
        = new List<string>() {
            "Bedfordshire",
            "Berkshire",
            "Buckinghamshire",
            "Cambridgeshire",
            "Cheshire",
            "Cornwall",
            "Cumberland",
            "Derbyshire",
            "Devon",
            "Dorset",
            "Durham",
            "Essex",
            "Gloucestershire",
            "Hampshire",
            "Herefordshire",
            "Hertfordshire",
            "Huntingdonshire",
            "Kent",
            "Lancashire",
            "Leicestershire",
            "Lincolnshire",
            "Middlesex",
            "Norfolk",
            "Northamptonshire",
            "Northumberland",
            "Nottinghamshire",
            "Oxfordshire",
            "Rutland",
            "Shropshire",
            "Somerset",
            "Staffordshire",
            "Suffolk",
            "Surrey",
            "Sussex",
            "Warwickshire",
            "Westmorland",
            "Wiltshire",
            "Worcestershire",
            "Yorkshire"
        };

    public static string Match(IEnumerable<string> places)
    {
        if (places == null || !places.Any()) return null;

        var r = GetLowerCase.FirstOrDefault(c => places
            .Select(s => s.ToLower().Trim())
            .Any(p => c.Contains(p)));

        return Capitalize(r);
    }

    public static string Match(string place)
    {
        place = Regex.Replace(place, @"[^a-zA-Z0-9]+", " ");

        if (string.IsNullOrEmpty(place))
            return "";

        IEnumerable<string> places = place.ToLower().Split(' ');

        var r = GetLowerCase.FirstOrDefault(c => places
            .Select(s => s.ToLower().Trim())
            .Any(p => c.Contains(p)));

        return Capitalize(r);
    }

    public static List<string> FromPlaceList(IEnumerable<string> places)
    {
        var locationList = new List<string>();

        foreach (var part in places)
        {
            if (locationList.Contains(part)) continue;

            if (Get.Contains(part))
                locationList.Add(part);
        }

        return locationList;
    }
}