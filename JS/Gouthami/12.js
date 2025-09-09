debugger;
let x=prompt("enter a value");
while (isNaN(x) == true)
{
      x=prompt("invalid input , please enter a valid input");
}
let n = Number(x);
 let isprime = true
   for( let i=2;i<(n-1);i++)
     {
        if (n%i==0)
	{
            isprime = false

     	}
      } 	
	if(isprime==true)
	{
        	console.log(n + " is a  prime number");
         }
	else
	{
		console.log(n + " is not a prime number");
}
   