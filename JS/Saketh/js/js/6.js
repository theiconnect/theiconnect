debugger;
let n = prompt("enter the number:")
while (isNaN(n) == true){
	input = prompt("invalid input please enter the correct input:")
		
}
n= Number(input)
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