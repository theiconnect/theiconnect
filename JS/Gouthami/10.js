debugger;
let marks=prompt("enter marks out of 100:");
while (isNaN(marks) == true )
{
    marks=prompt("invalid input , please enter a valid input");
}

let x=Number(marks);
let grade
if(x>=0 && x<=100)
{

if(x>=90)
{
     grade="A";
}
else if(x>=80)
{
     grade="B";
}
else if(x>=70)
{
     grade="C";
}
else if(x>=50)
{
     grade="D";
}
else
{
     grade="E";
}
}
else
{
  x=prompt("please a enter between 1 to 100")
}
  console.log(" your grade is " + grade);
   