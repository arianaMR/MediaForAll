sabio.ui.displayExceptions = sabio.ui.displayExceptions || {};

sabio.ui.displayExceptions = function (errors, displayDiv) {
	var errorHtml;
	for (var i = 0; i < errors.length; i++) {
		errorHtml = "<li>" + errors[i] + "</li>";
		displayDiv.append(errorHtml);
	}
};
