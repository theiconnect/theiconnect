let n = parseInt(prompt('Enter the number value:'));
debugger;
let small = 10;  // bigger than any digit
let digit;

while (n !== 0) {
    digit = Math.abs(n % 10);  // get last digit, positive
    if (digit < small) {
        small = digit;
    }
    n = Math.trunc(n / 10); // remove last digit
}

console.log("Smallest digit is:", small);
