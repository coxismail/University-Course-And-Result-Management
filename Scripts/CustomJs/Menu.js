jQuery(document).ready(function () {
    jQuery(".main-menu .bar").click(function () {
        jQuery(".main-menu>ul").slideToggle();
    });

    jQuery(window).resize(function () {
        var screenwidth = jQuery(window).width();
        if (screenwidth > 761) {
            jQuery(".main-menu ul").removeAttr("style");
        }
    });



    jQuery(".main-menu ul li").click(function () {
        jQuery(this).children("ul").slideToggle(1000);
    });
    jQuery(".main-menu ul ul").parent("li").children("a").append("&nbsp &nbsp<i class='fa fa-caret-down' aria-hidden='true'></i>");
    //jQuery(".main-menu ul li a").click(function () {

    //    jQuery(this).addClass("active").siblings().removeClass("active");

    //});
});