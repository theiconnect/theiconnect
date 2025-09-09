debugger;
let num=prompt("enter a number");
while(isNaN(num)==true)
{
	console.log("Invalid input , enter a valid input");
}
let x=Number(num);
let even=0;
let digit;
while(x!=0)
{
	digit = x%10; 
	if(digit%2==0)
	{
	
	even=digit+even;
	}
	x=Math.floor(x/10);
}
console.log("sum of even numbers "+ even);