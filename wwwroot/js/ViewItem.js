$(document).ready(function () {
	//star rating interaction
	$('.star-rating label').hover(
		function () {
			$(this).addClass('selected');
			$(this).prevAll('.bi-star-fill').addClass('selected');
		},
		function () {
			$('.star-rating .bi-star-fill').removeClass('selected');
			$('.star-rating input:checked').next('.bi-star-fill').addClass('selected');
			$('.star-rating input:checked').next('.bi-star-fill').prevAll('.bi-star-fill').addClass('selected');
		}
	);

	$('.star-rating input').change(function () {
		$('.star-rating .bi-star-fill').removeClass('selected');
		$(this).next('.bi-star-fill').addClass('selected');
		$(this).next('.bi-star-fill').prevAll('.bi-star-fill').addClass('selected');
	});

	// AJAX for review submission
	$('#reviewForm').submit(function (e) {
		e.preventDefault();
		var formData = $(this).serialize();
		var token = $("input[name='__RequestVerificationToken']").val();

		$.ajax({
			url: '/Review/Add',
			type: 'POST',
			data: formData,
			headers: {
				RequestVerificationToken: token
			},
			success: function (response) {
				if (response.success) {
					location.reload(); // Reload to show new review
				} else {
					alert(response.message);
				}
			},
			error: function (xhr) {
				alert("An error occurred: " + xhr.statusText);
			}
		});
	});

	$(".btn-delete-review").click(function (e) {
		e.preventDefault();
		var $button = $(this);
		var reviewId = $button.data("review-id");
		var token = $("input[name='__RequestVerificationToken']").val();

		if (confirm("Are you sure you want to delete this review?")) {
			$button.prop("disabled", true);
			$.ajax({
				url: '/Review/Delete/' + reviewId,
				type: 'DELETE',
				data: { reviewId: reviewId },
				headers: {
					RequestVerificationToken: token
				},
				success: function (response) {
					if (response.success) {
						$("#review-" + reviewId).remove();

					} else {
						alert(response.message);
					}
				},
				error: function (xhr) {
					alert("An error occurred: " + xhr.statusText);
				},
				complete: function () {
					$button.prop("disabled", false);
				}
			});
		}
	});
});