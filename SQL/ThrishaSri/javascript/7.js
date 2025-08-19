debugger;
let n=prompt("enter a number");
let count=0;
while(n>0)
{
	n=Math.trunc(n/10);
	count++;
}
console.log(count);