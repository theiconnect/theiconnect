debugger;
let a = prompt("enter the first number:")
let b = prompt("enter the second number:")
let c = prompt("enter the third number:")
while (isNaN(a) == true || isNaN(b) == true || isNaN(c) == true){
	a = prompt("invalid input please enter the correct input:")
	
	b= prompt("invalid input please enter the correct input:")
	
	c = prompt("invalid input please enter the correct input:")
	
}
a = Number(a)
b = Number(b)
c = Number(c)
if(a == b && b == c && c == a){
    console.log("all are equal")
}
else{
    if(a >= b && a >= c){
        console.log(a,"is a largest Number")
    }
    else if(b >= a && b >= c){
        console.log(b,"is a largest Number")
    }
    else if(c >= a && c >= b){
        console.log(c,"is a largest Number")
    }
}