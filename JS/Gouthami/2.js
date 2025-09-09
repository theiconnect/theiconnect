
debugger;
let n1=prompt("enter your first number");
let n2=prompt("enter your second number");
let n3=prompt("enter your third number");
while (isNaN(n1) == true || isNaN(n2) == true || isNaN(n3) == true )
{
    n1=prompt("invalid input , please enter a valid input");
    n2=prompt("invalid input , please enter a valid input");
    n3=prompt("invalid input , please enter a valid input");
}
let x=Number(n1);
let y=Number(n2);
let z=Number(n3);
let largest;


           if(x>=y && x>=z)
                {
                    largest=x;
                }
            else if(y>=z && x>=z)
                {
                    largest=y;
                }
            else
                {
                    largest=z;
                }

            console.log("The largest number is:" + largest );

        