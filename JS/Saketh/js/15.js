/*Write a program that takes two numbers and an operator (+, -, *, /) as input from the user and performs the corresponding operation. Print the result. Use if-else to handle the operator choice.*/


debugger;
let input = prompt("enter the first number")
let x = Number(input)
let input1 = prompt("enter the Second number")
let y = Number(input1)
let operator = prompt("enter the operator")
let z
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


	



