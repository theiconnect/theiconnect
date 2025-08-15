/*Count How Many Times Digit 3 Appears (0–N)
	 Given a number N, count how many times the digit 3 appears from 1 to N. */


let input = prompt("enter the number")
let x = Number(input)
let count = 0
for ( let i=0 ;i <=x ; i++){
	while( i != 0){
		if( i % 10 == 3){ 
		count ++
		}
		i = Math.floor(i / 10)
	}	
}
console.log(count,"times will appear 3 from 1 to",x)
