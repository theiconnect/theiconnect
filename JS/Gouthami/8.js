let num1=(prompt("enter  first number"));
let num2=(prompt("enter  second number"));
while (isNaN(num1) == true || isNaN(num2) == true )
{
    num1=prompt("invalid input , please enter a valid input");
    num2=prompt("invalid input , please enter a valid input");
}

let x=Number(num1);
let y=Number(num2);
let result = x + y;
console.log("the sum is =" + result);
