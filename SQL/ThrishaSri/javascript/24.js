
let n=prompt("enter a number : ");
while(isNaN(n)==true)
{
	console.log("Invalid input , enter a valid input");
}
let x=Number(n);
let count=0;
for(let i=1;i<=x;i++)
{
	while(x!=0)
	{
		if(x%10==3)
		{
			count++;
		}
		x=Math.floor(x/10);

	}
}
console.log(count);



