let n = Number(prompt('enter the number:'));
let sum = 0;
let product = 1;

let digit =0;
while(n>0){
    digit = n % 10;
    product *= digit;
    sum += digit;
    n = Math.trunc(n/10);
   
}
let result = product - sum;
console.log(result);