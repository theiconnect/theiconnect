debugger;
let n=prompt("enter a value")
while(isNaN(n) == true)
{
   n = prompt("invalid input, please enter a valid input");
}
 let x=Number(n);

for(let i=1;i<=x;i++)
{

  for (let j=1;j<=i;j++)
   {
      console.log("*");
   }

  console.log("\n");
}

