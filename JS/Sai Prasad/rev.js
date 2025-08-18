let num = prompt('enter a number :');
debugger;
let rev = 0;
while(num!=0){
    let digit = Math.abs(num%10);
    rev = rev * 10 + digit
    num = Math.trunc(num/10);
}
console.log(rev);