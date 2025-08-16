debugger;
let f = prompt("Enter the number:")
while (isNaN(f) == true){
	input = prompt("invalid input please enter the correct input:")
	
	
}
f= Number(input)
let fact = 1
for(let i=1;i <= f ; i++){
    fact = fact * i
 }
 console.log(fact)