debugger;
let n = prompt("enter the range:")
while (isNaN(n) == true){
	input = prompt("invalid input please enter the correct input:")
	
}
n= Number(input)
let sum = 0
for(let i=0; i <= n ; i++){
   sum = sum + i
}
console.log(sum)