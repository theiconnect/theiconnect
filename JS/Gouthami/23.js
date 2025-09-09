//Check If a Number is a “Perfect Square and Even” A number is valid only if it's a perfect square and an even number.

debugger;
let n= prompt("enter a number");
while(isNaN(n) == true)
{
   n = prompt("invalid input, please enter a valid number");
}
let x=Number(n);
if(Math.sqrt(x)*Math.sqrt(x) == x & (x % 2 == 0))
   {
      console.log( x + " is valid as  a perfect square and even ");
}

else
{
   console.log (x + " is  not valid as perfect square and even ");
}
