using Dumpify;
using System;

IEnumerable<int> collection = [1, 2, 3, 4, 5, 1];

// Video reference: https://www.youtube.com/watch?v=7-P6Mxl5elg
// Demo of all 74 LINQ extension methods with examples.
// Using Dumpify to print results via .Dump() instead of Console.WriteLine().

//--------------------------------------FILTERING--------------------------------------

// Where - filter elements by predicate
collection.Where(x => x > 2).Dump();

// OfType - filter by type
IEnumerable<object> collection2 = [1, "abc", 3, 4, 5];
collection2.OfType<int>().Dump();
collection2.OfType<string>().Dump();

// Skip / Take - skip or take N elements
collection.Skip(3).Dump();
collection.Take(3).Dump();

// SkipLast / TakeLast - operate from the end
collection.SkipLast(3).Dump();
collection.TakeLast(3).Dump();

// SkipWhile / TakeWhile - stop/start once predicate fails
collection.SkipWhile(x => x < 2).Dump();
collection.TakeWhile(x => x < 2).Dump();

//--------------------------------------PROJECTION--------------------------------------

// Select - transform each element
collection.Select(x => x.ToString()).Dump();
collection.Select(x => x > 2).Dump();

// Select with index
collection.Select((x, i) => $"Index {i}, Element {x}").Dump();

// SelectMany - flatten nested collections
IEnumerable<List<int>> collection3 = [[1, 2, 3], [4, 5, 6]];
collection3.SelectMany(x => x).Dump();
collection3.SelectMany((x, i) => x.Select(v => $"Index {i}, Value {v}")).Dump();

// Cast - convert sequence to target type
collection.Cast<int>().Dump();

// Chunk - split into fixed-size segments
collection.Chunk(2).Dump();

//--------------------------------------EXISTENCE / QUANTITY CHECKS--------------------------------------

// Any - at least one element matches
collection.Any(x => x > 2).Dump();

// All - every element matches
collection.All(x => x > 0).Dump();

// Contains - check if element exists
collection.Contains(10).Dump();

//--------------------------------------SEQUENCE MANIPULATION--------------------------------------

// Append / Prepend
collection = collection.Append(5).Dump();
collection.Prepend(0).Dump();

//--------------------------------------AGGREGATION--------------------------------------
// (Immediate execution methods start here)

collection.Where(i => i > 2).Count().Dump();
collection.TryGetNonEnumeratedCount(out int count).Dump();

IEnumerable<Person> people = [new(0, "You", 15), new(1, "Me", 16), new(2, "Them", 16)];

// Max / MaxBy
people.Max(p => p.age).Dump();
people.MaxBy(p => p.age).Dump();

// Min / MinBy
people.Min(p => p.age).Dump();
people.MinBy(p => p.age).Dump();

// Sum / Average / LongCount
collection.Sum().Dump();
collection.Average().Dump();
collection.LongCount().Dump();

// Aggregate - generalized reduction
collection.Aggregate((x, y) => x + y).Dump();             // sum
collection.Aggregate(10, (x, y) => x + y).Dump();         // seed
collection.Aggregate(10, (x, y) => x + y, r => r / 2).Dump(); // seed + result selector

// Custom aggregate: comma-separated string
collection.Select(x => x.ToString()).Aggregate((x, y) => x + ", " + y).Dump();

//--------------------------------------ELEMENT OPERATORS--------------------------------------

collection.First().Dump();                          // throws if empty
collection.FirstOrDefault().Dump();                 // default(T) if empty
collection.FirstOrDefault(Int32.MinValue).Dump();   // custom default

// Single / SingleOrDefault - ensure exactly one element
//collection.Single().Dump();
//collection.SingleOrDefault(-1).Dump();

collection.ElementAt(0).Dump();                     // throws if out of range
collection.ElementAtOrDefault(10).Dump();           // safe variant

collection.DefaultIfEmpty().Dump();                 // insert default if empty

//--------------------------------------CONVERSION--------------------------------------

collection.ToArray().Dump();
collection.ToList().Dump();
collection.ToHashSet().Dump();

people.ToLookup(p => p.age).Dump();
people.ToLookup(p => p.age)[16].Dump();
people.ToLookup(p => p.age)[15].Single().name.Dump();

//--------------------------------------GENERATION--------------------------------------

Enumerable.Range(1, 100).Dump();
Enumerable.Repeat(0, 100).Dump();
Enumerable.Empty<int>().Dump();

//--------------------------------------SET OPERATIONS--------------------------------------

collection.Distinct().Dump();
people.DistinctBy(p => p.age).Dump();

IEnumerable<int> setOp1 = [1, 2, 3];
IEnumerable<int> setOp2 = [2, 3, 4];

setOp1.Union(setOp2).Dump();
setOp1.Intersect(setOp2).Dump();
setOp1.Except(setOp2).Dump();

IEnumerable<Person> setPpl1 = [new(0, "You", 15), new(1, "Me", 16)];
IEnumerable<Person> setPpl2 = [new(2, "You", 15)];

setPpl1.UnionBy(setPpl2, x => x.id).Dump();
setPpl1.IntersectBy(setPpl2.Select(x => x.name), p => p.name).Dump();
setPpl1.ExceptBy(setPpl2.Select(i => i.age), p => p.age).Dump();
setPpl1.SequenceEqual(setPpl2).Dump();

//--------------------------------------JOINING / GROUPING--------------------------------------

IEnumerable<int> coll1 = [1, 2, 3];
IEnumerable<string> coll2 = ["a", "b", "c"];
coll1.Zip(coll2).Dump();

IEnumerable<Product> products = [new(0, "Shoes"), new(0, "Jacket"), new(1, "Jeans")];

people.Join(products, p => p.id, pr => pr.PersonId, (p, pr) => $"{p.name} bought {pr.name}").Dump();

people.GroupJoin(products, p => p.id, pr => pr.PersonId,
    (p, prs) => $"{p.name} bought {string.Join(',', prs)}").Dump();

IEnumerable<int> collec2 = [6, 7, 8, 9, 10];
collection.Concat(collec2).Dump();

people.GroupBy(p => p.age).Dump();
IGrouping<int, Person> lastGroup = people.GroupBy(p => p.age).Last();
lastGroup.Key.Dump();

//--------------------------------------SORTING--------------------------------------

collection.Order().Dump();
collection.OrderDescending().Dump();

people.OrderBy(p => p.age).Dump();

// OrderBy with key transformation (here: reverse order by multiplying with -2)
collection.OrderBy(i => i * -2).Dump();  // 5,4,3,2,1,1

people.OrderByDescending(p => p.age).Dump();

// ThenBy / ThenByDescending - secondary sorting
IEnumerable<Person> peoples = [ 
    new(0,"John", 24),
    new(1,"John", 27),
    new(2,"Mary", 29)
];

peoples.OrderBy(i => i.name).ThenBy(i => i.age).Dump();
peoples.OrderBy(i => i.name).ThenByDescending(i => i.age).Dump();

//Reverse - Reverses the elements in collection
collection.Reverse().Dump();

record Person(int id, string name, int age);
record Product(int PersonId, string name);
