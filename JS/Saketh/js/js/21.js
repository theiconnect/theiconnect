debugger;
let input = prompt("enter the number")
while (isNaN(input) == true){
	input = prompt("invalid input please enter the correct input:")
}
let num = Number(input)

	if( num % 2 == 0 && Math.sqrt(num) * Math.sqrt(num) == num){
		console.log(num,'is perfect square and even')
	}
	else{
		console.log(num,'is not valid')
	}
