

//      //function UploadImage(formdata) {

//      //    var formdata = formdata;

//      //    $.ajax({
//      //        type: "POST",
//      //        url: '/Master/Upload_ProductImage',
//      //        dataType: "json",
//      //        data: function () {

//      //        }(),
//      //        contentType: "application/json; charset=utf-8",
//      //        success: function (result) {

//      //        }
//      //    });

//      //}


//      $("#ddlCategory").live("change", function () {
//          $("#ddlSubCategory").empty();
//          var Category_Id = $(this).val();

//          $.get("GetSubCategoryList_ByCategoryId", { Category_Id: Category_Id }, function (result) {
//              for (var i in result) {
//                  $("#ddlSubCategory").append("<option value='" + result[i].SubCategoryId + "'>" + result[i].SubCategory + "</option>");

//              }

//          });




//          //$.ajax({
//          //    type: "GET",
//          //    url: 'GetSubCategoryList_ByCategoryId',
//          //    //dataType: "json",
//          //    data: JSON.stringify({ Category_Id: Category_Id }),
//          //    contentType: false,
//          //    processData: false,
//          //    //contentType: "application/json; charset=utf-8",
//          //    success: function (result) {
//          //        debugger;
//          //        var div = "";
//          //        for (var i in result) {
//          //            div += "<option value='" + result[i].SubCategoryId + "'>" + result[i].SubCategory + "</option>"

//          //        }

//          //        $("#Sub_Category_ID").html(div);
//          //    }
//          //});

//      });


//$(document).ready(function () {

//    $("#Btn_AddVariantList").click(function () {

//        $("#varianl_List").find("input[type=text]").each(function () {

//            var inputval = $.trim($(this).val());
//            if (inputval == "") {
//                swal({
//                    title: "Warning!",
//                    text: "Please fill all variant values",
//                    type: "error",
//                    icon: "error",
//                }, function () {
//                    //window.location = "AddProduct";
//                });

//                //$(this).focus();
//                //$(this).first("input[type=text]").focus();
//            }
//            else {

//                $("#varianl_List").find("input[type=text]").each(function () {

//                    if ($(this).val() != "") {
//                        $(this).attr('disabled', 'disabled');
//                    }

//                });

//            }
//        });

//    });

//    $("#addproduct").click(function () {

//        $("#_add_variant").hide();
//        $("#_add_product").show();

//    });
//    $("#addvariant").click(function () {

//        $("#_add_product").hide();
//        $("#_add_variant").show();

//    });

//    $('input[type="file"]').change(function () {

//        var sizefile = Number(this.files[0].size);
//        if (sizefile > 2097152) {
//            var cursive = parseFloat(this.files[0].size / 1048576).toFixed(2);
//            swal({
//                title: "Alert!",
//                text: "Your file size " + cursive + " MB. File size should not exceed 2 MB",
//                type: "info",
//                icon: "info",
//            }, function () {
//                //window.location = "";
//            });

//            $(this).val("");
//            return;
//        }
//        var validfile = ["bmp", "gif", "png", "jpg", "jpeg"];
//        var source = $(this).val();
//        var ext = source.substring(source.lastIndexOf(".") + 1, source.length).toLowerCase();
//        for (var i = 0; i < validfile.length; i++) {
//            if (validfile[i] == ext) {
//                break;
//            }
//        }
//        if (i >= validfile.length) {
//            swal({
//                title: "Alert!",
//                text: "Only following file extention is allowed " + validfile.join(", "),
//                type: "info",
//                icon: "info",
//            }, function () {
//                //window.location = "";
//            });

//            $(this).val("");
//            return;
//        }
//        else {
//            var input = this;
//            var targ = "";

//            if (input.files && input.files[0]) {

//                var filesAmount = input.files.length;
//                var div = "";
//                for (i = 0; i < filesAmount; i++) {
//                    var reader = new FileReader();

//                    reader.onload = function (event) {
//                        div = '<li>'
//                           + '<div class="uploaded-images" style="display: ;">'
//                               + '<img src="' + event.target.result + '" id="" width="100%" height="auto" />'
//                               + '<span class="mdi mdi-close-circle circle-remove"></span>'
//                           + '</div>'
//                       + '</li>'
//                        $("#ulid").append(div);
//                        //$($.parseHTML('<img>')).attr('src', event.target.result).appendTo("#ulid");
//                    }

//                    reader.readAsDataURL(input.files[i]);
//                }

//                //var reader = new FileReader();
//                //reader.onload = function (e) {
//                //    targ = e.target.result;
//                //    // here e.target.result shows the image 

