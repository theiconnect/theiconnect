debugger;
let input = prompt("Enter the Number:")
while (isNaN(input) == true){
	input = prompt("invalid input please enter the correct input:")
}
let number = Number(input)
let digit,rev = 0
while( number != 0){
	digit = number % 10
	rev = rev * 10 + digit
	number = Math.floor(number / 10)
}
let res = rev % 10 
console.log(res)