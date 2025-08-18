debugger;
let num = Number(prompt('enter the number:' ));
let x=num;
let digit=0,rev = 0;
while(x != 0){
    digit = x%10;
    rev = rev * 10 + digit;
    x = Math.trunc(x/10);
}
if(num == rev){
    console.log('It is a Palindrome');
}
else{
    console.log('It is not a palindrome')
}