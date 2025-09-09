debugger;
let tablenum=prompt("enter a number:");
while (isNaN(tablenum) == true )
{
    tablenum=prompt("invalid input , please enter a valid input");
}
let x=Number(tablenum);
        for( let i=1; i<=10; i++)
            { 
               console.log( x + " * " + i + " = " + x*i) 
            }
