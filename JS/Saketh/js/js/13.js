let input = prompt("Guess a Number between 0-10:")
let x = Number(input)
let crctNum = 8
while (isNaN(x) == true){
	input = prompt("invalid input please enter the correct input:")		
}
x= Number(input)
if( x >= 0 && x <=10){
if( x > crctNum ){
	console.log("it is too high")
}
else if( x < crctNum){
	console.log("it is too low")
}
else{
	console.log("congrats you guess a correct number")
}
}
else{
	console.log("please enter a number between the 0-10")
}