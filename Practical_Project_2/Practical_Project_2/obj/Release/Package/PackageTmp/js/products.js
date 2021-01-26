
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
                    sb.append("<div class='agile_top_brand_left_grid1'>");
                    sb.append("<figure>");
                    sb.append("<div class='snipcart-item block'>");
                    sb.append("<div class='snipcart-thumb'>");
                    sb.append("<a href='#' onclick='return false'><img title=' ' alt=' ' src='/images/" + data[j].Image + "' width='150' height='150'></a>");
                    sb.append("<p>" + data[j].Name + "</p>");
                    sb.append("<h4>$" + data[j].Price + "</h4>");
                    sb.append("</div>");
                    sb.append("<div class='snipcart-details top_brand_home_details'>");
                    sb.append("<a href='#' id='addToCart' class='btn btn-primary form-control' disabled>Add to cart</a>");
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
    getCategories();
    getItems($("ul.cate li.active").attr("id"), $(".itemsPerPage").val(), $("ul.pagination li.active").val());
    updateNumOfItemsAndNumOfPages();
    createPaginationLinks(1);
});