debugger;
let n=prompt("enter a number");
let sum=0;
let product=1;

while(n>0)
{
	let digit=n%10;
	product=product*digit;
	sum=sum+digit;
	n=n/10;
}
console.log("result is : ",product-sum);
