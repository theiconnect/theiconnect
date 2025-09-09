debugger;
let num = prompt("Enter a value");
while (isNaN(num) == true )
{
    num=prompt("invalid input , please enter a valid input");
}

let rev = 0;
let x = Number(num);

while (x != 0) {
    let digit = x % 10;
    rev = rev * 10 + digit;
    x = Math.floor(x / 10);
}

console.log(rev);