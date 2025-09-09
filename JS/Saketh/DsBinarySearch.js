//1.GetArraySize
//2.ValidateArraySize
//3.GetArrayElementsFromUser
//4.GetSearchElement
//5.PerformLinearSearch
//6.PrintOutput
debugger;
function getArraySize() {
    let input = prompt("Please enter the size of an array:")
    let arraySize = Number(input)
    while (isNaN(arraySize)) {
        arraySize = prompt("Invalid input, please enter correct the size of an array:")
    }
    return arraySize;
}

function getValidationArraySize(size) {
    if (size <= 1) {
        return false;
    }
    else {
        return true;
    }
}

function getArrayElementsFromUser(size) {
    let arr = []
    for (let i = 1; i <= size; i++) {
        arrUserInput = Number(prompt("Enter the element" + i));
        while (isNaN(arrUserInput)) {
            arrUserInput = Prompt("Invalid input please enter a valid Element:")
        }
        arr[i - 1] = arrUserInput
    }
    return arr;
}

function getSearchElement() {
    let searchElementInput = prompt("Enter the element you want to search:")
    let searchElement = Number(searchElementInput)
    return searchElement;
}

function BinarySearch(array, searchEle) {
    let low = 0
    let high = array.length - 1
    let mid

    let isfound = false
    while (low <= high) {
        mid = Math.floor((low + high) / 2)
        if (array[mid] == searchEle) {
            console.log(`the searchElement: ${searchEle} found at the index ${mid}`)
            isfound = true
            break;
        }
        else if (array[mid] > searchEle) {
            high = mid - 1
        }
        else {
            low = mid + 1

        }
    }
    if (isfound == false) {
        console.log(`the searchElement: ${searchEle} is not found in these array`)
    }
    return mid
}




function exec() {
    let size = getArraySize();

    let isValidSize = getValidationArraySize(size);
    while (!isValidSize) {
        size = getArraySize();
        isValidSize = getValidationArraySize(size);
    }

    let array = getArrayElementsFromUser(size);
    let searchEle = getSearchElement();
    let output = BinarySearch(array,searchEle);
}
exec();


















debugger;






let searchElementInput = prompt("Enter the element you want to search:")
let searchElement = Number(searchElementInput)


