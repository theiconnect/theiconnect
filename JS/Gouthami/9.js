debugger;
let n = prompt("enter a number")
while (isNaN(n) == true )
{
    n=prompt("invalid input , please enter a valid input")
}

let count=0;
let x=Number(n)
while(x!=0)      
 {
    digit = x % 10;
       if()
{
       count++
}
      x= Math.floor(x/10);
  }
   console.log(count)