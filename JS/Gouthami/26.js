//Find Sum of All Prime Digits in a Number


debugger;
let number =prompt ("enter a number");
while(isNaN(number) == true)
{
   number = prompt("invalid input, please enter a valid number");
}
let x=Number(number);
let count = 0;
let sum =0;
let digit ;
let temp = x;
while(x!=0)
  {
   digit = x % 10;
    count = 0;
     for ( i=1; i<=digit; i++)
	{
		
	   if(digit % i == 0)
		{
		    count ++;
          	}
	}
	    if ( count == 2)
		{
		     sum = digit + sum ;
		}

      x = Math.floor(x/10);
}

console.log("sum of all prime digits in a " + temp + " = " + sum);