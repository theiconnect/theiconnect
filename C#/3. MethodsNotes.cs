
What is a method in c#?
=======================================================================================
A method is a block of code that performs a specific task. It is a collection of statements that are executed when the method is called. 
Methods are used to break down a program into smaller, manageable pieces, making it easier to read and maintain. Methods can be called multiple times, 
allowing for code reuse. 
They can also take parameters, which allow for more flexibility in their behavior.
Syntax:
=======================================================================================
<accessModifier> <returnType> methodName(parameterList)
{
    // method body
    // code statements
    return value; // if return type is not void
}

1. Access Modifiers:
=======================================================================================
=> They define the visibility and accessibility of the method.
=> Public: The method is accessible from anywhere.
=> Private: The method is only accessible within the class it is defined.
=> Protected: The method is accessible within the class and its derived classes.
=> Internal: The method is accessible within the same assembly (project).

public void Method1() { }    // Accessible everywhere
private void Method2() { }   // Only within same class
protected void Method3() { } // Within same class and any derived classes
internal void Method4() { }  // Within same assembly
protected interanl void Method5() { } // Within same assembly and any derived classes of same or other assemblies

2. Return Type:
=======================================================================================
=> The type of value that the method returns.
=> If the method doesn't return anything, use void.
=> You can also use other types like int, string, bool, etc.
=> Whenever if we use a return type other than void means your method should return a value of "returntype" type

public void DisplayMessage() { }        // Returns nothing (void)
public int GetAge() { return 25; }      // Returns integer
public string GetName() { return "John"; } // Returns string
public bool IsValid() { return true; }   // Returns boolean


3. Method Name:
=======================================================================================
=> It should follow the naming conventions
=> Use PascalCase for method names (e.g., GetAge, DisplayMessage)
=> It should be descriptive of what the method does.

4. Parameters:
=======================================================================================
=> They are used to pass data to the method.
=> They can be optional or required.
=> You can have multiple parameters separated by commas.

// No parameters
public void ShowMenu() { }

// Single parameter
    public void PrintName(string name) { }
    for Calling ==> PrintName("name");
// Multiple parameters
    public void SetCoordinates(int x, int y) { }
    for Calling ==> SetCoordinates(1,2);

// Optional parameters
    public void Configure(string name, int age = 18) { }

    Calling Use case 1=> SetCoordinates("name",32);
    // in case 2 : as we didn't pass 2nd parameter(int) method will take 18 as 2nd parameter.
    Calling Use case 2=> SetCoordinates("name");

// Reference parameters
    public void Swap(ref int a, ref int b) { }

// Output parameters
    public void GetValues(out int x, out int y) { }

public class Calculator
{
    // Basic method
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Method with optional parameter
    public double Calculate(double amount, double rate = 0.1)
    {
        return amount * rate;
    }

    // Method with out parameter
    //without using return type also we can able to get quotient and remainder by using out parameters.
    public void DivideWithRemainder(int dividend, int divisor, out int quotient, out int remainder) 
    {
        quotient = dividend / divisor;
        remainder = dividend % divisor;
    }

    // Method with reference parameter
    public void SwapNumbers(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }
}

// Using these methods
class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();

        // Using basic method
        int sum = calc.Add(5, 3);  // returns 8

        // Using optional parameter
        double result1 = calc.Calculate(100);     // uses default rate 0.1
        double result2 = calc.Calculate(100, 0.2); // uses specified rate

        // Using out parameters
        int quotient, remainder;
        calc.DivideWithRemainder(10, 3, out quotient, out remainder);
        // quotient = 3, remainder = 1

        // Using ref parameters
        int a = 5, b = 10;
        calc.SwapNumbers(ref a, ref b);
        // Now a = 10, b = 5
    }
}


4.1: ref and out parameters
====================================
// ref requires variable to be initialized before use
int number = 10;
MethodWithRef(ref number); // Valid

int unassignedNumber;
MethodWithRef(ref unassignedNumber); // Invalid! Must be initialized first

// out doesn't require initialization
int result;
MethodWithOut(out result);  // Valid - no initialization needed

Ref Example:
===================
public void MethodWithRef(ref int x)
{
    // With ref:
    // - Can read existing value
    // - May or may not modify the value
    Console.WriteLine(x);  // Valid - can read value
    x = 100;              // Optional - may modify
}
public class Calculator
{
    // ref is good for swap operations
    public void Swap(ref int a, ref int b)
    {
        int temp = a;  // Can read initial values
        a = b;
        b = temp;
    }
}

// Usage
int x = 5, y = 10;
Calculator calc = new Calculator();
calc.Swap(ref x, ref y);
Console.WriteLine($"x: {x}, y: {y}");  // x: 10, y: 5


out Example:
===================
public void MethodWithOut(out int x)
{
    // With out:
    // - Must assign value before method ends
    // - Cannot read value before assigning
    Console.WriteLine(x);  // Invalid! Cannot read before assigning
    x = 100;              // Must assign value
}

public class Calculator
{
    // out is good for returning multiple values
    public void DivideWithRemainder(int dividend, int divisor, out int quotient, out int remainder) 
    {
        quotient = dividend / divisor;    // Must assign value
        remainder = dividend % divisor;    // Must assign value
    }
}

// Usage
Calculator calc = new Calculator();
int quotient, remainder;  // No need to initialize
calc.DivideWithRemainder(10, 3, out quotient, out remainder);
Console.WriteLine($"Quotient: {quotient}, Remainder: {remainder}");
// Output: Quotient: 3, Remainder: 1