//                //    $(input).parent().parent().hide()
//                //    $(input).parent().parent().next().find(".uploaded-images").show()
//                //    $(input).parent().parent().next().find(".img").attr("src", targ);
//                //};
//                //reader.readAsDataURL(input.files[0])

//            }
//            //var formdata = new FormData();
//            //var file = $(this).get(0).files;
//            //formdata.append(file[0].name, file[0]);
//            //UploadImage(formdata);

//            //$.ajax({
//            //    type: "POST",
//            //    url: '/Master/Upload_ProductImage',
//            //    dataType: "json",
//            //    data: function () {
//            //        debugger;
//            //        var formdata = new FormData();
//            //        var file = $(input).get(0).files;
//            //        formdata.append(file[0].name, file[0]);

//            //        return formdata;
//            //    }(),
//            //    contentType: false,
//            //    processData: false,
//            //    //contentType: "application/json; charset=utf-8",
//            //    success: function (result) {

//            //    }
//            //});

//        }
//    });

//    $(document).on('click', ".circle-remove", function () {
//        $(this).parent().parent().remove();
//        $(this).val("");
//    });

//    //$(".circle-remove").click(function () {

//    //    //$(this).parent().hide();
//    //    //$(this).parent().parent().prev().show();
//    //    //$(this).val("");
//    //});


//    $("#Btn_AddProduct").click(function () {

//        $('form').validate();

//        if ($('form').valid()) {

//            ShowLoader();

//            var Category_ID = $.trim($("#ddlCategory").val());
//            var Sub_Category_ID = $.trim($("#ddlSubCategory").val());
//            var Product_Variant_Id = $.trim($("#ddlProduct_Variant").val());
//            var Brand = $.trim($("#txtBrandName").val());
//            var Product_Name = $.trim($("#txtProductName").val());
//            var Product_Code = $.trim($("#txtProductCode").val());
//            var Price = $.trim($("#txtProductPrice").val());
//            var Quantity = $.trim($("#txtProductQuantity").val());
//            var Discount = $.trim($("#txtProductDiscount").val());
//            //var Description = $.trim($("#txtProductDescription").val());
//            var Description = CKEDITOR.instances.txtProductDescription.getData();
//            //Description = JSON.stringify(Description);

//            //var obj = JSON.stringify({
//            //    Category_ID: Category_ID,
//            //    Brand: Brand,
//            //    Product_Name: Product_Name,
//            //    Product_Code: Product_Code,
//            //    Price: Price,
//            //    Quantity: Quantity,
//            //    Discount: Discount,
//            //    Description: Description,
//            //})

//            //var qString = '?Category_ID=' + Category_ID + '&Brand=' + Brand + '&Product_Name=' + Product_Name + '&Product_Code=' + Product_Code + '&Price=' + Price + '&Quantity=' + Quantity + '&Discount=' + Discount + '&Description=' + Description;

//            $("#Btn_AddProduct").attr('disabled', 'disabled');
//            $("#Btn_AddProduct").html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>Loading...');
//            debugger;
//            $.ajax({
//                type: "POST",
//                url: 'AddProductDetails',
//                // url: 'AddProductDetails' + qString,
//                //dataType: "json",
//                //data: obj,
//                data: function () {
//                    var files = $('#fUpload').prop("files");
//                    var formdata = new FormData();
//                    for (var i = 0; i < files.length; i++) {
//                        formdata.append(files[i].name, files[i]);
//                    }

//                    var varcollec = [];
//                    $(".CommonClass").each(function () {
//                        debugger;
//                        if (GlobalVariantType != "4") {

//                            var First_Input = $(this).find('.first').val();
//                            var Second_Input = $(this).find('.second').val();
//                            var Third_Input = $(this).find('.third').val();

//                            //VariantCollection.push({ First_Input: First_Input, Second_Input: Second_Input, Third_Input: Third_Input })
//                            varcollec.push(GlobalVariantText+"|"+First_Input + "|" + Second_Input + "|" + Third_Input);
//                        }
//                        else {

//                            var First_Input = $(this).find('.first').val();
//                            var Second_Input = $(this).find('.second').val();
//                            var Third_Input = $(this).find('.third').val();
//                            var Fourth_Input = $(this).find('.fourth').val();

//                            //VariantCollection.push({ First_Input: First_Input, Second_Input: Second_Input, Third_Input: Third_Input, Fourth_Input: Fourth_Input })
//                            varcollec.push(GlobalVariantText + "|" + First_Input + "|" + Second_Input + "|" + Third_Input + "|" + Fourth_Input);
//                        }

//                    });
//                    debugger;
//                    var VariantCollection = varcollec.join("<|>");

