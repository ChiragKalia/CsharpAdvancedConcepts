using Dumpify;
using System;

IEnumerable<int> collection = [1, 2, 3, 4, 5, 1];

//https://www.youtube.com/watch?v=7-P6Mxl5elg

//Using Dumpify package to simplify console outputs.
// Instead of writing a separate Console.WriteLine(), you can simply use .Dump() method to output values to the console.

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

IEnumerable<Person> People = [new(0, "You", 15), new(1, "Me", 16), new(2, "Them", 16)];

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
//This will return first element in the collection. Same goes for Last() - it will return the last element in the collection.
collection.First().Dump();

//If you don't want to output exception in case of no elements, you can use FirstOrDefault
//which outputs the default value of the type specified.

collection.FirstOrDefault().Dump();

//If you want to mention specific default value, you can do so 
collection.FirstOrDefault(Int32.MinValue).Dump();

//Check if the collection has only one element or not
//collection.Single().Dump();

//If collection length is zero and you want to return a specific default. 
//Will throw an InvalidOperationException if sequence contains more than one element.
//collection.SingleOrDefault(-1).Dump();  

//ElementAt, ElementAtOrDefault
//This will return element at the specified index. If the element doesn't exist, then it would throw IndexOutofRange exception.
collection.ElementAt(0).Dump();
// If we don't want to throw an exception, we can use ElementAtOrDefault instead

//DefaultIfEmpty - Add a default element to collection if it is empty.
collection.DefaultIfEmpty().Dump();

//--------------------------------------CONVERSION METHODS--------------------------------------
// Immediate Execution
// ToArray - Converts the collection to an array.
collection.ToArray().Dump();
// ToList - Similarly turns collection to a list.
// ToDictionary - Similarly turns collection to a dictionary.
//collection.ToDictionary(key=> key, value=> "Val").Dump();
// ToHashSet - Convert this to Hashset.
collection.ToHashSet();
// ToLookup - If you want to create a lookup table based on the age of the Person record.
// This will group all records in collection based on the age. 
People.ToLookup(x => x.age).Dump();
// If we want to only display Persons's name whose age is 16, we can do the following
People.ToLookup(x => x.age)[16].Dump();
// If you believe there is going to be only one person that matches this criteria and want to display their name, you can do the following:
People.ToLookup(x => x.age)[15].Single().name.Dump();

//--------------------------------------GENERATION METHODS--------------------------------------

// AsEnumerable, AsQueryable
//These simply cast the collection into IEnumerable or IQueryable
//Range, Repeat, Empty - Immediate Execution

//Range - Get numbers from a specified index to the count. For example if you want numbers from 1 to 100.
Enumerable.Range(1, 100).Dump(); // Creates an enumerable which holds numbers from 1 to 100.

//Repeat - Repeats one value to the count specified
Enumerable.Repeat(0, 100).Dump();

//Empty - Generates an empty enumerable of the type specified.
//This is static, so if you reference it in multiple areas of your code, it won't create new lists.
Enumerable.Empty<int>().Dump();

//--------------------------------------SET OPERATIONS--------------------------------------

// Distinct, DistinctBy
// Distinct - gives us the unique values in the collection.
collection.Distinct().Dump();
// DistinctBy - If you have a collection that has a set of fields and you want to take the distinct by a particular field.
//For the below example, it would output all Persons with distinct ages
People.DistinctBy(i => i.age).Dump();

IEnumerable<int> setOp1 = [1,2,3];
IEnumerable<int> setOp2 = [2,3,4];

//Union - Gets us the combination of the distinct elements in both collections. For the above case it would return 1,2,3,4
setOp1.Union(setOp2).Dump();

//Intersect - Gives us the elements that are common in both collections. It would return 2,3
setOp1.Intersect(setOp2).Dump();

//Except - will only give us the elements in setOp1 that aren't there in setOp2. It would return 1 for the above collections
setOp1.Except(setOp2).Dump();

IEnumerable<Person> setPpl1 = [new(0, "You", 15), new(1, "Me", 16)];
IEnumerable<Person> setPpl2 = [new(2, "You", 15)];

//UnionBy - Gives us the combination of distinct elements in both collections but based on the predicate specified.
//This outputs two persons with id's 0,1 and 2 even though the rest of the fields are not distinct.
setPpl1.UnionBy(setPpl2, x => x.id).Dump();

//IntersectBy -  Gives us the elements that are common in both collections but based on the predicate specified.
//For the above example, it would return 0, "You", 15 since we are matching based on the name.
setPpl1.IntersectBy(setPpl2.Select(x => x.name), p => p.name).Dump();

//ExceptBy - Gives us the elements from setOp1 that aren't there in setOp2 based on the specified condition.
//Outputs 1, "Me", 16 since that is the only age that isn't there in setPpl2.
setPpl1.ExceptBy(setPpl2.Select(i => i.age), p => p.age).Dump();

//SequenceEqual - Returns a boolean true or false if two sequences are equal based on the elements.
// as these two enumerables aren't equal - it returns false.
setPpl1.SequenceEqual(setPpl2).Dump();

//--------------------------------------Joining and Grouping--------------------------------------


record Person(int id, string name, int age);