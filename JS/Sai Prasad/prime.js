let x = prompt("enter the x value")
debugger;
let count = 0;
for(let i=2;i<= x-1;i++){
    if(x%i == 0){
        count++;
    }
}
if(count >= 2){
    console.log('Prime')
}
else{
    console.log('Not Prime')
}