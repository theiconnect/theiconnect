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
  let arr = []
  for (i = 1; i <= size; i++){

     arrayelement = Number(prompt("enter an array element"));

    while (isNaN(arrayelement)) {
      arrayelement = prompt("invalid input,please enter a valid input");
  }
  arr[i - 1] = arrayelement
}
  return arr;
}

function getTargetValue() {
  let targetValue = Number(prompt("enter a target value"));
  while (isNaN(targetValue)) {
    targetValue = prompt("invalid input,please enter a valid input");

  }
  return targetValue;
}

function binarySearch(array, searchValue) 
{
    let low=0;
    let high=array.length-1;
    let mid;
    while(low<=high)
        {
            mid=low+high/2;
            if(array[mid] == searchValue){
               return mid;
            }
             else if(array[mid] < searchValue){
                low=mid+1;
            }
            else{
                high=mid-1;
            }
        }
      return -1;

}

function Result(index, searchValue) {
  if (index == -1) {
    console.log(`search element: ${searchValue} not found in the array`)
  }
  else {
    console.log(`search element: ${searchValue} present at the index ${index}`)
  }
}




function main() {
  let size = getArraySize();
  let isValidize = getArraySizeValidation(size);
  if (!isValidize) {
    size = getArraySize();
    isValidize = getArraySizeValidation(size);
  }
  let array = getArrayElementFromUser(size);
  let searchValue = getTargetValue();
  let index = binarySearch(array, searchValue);
  Result(index, searchValue);


}
main();