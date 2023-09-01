// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
	$("#SaveButton").click(function (e) {
		var vm = {};
		vm.Channels = new Array();
		channelsBlock = document.querySelector('#Channels');
		var channels = channelsBlock.children;
		for (var i = 0; i < channels.length; i++) {
			var channel = {};
			channel.Id = channels[i].getAttribute('id');
			channel.ImageUrl = channels[i].querySelector('#ImageUrl').getAttribute('src');
			channel.Title = channels[i].querySelector('#Title').textContent;
			channel.IsSelected = channels[i].querySelector('#IsSelected').checked;
			vm.Channels.push(channel);
		}

		vm.Rules = new Array();
		vm.Rules.push({
			Name: 'Name',
			RegexPattern: 'None',
			Channel: {
				Id: 'Test_Id',
				Title: 'Test',
				ImageUrl: 'None',
			},
		})

		$.ajax({
			url: "Home/Save",
			type: "POST",
			dataType: 'json',
			data: { indexVM: vm }
			,
			success: function (response) {
				alert("Success");
			},
			// error: function (xhr, status, error) {
			//     alert("Failed");
			// },
		});
	});
});

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
			document.getElementById("Birthday").value = response.birthday.split('T')[0];
			document.getElementById("PhoneNumber").value = response.phoneNumber;
			document.getElementById("Email").value = response.email;
			document.getElementById("VkId").value = response.vkId;
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