//                    //$('input[type="file"]').each(function () {
//                    //    debugger;
//                    //    if (!$(this).val() == "") {
//                    //        var file = $(this).get(0).files;
//                    //        formdata.append(file[0].name, file[0]);
//                    //    }
//                    //});
//                    formdata.append('Category_ID', Category_ID);
//                    formdata.append('Sub_Category_ID', Sub_Category_ID);
//                    formdata.append('Product_Variant_Id', Product_Variant_Id);
//                    formdata.append('Brand', Brand);
//                    formdata.append('Product_Name', Product_Name);
//                    formdata.append('Product_Code', Product_Code);
//                    formdata.append('Price', Price);
//                    formdata.append('Quantity', Quantity);
//                    formdata.append('Discount', Discount);
//                    formdata.append('Description', Description);
//                    //formdata.append('VariantCollection', JSON.stringify(VariantCollection));
//                    formdata.append('VariantCollection', VariantCollection);

//                    return formdata;
//                }(),
//                contentType: false,
//                processData: false,
//                //contentType: "application/json; charset=utf-8",
//                success: function (result) {

//                    $("#Btn_AddProduct").removeAttr('disabled');
//                    $("#Btn_AddProduct").html('Add Product');

//                    HideLoader();

//                    //var result = JSON.parse(result);
//                    if (result == "done") {

//                        swal({
//                            title: "Success!",
//                            text: "Product added successfully!",
//                            type: "success",
//                            icon: "success",
//                        }, function () {
//                            window.location = "AddProduct";
//                        });

//                    }
//                    else {

//                        swal({
//                            title: "Warning!",
//                            text: "Cannot create product this time please try again later",
//                            type: "error",
//                            icon: "error",
//                        }, function () {
//                            window.location = "AddProduct";
//                        });

//                    }

//                }
//            });

//        }
//        else {
//            $('body, html').animate({ scrollTop: 0 }, 'slow');
//        }

//    });

//});

//$('#ddlCategory').select2({
//    //minimumResultsForSearch: Infinity
//});
//$('#ddlSubCategory').select2({
//    //minimumResultsForSearch: Infinity
//});
//$('#ddlProduct_Variant').select2({
//    //minimumResultsForSearch: Infinity
//});
//var GlobalVariantType = "";
//var GlobalVariantText = "";
//$("#ddlProduct_Variant").on("change", function () {
//    $("#variantTable").hide();
//    $("#Btn_AddVariant").show();
//    $("#txt_firstinput").val("");
//    $("#txt_secondinput").val("");

//    var variantType = $("#ddlProduct_Variant").val();
//    GlobalVariantType = variantType;
//    var variantText = $("#select2-ddlProduct_Variant-container").attr("title");
//    GlobalVariantText = variantText;

//    if (variantType == "4") {
//        $("#_all_first_variant").html("");
//        $("#_all_second_variant").html("");
//        $("#lable_first").text("size");
//        $("#_first_variant").show();
//        $("#_second_variant").show();
//        $("#_variantbutton").show();

//    }
//    else {

//        if (variantText == "Select Variant") {
//            $("#_all_first_variant").html("");
//            $("#_all_second_variant").html("");
//            $("#_second_variant").hide();
//            $("#_first_variant").hide();
//            $("#_variantbutton").hide();
//        }
//        else {
//            $("#_all_first_variant").html("");
//            $("#_all_second_variant").html("");
//            $("#lable_first").text(variantText);
//            $("#_second_variant").hide();
//            $("#_first_variant").show();
//            $("#_variantbutton").show();
//        }

//    }
//});

////$("#btnPlus_First").click(function () {
////    debugger;
////    var variant_array = [];

////    var value = $("#txt_firstinput").val();
////    var arr = variant_array.push(value);
////    $("#_all_first_variant").append("<span class=''>" + value + "</span>");
////    $("#txt_firstinput").val("");
////});

//var first_variant_array = [];
//var second_variant_array = [];
//var arr = [];
//$("#txt_firstinput").keypress(function (e) {
//    if (e.keyCode == "13") {
//        var value = $.trim($("#txt_firstinput").val());
//        first_variant_array.push(value);
//        $("#_all_first_variant").append("<span class=''>" + value + "<a href='javascript:;' class='mdi mdi-close mr-1' id='firstremoveselection'></a></span>");
//        $("#txt_firstinput").val("");
//    }

//});
//$("#txt_secondinput").keypress(function (e) {
//    if (e.keyCode == "13") {
//        var value = $.trim($("#txt_secondinput").val());
//        second_variant_array.push(value);
//        $("#_all_second_variant").append("<span class=''>" + value + "<a href='javascript:;' class='mdi mdi-close mr-1' id='secondremoveselection'></a></span>");
//        $("#txt_secondinput").val("");
//    }

