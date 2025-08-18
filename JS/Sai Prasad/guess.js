let num = prompt("enter the Guess Number:");
let guess = Number(num);
let cat = 7;
while(isNaN(guess) == true){
    num = prompt("Inavalid enter correct number:")
}
if(guess >= 0 && guess <= 10){
    if(guess > cat){
        console.log('its high')
    }
    else if(guess < cat){
        console.log('its Low')
    }
    else{
        console.log('congrats you guess the number')
    }
}
else{
    console.log('please enter a number the 0 -10');
}