function validar_password() {
	var password = document.getElementById("password");
	var confirm_password = document.getElementById("confirm_password");
	var submit_button = document.getElementById("submit_button");
	var mensaje_error = document.getElementById("mensaje_error");
	if (password.value == confirm_password.value) {
		mensaje_error.innerText = "";
		submit_button.disabled = false;
	} else {
		mensaje_error.innerText = "Las contraseñas no coinciden.";
		submit_button.disabled = true;
	}
}
