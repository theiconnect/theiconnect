let x = prompt('enter the number x is :')
let y = prompt('enter the number y is :')
let z = prompt('enter the number z is :')
debugger;
if(x == y && y == z){
    console .log('All are equal');
}
else{
    if(x>=y && x>=z){
        console.log("x is largest :",x);
    }
    else if(y>=x && y>=z){
        console.log('y is largest :',y)
    }
    else{
        console.log('z is largest :',z)
    }
}
