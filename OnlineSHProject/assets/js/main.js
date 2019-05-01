$(document).ready(function(){

    // niceScroll start
    $("html").niceScroll({
        cursorcolor: "#1f4ba5",
        cursorwidth: "13px",
        cursorborderradius: "0px",
        zindex: "31",
        scrollspeed: "20"
    });
    // niceScroll end

    // scroll to top start
    if ($(window).scrollTop() > 100){
        $(".scroll-to-top").fadeIn(400);
    }
    else{
        $(".scroll-to-top").fadeOut(400);
    }

    $(window).scroll(function(){
        if ($(window).scrollTop() > 100){
            $(".scroll-to-top").fadeIn(400);
        }
        else{
            $(".scroll-to-top").fadeOut(400);
        }
    });

    $(".scroll-to-top").click(function(event){
        event.preventDefault();
        $("html, body").animate({
            scrollTop: 0
        },1000);
    });
    // scroll to top end

    // navbar start
    if ($(window).scrollTop() > 0){
        $(".navbar").removeClass("py-3");
        $(".navbar").addClass("py-0");
        $(".navbar").css("box-shadow", "0px 2px 10px rgba(0,0,0,.25)");
        $(".navbar .navbar-brand").css("font-size", "19px");
        $(".navbar .nav-link").css("font-size", "12px");
        $(".homeNavbar.navbar").addClass ("bg-light");
        
    }
    else if ($(window).scrollTop() == 0){
        $(".navbar").removeClass("py-0");
        $(".navbar").addClass("py-3");
        $(".navbar").css("box-shadow", "none");
        $(".navbar .navbar-brand").css("font-size", "22px");
        $(".navbar .nav-link").css("font-size", "14px");
        $(".homeNavbar.navbar").removeClass("bg-light");
    };

    $(window).scroll(function(){
        if ($(window).scrollTop() > 0){
            $(".navbar").removeClass("py-3");
            $(".navbar").addClass("py-0");
            $(".navbar").css("box-shadow", "0px 2px 10px rgba(0,0,0,.25)");
            $(".navbar .navbar-brand").css("font-size", "19px");
            $(".navbar .nav-link").css("font-size", "12px");
            $(".homeNavbar.navbar").addClass ("bg-light");
        }
        else if ($(window).scrollTop() == 0){
            $(".navbar").removeClass("py-0");
            $(".navbar").addClass("py-3");
            $(".navbar").css("box-shadow", "none");
            $(".navbar .navbar-brand").css("font-size", "22px");
            $(".navbar .nav-link").css("font-size", "14px");
            $(".homeNavbar.navbar").removeClass("bg-light");
        };
    });
    // navbar end

    // hover of images in home page start
    $(".home .mainSectionImg").hover(
        function(){
            $(this).children(".imgDetails").addClass("d-block");
        }
        ,
        function(){
            $(this).children(".imgDetails").removeClass("d-block");
        }
    );
    // hover of images in home page end

    // multi images of product in home page start
    $(".thumb").children().click(function(){
        $(this).siblings().css("border", "1px solid #e6e3e3");
        $(this).css("border", "1px solid #727272");
        var thumbSrc = $(this).children().attr("src");
        $(this).parents(".mainSectionImg").children("img").attr("src", thumbSrc);
    });
    // multi images of product in home page end

    // notifications page start
    var notificationsRowsNum = 0;
    $(".notifications tbody tr").each(function(){
        ++notificationsRowsNum;
    });
    if(notificationsRowsNum == 0){
        $(".notifications table").hide();
        $(".notifications .no-notifications").addClass("d-block");
    }

    $(".notifications .delete button").click(function(){
        $(this).parents("tr").remove();
        --notificationsRowsNum;
        if(notificationsRowsNum == 0){
            $(".notifications table").hide();
            $(".notifications .no-notifications").addClass("d-block");
        }
    });

    $(".notifications .deleteAll").click(function(){
        $(".notifications tbody tr").each(function(){
            $(this).remove();
            --notificationsRowsNum;
            if(notificationsRowsNum == 0){
                $(".notifications table").hide();
                $(".notifications .no-notifications").addClass("d-block");
        }
        });
    });

    $(".notifications .subject").each(function(){
        var subjectP = $(this).find("span").text();
        $(this).find("p").text(subjectP);

        if( $(this).find("span").text().length > 100 ){
            var trimmedText = $(this).find("span").text().substr(0, 100);
            $(this).find("span").text(trimmedText + "....");
        }
    });

    $(".notifications .subject span").click(function(){
        $(".notifications .modal-title").text( $(this).parents("tr").find(".sender").text() );
        
        $(".notifications .modal-body").text( $(this).siblings("p").text() );
    });
    // notifications page end

    // user account page start
    var accountRowsNum = 0;
    $(".userAccount #v-pills-order-history tbody tr").each(function(){
        ++accountRowsNum;
    });
    if(accountRowsNum == 0){
        $(".userAccount #v-pills-order-history table").hide();
        $(".userAccount .no-orders").addClass("d-block");
    }
    else{
        $(".userAccount .no-orders").removeClass("d-block");
    }
    // user account page end

});