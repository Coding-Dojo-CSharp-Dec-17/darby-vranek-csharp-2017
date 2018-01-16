// Write your Javascript code.
$(document).ready(function() {
	$(".title_text").change(function() {
		$.ajax({
			url: "Update",
			data: { field: "title", text: $(this).val(), id: $(this).parent().prop("id") },
			method: "POST"
		});
	});
	$(".description_text").change(function() {
		$.ajax({
			url: "Update",
			data: { field: "description", text: $(this).val(), id: $(this).parent().prop("id") },
			method: "POST"
		});
	});
	$(".delete").click(function() {
		$.ajax({
			url: "Delete",
			data: { id: $(this).val() },
			method: "POST"
		});
		$(this).parent().remove();
	});
});