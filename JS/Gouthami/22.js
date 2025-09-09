// Find the Smallest Digit in a Number
//Scan the digits and return the smallest one.


debugger;
let n= prompt("enter a number");
while(isNaN(n) == true)
{
   n = prompt("invalid input, please enter a valid number");
}
let x=Number(n);
let smallest = 9;
while(x!=0)
  {
  let digit = x % 10;
  	if (smallest > digit)
	    {
		smallest = digit;
	     }
	else
	    {
		smallest = smallest;
	    }
   x = Math.floor(x/10);
   }
  console.log(" smallest digit of "  +  " is : " + smallest);