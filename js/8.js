 let p =prompt("enter the number:")
while (isNaN(p) == true){
	input = prompt("invalid input please enter the correct input:")	
}
p= Number(input)
 let y = Number(p)
 let digit,rev=0 
 while( p != 0){    
     digit = p % 10   
     rev = rev * 10 + digit 
     p = Math.floor(p / 10) 
 }

if( y == rev){
	console.log(y,"is the plaindrome Number")
}
else{
	console.log(y," is not a plaindrome Number")
}