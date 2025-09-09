//Sum of Digits Until One Digit Remains Keep summing the digits of a number until the result is a single digit.Ex: 5123 -> 5+1+2+3 => 11 => 1+1=> 2


 debugger;
let number =prompt ("enter a number");
while(isNaN(number) == true)
{
   number = prompt("invalid input, please enter a valid number");
}
let x=Number(number);
let sum=0;
let sum1=0;
while(x!=0)
  {
  let digit = x % 10;
       
	  sum = digit + sum;

  	x = Math.floor (x /10);
  }
let y = sum;

while(y!=0)
{
  let digit1 = y % 10;
       
	  sum1 = digit1 + sum1;

  	y = Math.floor (y /10);
  }



  console.log(" sum of digits is " + sum1 );
 



