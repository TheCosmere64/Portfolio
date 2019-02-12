<!DOCTYPE html>
<html>
	
</script>
<head>
    <meta charset="UTF-8">
	<link rel="stylesheet" type="text/css" href="style.css">
	<script type="text/javascript" src="script.js"></script>
	<title>Registration Page</title>
</head>
<body>
	<div id="divide">
	<img src="logo.png"/>
	<a href="index.html">Home</a>
	<a href="resultsPage.php">Results</a>
	<a href="itemPage.html">Item</a>
	<a href="regPage.php">Register</a>
	</div>
	<br/>
	<div id="main">
		<h1>This Page Registers Users</h1>
		<form onsubmit="return validateRegister()" action="registrate.php" method="post">
		First Name: <input type="text" name="firstName" id="first name"></input>
		<br/>
		<br/>
		Last Name: <input type="text" name="lastName" id="last name"></input>
		<br/>
		<br/>
		Select Country: <select name="country" id="country">
		<option value="none">-select one-</option>
		<option value="QLD">QLD</option>
		<option value="NSW">NSW</option>
		<option value="SA">SA</option>
		<option value="WA">WA</option>
		<option value="NT">NT</option>
		<option value="VIC">VIC</option>
		<option value="TAS">TAS</option>
		<option value="ACT">ACT	</option>
		</select>
		<br/>
		<br/>
		Date of Birth: 
		<br/>
		Day: <input type="number" name="day" id="day"></input>
		Month: <input type="number" name="month" id="month"></input>
		Year: <input type="number" name="year" id="year"></input>
		<br/>
		<br/>
		Password: <input type="password" name="password" id="password"></input>
		<br/>
		<br/>
		Confirm Password: <input type="password" name="confirmPassword" id="confirm password"></input>
		<br/>
		<br/>
		<input type="submit" value="Register"></input>
		<br/>
		<br/>
		</form>
	</div>
</body>
<footer class="footer">
<p>Brisbane City Wifi. 2018.</p>
</footer>
</html>