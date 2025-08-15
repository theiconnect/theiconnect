 let p =prompt("enter the number:")
 let x = Number(p)
 let digit,rev=0 
 while( x != 0){    
     digit = x % 10   
     rev = rev * 10 + digit 
     x = Math.floor(x / 10) 
 }
 console.log(rev,'is the reverse of number') 