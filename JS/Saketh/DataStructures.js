debugger;
function getArraySize() {
    let input = prompt("Please enter the size of the array")
    let arraySize = Number(input)
    while (isNaN(arraySize)) {
        arraySize = prompt("invalid input please enter valid number")
    }
    return arraySize;
}

function validteArraySize(arraySize) {
    if (arraySize <= 1) {
        return false;
    } else {
        return true;
    }
}

function getArrayElementsFromUser(arraySize) {
    let studGrad = [];
    for (let i = 1; i <= arraySize; i++) {
        studGradInput = Number(prompt("please enter the element" + i));
        while (isNaN(studGradInput)) {
            studGradInput = prompt("please Enter a valid element")
        }
        studGrad[i - 1] = studGradInput
    }

    return studGrad;
}

function getSearchElement() {
    let searchInput = prompt("please Enter the value you want to search:")
    let searchValue = Number(searchInput)

    while (isNaN(searchValue)) {
        searchValue = prompt("Invalid input, please Enter any number that you want to search in the array!")
    }

    return searchValue;
}

function linearSearch(arr, searchKey) {
    let searchIndex = -1

    for (let i = 0; i <= arr.length; i++) {
        if (arr[i] == searchKey) {
            searchIndex = i
            break
        }
    }
    return searchIndex;//index
}

function printResult(index, searchValue) {
    if (index == -1) {
        console.log(`search element: ${searchValue} not found in the array`)
    }
    else {
        console.log(`search element: ${searchValue} present at the index ${index}`)
    }
}

function bubbleSort(arr){
    //logic
    //return arr;
}

function printArray(arr){
    
}

function main() {
    //1.GetArraySize
    let size = getArraySize();

    //2.ValidteArraySize
    let isValidSize = validteArraySize(size);
    while (!isValidSize) {
        size = getArraySize();
        isValidSize = validteArraySize(size)
    }

    //3.GetArrayElementsFromUser
    let stdArr = getArrayElementsFromUser(size);

    let sortedArray = bubbleSort(stdArr);
    //4.GetSearchElement
    let skey = getSearchElement();

    //5.PerformLinearSearch
    let index = linearSearch(stdArr, skey)

    //6.PrintOutput
    printResult(index, skey);

}
main();
