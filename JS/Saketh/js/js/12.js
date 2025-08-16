let input = prompt("enter the number:")
let marks
while (isNaN(marks) == true){
	input = prompt("invalid input please enter the correct input:")
}
marks= Number(input)	
if(marks > 0 && marks < 101){
	if(marks >= 90 && marks <= 100){
		console.log("Your Grade is A")
	}
	else if( marks >=80 && marks <= 89){
		console.log("Your Grade is B")
	}
	else if( marks >= 70 && marks <= 79){
		console.log("Your Grade is C")
	}
	else if( marks >= 60 && marks <= 69){
		console.log("Your Grade is D")
	}
	else{
		console.log("Your Grade is F")
	}

}
else{
	console.log("Please enter a number between 0-100")
}
