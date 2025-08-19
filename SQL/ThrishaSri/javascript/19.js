debugger;
let n=Number(prompt("enter a number"));
let y=Number(prompt("enter a number"));
let count=0;
for(let i=n;i<=y;i++)
{
	if(i%3==0 || i%5==0)
	{
		count++;
	}
}
console.log(count);
	
	