$(document).ready(function () {
	$(".delete-btn").click(function () {
		var itemId = $(this).data("id");

		if (confirm("Are you sure you want to delete this item?")) {
			$.ajax({
				url: '/Item/Delete/' + itemId,
				type: 'DELETE',
				success: function () {
					$('#row-' + itemId).remove();
				},
				error: function () {
					alert("Failed to delete item.");
				}
			});
		}
	});
	$(".delete-category-btn").click(function () {
		var categoryId = $(this).data("category-id");

		if (confirm("Are you sure you want to delete this category?")) {
			$.ajax({
				url: '/Category/Delete',
				type: 'DELETE',
				data: { categoryId: categoryId },
				success: function () {
					$('#row-' + categoryId).remove();
				},
				error: function () {
					alert("Failed to delete item.");
				}
			});
		}
	});
});