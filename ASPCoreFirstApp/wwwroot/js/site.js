// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    console.log("Page is ready");

    $(".customerRadio").change(function () {
        console.log("Radio button selected");
        doCustomerUpdate()
    });

    $("#selectCustomer").click(function (event) {
        event.preventDefault();
        console.log("Submit button was clicked");
        doCustomerUpdate();
    });

    function doCustomerUpdate() {
        $.ajax({
            datatype: "text/plain",
            url: 'customer/ShowOnePerson',
            data: $("form").serialize(),
            success: function (data) {
                console.log(data);
                $("#customerInformationArea").html(data);
            }

        });
    };
});