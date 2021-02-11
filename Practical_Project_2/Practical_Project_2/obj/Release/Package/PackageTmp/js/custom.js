
// /Admin/Index & /User/Index & /Home/Products
var sb = new StringBuilder();

function getCategories() {
    $.ajax({
        url: "/api/Items",
        type: "GET",
        contentType: "application/json ; charset=utf-8",
        dataType: "JSON",
        success: function (data) {
            $("ul.cate").html("");
            var categories = "";
            sb.append("<li id='" + data[0].ID + "' class='active selectedCat'><a href='#' onclick='return false'><i class='fa fa-arrow-right' aria-hidden='true'></i>" + data[0].Name + "</a></li>");
            for (var i = 1; i < data.length; i++) {
                sb.append("<li id='" + data[i].ID + "'><a href='#' onclick='return false'><i class='fa fa-arrow-right' aria-hidden='true'></i>" + data[i].Name + "</a></li>");
            }
            categories = sb.toString();
            $("ul.cate").html(categories);
            sb.clear();
        },
        async: false
    });
}

function createPaginationLinks(activeLinkId) {
    var numbering = "";
    sb.append("<nav class='numbering'>");
    sb.append("<ul class='pagination paging'>");
    sb.append("<li class='previous'>");
    sb.append("<a href='#' aria-label='Previous' onclick='return false'>");
    sb.append("<span aria-hidden='true'>&laquo;</span>");
    sb.append("</a>");
    sb.append("</li>");
    updateNumOfItemsAndNumOfPages();
    for (var i = 0; i < numOfPages; i++) {
        if ((i + 1) == activeLinkId)
            sb.append("<li class='pagination link active' id='" + (i + 1) + "'><a href='#' onclick='return false'>" + (i + 1) + "</a></li>");
        else
            sb.append("<li class='pagination link' id='" + (i + 1) + "'><a href='#' onclick='return false'>" + (i + 1) + "</a></li>");
    }
    sb.append("<li class='next'>");
    sb.append("<a href='#' aria-label='Next' onclick='return false'>");
    sb.append("<span aria-hidden='true'>&raquo;</span>");
    sb.append("</a>");
    sb.append("</li>");
    sb.append("</ul>");
    sb.append("</nav>");
    numbering = sb.toString();
    $("#links").html(numbering);
    sb.clear();
}

var numOfItems = 0;
var numOfPages = 0;
function updateNumOfItemsAndNumOfPages() {
    $.ajax({
        url: "/api/Items/" + $("ul.cate li.active").attr("id"),
        type: "GET",
        contentType: "application/json ; charset=utf-8",
        dataType: "JSON",
        success: function (data) {
            numOfItems = data;
            numOfPages = Math.ceil(numOfItems / $(".itemsPerPage").val());
        },
        async: false
    });
}

//click on category
$(document).on('click', 'ul.cate li', function () {
    $(this).addClass("active selectedCat");
    $(this).siblings().removeClass("active selectedCat");
    $("ul.pagination li.link").removeClass("active");
    $("ul.pagination > li.link:nth-child(2)").addClass("active");
    getItems($(this).attr("id"), $(".itemsPerPage").val(), $("ul.pagination li.active").val());
    createPaginationLinks(1);
    $("#btnCancel").trigger("click");
});

//click on pagination links
$(document).on('click', '.link', function () {
    $(this).addClass("active");
    $(this).siblings().removeClass("active");
    getItems($("ul.cate li.active").attr("id"), $(".itemsPerPage").val(), $(this).attr("id"));
});

//click on next
$(document).on('click', 'li.next', function () {
    var activeLinkId = $("ul.pagination li.active").attr("id");
    if (activeLinkId < numOfPages) {
        activeLinkId++;
        getItems($("ul.cate li.active").attr("id"), $(".itemsPerPage").val(), activeLinkId);
        createPaginationLinks(activeLinkId);
    }
});

//click on previous
$(document).on('click', 'li.previous', function () {
    var activeLinkId = $("ul.pagination li.active").attr("id");
    if (activeLinkId > 1) {
        activeLinkId--;
        getItems($("ul.cate li.active").attr("id"), $(".itemsPerPage").val(), activeLinkId);
        createPaginationLinks(activeLinkId);
    }
});

//select number of items per page
$(".itemsPerPage").change(function () {
    getItems($("ul.cate li.active").attr("id"), this.value, $("ul.pagination li.active").val());
    updateNumOfItemsAndNumOfPages();
    createPaginationLinks(1);
});