using System;
using System.Collections.Generic;
using System.Linq;
using KaratePacan;
using KaratePacan.Consts;
using KaratePacan.Models;

// ***************************** Task 1 *******************************
Console.WriteLine("*****TASK 1*****");

var months = new []
{
    "June",
    "July",
    "August",
    "December",
    "January",
    "February",
    "March",
    "April",
    "May",
    "September",
    "October",
    "November"
};

var summerMonths = new[]
{
    "June",
    "July",
    "August"
};

var winterMonths = new[]
{
    "December",
    "January",
    "February"
};

// Where length = n
Console.Write("Enter month name length: ");
int nameLength = Utils.ScanIntValue();

string[] nameLengthQueryResult = months.Where(x => x.Length == nameLength).ToArray();

Console.WriteLine($"Months with name length {nameLength}:");
Console.WriteLine(Utils.FormatCollection(nameLengthQueryResult));

Console.WriteLine();

// Where winter or summer months
Console.WriteLine("Winter and summer months:");

string[] winterSummerQueryResult = months
    .Where(x =>
        summerMonths.Contains(x)
        || winterMonths.Contains(x))
    .ToArray();

Console.WriteLine(Utils.FormatCollection(winterSummerQueryResult));

Console.WriteLine();

// Alphabet order
Console.WriteLine("Alphabet order months:");

string[] alphabetOrderResult = months
    .OrderBy(x => x)
    .ToArray();

Console.WriteLine(Utils.FormatCollection(alphabetOrderResult));

Console.WriteLine();

// Custom condition
Console.WriteLine("Custom query months:");

string[] customQueryResult = months
    .Where(x => x.Contains('u')
        && x.Length >= 4)
    .ToArray();

Console.WriteLine(Utils.FormatCollection(customQueryResult));

// ***************************** Task 2 *******************************

var flats = new List<Flat>
{
    new()
    {
        Number = 1,
        Floor = 1,
        Street = StreetNames.Kolesnikova,
        RoomCount = 4,
        HouseNumber = 1
    },
    new()
    {
        Number = 2,
        Floor = 1,
        Street = StreetNames.Kolesnikova,
        RoomCount = 2,
        HouseNumber = 1
    },
    new()
    {
        Number = 3,
        Floor = 1,
        Street = StreetNames.Suharevo,
        RoomCount = 8,
        HouseNumber = 1
    },
    new()
    {
        Number = 4,
        Floor = 2,
        Street = StreetNames.Suharevo,
        RoomCount = 6,
        HouseNumber = 1
    },
    new()
    {
        Number = 5,
        Floor = 2,
        Street = StreetNames.Suharevo,
        RoomCount = 2,
        HouseNumber = 1
    },
    new()
    {
        Number = 6,
        Floor = 3,
        Street = StreetNames.Suharevo,
        RoomCount = 3,
        HouseNumber = 1
    },
    new()
    {
        Number = 7,
        Floor = 3,
        Street = StreetNames.Suharevo,
        RoomCount = 3,
        HouseNumber = 1
    },
    new()
    {
        Number = 8,
        Floor = 1,
        Street = StreetNames.Natashevo,
        RoomCount = 1,
        HouseNumber = 1
    },
    new()
    {
        Number = 9,
        Floor = 1,
        Street = StreetNames.Natashevo,
        RoomCount = 2,
        HouseNumber = 1
    },
    new()
    {
        Number = 10,
        Floor = 2,
        Street = StreetNames.Natashevo,
        RoomCount = 4,
        HouseNumber = 1
    },
};

// Specific number count
Console.Write("Enter room count:");

int roomCount = Utils.ScanIntValue();
List<Flat> roomCountResult = flats.Where(x => x.RoomCount == roomCount).ToList();

Console.WriteLine(Utils.FormatCollection(roomCountResult.Select(x => x.Number.ToString())));

// First five flats on specific street
Console.Write("Enter street name:");
string streetName = Utils.ScanStringValue();

Console.Write("Enter house number:");
int houseNumber = Utils.ScanIntValue();

List<Flat> fiveFlatsResult = flats
    .Where(x => x.Street == streetName
        && x.HouseNumber == houseNumber)
    .Take(5)
    .ToList();

Console.WriteLine(Utils.FormatCollection(fiveFlatsResult.Select(x => x.Number.ToString())));

Console.WriteLine();

// Flats count on specific street
Console.Write("Enter street name:");
string streetName2 = Utils.ScanStringValue();

int flatCountResult = flats
    .Count(x => x.Street == streetName2);

Console.WriteLine(flatCountResult);

Console.WriteLine();

// Custom flat query
Console.Write("Enter room count:");
int roomCount2 = Utils.ScanIntValue();

Console.Write("Enter floor start range:");
int startFloorRange = Utils.ScanIntValue();

Console.Write("Enter floor end range:");
int endFloorRange = Utils.ScanIntValue();

List<Flat> customFlatsResult = flats
    .Where(x => x.RoomCount == roomCount2
        && x.Floor >= startFloorRange
        && x.Floor <= endFloorRange)
    .ToList();

Console.WriteLine(Utils.FormatCollection(customFlatsResult.Select(x => x.Number.ToString())));

// My query
var myQueryResult = flats
    .Where(x => x.Street == StreetNames.Suharevo)
    .OrderBy(x => x.RoomCount)
    .Select(x => x.RoomCount)
    .Sum();

Console.WriteLine(myQueryResult);

// Join query
var houses = new List<House>()
{
    new()
    {
        HouseNumber = 1,
        Name = "Egor"
    }
};

List<House> houseQueryResult = flats
    .Join(houses, f => f.HouseNumber, h => h.HouseNumber, (_, h) => h)
    .ToList();

Console.WriteLine(Utils.FormatCollection(houseQueryResult.Select(x => x.Name)));