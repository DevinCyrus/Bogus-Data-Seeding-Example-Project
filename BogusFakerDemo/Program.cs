using System;
using System.Collections.Generic;
using Bogus;

public class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? ContactNumber { get; set; }
    public string? Address { get; set; }
}
public class Program
{
    // Faker instance for generating Person objects
    private static Faker<Person>? _personFaker = null;

    // Method to get the Faker<Person> instance
    public static Faker<Person> GetPersonGenerator()
    {
        // Initialize the Faker<Person> instance if not already initialized
        if (_personFaker == null)
        {
            _personFaker = new Faker<Person>()
                .UseSeed(2024) // Set seed for deterministic data generation
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f => f.Person.LastName)
                .RuleFor(p => p.Email, f => f.Person.Email)
                .RuleFor(p => p.ContactNumber, f => f.Phone.PhoneNumber(format: "0#########"))
                .RuleFor(p => p.Address, f => f.Address.FullAddress());
        }

        return _personFaker;
    }

    public static void Main(string[] args)
    {
        // Obtain the Faker<Person> instance
        var personGenerator = GetPersonGenerator();

        // Generate a list of 10 persons
        List<Person> personList = personGenerator.Generate(10);

        // Print details of each person to the console
        foreach (var person in personList)
        {
            Console.WriteLine($"First Name: {person.FirstName}");
            Console.WriteLine($"Last Name: {person.LastName}");
            Console.WriteLine($"Email: {person.Email}");
            Console.WriteLine($"Contact Number: {person.ContactNumber}");
            Console.WriteLine($"Address: {person.Address}");
            Console.WriteLine();
        }
    }
}
