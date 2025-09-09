 //Count How Many Times Digit 3 Appears (0–N) Given a number N, count how many times the digit 3 appears from 1 to N.

debugger;
let n= prompt("enter a number");
while(isNaN(n) == true)
{
   n = prompt("invalid input, please enter a valid number");
}
let x=Number(n);
let digit,count=0;
for (let i=1; i<=x; i++)
  {
	let y = i
    while( y!= 0)
    {
	digit= y % 10
	
	if ( digit == 3)
	{
         count++
        }

      y = Math.floor(y/10);
}
}


console.log(count)