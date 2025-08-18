debugger;
let num = Number(prompt('enter the number :'));
let a = 0;
console.log(a);
let b = 1;
console.log(b);
while(isNaN(num) == true){
    num = prompt('invalid enter the correct num:')
}
while(b<=num){
    b=a+b;
    a=b-a;
    console.log(b)
}