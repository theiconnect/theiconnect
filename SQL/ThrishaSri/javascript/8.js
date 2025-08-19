\\8.Largest Number
let n = Number(prompt("Enter a number"));
let m = Number(prompt("Enter a number"));
let p = Number(prompt("Enter a number"));

if (n == m && m == p) {
    console.log("All are equal");
}
else{
 if (n >= m && n >= p) {
    console.log("Largest number is = "+n);
}
else if (m >= n && m >= p) {
    console.log("Largest number is = "+m);
}
else {
    console.log("Largest number is = "+p);
}
}