1. In the below program identify which conversions are correct and which are not.
class TypeCastingExamples
{
    static void Main()
    {
        byte byteValue = 100;
        int intValue = byteValue;
        Console.WriteLine($"Implicit conversion from byte to int: {intValue}");
        no convert the byte Value = intValue;   
        double value = 99.99;
        int truncatedValue = value;
        //99
        double doubleValue = 10.8;
        int truncatedValue = (int)doubleValue;
        Console.WriteLine($"Explicit conversion from double to int (truncated): {truncatedValue}");
        //truncatedValue=10

        string strNumber = "250";
        int convertedValue = Convert.ToInt32(strNumber); /*converted Value the string value*/
        Console.WriteLine($"Using Convert class to convert string to int: {convertedValue}");
        
        string strToParse = "300";
        int parsedInt = int.Parse(strToParse); 
        Console.WriteLine($"Using Parse method to convert string to int: {parsedInt}");
        //300,converted the string value
        string invalidString = "Hello";
        int result;
        bool isParsed = int.TryParse(invalidString, out result); 
        Console.WriteLine($"TryParse with invalid input (expected false): {isParsed}, Result: {result}");

        string nullStr = null;
        int intValue = Convert.ToInt32(nullStr); /*convert the string null*/
        int intValue2 = int.Parse(nullStr);/*not convert string null 
*/

        string nonNumericStr = "abc123";
        int parsedValue = int.Parse(nonNumericStr);  /*not convert string value*/

        int num = 100;
        object boxedNum = num; // Boxing: int to object (reference type)
        int unboxedNum = (int)boxedNum; // Unboxing: object back to int
        Console.WriteLine($"Boxing and Unboxing an int: {unboxedNum}");
        //100, the boxing value converted unboxing
        object obj = "Hello World!";
        int incompatibleCast = (int)obj;  

        int? nullableInt = 500; // Nullable int using '?'
        int regularInt = nullableInt ?? 0; // If nullableInt has a value, use it; otherwise, use 0
        Console.WriteLine($"Nullable to int with null-coalescing: {regularInt}");
        //500,
        object obj = "Hello World";
        string str = obj as string;
        Console.WriteLine($"Using 'as' for type conversion: {str}");
        // Returns null if conversion is not possible

        object obj = 10;
        string invalidAsCast = obj as string;  
        Console.WriteLine(invalidAsCast.Length);
        // Returns null if conversion is not possible

        object patternObj = 123;
        if (patternObj is int patternInt) 
        {
            Console.WriteLine($"Pattern matching with 'is' keyword: {patternInt}");
        }
        // Returns null if conversion is not possible

        bool boolVal = true;
        int invalidConversion = (int)boolVal;  

        int? nullableNum = 42;
        if (nullableNum.HasValue) // Check if nullable has a value
        {
            int regularNum = nullableNum.Value; 
            Console.WriteLine($"Nullable<int> to int: {regularNum}");
        }
        //42 Converts Nullable<int> to int
        string validString = "42";
        int result;
        bool success = int.TryParse(validString, result);  

        int? nullableValue = null;
        int nonNullableValue = nullableValue;  

        object boxedValue = "100";//Boxing
        int unboxedInt = (int)boxedValue; //Un-Boxing 
        //refrence type
        object boxedValue = int.Parse("100");//Boxing
        int unboxedInt = (int)boxedValue;//Un-Boxing
    }
}


2. Banking System Simulation with Type Conversions and Casting

using System;

