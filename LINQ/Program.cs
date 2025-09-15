using Dumpify;

IEnumerable<int> collection = [1, 2, 3, 4, 5];

//https://www.youtube.com/watch?v=7-P6Mxl5elg
//--------------------------------------FILTERING--------------------------------------

//Where
collection.Where(x => x > 2).Dump();

//OfType
IEnumerable<object> collection2 = [1, "abc", 3, 4, 5];
collection2.OfType<int>().Dump();
collection2.OfType<string>().Dump();

//Skip, Take
collection.Skip(3).Dump();
collection.Take(3).Dump();

//SkipLast, TakeLast
collection.SkipLast(3).Dump();
collection.TakeLast(3).Dump();

//SkipWhile, TakeWhile
////Continue skipping elements until the predicate is false
collection.SkipWhile(x => x < 2).Dump();
////Continue taking elements until the predicate is true
collection.TakeWhile(x => x < 2).Dump();

//--------------------------------------PROJECTION--------------------------------------

//Select gives us option to get each one of these elements and project them to a different type
collection.Select(x => x.ToString()).Dump();
collection.Select(x => x > 2).Dump(); //Returns true or false.
//Select with Index overload
collection.Select((x, i) => $"Index {i} and Element {x}").Dump();

//Select Many
IEnumerable<List<int>> collection3 = [[1, 2, 3], [4, 5, 6]];
//Flattens the inner lists into one list.
collection3.SelectMany(x => x).Dump();
//SelectMany with Index overload
collection3.SelectMany((x, i) => x.Select(x => $"index {i} and {x}")).Dump();

//Cast - from one type to another type
collection.Cast<int>().Dump();

//Chunk - Divides a collection into multiple collections based on the number of elements specified.
//Opposite of SelectMany
collection.Chunk(2).Dump();
//This will create 2 integer arrays from one.

//--------------------------------------EXISTENCE OR QUANTITY CHECKS--------------------------------------

//LINQ USUALLY USES DEFERRED EXECUTION EXCEPT FOR SOME EXTENSION METHODS. BELOW ARE IMMEDIATE EXECUTION METHODS

//Any - Returns true if there is a single element that passes the predicate specified, otherwise false.
collection.Any(x => x > 2).Dump();

// All - Returns true if all elements pass the predicate, false otherwise.
collection.All(x => x > 0).Dump();

// Contains - checks if collection contains the element specified in the predicate.
collection.Contains(10).Dump();

//--------------------------------------SEQUENCE MANIPULATION--------------------------------------

//Append or Prepend to a collection
collection = collection.Append(5).Dump();
collection.Prepend(0).Dump();

//--------------------------------------AGGREGATION METHODS--------------------------------------

//Max and MaxBy - Immediate Execution

IEnumerable<Person> People = [new("You", 15), new("Me", 16)];

People.Max(i => i.age).Dump();  //Changes the actual object.
People.MaxBy(i => i.age).Dump(); // Doesn't change the actual object.

record Person(string name, int age);
