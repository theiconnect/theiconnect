debugger;
let num = prompt("Enter a value");
while (isNaN(num) == true )
{
    num=prompt("invalid input , please enter a valid input");
}

let rev = 0;
let x = Number(num);
let orginal = x;

while (x != 0) {
    let digit = x % 10;
    rev = rev * 10 + digit;
    x = Math.floor(x / 10);
}

if( orginal == rev)
{
    console.log(orginal + " is a palindrome");
}
else
{
    console.log(orginal + " is not palindrome");
}
