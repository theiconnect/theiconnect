debugger;
let input = prompt('enter the number :');
while(isNaN(input) == true){
    input = prompt('invalid input enter the correct input')
}
let x = Number(input);
let y = Number(input);
let count = 0;
for(let i=1;i<=x;i++){
    while(x != 0){
        if(x % 10 == 3){
            count++;
        }
        x = Math.floor(x / 10);
    }
}
console.log(count,'times will appear 3 from 1 to',y)