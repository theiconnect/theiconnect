debugger;
function getArraySize() {
  let input = prompt("enter a size of an array");
  let arraysize = Number(input);
  while (isNaN(arraysize)) {
    arraysize = prompt("invalid input,pleasev enter a valid input");
  }
  return arraysize;
}

function getArraySizeValidation(size) {
  if (size <= 1) {
    return false;
  }
  else {
    return true;
  }

}

function getArrayElementFromUser(size) {
  let array = []
  for (i = 1; i <= size; i++){

     arrayelement = Number(prompt("enter an array element"));

    while (isNaN(arrayelement)) {
      arrayelement = prompt("invalid input,please enter a valid input");
  }
  array[i - 1] = arrayelement
}
  return array;
}



function bubbleSort(arr) {
    for (let i = 0; i < arr.length; i++) {
        for (let j = 0; j < arr.length - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                let temp = arr[j];     
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
    return arr; 
    }

function main() {
  let size = getArraySize();
  let isValidize = getArraySizeValidation(size);
  if (!isValidize) {
    size = getArraySize();
    isValidize = getArraySizeValidation(size);
  }
  let arr = getArrayElementFromUser(size);
console.log("These is unsorted array")
   console.log(arr)
   let result = bubbleSort(arr);
   console.log("These is sorted array")
   console.log(result);
}



main();