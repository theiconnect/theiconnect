debugger;
let x = prompt("enter the number:")
while (isNaN(x) == true){
	x = prompt("invalid input please enter the correct input:")
}
let num = Number(x)
let digit,sum = 0
while( num != 0 ){
	digit = num % 10
	count = 0
	for( let i = 1; i <= digit ; i++ ){
		if( digit % i == 0){
			count ++
		}
	}
	if(count == 2){
			sum = sum + digit
		}
		
	num = Math.floor(num / 10)
}

console.log(sum)