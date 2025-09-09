debugger;

let input = prompt("please enter a size of array");
let arraySize = Number(input);
while (isNaN(arraySize)) {
    arraySize = prompt("invalid input please enter only the number")
}

while (arraySize <= 1) { 
    arraySize = prompt("please enter a valid array size which is range of 2 and above");
}
let stdGrade = []
let stdGrades = Number(stdGrade)
for (let count = 1; count <= arraySize; count++) {
    stdGrades[count - 1] = prompt("enter element" + count);
}
let searchInput = prompt("please enter the value you want to search");
let searchValue = Number(searchInput);
let searchIndex = -1;
for (let index = 0; index < stdGrades.length - 1; index = index + 1) {
    if (stdGrades[index] == searchValue) {
        searchIndex = index;
        break;
    }

}
if (searchIndex == -1) {
    console.log("SearchElement " + searchValue + " not found in the array");
}
else {
    console.log("searchElement " + searchValue + " found in the array");
}
