debugger;
let u=Number(prompt("enter a number"));
let sum=0;
while(u != 0)
{
	digit=u% 10;
if (digit%2==0)
{
	sum=sum+digit;
}
u=Math.floor(u/10);
}
console.log(sum);