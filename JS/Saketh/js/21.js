debugger;
let input = prompt("enter the number")
let num = Number(input)

	if( num % 2 == 0 && Math.sqrt(num) * Math.sqrt(num) == num){
		console.log(num,'is perfect square and even')
	}
	else{
		console.log(num,'is not valid')
	}
