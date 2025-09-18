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

//Count (Immediate Execution)
collection.Where(i=> i > 2).Count().Dump();

// TryGetNonEnumeratedCount - Returns the count of elements in a collection without enumerating it.
// if the count cannot be determined without enumeration, it returns false, otherwise true.
collection.TryGetNonEnumeratedCount(out int count).Dump();

//Max and MaxBy - Immediate Execution

IEnumerable<Person> People = [new("You", 15), new("Me", 16)];

//Max returns the maximum value based on the selector provided.
People.Max(i => i.age).Dump();
//MaxBy returns the element that has the maximum value based on the selector provided.
People.MaxBy(i => i.age).Dump();

//Min and MinBy - Immediate Execution
People.Min(i => i.age).Dump(); 
People.MinBy(i => i.age).Dump(); //If you don't want to manipualte the actual object.

//Sum - Immediate Execution - Works only on numeric types.
collection.Sum().Dump();

//Average - Immediate Execution - Works only on numeric types.
collection.Average().Dump();

//LongCount - Immediate Execution - Returns long instead of int.
collection.LongCount().Dump();

//Aggregate - Immediate Execution - More generalized form of aggregation. Under the hood it uses a loop to iterate through each element and perform the operation specified.
//Underrated extension method.
// This is implementing Sliding window technique, where we are taking two elements at a time and performing the operation specified. Then x is replaced by the result of the operation and y is replaced by the next element in the collection.
collection.Aggregate((x, y) => x + y).Dump(); //Sum of all elements.

//Overload with seed value.
collection.Aggregate(10, (x, y) => x + y).Dump(); //Sum of all elements + seed value.

//Overload with seed value and result selector.
collection.Aggregate(10, (x, y) => x + y, x => x/2).Dump(); // (Sum of all elements + seed value) divided by 2.

//Let's say you want to display the list in a comma separated format.
collection.Select(x => x.ToString()).Aggregate((x, y) => x + ", " + y).Dump();


//--------------------------------------ELEMENT OPERATORS--------------------------------------

// First - Immediate Execution
//If there are no elements, this will output InvalidOperationException.
collection.First().Dump();

//If you don't want to output exception in case of no elements, you can use FirstOrDefault
//which outputs the default value of the type specified.

collection.FirstOrDefault().Dump();

//If you want to mention specific default value, you can do so 
collection.FirstOrDefault(Int32.MinValue).Dump();

record Person(string name, int age);