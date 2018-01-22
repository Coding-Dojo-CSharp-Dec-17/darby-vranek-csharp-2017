$(document).ready(function() {
	$("#search_form").submit(function(event) {
		event.preventDefault();
		var settings = {
			"async": true,
			"api_key": "0861ba80923a19dd74d42cc74132fb38",
			"crossDomain": true,
			"url": "https://api.themoviedb.org/3/search/movie",
			"method": "GET",
			"data": {
				"query": $("input:first").val(),
				"api_key": "0861ba80923a19dd74d42cc74132fb38"
			}
		}
		$.ajax(settings).done(function(response) {
			if (response["results"].length != 0)
			{
				var title = response["results"][0]["title"];
				var rating = response["results"][0]["vote_average"];
				var release_date = new Date(response["results"][0]["release_date"]).toLocaleDateString("en-US", { month: "long", day: "numeric", year: "numeric" });
				$.post("Search", { title: title, rating: rating, release_date: release_date });
				$("#results").prepend(`
				<tr>
					<td>${title}</td>
					<td>Rating: ${rating}</td>
					<td>Released ${release_date}</td>
				</tr>`);
			}
		});
	});
});