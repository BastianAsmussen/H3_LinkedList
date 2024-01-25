using System.Diagnostics;

Console.WriteLine("Generating...");
var linkedList = LinkedList.LinkedList<int>.GenerateRandom(10_000);
// Console.WriteLine($"Unsorted: {linkedList}");

Console.WriteLine("Sorting...");
var start = Stopwatch.StartNew();
linkedList.Sort();

// Console.WriteLine($"Sorted: {linkedList}");
Console.WriteLine($"Duration: {start.ElapsedMilliseconds}ms.");
