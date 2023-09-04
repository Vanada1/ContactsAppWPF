// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function SelectedChanged() {
	var e = document.getElementById("SelectionContact");
	var id = e.options[e.selectedIndex].id;

	$.ajax({
		url: "Home/GetContact",
		type: "POST",
		dataType: 'json',
		data: { id: id }
		,
		success: function (response) {
			document.getElementById("LastName").value = response.lastName;
			document.getElementById("FirstName").value = response.firstName;
			document.getElementById("PhoneNumber").value = response.phoneNumber;

			if (response.birthday != null) {
				document.getElementById("Birthday").value = response.birthday.split('T')[0];
			} else {
				document.getElementById("Birthday").value = null;
			}

			if (response.email != null) {
				document.getElementById("Email").value = response.email;
			} else {
				document.getElementById("Email").value = "";
			}

			if (response.vkId != null) {
				document.getElementById("VkId").value = response.vkId;
			} else {
				document.getElementById("VkId").value = "";
			}
		},
		error: function (xhr, status, error) {
		    alert("Failed");
		},
	});
}

function EditContact() {
	var e = document.getElementById("SelectionContact");
	var id = e.options[e.selectedIndex].id;
	window.location.href = 'Home/EditContact/' + id;
}

function RemoveContact() {
	var e = document.getElementById("SelectionContact");
	var id = e.options[e.selectedIndex].id;
	$.ajax({
		url: "Home/RemoveContact",
		type: "GET",
		dataType: 'json',
		data: { id: id }
		,
		success: function (response) {
			window.location.href = '';
		},
		error: function (xhr, status, error) {
			alert("Failed");
		},
	});
}