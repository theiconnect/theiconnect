//Modularize
//1.GetArraySize
//2.ValidteArraySize
//3.GetArrayElementsFromUser
//4.GetSearchElement
//5.PerformLinearSearch
//6.PrintOutput
debugger;

//Parameter less function ex: function getArraySize(){}
//Parameterized functions ex: function validateArraySize(parameter1, parameter2){}
//function statement
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
    /*
    if (size <= 1)
        return false;
    else
        return true;
    */

    //blocks if, for, while, switch... if only signle statement 
    //present then {} are optional
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

function linearSearch(arr, searchKey){
    let searchIndex = -1

    for (let i = 0; i <= arr.length; i++) {
        if (arr[i] == searchKey) {
            searchIndex = i
            break
        }
    }
    return searchIndex;//index
}

function printResult(index, searchValue){
    if (index == -1) {
        console.log(`search element: ${searchValue} not found in the array`)
    }
    else {
        console.log(`search element: ${searchValue} present at the index ${index}`)
    }
}

function main() {
    //function calling/caller/function invokation
    //calling parameter less function
    let size = getArraySize();

    //calling parameterized function
    //caller
    //caller will pass arguments
    let isValidSize = validteArraySize(size);
    while (!isValidSize) {
        size = getArraySize();
        isValidSize = validteArraySize(size)
    }

    //getan array
    let stdArr = getArrayElementsFromUser(size);

    //get search key 
    let skey = getSearchElement();

    //Perform Linear Search
    let index = linearSearch(stdArr, skey) 
    
    //Print Result
    printResult(index, skey);

}
main();




debugger
function linearSearch() {
    let input = prompt("Please enter the size of the array")
    let arraySize = Number(input)
    let count = 0
    while (isNaN(arraySize)) {
        arraySize = prompt("invalid input please enter only the number")
        count++
        if (count < 3) {
            break
        }
    }
    while (arraySize <= 1) {
        arraySize = prompt("please enter a vaild arraysize in the range of 2 and above");
    }
    let studGrad = []
    for (let i = 1; i <= arraySize; i++) {
        studGradInput = Number(prompt("please enter the element" + i));
        while (isNaN(studGradInput)) {
            studGradInput = prompt("please Enter a valid element")
        }
        studGrad[i - 1] = studGradInput
    }

    let searchInput = prompt("please Enter the value you want to search:")
    let searchValue = Number(searchInput)

    while (isNaN(searchValue)) {
        searchValue = prompt("Invalid Input please Enter the value you want to search:")
    }

    let searchIndex = -1

    for (let i = 0; i <= studGrad.length; i++) {
        if (studGrad[i] == searchValue) {
            searchIndex = i
            break
        }
    }

    if (searchIndex == -1) {
        console.log(`search element: ${searchValue} not found in the array`)
    }
    else {
        console.log(`search element: ${searchValue} present at the index ${searchIndex}`)
    }
}
//linearSearch();