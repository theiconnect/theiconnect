let input = prompt("enter the number")
while (isNaN(input) == true){
	input = prompt("invalid input please enter the correct input:")
	
}
n= Number(input)
for(let i = 0;i<= n;i++){
	if( i % 2 == 0){
		console.log(i)
}
}