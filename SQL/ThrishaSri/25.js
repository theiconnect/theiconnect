debugger;
let num=prompt("enter a number");
while(isNaN(num)==true)
{
	console.log("Invalid input , enter a valid input");
}
let x=Number(num);
let digit;
while(x!=0);
{
	digit=x%10;
	x=x/10;
}

console.log(digit);
