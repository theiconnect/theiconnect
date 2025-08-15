debugger;
let input = prompt("enter the number")
let x = Number(input)
let digit, rev =0 ,count = 0
while( x != 0){
	digit = x % 10
	rev = rev * 10 + digit
	x = Math.floor(x / 10)
}

	for( let i = 0 ; i <=rev ; i++ ){
		if( rev % i == 0){
			count ++
		}
	}
	if ( count == 2 ){
		console.log(rev,"is the prime number")
	}
	else
	{
		console.log(rev,"is not a prime number")
}