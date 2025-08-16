let input = prompt("enter the number:")
let x
while (isNaN(input) == true){
	input = prompt("invalid input please enter the correct input:")	
}
x= Number(input)
let a = 0 ,b = 1,c
console.log(a)
console.log(b)
for(let i=0 ; i<=x ;i++){
	c = a + b
	console.log(c)
	a = b
	b = c
}