debugger;
let input = prompt("enter the number")
while (isNaN(input) == true){
	input = prompt("invalid input please enter the correct input:")
}
let x = Number(input)
let count = 0
for ( let i=1 ;i <=x ; i++){
	let temp = i
	while( temp != 0){
		if( temp % 10 == 3){ 
		count ++
		}
		temp = Math.floor(temp/ 10)
	}	
}
console.log(count,"times will appear 3 from 1 to",x)

