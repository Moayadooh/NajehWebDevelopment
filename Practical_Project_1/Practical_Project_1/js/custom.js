
$(function () {
    //Menus Locations
    $("#home").click(function () {
        $("html,body").animate({ scrollTop: "0" }, 1000);
    });
    $("#menu").click(function () {
        if (isLaptop) {
            $("html,body").animate({ scrollTop: "770" }, 1000);
        }
        else if (isTablet) {
            $("html,body").animate({ scrollTop: "1210" }, 1000);
        }
        else {
            $("html,body").animate({ scrollTop: "950" }, 1000);
        }
    });
    $("#reservation").click(function () {
        if (isLaptop) {
            $("html,body").animate({ scrollTop: "2800" }, 1000);
        }
        else if (isTablet) {
            $("html,body").animate({ scrollTop: "5250" }, 1000);
        }
        else {
            $("html,body").animate({ scrollTop: "4900" }, 1000);
        }
    });
    $("#about-us").click(function () {
        if (isLaptop) {
            $("html,body").animate({ scrollTop: "3500" }, 1000);
        }
        else if (isTablet) {
            $("html,body").animate({ scrollTop: "6000" }, 1000);
        }
        else {
            $("html,body").animate({ scrollTop: "6100" }, 1000);
        }
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

    //Navigation Bar
    function WhiteHover() {
        $("header nav a").css({ color: "rgb(61, 37, 20)" });
        $("header nav a").mouseenter(function () {
            $(this).css({ color: "#ffffff" });
        });
        $("header nav a").mouseleave(function () {
            $(this).css({ color: "rgb(61, 37, 20)" });
        });
    }

    function WhiteHover2() {
        $("header nav a").css({ color: "#000000" });
        $("header nav a").mouseenter(function () {
            $(this).css({ color: "#ffffff" });
        });
        $("header nav a").mouseleave(function () {
            $(this).css({ color: "#000000" });
        });
    }

    function GrayHover() {
        $("header nav a").css({ color: "#ffffff" });
        $("header nav a").mouseenter(function () {
            $(this).css({ color: "darkgray" });
        });
        $("header nav a").mouseleave(function () {
            $(this).css({ color: "#ffffff" });
        });
    }

    var isMobile = false;
    var isTablet = false;
    var isLaptop = false;
    function CheckDeviceWidth() {
        isMobile = false;
        isTablet = false;
        isLaptop = false;
        if ($(window).width() < 768) {
            isMobile = true;
        }
        else if ($(window).width() >= 768 && $(window).width() <= 991) {
            isTablet = true;
        }
        else {
            isLaptop = true;
        }
    }

    function NavbarFormat() {
        if (isMobile) {
            $(".navigation").addClass("navbar-fixed-top");
            GrayHover();
        }
        else if (isTablet) {
            $(".navigation").removeClass("navbar-fixed-top");
            FixNavbar();
        }
        else {
            $(".navigation").removeClass("navbar-fixed-top");
            if ($(window).scrollTop() >= 5) {
                FixNavbar();
            }
        }
    }

    function FixNavbar() {
        $("header nav").css({
            position: "fixed",
            left: 0,
            top: -22,
            backgroundColor: "darkgray",
            opacity: 0.5,
            padding: "7px",
            width: "100%",
            zIndex: 3
        });
        WhiteHover2();
    }

    function FreeNavbar() {
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

    CheckDeviceWidth();
    NavbarFormat();
    $(window).resize(function () {
        CheckDeviceWidth();
        NavbarFormat();
        if (isLaptop) {
            if ($(window).scrollTop() < 5) {
                FreeNavbar();
            }
        }
    });

    if (isLaptop) {
        $("header figure.burger-image").animate({ left: "0%", opacity: 1 }, 300);
    }
    $(window).scroll(function () {
        if (isLaptop) {
            if ($(window).scrollTop() >= 5) {
                FixNavbar();
            }
            else if ($(window).scrollTop() < 5) {
                FreeNavbar();
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
        }
        else if (isTablet) {
            //Images Animation
            if ($(window).scrollTop() >= 100) {
                $("header figure.burger-image").animate({ left: "0%", opacity: 1 }, 300);
            }
            if ($(window).scrollTop() >= 300) {
                $("#best-burger figure.popular, #best-burger figure.fun, #best-burger figure.fresh").animate({ left: "0%", opacity: 1 }, 1000);
            }
            $("#choose-burger figure.left-burger, #choose-burger figure.right-burger").animate({ left: "0%", opacity: 1 }, 1000);
            $("#choose-burger figure.mid-burger").animate({ opacity: 1 }, 1000);
            if ($(window).scrollTop() >= 4800) {
                $("#reservation div.food-images").animate({ opacity: 1 }, 1000);
            }
        }
    });
    
});