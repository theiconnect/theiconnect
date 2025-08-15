debugger;
let input = prompt("enter the number")
let x = Number(input)
let digit,count=0
while( x != 0 ){
	digit = x % 10
	x = Math.floor(x / 10)
	count ++
}
console.log(count,"Are the no of digits in a given number")
