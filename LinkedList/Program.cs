const int size = 1_000_000;

Console.WriteLine($"Generating LinkedList with {size:N0} elements...");
var start = DateTime.Now;
var linkedList = LinkedList.LinkedList<int>.GenerateRandom(size);

// Console.WriteLine($"Unsorted: {linkedList}");
Console.WriteLine($"Generation took {(DateTime.Now - start).TotalMilliseconds:N0}ms.");

Console.WriteLine($"Sorting LinkedList with {size:N0} elements...");
start = DateTime.Now;
linkedList.Sort();

// Console.WriteLine($"Sorted: {linkedList}");
Console.WriteLine($"Sorting took {(DateTime.Now - start).TotalMilliseconds:N0}ms.");
