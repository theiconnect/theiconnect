debugger;
let n=Number(prompt("enter a number"));
let digit
let sum= 0;

while(n != 0)
{
	digit=n % 10;
	let count = 0;
	for (let i = 1; i <= digit; i++) {
        if (digit % i == 0) {
            count++;
        }
    }

    if (count == 2) {
        sum=sum+digit;
    } 
	n=Math.floor(n/10);
}
console.log(sum);
