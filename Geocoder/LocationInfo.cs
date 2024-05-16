namespace Geocoder;

public class LocationInfo
{
    public bool IsValid { get; set; } = false;

    public string Error { get; set; }

    public bool IsUK()
    {
        return this.Country == "United Kingdom";
    }

    public string PostalTown { get; set; }
    public string Political { get; set; }
    public string State { get; set; }
    public string County { get; set; } = "";
    public string Country { get; set; }

    public double lat { get; set; }
    public double lng { get; set; }
}