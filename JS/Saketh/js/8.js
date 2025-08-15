 let p =prompt("enter the number:")
 let y = Number(p)
 let x = Number(p)
 let digit,rev=0 
 while( x != 0){    
     digit = x % 10   
     rev = rev * 10 + digit 
     x = Math.floor(x / 10) 
 }

if( y == rev){
	console.log(y,"is the plaindrome Number")
}
else{
	console.log(y," is not a plaindrome Number")
}