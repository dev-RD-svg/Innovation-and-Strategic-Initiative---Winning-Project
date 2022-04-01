$(document).ready(function () {
	$('.minus').click(function () {
		var $input = $(this).parent().find('input');
		var count = parseInt($input.val()) - 1;
		count = count < 1 ? 0 : count;
		$input.val(count);
		$input.change();
		return false;
	});
	$('.plus').click(function () {
		var $input = $(this).parent().find('input');
		$input.val(parseInt($input.val()) + 1);
		$input.change();
		return false;
	});

	//$('#calculate').click(function (e) {
	//	alert();
	//	e.preventDefault();
	//});


	window.onload = function () {

		document.getElementById("cheesesandwich");
		//document.getElementById("b").innerHTML = "";

	}

});