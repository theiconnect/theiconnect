let marks=prompt("enter a number");
if (marks<=0)
{
	console.log("Invalid");
}
else if(marks>=90)
{
	console.log("A grade");
}
else if(marks>=89)
{
	console.log("B grade");
}
else if(marks>=79)
{
	console.log("C grade");
}
else if(marks>=69)
{
	console.log("D grade");
}
else
{
	console.log("F grade");
}