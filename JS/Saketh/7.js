 let p =prompt("enter the number:")
while (isNaN(p) == true){
	input = prompt("invalid input please enter the correct input:")
	
}
p= Number(input)
 let digit,rev=0 
 while( p != 0){    
     digit = p % 10   
     rev = rev * 10 + digit 
     p = Math.floor(p / 10) 
 }
 console.log(rev,'is the reverse of number') 