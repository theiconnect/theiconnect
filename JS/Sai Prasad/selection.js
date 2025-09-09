debugger;
function main() {
    let size = getArraySize();

    let isValidSize = validateSize(size);
    while (!isValidSize) {
        size = getArraySize();
        isValidSize = validateSize(size);
    }
    let array = getArrayElementsFromUser(size);
    console.log(array)
    let result = selectionsort(array)
    console.log(array)


    function getArraySize() {
        let input = prompt('please enter size of an array');
        let arraySize = Number(input);
        while (isNaN(arraySize)) {
            arraySize = Number(prompt('please enter a valid input'))
        }
        return arraySize;

    }
    function validateSize(size) {
        if (size < 1) {
            return false;
        }
        else {
            return true;
        }
    }
    function getArrayElementsFromUser(arraySize) {
        let getArray = [];
        for (let i = 1; i <= size; i++) {
            let element = Number(prompt('enter the element' + i));
            while (isNaN(element)) {
                element = prompt('invalid element,please enter valid element ')
            }
            getArray[i - 1] = element;
        }
        return getArray;
    }
    function selectionsort(array) {
        for (let i = 0; i < array.length - 2; i++) {
            for (let j = i + 1; j < array.length; j++) {
                if (array[i] > array[j]) {
                    array[i] = array[i] + array[j];
                    array[j] = array[i] - array[j];
                    array[i] = array[i] - array[j];
                }

            }

        }
        return array
    }

}
main();









