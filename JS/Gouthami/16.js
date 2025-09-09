debugger;
let Fnum=prompt("enter your first number");
let Snum=prompt ("enter your second number");
let operator=prompt("enter your operator");
while(isNaN(Fnum)==true || isNaN(Snum)== true )
{
    Fnum = prompt("invalid input, please enter a valid input");
    Snum  = prompt("invalid input, please enter a valid input");
   }
let x=Number(Fnum);
let y=Number(Snum);

if(operator == "+")
 {
	console.log(x  + "+"  + y + "=" + (x + y));
}
else if(operator == "-")   

 {
    console.log(x + "-" + y  + " = " + (x - y));
}
else if(operator == "*")

 {
    console.log(x + "*" + y + " = " + (x * y));
}
 else if(operator == "/")
 {
    console.log(x + "/" + y + " = " + (x / y));
}