debugger;
let n= prompt("enter a positive number");
while (isNaN(n) == true )
{
    n=prompt("invalid input , please enter a valid input");
}
        let sum=0;
            for( let i=1; i<=n; i++)
            {
               sum=sum+i
            }
            console.log("sum="+sum);
