let n = Number(prompt('enter the number:'));
let digit = 0;
let max = 0;
while(n != 0){
    digit = Math.abs(n%10);
    if(digit > max){
        max = digit;
    }
    n = Math.trunc(n/10);

}
console.log(max);