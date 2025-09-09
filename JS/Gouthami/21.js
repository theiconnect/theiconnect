// find the Difference Between Product and Sum of Digits
//Input a number and return the result of (product of digits) - (sum of digits).
 //Sum of All Even Digits in a Number
 //Only add even digits from the number.
 // Find the Smallest Digit in a Number
//Scan the digits and return the smallest one.




 debugger;
let number =prompt ("enter a number");
while(isNaN(number) == true)
{
   number = prompt("invalid input, please enter a valid number");
}
let x=Number(number);
let sum=0;
let product=1;
while(x!=0)
  {
  let digit = x % 10;
       
	  sum = digit + sum;
	product = digit * product;

  	x = Math.floor (x /10);
  }

console.log("(product of digits - sum of digits)" + (product - sum ));
