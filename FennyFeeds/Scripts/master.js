function ShowLoader() {
    $(".loader").show();
    return false;
}

function HideLoader() {
    $(".loader").hide();
    return true;
}

$('select').on('select2:select', function (evt) {
    //debugger;
    //if ($(this).parent().find(".select2-container--default .select2-selection--single").children().attr("title") == "Select") {
    //    //$(this).find("field-validation-valid").html("please");
    //    $(this).parent().find(".select2-container--default .select2-selection--single").css("border", "1px solid red");
    //}
    //else {
    //    $(this).blur();
    //    $(this).parent().find(".select2-container--default .select2-selection--single").css("border", "");
    //}
    $(this).blur();
    $(this).parent().find(".select2-container--default .select2-selection--single").css("border", "");
});

$(document).ready(function () {

    /////////FOOTER SUBSCRIPTION START/////////
    $("#Btn_Subscription").click(function () {
        try {

            $('#form1').validate();

            if ($('#form1').valid()) {
                ShowLoader();

                $("#Btn_Subscription").attr('disabled', 'disabled');
                $("#Btn_Subscription").html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>');
                ShowLoader();
                var Email_Id = $.trim($("#txtSub_Email").val());
                var obj = {
                    Email_Id: Email_Id
                }
                $.ajax({
                    type: "POST",
                    url: "/Master/Suscribe",
                    data: obj,
                    //contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {

                        $("#Btn_Subscription").removeAttr('disabled');
                        $("#Btn_Subscription").html('<span class="mdi mdi-send"></span>');

                        HideLoader();

                        //var result = JSON.parse(result);
                        if (result == "done") {

                            swal({
                                title: "Success!",
                                text: "You have successfully subscribed to our newsletter!",
                                type: "success",
                                icon: "success",
                            }, function () {
                                //window.location = "DonateBlood";
                                $("#txtSub_Email").val("");
                            });

                        }
                        else if (result == "emailexist") {

                            swal({
                                title: "Alert!",
                                text: "You have already subscribe to our newsletter!",
                                type: "info",
                                icon: "info",
                            }, function () {
                                //window.location = "DonateBlood";
                                $("#txtSub_Email").val("");
                            });

                        }
                        else {

                            swal({
                                title: "Error!",
                                text: "Cannot subscribe this time please try again later",
                                type: "error",
                                icon: "error",
                            }, function () {
                                //window.location = "DonateBlood";
                                $("#txtSub_Email").val("");
                            });

                        }

                    }
                });

            }
            else {
                ShowLoader();
                $("#txtSub_Email").focus();
            }


        } catch (e) {

        }

    });
    /////////FOOTER SUBSCRIPTION END/////////

});



/////////PRODUCT QUICK VIEW MODEL POPUP START/////////
function Get_ProductQuickView(Product_ID) {
    ShowLoader();
    try {
        var url = '../Master/ProductQuickView?Product_ID=' + Product_ID;// '@Url.Action("GetProductRecordsForEdit?Record_ID=")';

        $("#loadproductquickview").load(url, function () {
            HideLoader();
            $("#productquickviewmodal").modal("show");

            //$('#myCarousel').carousel({
            //    interval: 5000
            //});

            ////Handles the carousel thumbnails
            //$('[id^=carousel-selector-]').click(function () {
            //    var id = this.id.substr(this.id.lastIndexOf("-") + 1);
            //    var id = parseInt(id);
            //    $('#myCarousel').carousel(id);
            //});

            //// When the carousel slides, auto update the text
            //$('#myCarousel').on('slid.bs.carousel', function (e) {
            //    var id = $('.item.active').data('slide-number');
            //    $('#carousel-text').html($('#slide-content-' + id).html());
            //});

        })

    } catch (e) {

    }

}
/////////PRODUCT QUICK VIEW MODEL POPUP END/////////

/////////PRODUCT DETAILS START/////////
function Get_ProductDetails() {
    try {
        //ShowLoader();
        $.ajax({
            type: "GET",
            url: '../Master/Get_ProductDetails',
            dataType: "json",
            contentType: false,
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                //HideLoader();

                $("#displayfeatureds").html(result);

            }
        });


    } catch (e) {

    }

}
/////////PRODUCT DETAILS END/////////


