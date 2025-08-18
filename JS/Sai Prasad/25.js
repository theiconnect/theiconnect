debugger;
let num = Number(prompt('enter the number :'));
let rev = 0,digit = 0,count = 0;
while(isNaN(num) == true){
    num = prompt('invalid num enter the correct num :')
}
while(num!=0){
    digit = num % 10;
    rev = rev * 10 + digit;
    num = Math.trunc(num / 10);
}
for(let i=1;i<=rev;i++){
    if(rev % i == 0){
        count++;
    }
}
if(count == 2){
    console.log(rev,'is the prime')
}
else{
    console.log('not prime',rev);
}