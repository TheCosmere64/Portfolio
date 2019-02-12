/*
function validate(){
	if(checkName() == false){
		return false;
	}
	else if(checkSuburb() == false){
		window.alert("No suburb Selected");
		return false;
	}
	else{
		return true;
	}
}
	
	
function checkSuburb(){

	if(document.getElementById("suburb").options[document.getElementById("suburb").selectedIndex].value == "none"){
		window.alert("Select a suburb");
		return false;
	}	
	else{
		return true;
	}
}

function checkName(){
	
	if(document.getElementById("name").value == ""){
		window.alert("Enter your name");
		return false;
	}
	else{
		return true;
	}
}
*/
function validateSearch(){
	if(checkName("first name") == false){
		return false;
	}
	else if(checkLocation("suburb") == false){	
		return false;
	}
	else{
		return true;
	}
}

function validateRegister(){
	if(checkName("first name") == false){
		return false;
	}
	else if(checkName("last name") == false){
		return false;
	}
	else if(checkLocation("country") == false){	
		return false;
	}
	else if(checkDate() == false){
		return false;
	}
	else if(checkPassword() == false){
		return false;
	}
	else{
		window.alert("You have been registered!");
		return true;
	}
}	
	
function checkDate(){
	var day = document.getElementById("day").value
	var month = document.getElementById("month").value
	var year = document.getElementById("year").value
	
	window.alert
	
		if(day == "" || day > 31 || (month == 2 && day > 27) || ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30)){
			window.alert("Enter valid day");
			return false;
		}
		else if(month == "" || month > 12 || month < 0){
			window.alert("Enter valid month");
			return false;
		}
		else if(year == "" || year < 1900 || year > 2018){
			window.alert("Enter Valid Year");
			return false;
		}
		else{
			return true;
		}
}
	
function checkLocation(item){

	if(document.getElementById(item).options[document.getElementById(item).selectedIndex].value == "none"){
		window.alert("Select a " + item);
		return false;
	}	
	else{
		return true;
	}
}

function checkName(item){

	if(document.getElementById(item).value == ""){
		window.alert("Enter your " + item);
		return false;
	}
	else{
		return true;
	}
}

function checkPassword(){
	if(document.getElementById("password").value == ""){
		window.alert("Please enter password");
		return false;
	}
	else if(document.getElementById("password").length < 8 || document.getElementById("password").length > 15){
		window.alert("Password must be between 8 and 15 characters");
		return false;
	}
	else if(document.getElementById("password").value != "" && document.getElementById("confirm password").value == ""){
		window.alert("Please confirm your password");
		return false;
	}
	else if(document.getElementById("confirm password").value != document.getElementById("password").value){
		window.alert("Password does not match");
		return false;
	}
	else{
		return true;
	}
	
	
}