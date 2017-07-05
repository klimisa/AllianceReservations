using System;

namespace AllianceReservations.Application
{
    public class Business: ActiveRecordBase
    {
        public string Name { get; }
        public Address Address { get; }

        public Business(string name, Address address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Argument is null or whitespace", nameof(name));
            Name = name;
            Address = address;
        }

        public static Business Find(string id)
        {
            return null;
        }

        public void Save()
        {

        }

        public void Delete()
        {

        }
    }
}