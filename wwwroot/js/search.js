$(document).ready(function () {
	const searchWrapper = document.querySelector(".header__search");
	const inputBox = document.querySelector("#txtSearch");
	const suggestBox = document.querySelector(".suggest__box");

	// Suggest when type input
	inputBox.onkeyup = (e) => {
		let userData = e.target.value;
		let suggestArray = [];

		if (userData) {
			suggestArray = (function () {
				var array = [];
				$.ajax({
					async: false,
					global: false,
					url: "/Search/SearchArtist",
					dataType: "json",
					data: {
						term: userData,
					},
					success: function (response) {
						array = response;
					},
				});

				$.ajax({
					async: false,
					global: false,
					url: "/Search/SearchMusic",
					dataType: "json",
					data: {
						term: userData,
					},
					success: function (response) {
						array = array.concat(response);
						console.log(response);
					},
				});
				return array;
			})();

			suggestArray.forEach((element) => {
				element.item =
					'<li class="suggest__item"><a href="' +
					element.Link +
					'" class="suggest__link">' +
					element.Name +
					"</a></li>";
			});
			searchWrapper.classList.add("active");
		} else {
			searchWrapper.classList.remove("active");
		}
		suggestList(suggestArray);
	};

	// Add suggest data list to html
	function suggestList(list) {
		let listData = "";

		if (!list.length) {
			let userValue = inputBox.value;
			listData =
				'<li class="suggest__item"><a href="#" class="suggest__link">' +
				userValue +
				"</a></li>";
		} else {
			list.forEach((element) => {
				listData = listData.concat(element.item);
			});
		}
		suggestBox.innerHTML = listData;
	}

	// Click to show suggest if having user data
	$("#txtSearch").click(function () {
		let userValue = inputBox.value;
		if (userValue) {
			searchWrapper.classList.add("active");
		}
	});

	// Click outside input -> hide suggest box
	$(document).mouseup(function (e) {
		var suggest_box = $(".suggest__box");
		if (!suggest_box.is(e.target) && suggest_box.has(e.target).length === 0) {
			searchWrapper.classList.remove("active");
		}
	});
	// $("#txtSearch").autocomplete({
	// 	source: function (request, response) {
	// 		$.ajax({
	// 			url: "/Artist/GetArtist",
	// 			dataType: "json",
	// 			data: {
	// 				term: request.term,
	// 			},
	// 			success: function (result) {
	// 				for (var k in result) {
	// 					console.log(result[k]);
	// 				}
	// 			},
	// 		});
	// 	},

	// 	minLength: 1,
	// });
});