//});

//$("#firstremoveselection").live("click", function () {
//    var removeItem = $(this).parent().text();
//    first_variant_array.splice($.inArray(removeItem, first_variant_array), 1);
//    $(this).parent().remove();
//});
//$("#secondremoveselection").live("click", function () {
//    var removeItem = $(this).parent().text();
//    second_variant_array.splice($.inArray(removeItem, second_variant_array), 1);
//    $(this).parent().remove();
//});
//$("#RemoveVariantFromList").live("click", function () {
//    $(this).parent().parent().remove();
//    var leng = $("#varianl_List").find("tr").length;
//    if (leng == 0) {
//        $("#variantTable").hide();
//    }

//});

//$("#Btn_AddVariant").click(function () {

//    if (GlobalVariantType != "4") {
//        if ($("#_all_first_variant").children().length == 0) {
//            swal({
//                title: "Warning!",
//                text: "Please enter variant value",
//                type: "error",
//                icon: "error",
//            }, function () {
//                //window.location = "AddProduct";
//            });

//            return false;
//        }

//        $("#dy1").text(GlobalVariantText);
//        $("#dy2").text(GlobalVariantText);
//        $("#dy3").hide();
//        $("#_first_variant").hide();
//        $("#_second_variant").hide();
//        $("#Btn_AddVariant").hide();

//        var final_first_variant_array = (first_variant_array.length > second_variant_array.length ? first_variant_array : second_variant_array);
//        //var final_second_variant_array = (second_variant_array.length < first_variant_array.length ? second_variant_array : first_variant_array);

//        var div = "";
//        for (var i = 0; i < final_first_variant_array.length; i++) {

//            div += "<tr class='CommonClass'>"
//              + "<th class='wd-10'><input type='text' class='form-control' readonly='readonly' value='" + final_first_variant_array[i] + "' /></th>"
//              + "<th class='wd-10'><input type='text' class='form-control first' value='' /></th>"
//              + "<th class='wd-10'><input type='text' class='form-control second' value='' /></th>"
//              + "<th class='wd-10'><input type='text' class='form-control third' value='' /></th>"
//              + "<th class='wd-10'><i class='mdi mdi-delete-forever' id='RemoveVariantFromList'></i></th>"
//              + "</tr>"
//        }

//        $("#varianl_List").html(div);
//        $("#variantTable").show();

//        $("#_all_first_variant").html("");
//        $("#_all_second_variant").html("");

//        first_variant_array = [];
//        second_variant_array = [];


//    }
//    else {

//        if ($("#_all_first_variant").children().length == 0 || $("#_all_second_variant").children().length == 0) {
//            swal({
//                title: "Warning!",
//                text: "Please enter variant value",
//                type: "error",
//                icon: "error",
//            }, function () {
//                //window.location = "AddProduct";
//            });

//            return false;
//        }
//        $("#dy1").text(GlobalVariantText);
//        $("#dy2").text("Size");
//        $("#dy3").show();
//        $("#_first_variant").hide();
//        $("#_second_variant").hide();
//        $("#Btn_AddVariant").hide();

//        var final_first_variant_array = (first_variant_array.length > second_variant_array.length ? first_variant_array : second_variant_array);
//        var final_second_variant_array = (second_variant_array.length < first_variant_array.length ? second_variant_array : first_variant_array);

//        var div = "";
//        for (var i = 0; i < final_first_variant_array.length; i++) {

//            for (var j = 0; j < final_second_variant_array.length; j++) {

//                div += "<tr class='CommonClass'>"
//              + "<th class='wd-10'><input type='text' class='form-control' readonly='readonly' value='" + final_first_variant_array[i] + " / " + final_second_variant_array[j] + "' /></th>"
//              + "<th class='wd-10'><input type='text' class='form-control first' value='' /></th>"
//              + "<th class='wd-10'><input type='text' class='form-control second' value='' /></th>"
//              + "<th class='wd-10'><input type='text' class='form-control third' value='' /></th>"
//              + "<th class='wd-10'><input type='text' class='form-control fourth' value='' /></th>"
//              + "<th class='wd-10'><i class='mdi mdi-delete-forever' id='RemoveVariantFromList'></i></th>"
//              + "</tr>"
//            }

//        }
//        $("#varianl_List").html(div);
//        $("#variantTable").show();

//        $("#_all_first_variant").html("");
//        $("#_all_second_variant").html("");

//        first_variant_array = [];
//        second_variant_array = [];


//    }

//});

