using System;

namespace AllianceReservations.Application
{
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }

        public Address(string street, string city, string state, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Argument is null or whitespace", nameof(street));
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("Argument is null or whitespace", nameof(city));
            if (string.IsNullOrWhiteSpace(state))
                throw new ArgumentException("Argument is null or whitespace", nameof(state));
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException("Argument is null or whitespace", nameof(zipCode));

            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}