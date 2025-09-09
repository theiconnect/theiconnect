debugger;

function getArraySize() {
    let arraySize = Number(prompt("Please enter the size of the array"));
    while (isNaN(arraySize) ) {
        arraySize = Number(prompt("Invalid input! Please enter an integer greater than 1"));
    }
    return arraySize;
}

function validateArraySize(size) {
    return size > 1;
}

function getArrayElementsFromUser(arraySize) {
    let studGrad = [];
    for (let i = 1; i <= arraySize; i++) {
        let studGradInput = Number(prompt("Please enter the element " + i));
        while (isNaN(studGradInput)) {
            studGradInput = Number(prompt("Please enter a valid number for element " + i));
        }
        studGrad[i - 1] = studGradInput;
    }
    return studGrad;
}

function bubbleSort(array) {
    for (let i = 0; i < array.length - 1; i++) {
        for (let j = 0; j < array.length - 1 - i; j++) {
            if (array[j] > array[j + 1]) {
                let temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }
        }
    }
    return array;
}

function main() {
    let size = getArraySize();
    while (!validateArraySize(size)) {
        size = getArraySize();
    }
    
    let stdArr = getArrayElementsFromUser(size);
    let value = Number(prompt("Please enter the value you want to search"));
    
    let sortedArr = bubbleSort(stdArr);
    console.log("Sorted Array:", sortedArr);
    
    let foundIndex = sortedArr.indexOf(value);
    if (foundIndex !== -1) {
        console.log(`Value ${value} found at position ${foundIndex}`);
    } else {
        console.log(`Value ${value} not found in the array`);
    }
}

main();
