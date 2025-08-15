debugger;
let input = prompt("enter the starting range")
let input1 = prompt("enter the  ending range")
let A = Number(input)
let B = Number(input1)
let count = 0
for(let i=A ; i <=B ; i++){
	if( i % 3 == 0 || i % 5 == 0){
		count++
	}
}
console.log(count)