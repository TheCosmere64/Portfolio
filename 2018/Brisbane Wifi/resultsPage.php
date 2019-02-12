<html>
<head>
    <meta charset="UTF-8">
	<link rel="stylesheet" type="text/css" href="style.css?d=<?php echo time(); ?>">
	<title>Search Results Page</title>
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
	<?php 
		$title = $_POST['firstName']
	?>
	
	<h1>Welcome <?php  print_r($title); ?></h1>
		<form>
		
		</form>
		
<div id="results">

<div id="td"> <img src="Roma-Street-Parklands-Playground-7.jpg">

<br/> <h3> Roma Street Parkland </h3>

<br/> Co-ordinates: <br/> <h3> -27.461694, 153.017868 </h3>

<br/> Rating: <br/> <img id="rating" src="download.png"></img>

<a href="itemPage.html">More information</a> 

 </div>



<div id="td"> <img src="img16722.jpg">

	<br/><h3> Oriel Park </h3>	
	
	<br/> Co-ordinates: <br/> <h3> -27.429368, 153.057685 </h3>
	
	<br/> Rating: <br/> <img id="rating" src="download.png"></img>
	
	<a href="itemPage.html">More information</a> 

</div>

<div id="td"> <img src="download.jpg">

	<br/> <h3> Queens Street Mall </h3>
	
	<br/> Co-ordinates: <br/> <h3> -27.469382, 153.025197 </h3>
	
	<br/> Rating: <br/> <img id="rating" src="download.png"></img>
	
	<a href="itemPage.html">More information</a> 
	
</div>
</div>
</div>
</body> 
<footer class="footer">
<p>Brisbane City Wifi. 2018.</p>
</footer>
</html>