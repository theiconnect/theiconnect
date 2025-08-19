debugger;
let n=Number(prompt("enter a number"));
let digit=0;
let rev=0;
let count=0;
while(n!=0)
{
	digit=n%10;
	rev=rev*10+digit;
	n=Math.floor(n/10);
}
console.log(rev);
for (let i = 1; i <= rev; i++) {
        if (rev % i == 0) {
            count++;
        }
    }

    if (count == 2) {
        console.log(rev + " is a prime number");
    } else {
        console.log(rev + " is not a prime number");
    }
