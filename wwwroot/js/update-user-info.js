$(document).ready(function () {
	const Toast = Swal.mixin({
		toast: true,
		position: "top-end",
		showConfirmButton: false,
		timer: 2000,
		timerProgressBar: true,
	});

	const updateNameForm = document.getElementById("updateNameForm");
	const updatePasswordForm = document.getElementById("updatePasswordForm");

	// Submit form change name event
	updateNameForm.addEventListener("submit", function (event) {
		var userID = document.getElementById("userID").value;
		var name = document.getElementById("firstname").value;

		$.ajaxSetup({
			cache: false,
		});
		$.ajax({
			async: false,
			global: false,
			url: "/Account/UpdateNameUser",
			dataType: "json",
			data: {
				userID: userID,
				name: name,
			},
			success: function (response) {
				// Reload change name form
				var loadUrl = "/Account/Profile";
				$(".sign__group--name").load(loadUrl + " .sign__group--name");
				$(".profile__meta").load(loadUrl + " .profile__meta");

				// Toast message
				Toast.fire({
					icon: response.icon,
					title: response.title,
				});
			},
		});

		event.preventDefault();
	});

	// Submit form change password event
	updatePasswordForm.addEventListener("submit", function (event) {
		var userID = document.getElementById("userID").value;
		var oldpass = document.getElementById("oldpass").value;
		var newpass = document.getElementById("newpass").value;
		var confirmpass = document.getElementById("confirmpass").value;

		$.ajaxSetup({
			cache: false,
		});

		$.ajax({
			async: false,
			global: false,
			url: "/Account/UpdatePasswordUser",
			dataType: "json",
			data: {
				userID: userID,
				oldpass: oldpass,
				newpass: newpass,
				confirmpass: confirmpass,
			},
			success: function (response) {
				// Reset input
				$("#oldpass").val("");
				$("#newpass").val("");
				$("#confirmpass").val("");

				// Toast message
				Toast.fire({
					icon: response.icon,
					title: response.title,
				});
			},
		});

		event.preventDefault();
	});
});
