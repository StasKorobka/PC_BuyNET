$(document).ready(function () {
	$(".btn-add-to-cart").click(function (e) {
		e.preventDefault(); // Prevent default button behavior

		var itemId = $(this).data("id");

		$.ajax({
			url: '/Item/Buy',
			type: 'POST',
			data: { itemId: itemId }, // Send itemId as form data
			success: function (response) {

			},
			error: function () {
				alert("An error occurred while adding the item to the cart.");
			}
		});
	});
});