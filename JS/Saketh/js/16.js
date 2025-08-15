let input = prompt("enter the number")
let x = Number(input)
let digit, sum = 0 
while( x != 0){
	digit = x % 10 
	sum = sum + digit 
	x = Math.floor(x / 10)
}
console.log(sum," is the sum of all digits of a Given number")