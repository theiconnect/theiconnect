debugger;
let a=0;
console.log(a);
let b=1;
console.log(b);
while(b<100)
{
	b=a+b;
	a=b-a;
	console.log(b);
}

