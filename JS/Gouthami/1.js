debugger;
let x = prompt("enter a number");
while (isNaN(x) == true )
{
    x=prompt("invalid input , please enter a valid input");
}
let num=Number(x);

  
        if(num%2==0)
        {
            console.log(num  + " is even ");
        }
        else
        {
            console.log(num  + " is odd ");
        }