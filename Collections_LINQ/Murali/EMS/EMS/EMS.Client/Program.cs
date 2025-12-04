// See https://aka.ms/new-console-template for more information
using EMS.Client;
using EMS.Models;


int? sal1 = 1000;
int? sal2 = 2000;
int? sal3 = null;

var lst1 = new List<int?> { sal1, sal2, sal3 };
int max = sal1.Value;
foreach (var sal in lst1)
{
    if (sal > max)
    {
        max = sal.Value;
    }
    Console.WriteLine(sal ?? 0);

    Console.WriteLine(sal.HasValue ? sal.Value : 0);

    if(sal != null)
        Console.WriteLine(sal.Value);
    else
        Console.WriteLine(0);
}

Console.WriteLine(max);

return;


