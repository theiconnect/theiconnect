
/*let digit = 0;
let sum = 0;
while(n!=0){
    digit = n%10;
    sum = sum + digit;
    n = Math.trunc(n / 10);
}
console.log(sum);*/
let n = parseInt(prompt('Enter the number:'));
let sum = 0;

while (n > 9) { // repeat until single digit
    sum = 0; // reset sum each time
    while (n > 0) {
        let digit = n % 10;
        sum += digit;
        n = Math.trunc(n / 10); // remove last digit
    }
    n = sum; // start again with sum of digits
}

console.log(n);
