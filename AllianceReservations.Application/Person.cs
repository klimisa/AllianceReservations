using System;

namespace AllianceReservations.Application
{
    public class Person: ActiveRecordBase
    {

        public string FirstName { get; }
        public string LastName { get; }
        public Address Address { get; }

        public Person(string firstname, string lastName, Address address)
        {

            if (address == null) throw new ArgumentNullException(nameof(address));
            if (string.IsNullOrWhiteSpace(firstname))
                throw new ArgumentException("Argument is null or whitespace", nameof(firstname));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Argument is null or whitespace", nameof(lastName));

            FirstName = firstname;
            LastName = lastName;
            Address = address;
        }

        public static Person Find(string id)
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