debugger;
let input = prompt("enter the starting range")
let input1 = prompt("enter the  ending range")
while (isNaN(input) == true || isNaN(input1) == true){
	input = prompt("invalid input please enter the correct input:")
	input1 =prompt("invalid input please enter the correct input:")

}
let A = Number(input)
let B = Number(input1)
let count = 0
for(let i=A ; i <=B ; i++){
	if( i % 3 == 0 || i % 5 == 0){
		count++
	}
}
console.log(count)