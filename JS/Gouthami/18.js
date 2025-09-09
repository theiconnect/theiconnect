
//Sum of All Even Digits in a Number
 //Only add even digits from the number.
 
debugger;
let number =prompt ("enter a number");
while(isNaN(number) == true)
{
   number = prompt("invalid input, please enter a valid number");
}
let x=Number(number);
let evensum=0;
while(x!=0)
  {
  let digit = x % 10;
       if(digit % 2 == 0)
 	{
	  evensum = digit + evensum;
           }
     x = Math.floor (x /10);
  }
  console.log(" sum of even is " + evensum );




