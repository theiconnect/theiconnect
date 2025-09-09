debugger;
let evennum=prompt("enter a number");
while (isNaN(evennum) == true )
{
    evennum=prompt("invalid input , please enter a valid input");
}

let x=Number(evennum);

        let evensum = 0;
        for(let i=2; i<=x; i+2)
    {
        evensum=evensum+i;
        
    }
      console.log("sum of even number="+ evensum);
