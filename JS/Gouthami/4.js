debugger;
let factnum=prompt("enter a factnum");
while (isNaN(factnum) == true )
{
    factnum=prompt("invalid input , please enter a valid input");
}
let x=Number(factnum);

        let fact=1;
            for( let i=1; i<=x; i++)
            {
                fact=fact*i;
            }
            console.log("factorial="+fact);
    