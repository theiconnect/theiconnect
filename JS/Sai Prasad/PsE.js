let num = Number(prompt('enter the number :'));
while(isNaN(num) == true){
    num = prompt('invalid input enter the correct number:')
}
if(num % 2 == 0 && Math.sqrt(num) * Math.sqrt(num) == num ){
    console.log(num,'is perfect square and even')
}
else{
    console.log(num,'is not valid')
}
