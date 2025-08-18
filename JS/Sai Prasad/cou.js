debugger;
let n = prompt('enter the number :');
let count = 0;
/*let count = 0;
while(n>0)
	{
	  n = n /10;
	  count = count + 1;
   
 	}
	console.log(count);*/


while(n>0){
	n = Math.trunc(n/10);
	count++;
}
console.log(count);