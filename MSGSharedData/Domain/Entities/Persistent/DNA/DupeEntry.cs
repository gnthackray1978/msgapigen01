using System;
using MSGSharedData.Data.Services.interfaces.domain;

namespace FTMContextNet.Domain.Entities.Persistent.Cache
{
    public partial class DupeEntry : IEquatable<DupeEntry>, IName, ISurname
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Ident { get; set; }
        public string Origin { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public string Location { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public int ImportId { get; set; }

        public int UserId { get; set; }

        //Function to implement getHashCode
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + PersonId.GetHashCode();
                hash = hash * 23 + Ident.GetHashCode();
                hash = hash * 23 + Origin.GetHashCode();
                hash = hash * 23 + YearStart.GetHashCode();
                hash = hash * 23 + YearEnd.GetHashCode();
                hash = hash * 23 + Location.GetHashCode();
                hash = hash * 23 + FirstName.GetHashCode();
                hash = hash * 23 + Surname.GetHashCode();
                hash = hash * 23 + ImportId.GetHashCode();
                hash = hash * 23 + UserId.GetHashCode();
                return hash;
            }
        }
        //Function to implement Equals
        public bool Equals(DupeEntry other)
        {
            if (this.Id != other.Id) return false;
            if (this.PersonId != other.PersonId) return false;
            if (this.Ident != other.Ident) return false;
            if (this.Origin != other.Origin) return false;
            if (this.YearStart != other.YearStart) return false;
            if (this.YearEnd != other.YearEnd) return false;
            if (this.Location != other.Location) return false;
            if (this.FirstName != other.FirstName) return false;
            if (this.Surname != other.Surname) return false;
            if (this.ImportId != other.ImportId) return false;
            if (this.UserId != other.UserId) return false;

            return true;
        }

        //Function to implement Equals
        public override bool Equals(object obj)
        {
            return this.Equals(obj as DupeEntry);
        }

    }
}