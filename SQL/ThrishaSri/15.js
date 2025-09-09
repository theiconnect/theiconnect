debugger;
let x=prompt("enter a number");
let n=Number(x);
let small=9;
while(n!=0)
{
	digit=n%10;
	if(small>digit)
	{
		small=digit;
	}
	n=Math.floor(n/10);
}
console.log(small);	