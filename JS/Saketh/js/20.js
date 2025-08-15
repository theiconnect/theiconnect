debugger;
let input = prompt("enter the number:")
let num = Number(input)
let digit,smallest=9
while( num != 0 ){
	digit = num % 10
	if(digit < smallest){
		smallest = digit
	}
	else{
		smallest = smallest 
	}

	num = Math.floor(num / 10)
}
console.log(smallest,"is the smallest digit in a number")