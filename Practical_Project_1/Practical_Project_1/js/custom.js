
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

    function LaptopNavigation() {
        $("header nav").css({
            position: "fixed",
            left: "0",
            top: -22,
            backgroundColor: "black",
            opacity: 0.5,
            padding: "7px",
            width: "100%",
            zIndex: 99999
        });
    }
    function MobileNavigation() {
        $("header nav").css({
            width: "auto",
            background: "none",
            opacity: 1,
            marginTop: "21px",
            marginRight: 0,
            position: "relative",
            left: 0,
            top: 15,
            zIndex: 99999
        });
    }
    function RemoveNavBackgroundAndButton() {
        //$("header .navbar-inverse").css({
        //    background: "none",
        //    border: "none"
        //});
        //$("header .navbar-header").css({
        //    display: "none"
        //});
    }
    function DisplayNavBackgroundAndButton() {
        //$("header .navbar-inverse").css({
        //    position: "fixed",
        //    left: 0,
        //    top: "-5px",
        //    backgroundColor: "black",
        //    width: "100%",
        //    zIndex: 99
        //});
        //$("header .navbar-header").css({
        //    display: "block"
        //});
    }

    //if ($(window).width() <= 767) {
    //    $(".navigation").addClass("navbar-fixed-top");
    //    MobileNavigation();
    //    DisplayNavBackgroundAndButton();
    //}
    //else {
    //    //var marRight = "46px";
    //    $(".navigation").removeClass("navbar-fixed-top");
    //    LaptopNavigation();
    //    RemoveNavBackgroundAndButton();
    //}

    var isMobile = false;
    if ($(window).width() <= 767) {
        $(".navigation").addClass("navbar-fixed-top");
        isMobile = true;
        //MobileNavigation();
        //DisplayNavBackgroundAndButton();
    }
    else {
        //var marRight = "46px";
        $(".navigation").removeClass("navbar-fixed-top");
        isMobile = false;
        //LaptopNavigation();
        //RemoveNavBackgroundAndButton();
    }
    $(window).resize(function () {
        if ($(window).width() <= 767) {
            $(".navigation").addClass("navbar-fixed-top");
            isMobile = true;
            //MobileNavigation();
            //DisplayNavBackgroundAndButton();
        }
        else {
            //var marRight = "46px";
            $(".navigation").removeClass("navbar-fixed-top");
            isMobile = false;
            //LaptopNavigation();
            //RemoveNavBackgroundAndButton();
        }
    });

    //if (isMobile) {
    //    $("header nav").css({
    //        backgroundColor: "black",
    //        opacity: 0.5
    //    });
    //}

    $(window).scroll(function () {
        //Control Navigation Bar
        if (isMobile == false) {
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
                    top: 0
                });
                $("header nav a").css({ color: "rgb(61, 37, 20)" });
                $("header nav a").mouseenter(function () {
                    $(this).css({ color: "#ffffff" });
                });
                $("header nav a").mouseleave(function () {
                    $(this).css({ color: "rgb(61, 37, 20)" });
                });
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