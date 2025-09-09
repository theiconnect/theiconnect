//Count All Numbers Divisible by 3 or 5 Between A and B Input: A and B (range). Output: Count of numbers divisible by 3 or 5 in that range.

debugger;
let a = prompt("enter a value ");
let b = prompt("enter a value");
while(isNaN(a)== true || isNaN(b)== true)
{
   
prompt("invalid input , please enter a valid input");
}

let x=Number(a);
let y=Number(b);

let count = 0;

for(i=x; i<=y; i++)
  {
  	if(i % 3 == 0 || i % 5 == 0)
   		{
			count++;
		}
	}
console.log("count of numbers divisible by 3 or 5 in the range of " + x + " and " + y + " = " + count ); 
		     	

