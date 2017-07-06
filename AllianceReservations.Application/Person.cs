using System;
using System.Collections.Generic;
using System.Linq;

namespace AllianceReservations.Application
{
    public class Person : ActiveRecordBase
    {
        private static readonly List<Person> Persons = new List<Person>();
        public string FirstName { get; }
        public string LastName { get; }
        public Address Address { get; }

        public Person(string firstname, string lastName, Address address) : this("", firstname, lastName, address)
        {

        }

        public Person(string id, string firstname, string lastName, Address address)
        {

            if (address == null) throw new ArgumentNullException(nameof(address));
            if (string.IsNullOrWhiteSpace(firstname))
                throw new ArgumentException("Argument is null or whitespace", nameof(firstname));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Argument is null or whitespace", nameof(lastName));

            Id = id;
            FirstName = firstname;
            LastName = lastName;
            Address = address;
        }

        public static Person Find(string id)
        {
            return Persons.SingleOrDefault(p => p.Id == id);
        }

        public void Save()
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                Id = NextId();
                var address = new Address(Address.Street, Address.City, Address.State, Address.ZipCode);
                var person = new Person(Id, FirstName, LastName, address);
                Persons.Add(person);
            }
        }

        private string NextId()
        {
            return (Persons.Count + 1).ToString();
        }


        public void Delete()
        {
            Persons.RemoveAll(p => p.Id == Id);
            Id = string.Empty;
        }

        public override bool Equals(object obj)
        {
            var o = obj as Person;
            return
                o != null &&
                FirstName == o.FirstName &&
                LastName == o.LastName &&
                Address.Equals(o.Address);
        }

        public override int GetHashCode()
        {
            var startValue = 17;
            var multiplier = 59;

            var hashCode = startValue;
            hashCode = hashCode * multiplier + FirstName.GetHashCode();
            hashCode = hashCode * multiplier + LastName.GetHashCode();
            hashCode = hashCode * multiplier + Address.GetHashCode();
            return hashCode;
        }
    }
}