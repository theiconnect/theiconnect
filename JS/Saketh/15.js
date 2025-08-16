debugger;
let input = prompt("enter the first number")
let x= Number(input)
let input1 = prompt("enter the Second number")
let y= Number(input1)
let operator = prompt("enter the operator")
let z
while (isNaN(input) == true || isNaN(input1) == true){
	input = prompt("invalid input please enter the correct input:")
	input1 = prompt("invalid input please enter the correct input:")
	operator = prompt("invalid input please enter the correct input:")
}
if( operator == "+"){
	z = x + y
	console.log(z) 	
}
else if( operator == "-"){
	z = x - y
	console.log(z) 	
}
else if( operator == "*"){
	z = x * y
	console.log(z) 	
}
else if( operator == "/"){
	z = x / y
	console.log(z) 	
}


	



