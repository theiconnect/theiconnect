//Find the First Digit of a Number Without String Conversion extract the first digit of any number. Ex: 653 => 6


debugger;
let n= prompt("enter a number");
while(isNaN(n) == true)
{
   n = prompt("invalid input, please enter a valid number");
}
let x=Number(n);
let digit;
while(x!=0)
  {
     digit = x % 10;
       x = Math.floor (x/10);
}
console.log(digit);
