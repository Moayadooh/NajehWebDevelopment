
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
        //$("header .sign-in-form").animate({ opacity: 0, position: "relative", left: "900%" }, 0, function () {
        //    $(this).animate({ opacity: 1, position: "relative", left: 0, top: 0 }, 500);
        //});
        $("header .sign-in-form").animate({ opacity: 1, position: "relative", left: 0 }, 0);
    });
    $(".form-signin .glyphicon-remove").click(function () {
        $("header .sign-in-form").animate({ opacity: 0, position: "relative", left: "-300%" }, 200, function () {
            $(".modal").modal('hide');
        });
    });

    $("header figure.burger-image").animate({ left: "0%", opacity: 1 }, 300);

    //Control Navigation Bar
    function WhiteHover() {
        $("header nav a").css({ color: "rgb(61, 37, 20)" });
        //$("header nav a").mouseenter(function () {
        //    $(this).css({ color: "#ffffff" });
        //});
        //$("header nav a").mouseleave(function () {
        //    $(this).css({ color: "rgb(61, 37, 20)" });
        //});
    }
    function Hover() {
        $("header nav a").css({ color: "#ffffff" });
        //$("header nav a").mouseenter(function () {
        //    $(this).css({ color: "rgb(61, 37, 20)" });
        //});
        //$("header nav a").mouseleave(function () {
        //    $(this).css({ color: "#ffffff" });
        //});
    }
    var isMobile = false;
    if ($(window).width() <= 767) {
        $(".navigation").addClass("navbar-fixed-top");
        isMobile = true;
        Hover();
    }
    else {
        $(".navigation").removeClass("navbar-fixed-top");
        isMobile = false;
        WhiteHover();
    }
    $(window).resize(function () {
        if ($(window).width() <= 767) {
            $(".navigation").addClass("navbar-fixed-top");
            isMobile = true;
            Hover();
        }
        else {
            $(".navigation").removeClass("navbar-fixed-top");
            isMobile = false;
            if ($(window).scrollTop() >= 5)
                Hover();
            else if ($(window).scrollTop() < 5)
                WhiteHover();
        }
    });

    $(window).scroll(function () {
        //Navigation Bar Position
        if (!isMobile) {
            if ($(window).scrollTop() >= 5) {
                $("header nav").css({
                    position: "fixed",
                    left: "0",
                    top: -22,
                    backgroundColor: "black",
                    opacity: 0.5,
                    padding: "7px",
                    width: "100%",
                    zIndex: 3
                });
                Hover();
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
                    top: 0
                });
                WhiteHover();
            }
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