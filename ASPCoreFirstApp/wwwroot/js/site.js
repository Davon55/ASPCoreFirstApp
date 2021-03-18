// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    //this button click fills the modal form iwth data and displays it.
    $(document).on("click", ".edit-product-button", function (event) {
        event.preventDefault();


        //get the existing data from the current record 
        var myProductId = $(this).data('id');
        var myProductName = $(this).parent().find('.product-name').html();
        var myProductPrice = $(this).parent().find('.product-price').html().replace("$", "");
        var myProductDescription = $(this).parent().find('.product-description').html();


        console.log("clicked button #" + myProductId);
        console.log("name = " + myProductName);
        console.log("price = " + myProductPrice);
        console.log("desc = " + myProductDescription);

        //fil in the data entry form 
        $(".modal-dialog #Id").val(myProductId);
        $(".modal-dialog #Name").val(myProductName);
        $(".modal-dialog #Price").val(myProductPrice);
        $(".modal-dialog #Description").val(myProductDescription);

    });

    //respond to the modal's save button
    $("#save-product").click(function () {
        //create a JSON object in order to submit the new changes to the controller
        var Product = {
            "Id": $('#Id').val(),
            "Name": $('#Name').val(),
            "Price": $('#Price').val(),
            "Description": $('#Description').val()
        };
        console.log(Product)
        doProductUpdate(Product)

        function doProductUpdate(product){
            $.ajax({
                dataType: "json",
                url: '/products/ProcessEditReturnOneItem',
                data: product,
                success: function (data) {
                    //we should see a _productCard HTML printed to the console
                    console.log(data);
                    //target the correct product card by using its id number
                    $("#card-number-" + Product.Id).html(data);
                }
            });
        };
    });
});