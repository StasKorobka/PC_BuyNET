$(document).ready(function () {
	$(".btn-delete-wishlist").click(function (e) {
		e.preventDefault();
		var $button = $(this);
		var wishlistItemId = $button.data("wishlist-item-id");
		var token = $("input[name='__RequestVerificationToken']").val();

		if (confirm("Are you sure you want to remove this item from your wishlist?")) {
			$button.prop("disabled", true);
			$.ajax({
				url: '/Wishlist/Delete',
				type: 'DELETE',
				data: { wishlistItemId: wishlistItemId },
				headers: {
					RequestVerificationToken: token
				},
				success: function (response) {
					if (response.url) {
						window.location.href = response.url;
					} else {
						$button.closest(".card").remove();
						//alert("Item removed from wishlist successfully.");
						if ($(".card").length === 0) {
							$(".row").replaceWith("<p>Your wishlist is empty.</p>");
						}
					}
				},
				error: function (xhr) {
					alert("An error occurred: " + xhr.statusText);
					if (xhr.status === 401) {
						window.location.href = "/Identity/Account/Login";
					}
				},
				complete: function () {
					$button.prop("disabled", false);
				}
			});
		}
	});
});