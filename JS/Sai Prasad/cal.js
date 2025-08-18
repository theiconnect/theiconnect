debugger;
let num1 = Number(prompt('enter a num1 value :'));
let num2 = Number(prompt('enter a num2 value :'));
let operator = prompt('Give a operator');
if(operator == '+' ){

    console.log('sum of two :',num1 + num2);
}
else if(operator == '-'){
    console.log('subtraction of values :',num1 - num2);
}
else if(operator == '*'){
    console.log('multiply values :',num1*num2);
}
else if(operator == '/'){
    console.log('Division of values :',num1/num2);
}
else{
    console.log('print inavalid operator');
}