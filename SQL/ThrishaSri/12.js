debugger;
let num = Number(prompt("Enter a number"));
let count = 0;

if (num > 1) {
    for (let i = 2; i <= num - 1; i++) {
        if (num % i == 0) {
            count++;
        }
    }

    if (count == 0) {
        console.log(num + " is a prime number");
    } else {
        console.log(num + " is not a prime number");
    }
} 
else {
    console.log("Number is invalid");
}
