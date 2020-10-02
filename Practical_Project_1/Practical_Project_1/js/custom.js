﻿

$(function () {
    $("#login").click(function () {
        $("header .sign-in-form").animate({ opacity: 1, width: "auto" }, 0);
    });

    $(".form-signin .glyphicon-remove").click(function () {
        $("header .sign-in-form").animate({ opacity: 0, width: "0px" }, 300, function () {
            $(".modal").modal('hide');
        });

        //$("body").removeClass("modal-open");
        //$("header div .modal").removeClass("in");
        //$("header div .modal").css("display", "none");
        
        //$("div").filter(".modal-backdrop").remove();
        //$("body").css("all", "unset");
    });

    $("header figure.burger-image").animate({ left: "0%", opacity: 1 }, 300);

    $(window).scroll(function () {
        if ($(window).scrollTop() >= 200) {
            $("#best-burger figure.popular, #best-burger figure.fun, #best-burger figure.fresh").animate({ left: "0%", opacity: 1 }, 1000);
        }
        if ($(window).scrollTop() >= 800) {
            $("#choose-burger figure.left-burger, #choose-burger figure.right-burger").animate({ left: "0%", opacity: 1 }, 1000);
            $("#choose-burger figure.mid-burger").animate({ opacity: 1 }, 1000);
        }
        if ($(window).scrollTop() >= 2450) {
            $("#reservation div.food-images").animate({ opacity: 1 }, 1000);
        }
    });

    //$("#choose-burger figure.mid-burger img").mouseenter(function () {
    //    $(this).animate({ width: "90%"}, 500);
    //});

    //$("#choose-burger figure.mid-burger img").mouseleave(function () {
    //    $(this).animate({ width: "100%" }, 500);
    //});
    
});