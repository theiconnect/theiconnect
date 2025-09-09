//Convert a 3-Digit Number into Its Reverse and Check If It’s Prime
 //Take a 3-digit number → reverse it → check if the result is prime.

debugger;
let num = 522;

let rev = 0;
let isprime = true;

while (num != 0) {
    let digit = num % 10;
    rev = rev * 10 + digit;
   
     
    num= Math.floor(num / 10);
}

     for (let i=2; i<=(rev - 1); i++)
 	{
            if(rev % i == 0)
		{
		     isprime = false;
		}

}
            if(isprime== true)
		{
			console.log(" the rev of a number is prime");
}
        else
{
console.log("the rev of anumber is not prime");
}