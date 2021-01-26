
function uploadImage() {
    // Checking whether FormData is available in browser
    if (window.FormData !== undefined) {

        var fileUpload = $("#ImageFile").get(0);
        var files = fileUpload.files;

        // Create FormData object
        var fileData = new FormData();

        // Looping over all files and add it to FormData object
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }

        // Adding one more key to FormData object
        fileData.append('username', 'Manas');

        $.ajax({
            url: '/Admin/UploadImage',
            type: "POST",
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            data: fileData,
            success: function (result) {
                if (result != "No file selected.")
                    $('#ImageName').val(result);
                var $el = $('#ImageFile');
                $el.wrap('<form>').closest('form').get(0).reset();
                $el.unwrap();
            },
            error: function (err) {
                alert(err.statusText);
            },
            async: false
        });
    } else {
        alert("FormData is not supported.");
    }
}

function getItems(catId, itemsPerPage, pageNum) {
    pageNum = typeof pageNum !== 'undefined' ? pageNum : 0;
    $.ajax({
        url: "/api/Items/" + catId + "/" + itemsPerPage + "/" + pageNum,
        type: "GET",
        contentType: "application/json ; charset=utf-8",
        dataType: "JSON",
        success: function (data) {
            $("#items").html("");
            var sb = new StringBuilder();
            for (var i = 0; i < data.length; i = i + 3) {
                var row = "<div class='agile_top_brands_grids'>" + "</div>";
                $("#items").append(row);
                var item = "";
                var j = i;
                var k = 3;
                while (k > 0) {
                    sb.append("<div class='col-md-4 top_brand_left'>");
                    sb.append("<div class='hover14 column'>");
                    sb.append("<div class='agile_top_brand_left_grid'>");
                    sb.append("<div id='icones'>");
                    sb.append("<div id='removeIcone'><i class='fas fa-remove' value=" + data[j].ID + " ></i></div>");
                    sb.append("</div>");
                    sb.append("<div class='agile_top_brand_left_grid1'>");
                    sb.append("<figure>");
                    sb.append("<div class='snipcart-item block'>");
                    sb.append("<div class='snipcart-thumb'>");
                    sb.append("<a href='#' onclick='return false'><img title=' ' alt=' ' src='/images/" + data[j].Image + "' width='150' height='150'></a>");
                    sb.append("<p>" + data[j].Name + "</p>");
                    sb.append("<h4>$" + data[j].Price + "</h4>");
                    sb.append("</div>");
                    sb.append("<div class='snipcart-details top_brand_home_details'>");
                    sb.append("<button type='button' id='editItem' class='btn btn-warning form-control' value=" + data[j].ID + "><i class='fas fa-edit'></i> Edit</button>");
                    sb.append("</div>");
                    sb.append("</div>");
                    sb.append("</figure>");
                    sb.append("</div>");
                    sb.append("</div>");
                    sb.append("</div>");
                    sb.append("</div>");
                    item = sb.toString();
                    $(".agile_top_brands_grids:last-child").append(item);
                    sb.clear();
                    j++;
                    k--;
                    if (j == data.length)
                        break;
                }
                $(".agile_top_brands_grids:last-child").append("<div class='clearfix'> </div>");
            }
        },
        async: false
    });
}

$(function () {
    //Add item
    $("#btnAdd").click(function () {
        uploadImage();
        var formdata = {
            CategoryID: $("#CategoryDDL").val(),
            Name: $("#txtName").val(),
            Image: $("#ImageName").val(),
            Price: $("#txtPrice").val(),
            IsAvailable: true
        }
        $.ajax({
            url: "/api/AddItem",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "JSON",
            data: JSON.stringify(formdata),
            success: function (data) {
                $("ul.cate li#" + data.CategoryID + "").trigger("click");
                getItems(data.CategoryID, $(".itemsPerPage").val(), $("ul.pagination li.active").val());
                updateNumOfItemsAndNumOfPages();
                createPaginationLinks(numOfPages);
                $("ul.pagination li.active").trigger("click");
                $("#btnCancel").trigger("click");
            },
            error: function (e) {
                alert(e.responseText);
            },
            async: false
        });
    });

    //Edit item
    $(document).on("click", "#editItem", function () {
        $.ajax({
            url: "/api/GetItem/" + $(this).attr("value"),
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "JSON",
            success: function (data) {
                $("#ID").val(data.ID);
                $("#CategoryDDL").val(data.CategoryID);
                $("#txtName").val(data.Name);
                $("#ImageName").val(data.Image);
                $("#txtPrice").val(data.Price);
                $("#btnAdd").css("display", "none");
                $("#btnSave, #btnCancel").css("display", "block");
            },
            error: function (e) {
                alert(e.responseText);
            },
            async: false
        });
    });

    //Update item
    $("#btnSave").click(function () {
        uploadImage();
        var formdata = {
            ID: $("#ID").val(),
            CategoryID: $("#CategoryDDL").val(),
            Name: $("#txtName").val(),
            Image: $("#ImageName").val(),
            Price: $("#txtPrice").val(),
            IsAvailable: true
        }
        $.ajax({
            url: "/api/UpdateItem/" + $("#ID").val(),
            type: "PUT",
            contentType: "application/json; charset=utf-8",
            dataType: "JSON",
            data: JSON.stringify(formdata),
            success: function () {
                getItems($("ul.cate li.active").attr("id"), $(".itemsPerPage").val(), $("ul.pagination li.active").val());
                $("ul.pagination li.active").trigger("click");
                $("#btnCancel").trigger("click");
            },
            error: function (e) {
                alert(e.responseText);
            },
            async: false
        });
    });

    //cancel update
    $("#btnCancel").click(function () {
        $("#btnSave, #btnCancel").css("display", "none");
        $("#btnAdd").css("display", "block");
        $("#CategoryDDL").val("");
        $("#txtName").val("");
        $("#txtPrice").val("");
    });

    //remove item
    $(document).on("click", ".fas.fa-remove", function () {
        var conf = confirm("Are you sure you want to delete this item?");
        if (conf) {
            $.ajax({
                url: "/api/DeleteItem/" + $(this).attr("value"),
                type: "DELETE",
                contentType: "application/json; charset=utf-8",
                dataType: "JSON",
                success: function (data) {
                    getItems(data.CategoryID, $(".itemsPerPage").val(), $("ul.pagination li.active").val());
                    updateNumOfItemsAndNumOfPages();
                    createPaginationLinks(numOfPages);
                    $("ul.pagination li.active").trigger("click");
                    $("#btnCancel").trigger("click");
                },
                error: function (e) {
                    alert(e.responseText);
                },
                async: false
            });
        }
    });

    getCategories();
    getItems($("ul.cate li.active").attr("id"), $(".itemsPerPage").val(), $("ul.pagination li.active").val());
    updateNumOfItemsAndNumOfPages();
    createPaginationLinks(1);
});