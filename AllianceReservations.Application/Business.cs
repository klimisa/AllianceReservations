using System;
using System.Collections.Generic;
using System.Linq;

namespace AllianceReservations.Application
{
    public class Business: ActiveRecordBase
    {
        private static readonly List<Business> Businesses = new List<Business>();
        public string Name { get; }
        public Address Address { get; }

        public Business(string name, Address address): this("", name, address)
        {

        }

        public Business(string id, string name, Address address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Argument is null or whitespace", nameof(name));

            Id = id;
            Name = name;
            Address = address;
        }

        public static Business Find(string id)
        {
            return Businesses.SingleOrDefault(p => p.Id == id);
        }

        public void Save()
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                Id = NextId();
                var address = new Address(Address.Street, Address.City, Address.State, Address.ZipCode);
                var business = new Business(Id, Name, address);
                Businesses.Add(business);
            }
           
        }

        private string NextId()
        {
            return (Businesses.Count + 1).ToString();
        }

        public void Delete()
        {
            Businesses.RemoveAll(p => p.Id == Id);
            Id = string.Empty;
        }

        public override bool Equals(object obj)
        {
            var o = obj as Business;
            return
                o != null &&
                Name == o.Name &&
                Address.Equals(o.Address);
        }

        public override int GetHashCode()
        {
            var startValue = 17;
            var multiplier = 59;

            var hashCode = startValue;
            hashCode = hashCode * multiplier + Name.GetHashCode();
            hashCode = hashCode * multiplier + Address.GetHashCode();
            return hashCode;
        }
    }
}