debugger;
function main() {
    let size = getArraySize();

    let isValidSize = validateArraySize(size);
    while (!isValidSize) {
        size = getArraySize();
        isValidSize = validateArraySize(size);
    }

    let arr = getArrayElementsFromUser(size);

    let target = getSearchElement();
    let result = binarySearch(arr,target);
    if(result !== -1){
        console.log('i found the element'+arr[result]+'at mid'+result)
    }
    else{
        console.log('element not found in the array');
    }




    function getArraySize() {
        let input = prompt('please enter the size of array');
        let arraySize = Number(input);
        while (isNaN(arraySize)) {
            arraySize = prompt('invalid input please enter valid input')
        }
        return arraySize;
    }
    function validateArraySize(arraySize) {
        if (arraySize <= 1) {
            return false;
        }
        else {
            return true;
        }

    }
    function getArrayElementsFromUser(arraySize) {
        let stdGrades = [];

        for (let count = 1; count <= arraySize; count++) {
            let element = Number(prompt('enter element' + count));
            while (isNaN(element)) {
                element = prompt('please enter a valid element')
            }
            stdGrades[count - 1] = element
        }
        return stdGrades;
    }
    function getSearchElement() {
        let searchInput = prompt('please enter the value you want to search:')
        let searchValue = Number(searchInput);
        while (isNaN(searchValue)) {
            searchValue = prompt('invalid input ,please enter proper input')
        }
        return searchValue;
    }
    function binarySearch(arr, target) {
        let low = 0;
        let high = arr.length-1;
        
        while (low <= high) {
             let mid = Math.floor((low + high) / 2)
            if (arr[mid] == target) {
                return mid;
            }
            else if (arr[mid] < target) {
                low = mid + 1;
            }
            else {
                high = mid - 1;
            }
        }
       
        return -1;
    }
}
main();