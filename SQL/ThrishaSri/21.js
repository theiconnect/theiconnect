debugger;
let pali=Number(prompt("enter a number"));
let orginal=pali;
let rev=0;
let digit=0;
while(pali!=0)
{
	digit = pali%10;
	rev=rev*10+digit;
	pali=Math.floor(pali/10);
}
if(orginal==rev)
{
	console.log(rev,"Palindrome");
}
else
{
	console.log(rev,"Not palindrome");
}
