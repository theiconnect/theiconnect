4.Reverse of a number
let n = prompt("enter a number");
let rev=0;
let x = Number(n);

    while (x != 0)
     {
        let digit = x % 10;
       rev = rev * 10 + digit;
       x = Math.floor(x/10);
}
    console.log (rev);