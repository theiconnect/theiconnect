let input = prompt("enter the number")
let num = Number(input)
let sum = 0,digit
 while( num != 0){
	digit = num % 10
	if( digit % 2 == 0){
		sum = sum + digit
	}
	num = Math.floor(num / 10)
}
console.log(sum,"is the sum of all even digits in a given number")