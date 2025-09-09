debugger;
function getArraySize(){
    let input = prompt("Enter the size of the array:");
    let arraySize = Number(input)
    while(isNaN(arraySize)){
        arraySize =prompt("Invalid input,Please Enter the correct size of the array:");
    }
    return arraySize;
}

function getValidationArraySize(size){
    if(size <= 1){
        return false
    }
    else{
        return true
    }
}

function getArrayElementsFromUser(size){
    let arr=[]
    for(let i = 1 ; i<=size;i++){
        arrUserInput = Number(prompt(`Enter the element ${i}`))
        while(isNaN(arrUserInput)){
            arrUserInput = prompt("Please Enter the correct Element:"+i)
        }
        arr[i-1]= arrUserInput
    }
    return arr;

}

function Selectionsort(array){
    for(i=0;i<=array.length-2;i++){
        for(j=i+1;j<=array.length;j++){
            if(array[i] > array[i+1]){
                let temp = array[i]
                array[i] = array[i+1]
                array[i+1] = temp
            }
        }
    }
    return array;
}

function main(){
    let size = getArraySize();
   let isValidSize = getValidationArraySize(size);
   while(!isValidSize){
        size = getArraySize();
        isValidSize = getValidationArraySize(size);
   }
   let array = getArrayElementsFromUser(size);
   console.log("These is unsorted array")
   console.log(array)
   let result = Selectionsort(array);
   console.log("These is sorted array")
   
}
main();