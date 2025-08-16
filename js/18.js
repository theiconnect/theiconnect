debugger;
let input = prompt("enter the number:")
while (isNaN(input) == true){
	input = prompt("invalid input please enter the correct input:")
}
let x = Number(input)
let digit, product=1, sum=0
while( x != 0 ){
	digit = x % 10
	product = product * digit
	sum = sum + digit
	x = Math.floor( x / 10)
} 
let diff = product - sum
console.log(diff,"is the difference between product and sum of the digits of a number")