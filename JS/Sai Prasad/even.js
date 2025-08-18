/*let num = prompt("enter the number :");
debugger;
if(num%2 == 0){
    console.log(num,'is even')
}
else{
    console.log(num,'is odd')
}*/

let num = prompt("enter the num :");

let even_sum = 0;
let odd_sum = 0;

while(num!=0){
    let digit = num%10;
    if(digit%2 == 0){
         even_sum = even_sum + digit;
    }
    else{
         odd_sum = odd_sum + digit;
    }
    num = num/10;
}
console.log(even_sum)
console.log(odd_sum)