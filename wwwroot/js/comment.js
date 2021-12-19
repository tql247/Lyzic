$(document).ready(function () {
	const form = document.getElementById("commentForm");

	form.addEventListener("submit", function (event) {
		var dataComment = document.getElementById("commentContent").value;
		var idMusic = document.getElementById("idMusic").value;

		console.log(idMusic);
		$.ajaxSetup({
			cache: false,
		});
		$.ajax({
			async: false,
			global: false,
			url: "/Comment/InsertComment",

			data: {
				idMusic: idMusic,
				content: dataComment,
			},
			success: function (response) {
				if (response == "success") {
					// load comment
					var loadUrl = "/music/details/" + idMusic;
					$(".comment__load").load(loadUrl + " .comment__load");
					$(".comments__title").load(loadUrl + " .comments__title");
					$("#commentContent").val("").empty();
				}
			},
		});
		event.preventDefault();
	});
});
