  Types:
====================
Understanding value types and reference types, as well as stack and heap memory, is fundamental to working effectively with C#

Value Types:
===========
=> Examples: int, float, double, bool, char, struct, enum(Categories/List Ex: Status=> InProgress, Pending, Completed, Errored)
=> Stored directly on the stack
=> Each variable has its own copy of the data
=> When you assign a value type to another variable, it creates a copy

Reference Types:
=====================
=> Examples: class, interface, delegate, string,array, object
=> Stored on the heap memory.
=> Variables hold a reference (memory address) to the data, not the data itself
=> When you assign a reference type to another variable, both variables refer to the same object because it stores reference address of the actual value.

Stack and Heap Memory:
####################################

Stack:
==================
=> A region of memory that operates in a Last-In-First-Out (LIFO) manner
=> Used for static memory allocation
=> Stores local variables and method parameters
=> Memory allocation and deallocation are automatically handled
=> Faster access compared to heap
=> Limited in size (typically around 1 MB).

Heap:
=======================
=> A region of memory used for dynamic memory allocation
=> Managed by the garbage collector in .NET
=> Stores objects (instances of classes)
=> More flexible in size but slower access compared to stack
=> Memory allocation and deallocation are managed by the garbage collector

Difference (Stack vs. Heap)
=================================
Memory Allocation:
    Value types(VT): Memory is allocated on the stack
    Reference types(RT): The reference is stored on the stack, but the object itself is on the heap
Lifetime:
    VT : Lifetime is deterministic, tied to the scope they're declared in
    RT : Lifetime is managed by the garbage collector
Assignment Behavior:
    VT : Assigning creates a copy of the value
    RT : Assigning copies the reference, not the object itself
Performance:
    VT : Generally faster as they're accessed directly from the stack
    RT : Slightly slower due to the extra step of dereferencing
Nullability:
    VT : Cannot be null by default (though C# 8.0 introduced nullable value types)=> By using Nullable class Microsoft implemented Nullable versions of value types.
    RT : Can be null

Type Casting/Type Conversions/Type Parsing
=============================================

Implicit conversion:
====================
Implicit conversion, also known as widening conversion, occurs automatically when you're converting from a smaller type to a larger type, where no data loss will occur. 
The compiler performs these conversions without requiring explicit syntax.

Allowed Conversions
===============================
byte byteValue = 255;
short shortValue = byteValue;  // Implicit conversion from byte to short
int intValue = shortValue;     // Implicit conversion from short to int
long longValue = intValue;     // Implicit conversion from int to long
float floatValue = 10.5f;
double doubleValue = floatValue;  // Implicit conversion from float to double
int intValue = 100;
float floatValue = intValue;   // Implicit conversion from int to float
double doubleValue = intValue; // Implicit conversion from int to double
char charValue = 'A';
//char is essentially a 16-bit unsigned integer.
int intValue = charValue;  // Implicit conversion from char to int
//Enums are not internally represented as integers.
enum Days { Sunday, Monday, Tuesday }
int dayValue = (int)Days.Monday;  // explicit conversion from enum to int is required


Not Allowed Conversions
================================
double doubleValue = 10.5;
int intValue = doubleValue;  // lead to data loss (fractional part) - Error: Cannot implicitly convert double to int
long longValue = 1000;
int intValue = longValue;  // Error: Cannot implicitly convert long to int
uint uintValue = 42;
//uint can hold some values that int cannot (large positive numbers).
int intValue = uintValue;  // Error: Cannot implicitly convert uint to int
bool boolValue = true;
float floatValue = 3.14f;
double doubleValue = 3.14;
decimal decimalValue1 = floatValue; // Error: Cannot implicitly convert float to decimal
decimal decimalValue2 = doubleValue; // Error: Cannot implicitly convert double to decimal
//Note:Surprisingly, there is no implicit conversion from float or double to decimal, even though decimal has a larger range. This is because decimal uses a different internal representation (base-10) compared to float and double (base-2), which can lead to precision issues.
//unrelated types.
int intValue = boolValue;  // Error: Cannot implicitly convert bool to int
object obj = new object();
//Note: for every class in .net parent is object
//Even though string inherits from object, there's no guarantee that an object is actually a string.
string str = obj;  // Error: Cannot implicitly convert object to string

Summary:
================
Implicit conversions are designed to be safe and lossless. They're typically used when 
converting from a smaller range to a larger range, or when all values of the source type can be represented
in the target type. When these conditions are not met, you'll need to use explicit conversion (casting) or 
other conversion methods, being aware of potential data loss or runtime errors.


Explicit Conversions
============================
Explicit conversion, also known as explicit casting, is a way to manually convert a value 
from one data type to another when the conversion is not implicitly allowed by the compiler. 
This is typically necessary when there's a risk of data loss or when the conversion isn't considered safe by default. 
=> Converting from a larger data type to a smaller one
=> Converting between types where data loss might occur
=> Converting between types that are not implicitly convertible

Risks:
=> When converting from a larger type to a smaller type, you may lose precision or even completely change the value.
=> If the conversion is not valid, it can throw an InvalidCastException.

When to use:
=> When you're certain about the underlying type and the conversion is safe
=> When you're willing to accept potential data loss
=> When you're prepared to handle potential exceptions
========================================================================================


Possible UseCases:

1. Converting one value type to another value type: 
=====================================================
a) Implicit conversion:
   
