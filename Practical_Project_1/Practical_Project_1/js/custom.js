
$(function () {
    //Menu Locations
    $("#home").click(function () {
        $("html,body").animate({ scrollTop: "0" }, 1000);
    });
    $("#menu").click(function () {
        $("html,body").animate({ scrollTop: "770" }, 1000);
    });
    $("#reservation").click(function () {
        $("html,body").animate({ scrollTop: "2800" }, 1000);
    });
    $("#about-us").click(function () {
        $("html,body").animate({ scrollTop: "3300" }, 1000);
    });

    //Login Form
    $("#login").click(function () {
        $("header .sign-in-form").animate({ opacity: 1, position: "relative", left: 0 }, 0);
    });
    $(".form-signin .glyphicon-remove").click(function () {
        $("header .sign-in-form").animate({ opacity: 0, position: "relative", left: "-300%" }, 200, function () {
            $(".modal").modal('hide');
        });
    });

    $("header figure.burger-image").animate({ left: "0%", opacity: 1 }, 300);
    $(window).scroll(function () {
        //Control Navigation Bar
        if ($(window).scrollTop() >= 5) {
            $("header nav").css({
                position: "fixed",
                left: "0",
                top: -22,
                backgroundColor: "gray",
                opacity: 0.6,
                padding: "7px",
                width: "100%"
            });
            $("header nav a").css({ color: "#ffffff" });
            $("header nav a").mouseenter(function () {
                $(this).css({ color: "rgb(61, 37, 20)" });
            });
            $("header nav a").mouseleave(function () {
                $(this).css({ color: "#ffffff" });
            });
        }
        else if ($(window).scrollTop() < 5) {
            $("header nav").css({
                width: "auto",
                background: "none",
                opacity: 1,
                marginTop: "21px",
                marginRight: "46px",
                position: "relative",
                left: 0,
                top: 0,
                zIndex: 3
            });
            $("header nav a").css({ color: "rgb(61, 37, 20)" });

            $("header nav a").mouseenter(function () {
                $(this).css({ color: "#ffffff" });
            });
            $("header nav a").mouseleave(function () {
                $(this).css({ color: "rgb(61, 37, 20)" });
            });
        }

        //Images Animation
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
    
});