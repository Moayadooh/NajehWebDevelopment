$(document).ready(function () {
    //Login Form
    //$("#login").click(function () {
    //    $("header .sign-in-form").animate({ opacity: 1, position: "relative", left: 0 }, 0);
    //});
    //$(".form-signin .glyphicon-remove").click(function () {
    //    $("header .sign-in-form").animate({ opacity: 0, position: "relative", left: "-300%" }, 200, function () {
    //        $(".modal").modal('hide');
    //    });
    //});

    $("#login").click(function () {
        $(".form-signin").animate({ opacity: 1, left: "50%" }, 1000);
        //$(".form-signin").fadeIn();
        //$(".form-signin").css({ "visibility": "visible", "display": "block" });
    });

    $(".form-signin .glyphicon-remove").click(function () {
        $(".form-signin").animate({ opacity: 0, left: "-50%" }, 1000, function () {
            $(this).animate({ opacity: 0, left: "200%" }, 0);
        });
        //$(".form-signin").fadeOut();
        //$(".form-signin").css({ "visibility": "hidden", "display": "none" });
    });

});
