<html>
<?php
require 'validate.php';
$errors = array();
validateEmail($errors, $_POST, 'email');
if ($errors) {
echo 'Errors:<br/>';
foreach ($errors as $field => $error){
echo "$field $error</br>";
}
} else {
echo 'Data OK!';
}
if (isset($_POST['email'])) {
validateEmail($errors, $_POST, 'email');
if ($errors) {
echo '<h1>Invalid, correct the following errors:</h1>';
foreach ($errors as $field => $error) {
echo "$field $error<br>";
}
// redisplay the form
include 'wrjeifsdacvkmns.php';
} else {
echo 'form submitted successfully with no errors';
}
} else {
include 'wrjeifsdacvkmns.php';
}
?>
</html>