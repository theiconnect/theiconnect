debugger;
let n=prompt("enter a number");
while(isNaN(n)==true)
{
	console.log("Invalid input , enter a valid input");
}
let x=Number(n);
let digit;

while(x>9)
{
	let sum=0;
	while(x!=0)
	{
		digit=x%10;
	
		sum=sum+digit;
	
		x=Math.floor(x/10);
	}
	x=sum;
}
	
console.log(x);