namespace TypeConversionComplexExample1
{
    class Program
    {
        static void Main()
        {
            // Part 1: Account Balance and Conversion
            double accountBalance = 1520.75;
            int roundedBalance = (int)accountBalance;  // Explicit cast
            Console.WriteLine($"Rounded Account Balance: {roundedBalance}");
            //1520.75 // Explicit conversion from double to int
            // Part 2: Deposit
            string depositStr = "200";
            int depositAmount = int.Parse(depositStr);  // Parsing string to int
            double newBalance = accountBalance + depositAmount;
            Console.WriteLine($"New Balance after Deposit: {newBalance}");
            // 1720.75 Explicit conversion from double to int
            // Part 3: Withdrawal
            object withdrawalObj = "150";
            int withdrawalAmount;
            if (int.TryParse((string)withdrawalObj, out withdrawalAmount))
            {
                if (newBalance >= withdrawalAmount)
                {
                    newBalance -= withdrawalAmount;
                    Console.WriteLine($"Balance after Withdrawal: {newBalance}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds for withdrawal.");
                }
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount.");
            }
            //1570.75 Explicit conversion from double to int

            // Part 4: Calculate Annual Interest with Nullable
            double interestRate = 0.03;
            double? interest = null;
            if (newBalance > 1000)
            {
                interest = newBalance * interestRate;
                Console.WriteLine($"Calculated Interest: {interest.Value}");
            }
            else
            {
                Console.WriteLine("Balance too low for interest calculation.");
            }
            // 47.1225 Explicit conversion from double to int 

            // Part 5: Simulate Monthly Transactions in a Loop
            Console.WriteLine("Simulating Monthly Transactions:");
            for (int i = 1; i <= 12; i++)
            {
                double transaction = i % 2 == 0 ? 100.50 : -50.25;  // Alternating deposit/withdrawal
                newBalance += transaction;
                Console.WriteLine($"Month {i}: Balance = {newBalance:F2}");
            }

            // Part 6: Error-prone casting attempt
            //Note: try catch blocks are used when an runtime exception occures instead of raising the error 
            //the execution will move to the catch block from the line where exception raised.
            //we can discuss in more detail in Exception Handling topic.
            object accountId = 12345;
            try
            {
                string invalidCast = (string)accountId;  // Intentional error: invalid cast
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Error: Attempted invalid cast from int to string.");
            }

            // Final balance and message
            Console.WriteLine($"Final Account Balance after Transactions: {newBalance:F2}");
            Console.WriteLine(newBalance >= 0 ? "Account is in good standing." : "Account is overdrawn.");
        }
    }
}

3. E-Commerce Inventory System with Type Conversions and Parsing
using System;

namespace TypeConversionComplexExample2
{
    class Program
    {
        static void Main()
        {
            // Part 1: Product Information
            string productId = "1001";
            int parsedProductId;
            if (int.TryParse(productId, out parsedProductId))//1001
            {
                Console.WriteLine($"Parsed Product ID: {parsedProductId}");//1001
            }
            else
            {
                Console.WriteLine("Invalid Product ID.");
            }
            //1001

            // Part 2: Inventory and Sales Conversion
            object nullableBoxed = (object)revenue;  // Boxing nullable double
            try
            {
                int invalidUnbox = (int)nullableBoxed;  // Error: Unboxing double as int
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Error: Invalid unboxing from double to int.");
            }

            // Final Inventory Status
            Console.WriteLine(stockCount > 0 ? "Inventory available." : "Out of stock."); object stockCountObj = 500;
            int stockCount = (int)stockCountObj;  // Unboxing from object
            double pricePerItem = 19.99;
            decimal totalInventoryValue = (decimal)(pricePerItem * stockCount);  // Explicit cast
            Console.WriteLine($"Total Inventory Value: {totalInventoryValue:C}");

            // Part 3: Sales and Nullable Handling
            int? soldItems = null;
                 soldItems = 50;
            double? revenue = soldItems * pricePerItem;  // Nullable type calculation
            Console.WriteLine($"Revenue from Sold Items: {revenue:C}");

            // Part 4: Discount Calculation with Casting
            string discountStr = "10";  // 10% discount
            int discountPercent;
            if (int.TryParse(discountStr, out discountPercent))
            {
                double discountAmount = pricePerItem * discountPercent / 100;
                Console.WriteLine($"Discount Amount per Item: {discountAmount:C}");
            }
            else
            {
                Console.WriteLine("Invalid discount value.");
            }

            // Part 5: Profit Calculation and Loop
            Console.WriteLine("Calculating Monthly Profits:");
            double monthlyProfit = 0;
            for (int month = 1; month <= 6; month++)
            {
                int sales = month % 2 == 0 ? 100 : 80;  // Alternating sales count
                double monthlyRevenue = sales * (pricePerItem - (double)discountPercent / 100);
                monthlyProfit += monthlyRevenue;
                Console.WriteLine($"Month {month}: Profit = {monthlyProfit:C}");
            } 

            // Part 6: Error-prone Nullable Unboxing
            object nullableBoxed = (object)revenue;  // Boxing nullable double
            try
            {
                int invalidUnbox = (int)nullableBoxed;  // Error: Unboxing double as int
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Error: Invalid unboxing from double to int.");
            }

            // Final Inventory Status
            Console.WriteLine(stockCount > 0 ? "Inventory available." : "Out of stock.");
        }
    }
}

