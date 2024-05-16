using System;
using Microsoft.AspNetCore.Authentication;

namespace FTMContextNet.Domain.Entities.Persistent.Cache;

public partial class TreeImport: IEquatable<TreeImport>
{
    public int Id { get; set; }
    public string DateImported { get; set; }

    public string FileSize { get; set; }

    public string FileName { get; set; }

    public DateTime? PersonsProcessed { get; set; }

    public DateTime? DupesProcessed { get; set; }

    public DateTime? MissingLocationsProcessed { get; set; }

    public DateTime? GeocodingProcessed { get; set; }

    public DateTime? CCProcessed { get; set; }

    public bool Selected { get; set; }

    public int UserId { get; set; }

    //Function to implement getHashCode
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + DateImported.GetHashCode();
            hash = hash * 23 + FileSize.GetHashCode();
            hash = hash * 23 + FileName.GetHashCode();
            hash = hash * 23 + Selected.GetHashCode();
            hash = hash * 23 + UserId.GetHashCode();
            hash = hash * 23 + DupesProcessed.GetHashCode();
            hash = hash * 23 + MissingLocationsProcessed.GetHashCode();
            hash = hash * 23 + GeocodingProcessed.GetHashCode();
            hash = hash * 23 + CCProcessed.GetHashCode();
            hash = hash * 23 + PersonsProcessed.GetHashCode();

            return hash;
        } 
    }

    //Function to implement Equals
    public bool Equals(TreeImport other)
    {
        if (this.Id != other.Id) return false;
        if (this.DateImported != other.DateImported) return false;
        if (this.FileSize != other.FileSize) return false;
        if (this.FileName != other.FileName) return false;
        if (this.Selected != other.Selected) return false;
        if (this.UserId != other.UserId) return false;

        if (this.GeocodingProcessed != other.GeocodingProcessed) return false;
        if (this.CCProcessed != other.CCProcessed) return false;
        if (this.DateImported!=other.DateImported) return false;
        if (this.PersonsProcessed != other.PersonsProcessed) return false;
        if (this.DupesProcessed  != other.DupesProcessed) return false;
        if (this.MissingLocationsProcessed !=  other.MissingLocationsProcessed) return false;


        return true;
    }

    //Function to implement Equals
    public override bool Equals(object obj)
    {
        return this.Equals(obj as TreeImport);
    }
}