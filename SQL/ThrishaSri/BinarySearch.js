debugger;

function getArraySize() {
    let input = prompt("Please enter the size of the array");
    let arraySize = Number(input);
    while (isNaN(arraySize)) {
        arraySize = Number(prompt("Invalid input! Please enter a valid number"));
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

function binarySearch(arr, value) {
    let low = 0;
    let high = arr.length - 1;

    while (low <= high) {
        let mid = Math.floor((low + high) / 2);

        if (arr[mid] == value) {
            return mid;
        } else if (arr[mid] < value) {
            low = mid + 1;
        } else {
            high = mid - 1;
        }
    }
    return -1; 
}

function printResult(index, searchValue) {
    if (index == -1) {
        console.log(`Search element ${searchValue} not found in the array`);
    } else {
        console.log(`Search element ${searchValue} found at index ${index}`);
    }
}

function main() {
    let size = getArraySize();
    while (!validateArraySize(size)) {
        size = getArraySize();
    }
    let stdArr = getArrayElementsFromUser(size);
    let value = Number(prompt("Please enter the value you want to search"));
    let index = binarySearch(stdArr, value);
    printResult(index, value);
}
main();
