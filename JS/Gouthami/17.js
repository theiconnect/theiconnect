

debugger;
let number =prompt ("enter a number");
while(isNaN(number) == true)
{
   number = prompt("invalid input, please enter a valid number");
}
let x=Number(number);
let evensum=0;
let oddsum=0;
while(x!=0)
  {
  let digit = x % 10;
       
     
    if(digit % 2 == 0)
 	{
	  evensum = digit + evensum;
           }
    else
	{
	  oddsum = digit  + oddsum;
	}

  	x = Math.floor (x /10);
  }
  console.log(" sum of even is " + evensum );
  console.log(" sum of odd is " + oddsum);