int intValue = 10;
long longValue = intValue; // Implicit conversion from int to long

b) Explicit conversion:

double doubleValue = 10.5;
int intValue = (int)doubleValue; // Explicit conversion from double to int

c) using Convert class:
float floatValue = 10.5f;
decimal decimalValue = Convert.ToDecimal(floatValue);

d) Parse method:
string stringValue = "100";
int parsedInt = int.Parse(stringValue);

e) TryParse method:

string stringValue = "100";
int result;
if (int.TryParse(stringValue, out result))
{
    Console.WriteLine($"Parsed value: {result}");
}


2. Converting one reference type to another reference type:
==============================================================

a) Implicit conversion (for inheritance):
class Animal { }
class Dog : Animal { }

Dog dog = new Dog();
Animal animal = dog; // Implicit conversion from derived class to base class

b) Explicit conversion (casting):

object obj = "Hello";
string str = (string)obj; // Explicit conversion from object to string

c) as operator:

object obj = "Hello";
string str = obj as string; // Returns null if conversion is not possible

d) is operator with pattern matching:

object obj = "Hello";
if (obj is string str)
{
    Console.WriteLine($"Length: {str.Length}");
}

3. Converting value type to reference type:
===================================================
//Note:**Interview Question: What is Boxing and Unboxing in C#?
a) Boxing (implicit):
int intValue = 10;
object boxedInt = intValue; // Boxing: value type to reference type

b) Nullable types:
int? nullableInt = 10; // Implicitly converts int to Nullable<int>

4. Converting reference type to value type:
===================================================
a) Unboxing (explicit):

object boxedInt = 10;
int unboxedInt = (int)boxedInt; // Unboxing: reference type to value type

b) Nullable types:

int? nullableInt = 10;
int regularInt = nullableInt.Value; // Converts Nullable<int> to int

Conversion ways:
=====================

1. Convert Class:
==================
=>Converting between value types
=>Converting from string to value types
=>Handling null values (Convert methods return default values for null inputs)

string strNumber = "123";
int number = Convert.ToInt32(strNumber);

// Handles null
string nullString = null;
int defaultValue = Convert.ToInt32(nullString); // Returns 0

2.Explicit Casting (datatype):
==================================
=> Converting between compatible types where data loss is acceptable
=> Performance is critical (it's generally the fastest method)

double doubleValue = 10.5;
int intValue = (int)doubleValue; // Truncates to 10
Note:
=> Avoid when there's a risk of unhandled exceptions (throws InvalidCastException if conversion is not possible)
=> Doesn't work for string to value type.

3.Parse Method:
================
=> Converting from string to value types

string strNumber = "123";
int number = int.Parse(strNumber);

=> Avoid when Input might be null (throws ArgumentNullException)

4.TryParse Method:
====================
=> Converting from string to value types
=> it avoids exceptions
=> for invalid input returns false
=> This is the recommended method for parsing strings

string strNumber = "123";
int number;//here converted value will stored in number variable 
if (int.TryParse(strNumber, out number))
{
    Console.WriteLine($"Parsed value: {number}");
}else{
    Console.WriteLine("Invalid string");
}

5. as operator
===========
=> converting between reference types
=>returns null for failed conversions

Points to be Remember:
=========================
Exception Handling:
    => Explicit casting and Parse can throw exceptions
    => Convert handles nulls by returning default values
    => as returns null for failed conversions
    => TryParse uses a boolean return value to indicate success

Type Support:
    => Explicit casting works between compatible types
    => Convert and Parse work well with strings and value types
    => as only works with reference types
    => TryParse is specific to value types
Performance:
    => Explicit casting is generally fastest
    => Convert and Parse methods are slightly slower
    => TryParse can be slower but is safer
Null Handling:
    => Convert handles nulls by returning default values
    => as returns null for failed conversions
    => Parse and explicit casting throw exceptions for null inputs
    => TryParse safely handles null inputs

