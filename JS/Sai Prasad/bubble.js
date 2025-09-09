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
    let sort = bubblesort(array);
    console.log(array);


    function getArraySize() {
        let input = prompt('please enter size of an array');
        let arraySize = Number(input);
        while (isNaN(arraySize)) {
             arraySize = prompt('please enter a valid input')
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
    function bubblesort(array){
        for(let i=0;i<array.length-1;i++){
            for(let j=0;j<array.length;j++){
                if(array[j]>array[j+1]){
                    array[j] = array[j] + array[j+1]
                    array[j+1] = array[j] - array[j+1]
                    array[j] = array[j] - array[j+1]
                }
            }
        }
        return array;
    }
}
main();