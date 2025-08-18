let marks = prompt('enter your marks:');
let grade = ""
if(marks>90 && marks<=100){
    grade = 'A'
}
else if(marks>=80){
    grade = 'B'
}
else if(marks>=70){
    grade = 'c'
}
else if(marks>=60){
    grade = 'D';
}
else{
    grade = 'F'
}
console.log(grade);