
//Payment
$("#orderNow").click(function () {
    var count = $(".total-count").text();
    if (parseInt(count) > 0) {
        var total = $(".total-cart").text();
        total = parseInt(total);
        var data = [{
            id: 1,
            name: 'item1',
            description: 'item1 desc',
            quantity: '1',
            amount_per_unit: '00.000',
            discount: {
                type: 'P',
                value: '10%'
            },
            total_amount: '000.000'
        },
        {
            id: 2,
            name: 'item2',
            description: 'item2 desc',
            quantity: '2',
            amount_per_unit: '00.000',
            discount: {
                type: 'P',
                value: '10%'
            },
            total_amount: '000.000'
        },
        {
            id: 3,
            name: 'item3',
            description: 'item3 desc',
            quantity: '1',
            amount_per_unit: '00.000',
            discount: {
                type: 'P',
                value: '10%'
            },
            total_amount: '000.000'
        }];

        goSell.config({
            containerID: "root",
            gateway: {
                publicKey: "pk_test_Vlk842B1EA7tDN5QbrfGjYzh",
                merchantId: null,
                language: "en",
                contactInfo: true,
                supportedCurrencies: "all",
                supportedPaymentMethods: "all",
                saveCardOption: false,
                customerCards: true,
                notifications: 'standard',
                callback: (response) => {
                    console.log('response', response);
                },
                onClose: () => {
                    console.log("onClose Event");
                },
                backgroundImg: {
                    url: 'imgURL',
                    opacity: '0.5'
                },
                labels: {
                    cardNumber: "Card Number",
                    expirationDate: "MM/YY",
                    cvv: "CVV",
                    cardHolder: "Name on Card",
                    actionButton: "Pay"
                },
                style: {
                    base: {
                        color: '#535353',
                        lineHeight: '18px',
                        fontFamily: 'sans-serif',
                        fontSmoothing: 'antialiased',
                        fontSize: '16px',
                        '::placeholder': {
                            color: 'rgba(0, 0, 0, 0.26)',
                            fontSize: '15px'
                        }
                    },
                    invalid: {
                        color: 'red',
                        iconColor: '#fa755a '
                    }
                }
            },
            customer: {
                id: null,
                first_name: "First Name",
                middle_name: "Middle Name",
                last_name: "Last Name",
                email: "demo@email.com",
                phone: {
                    country_code: "965",
                    number: "99999999"
                }
            },
            order: {
                amount: total,
                currency: "OMR",
                items: data,
                shipping: null,
                taxes: null
            },
            transaction: {
                mode: 'charge',
                charge: {
                    saveCard: false,
                    threeDSecure: true,
                    description: "Test Description",
                    statement_descriptor: "Sample",
                    reference: {
                        transaction: "txn_0001",
                        order: "ord_0001"
                    },
                    metadata: {},
                    receipt: {
                        email: false,
                        sms: true
                    },
                    redirect: "https://localhost:44302/User/PaymentSuccess", // https 44302 - http 8003 - http://moayad.somee.com/User/PaymentSuccess
                    post: null,
                }
            }
        });
        goSell.openLightBox();
    }
});



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