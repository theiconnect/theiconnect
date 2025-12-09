using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqpractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            //        List<string> names = new List<string> { "Ravi", "Teja", "Ram", "Rajesh" };

            //        Console.WriteLine("=== Filtering (Where) ===");
            //        var evenNumbers = numbers.Where(n => n % 2 == 0);
            //        Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));

            //        Console.WriteLine("\n=== Filtering (OfType) ===");
            //        List<object> data = new List<object>() { 1, "hello", 2, "world" };
            //        var strings = data.OfType<string>();
            //        Console.WriteLine("Strings Only: " + string.Join(", ", strings));

            //        Console.WriteLine("\n=== Projection (Select) ===");
            //        var squares = numbers.Select(n => n * n);
            //        Console.WriteLine("Squares: " + string.Join(", ", squares));

            //        Console.WriteLine("\n=== Projection (SelectMany) ===");
            //        List<List<int>> nested = new List<List<int>>
            //        {
            //            new List<int>{1, 2},
            //            new List<int>{3, 4}
            //        };
            //        var flat = nested.SelectMany(n => n);
            //        Console.WriteLine("Flattened List: " + string.Join(", ", flat));

            //        Console.WriteLine("\n=== Partitioning (Skip, Take) ===");
            //        Console.WriteLine("Skip 2: " + string.Join(", ", numbers.Skip(2)));
            //        Console.WriteLine("Take 3: " + string.Join(", ", numbers.Take(3)));

            //        Console.WriteLine("\n=== ordering (orderby, thenby, reverse) ===");
            //        Console.WriteLine("orderby: " + string.Join(", ", names.OrderBy(n => n)));
            //        Console.WriteLine("thenby: " + string.Join(", ", names.OrderBy(n => n.Length).ThenBy(n => n)));
            //        Console.WriteLine("reverse: " + string.Join(", ", numbers.AsEnumerable().Reverse()));

            //        Console.WriteLine("\n=== Grouping (GroupBy) ===");
            //        var groupByLength = names.GroupBy(n => n.Length);
            //        foreach (var group in groupByLength)
            //        {
            //            Console.WriteLine("Length " + group.Key + ": " + string.Join(", ", group));
            //        }

            //        Console.WriteLine("\n=== ToLookup ===");
            //        var lookup = names.ToLookup(n => n.Length);
            //        Console.WriteLine("Names with length 4: " + string.Join(", ", lookup[4]));

            //        Console.WriteLine("\n=== Set Operations (Distinct) ===");
            //        var nums = new List<int> { 1, 2, 2, 3 };
            //        Console.WriteLine("Distinct: " + string.Join(", ", nums.Distinct()));

            //        Console.WriteLine("\n=== conversions ===");
            //        int[] arr = numbers.ToArray();
            //        Console.WriteLine("toarray: " + string.Join(", ", arr));

            //        var dict = names.ToDictionary(n => n, n => n.Length);
            //        Console.WriteLine("ToDictionary:");
            //        foreach (var item in dict)
            //        {
            //            Console.WriteLine($"{item.Key} = {item.Value}");
            //        }

            //        Console.WriteLine("\n=== Element Operators ===");
            //        Console.WriteLine("First: " + numbers.First());
            //        Console.WriteLine("Last: " + numbers.Last());
            //        Console.WriteLine("Single (3): " + numbers.Single(n => n == 3));
            //        Console.WriteLine("ElementAt(2): " + numbers.ElementAt(2));

            //        Console.WriteLine("\nProgram Completed!");


            //        List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };
            //        List<int> emptyList = new List<int>();

            //        Console.WriteLine("=== First ===");
            //        Console.WriteLine("First: " + numbers.First());
            //        // Console.WriteLine(emptyList.First()); // throws exception

            //        Console.WriteLine("\n=== FirstOrDefault ===");
            //        Console.WriteLine("FirstOrDefault (numbers): " + numbers.FirstOrDefault());
            //        Console.WriteLine("FirstOrDefault (empty): " + emptyList.FirstOrDefault());

            //        Console.WriteLine("\n=== Last ===");
            //        Console.WriteLine("Last: " + numbers.Last());


            //        Console.WriteLine("\n=== LastOrDefault ===");
            //        Console.WriteLine("LastOrDefault (numbers): " + numbers.LastOrDefault());
            //        Console.WriteLine("LastOrDefault (empty): " + emptyList.LastOrDefault());

            //        Console.WriteLine("\n=== Single ===");
            //        Console.WriteLine("Single (value 30): " + numbers.Single(n => n == 30));


            //        Console.WriteLine("\n=== SingleOrDefault ===");
            //        Console.WriteLine("SingleOrDefault (value 30): " + numbers.SingleOrDefault(n => n == 30));
            //        Console.WriteLine("SingleOrDefault (not found): " + numbers.SingleOrDefault(n => n == 100));


            //        Console.WriteLine("\n=== ElementAt ===");
            //        Console.WriteLine("ElementAt(2): " + numbers.ElementAt(2));


            //        Console.WriteLine("\nProgram Finished!");
            //    }
            //    Console.WriteLine("=== Range ===");
            //                var rangeNumbers = Enumerable.Range(1, 5);
            //    Console.WriteLine("Range: " + string.Join(", ", rangeNumbers));

            //                Console.WriteLine("\n=== Repeat ===");
            //                var repeatValues = Enumerable.Repeat("Hello", 3);
            //    Console.WriteLine("Repeat: " + string.Join(", ", repeatValues));

            //                Console.WriteLine("\n=== Empty ===");
            //                var emptyList = Enumerable.Empty<int>();
            //    Console.WriteLine("Empty Count: " + emptyList.Count());

            //                Console.WriteLine("\nProgram Finished!");
            //        }
            //    List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            //    Console.WriteLine("=== Take ===");
            //    var take3 = numbers.Take(3);
            //Console.WriteLine("Take(3): " + string.Join(", ", take3));

            //    Console.WriteLine("\n=== Skip ===");
            //    var skip3 = numbers.Skip(3);
            //Console.WriteLine("Skip(3): " + string.Join(", ", skip3));

            //    Console.WriteLine("\n=== TakeWhile ===");
            //    var takeWhileLessThan5 = numbers.TakeWhile(n => n < 5);
            //Console.WriteLine("TakeWhile(n < 5): " + string.Join(", ", takeWhileLessThan5));

            //    Console.WriteLine("\n=== SkipWhile ===");
            //    var skipWhileLessThan5 = numbers.SkipWhile(n => n < 5);
            //Console.WriteLine("SkipWhile(n < 5): " + string.Join(", ", skipWhileLessThan5));

            //    Console.WriteLine("\nProgram Completed!");
            //}

            //List<object> data = new List<object> { 1, "hello", 2, "world", 3 };
            //List<string> names = new List<string> { "Ravi", "Teja", "Ram" };


            //Console.WriteLine("=== ToArray ===");
            //var nameArray = names.ToArray();
            //Console.WriteLine("ToArray: " + string.Join(", ", nameArray));

            //Console.WriteLine("\n=== ToList ===");
            //var nameList = nameArray.ToList();
            //Console.WriteLine("ToList: " + string.Join(", ", nameList));

            //Console.WriteLine("\n=== ToDictionary ===");
            //var dict = names.ToDictionary(n => n, n => n.Length);
            //foreach (var item in dict)
            //{
            //    Console.WriteLine($"{item.Key}: {item.Value}");
            //}

            //Console.WriteLine("\n=== oftype ===");
            //var onlystrings = data.OfType<string>();
            //Console.WriteLine("oftype<string>: " + string.Join(", ", onlystrings));

            //Console.WriteLine("\n=== Cast ===");
            //List<object> numObjects = new List<object> { 10, 20, 30 };
            //var castNumbers = numObjects.Cast<int>();
            //Console.WriteLine("Cast<int>: " + string.Join(", ", castNumbers));


            //Console.WriteLine("\nProgram Completed!");
            var students = new List<Student>
   }
    }
}


