debugger;
let input = prompt("enter the input:")
let x
while (isNaN(input) == true){
	input = prompt("invalid input please enter the correct input:")
	
	
}
x = Number(input)
if(x % 2 == 0){
     	console.log(x,"is even")
 }
else{
     	console.log(x,"is odd")
}
