let num=Number(prompt('enter the number :'));
let sum = 0;
let digit = 0;
while(isNaN(num) == true){
    num = prompt('invalid num enter the correct number:' )
}
while(num != 0){
    digit = num % 10;
    let count = 0;
    for(let i=1;i<=digit;i++){
        if(digit % i == 0){
            count ++;
        }
    }
    if(count == 2){
        sum += digit;
    }
    num = Math.trunc(num / 10);
}
console.log(sum);
