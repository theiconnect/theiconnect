let x = prompt("enter the number:")
while (isNaN(x) == true){
	input = prompt("invalid input please enter the correct input:")
	
	
}
x= Number(input)
for(let i=1;i<=10;i++){
    console.log(x,"X",i ,"=",x*i)
}