$(document).ready(function () {
	const form = document.getElementById("commentNotifyForm");

	form.addEventListener("submit", function (event) {
		var dataComment = document.getElementById("commentContent").value;
		var idNotification = document.getElementById("idNotification").value;

		$.ajaxSetup({
			cache: false,
		});
		$.ajax({
			async: false,
			global: false,
			url: "/Comment/InsertCommentNotification",

			data: {
				idNotification: idNotification,
				content: dataComment,
			},
			success: function (response) {
				if (response == "success") {
					// load comment
					var loadUrl = "/notification/details/" + idNotification;
					$(".comment__load").load(loadUrl + " .comment__load");
					$(".comments__title").load(loadUrl + " .comments__title");
					$("#commentContent").val("").empty();
				}
			},
		});
		event.preventDefault();
	});
});
