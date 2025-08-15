debugger;
let x = prompt("enter the number:")
let n= Number(x)
let count = 0
for(let i = 1; i <= n ; i++){
    if(n % i == 0){
        count++
    }
}
if(count == 2){
    console.log(n,"is the prime number")
}
else{
    console.log(n,"is not a prime")
}