/////////ADD WISHLIST START/////////
/////////Add product to wishlist/////
function AddToWishList(Product_ID) {
    debugger;
    ShowLoader();
    try {
        $.ajax({
            type: "POST",
            url: "../Master/AddToWishList?Product_ID=" + Product_ID,
            //data: obj,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                HideLoader();
                debugger;
                if (result.Action == "done") {

                    swal({
                        title: "Success!",
                        text: result.msg,
                        type: "success",
                        icon: "success",
                    });

                }
                else if (result.Action == "notlogin") {

                    swal({
                        title: "Alert!",
                        text: result.msg,
                        type: "info",
                        icon: "info",
                    });

                }
                else {

                    swal({
                        title: "Error!",
                        text: result.msg,
                        type: "error",
                        icon: "error",
                    });

                }
            }
        });

    } catch (e) {

    }
}
/////////ADD WISHLIST END/////////


/////////HOME PAGE START/////////
/////////Fetching all featured product////////
function Get_AllFeaturedProducts() {
    //ShowLoader();
    $.ajax({
        type: "GET",
        url: 'Get_All_FeaturedProducts',
        dataType: "json",
        contentType: false,
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            //HideLoader();
            if (result == "") {
  //              <div class="alert alert-danger alert-dismissible">
  //  <button type="button" class="close" data-dismiss="alert">&times;</button>
  //  <strong>Danger!</strong> This alert box could indicate a dangerous or potentially negative action.
  //</div>
                var div = "<div class='text-center'><img src='../content/images/no-record-found.png' style='margin-bottom:20px;' width='500px;' alt='...'><div class='alertBox'><span role='alert' class='alert alert-secondary alert-dismissible'> No Record Found </span></div></div>"
                $("#displayfeatureds").html(div);
            }
            else {
                $("#displayfeatureds").html(result);

                $('.owl-carousel').owlCarousel({
                    loop: true,
                    margin: 5,
                    nav: true,
                    dots: false,
                    autoplay: true,
                    //autoplayTimeout: 5000,
                    autoplayHoverPause: true,
                    responsive: {
                        0: {
                            items: 1
                        },
                        600: {
                            items: 2
                        },
                        1000: {
                            items: 5
                        }
                    }
                });

            }

            //$('.owl-carousel').owlCarousel('add', '<markup>').owlCarousel('refresh')
            //$('.owl-carousel').find('.owl-nav').removeClass('disabled');
            //$('.owl-carousel').on('changed.owl.carousel', function (event) {
            //    $(this).find('.owl-nav').removeClass('disabled');
            //});

        }
    });


}
/////////HOME PAGE END/////////


/////////SESSION START/////////
/////////If Session is not valid then show message otherwise redirect to wishlist page
function Check_LoginOrNotForWishList(Session) {
    try {

        if (Session != "") {
            window.location = "../WishList/Wishlist";
        }
        else {

            swal({
                title: "Error!",
                text: "You must login or create an account to see your wish list!",
                type: "error",
                icon: "error",
            });

        }
        //$.ajax({
        //    type: "get",
        //    url: "../Master/CheckLoginOrNotForWishList",
        //    //data: obj,
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    success: function (result) {
        //        HideLoader();
        //        debugger;
        //        if (result == true) {
        //            window.location = result.msg;
        //        }
        //        else if (result == false) {

        //            swal({
        //                title: "Error!",
        //                text: result.msg,
        //                type: "error",
        //                icon: "error",
        //            });

        //        }

        //    }
        //});

    } catch (e) {

    }
}
/////////SESSION END/////////


/////////SESSION START/////////
function Check_UserLoginOrNot(action, Session, ProductID) {
    try {
        debugger;
        if (action == "redirect_to_wishlist") {

            if (Session != "") {
                window.location = "../WishList/Wishlist";
            }
            else {

                swal({
                    title: "Error!",
                    text: "You must login or create an account to see your wish list!",
                    type: "error",
                    icon: "error",
                });

            }

        }
        else if (action == "addproduct_to_wishlist") {

            if (Session != "") {
                AddToWishList(ProductID);
            }
            else {

                swal({
                    title: "Error!",
                    text: "You must login or create an account to save this item to your wish list!",
                    type: "error",
                    icon: "error",
                });

            }

        }
        //else if (action == "addproduct_to_wishlist") {

        //}




    } catch (e) {

    }
}
/////////SESSION END/////////


/////////WISHLIST START/////////
function Get_WishList() {
    debugger;
    ShowLoader();

    try {
        $.ajax({
            type: "GET",
            url: '../WishList/Get_Wish_List',
            dataType: "json",
            contentType: false,
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                HideLoader();
                debugger;
                //if (result == "session_expire") {
                //    window.location = "../Home/Home";
                //}
                //else
                if (result == "") {
                    $("#_wishlist").html("<div><span>Empty Wishlist</span><img class='responsive' alt='' src='../content/images/s1.jpg'></div>");
                }
                else {
                    $("#_wishlist").html(result);
                }

            }
        });

    } catch (e) {

    }
}
/////////WISHLIST END/////////