Best Practices to use ref and out:
============================================
=> Use out when you need to return multiple values from a method
=> Use ref when you need to modify an existing value
=> if you want to return single value no need to use out/ref.

5. Method Body:
=======================================================================================
=> It contains the code that defines what the method does.
=> It can have local variables, statements, and return statements.
=> The return statement is used to specify the value that the method returns.
=> If the method is void, you can avoid the return statement.

public void MakeSandwich()
{
    // Steps to make a sandwich
    GetBread();
    AddLettuce();
    AddTomatoes();
    AddCheese();
}

=> They have one specific task
=> You can use them again and again
=> You can give them different things to work with (parameters)
// A simple method without parameters
public void SayHello()
{
    Console.WriteLine("Hello!");
}

// A method with parameters
public void SayHelloTo(string name)
{
    Console.WriteLine($"Hello, {name}!");
}

// A method that returns something
public int AddNumbers(int a, int b)
{
    return a + b;
}

// Using these methods
void Main()
{
    SayHello();              // Prints: Hello!
    SayHelloTo("John");      // Prints: Hello, John!
    int sum = AddNumbers(5, 3);  // sum will be 8
}

=> Methods are a way to organize code it makes our logic cleaner and easier.
=> You can reuse same method multiple times.
=> method can take input parameter(s).
=> method can return value.

Class members can be of 2 types those are static and non-static.



Example 1 - Static vs Non-Static Fields:
=======================================================================================
public class Student
{
    // Static field - shared across all instances
    public static int TotalStudents = 0;
    
    // Non-static fields - unique to each instance
    public string Name;
    public int Age;

    public Student(string name, int age)
    {
        Name = name;        Age = age;
        TotalStudents++; // Increment the static counter
    }
}

class Program
{
    static void Main()
    {
        Student student1 = new Student("Alice", 20);
        Student student2 = new Student("Bob", 22);

        // Accessing non-static fields (requires instance)
        Console.WriteLine($"Student 1: {student1.Name}, {student1.Age}");
        Console.WriteLine($"Student 2: {student2.Name}, {student2.Age}");

        // Accessing static field (using class name)
        Console.WriteLine($"Total Students: {Student.TotalStudents}");
    }
}

Example 2 - Static vs Non-Static Methods:
=======================================================================================
// Static method - can be called without instance
public class Calculator
{
    // Static method - can be called without instance
    public static int Add(int a, int b)
    {
        return a + b;
    }

    // Non-static method - requires instance
    public int Multiply(int a, int b)
    {
        return a * b;
    }
}

class Program
{
    static void Main()
    {
        // Using static method (no instance needed)
        int sum = Calculator.Add(5, 3);
        Console.WriteLine($"Sum: {sum}");

        // Using non-static method (instance required)
        Calculator calc = new Calculator();
        int product = calc.Multiply(5, 3);
        Console.WriteLine($"Product: {product}");
    }
}

Example 3 - Static Class vs Non-Static Class:
=========================================================

// Static class - can only contain static members
public static class MathUtility
{
    public static double PI = 3.14159;
    
    public static double CalculateCircleArea(double radius)
    {
        return PI * radius * radius;
    }
}

// Non-static class - can contain both static and non-static members
public class Circle
{
    // Non-static field
    private double radius;

    // Static field
    public static int CircleCount = 0;

    public Circle(double r)
    {
        radius = r;
        CircleCount++;
    }

    // Non-static method
    public double GetArea()
    {
        return MathUtility.PI * radius * radius;
    }
}

class Program
{
    static void Main()
    {
        // Using static class
        double area1 = MathUtility.CalculateCircleArea(5);
        Console.WriteLine($"Area using static class: {area1}");

        // Using non-static class
        Circle circle1 = new Circle(5);
        Circle circle2 = new Circle(3);
        
        Console.WriteLine($"Area of circle1: {circle1.GetArea()}");
        Console.WriteLine($"Total circles created: {Circle.CircleCount}"); // Output: 2
    }
}

Key differences between static and non-static members:

Static members:
================
=> Also called as class members. Common to all Non-Static/Instance/Object members.
=> Only one copy of the static member is created and shared among all instances of the class.
=> Accessed using the class name
=> Memory allocated once when class is loaded
=> Cannot access non-static members directly. if you want to use non-static members, you need to create an instance of the class.
=> 

Non-static members:
========================
=> All the non-static/Instance members are unique to each instance of the class.
=> Each object/instance has its own copy
=> Accessed using object/instance references
=> Memory allocated when object/instance is created
=> Can access both static and non-static members
=> If you create 100 objects for the class. 100 copies of non-static members are created and static members will be same for all of them.

extension methods:
=====================================

Extension methods are a special kind of static methods that can be called as if they were instance methods on the extended type. 
They are defined in a static class and the first parameter of the method specifies the type that the method operates on, preceded by the this keyword.

Here's a simple example of an extension method:

static class StringExtensions
{
    //You can use this method to reverse a string  wherever needed in the application.
    public static string ReverseStringToString(this string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

In this example, the Reverse method is an extension method for the string type. 
It reverses the string by converting it to a character array, reversing the array, 
and then converting it back to a string.

To use the extension method, you simply call it on an instance of the string type:

string original = "Hello, World!";
string reversed = original.ReverseStringToString(); 
Console.WriteLine(reversed); // Outputs "!dlroW ,olleH"

In this way, extension methods provide a way to add functionality to existing types without modifying their source code. They are a powerful feature of C# that allows for a more expressive and flexible programming paradigm.

    
