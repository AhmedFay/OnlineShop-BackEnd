$(document).ready(function(){

    function colorShoppingCartPath(){
        $(".shoppingCartLink.active").each(function(){

            $(this).parent().prevAll().children(".shoppingCartLink").css({
                "background-color":"#1f4ba5",
                "color":"#ffffff",
            });
            $(this).parent().prevAll().children(".shoppingCartPath").css({
                "background-color":"#1f4ba5",
                "color":"#ffffff",
            });

            $(this).parent().nextAll().children(".shoppingCartLink").css({
                "background-color":"#f6f6f6",
                "color":"#d5d5d5",
                "transition-duration":"0.4s"
            });
            $(this).parent().nextAll().children(".shoppingCartPath").css({
                "background-color":"#f6f6f6",
                "color":"#d5d5d5",
                "transition-duration":"0.6s"
            });

            $(this).css({
                "background-color":"#1f4ba5",
                "color":"#ffffff",
                "transition-duration":"0.6s"
            });
            $(this).siblings(".shoppingCartPath").css({
                "background-color":"#1f4ba5",
                "color":"#ffffff",
                "transition-duration":"0.4s"
            });
        });
    }

    $(".next-step-cart").click(function(e){
        e.preventDefault();

        $(".shoppingCartLink").removeClass("active");
        $("#pills-pin-tab").addClass("active");
        
        $("#pills-bag").removeClass("show");
        $("#pills-bag").removeClass("active");

        $("#pills-pin").addClass("show");
        $("#pills-pin").addClass("active");

        colorShoppingCartPath();
    });

    $(".back-delivery").click(function(e){
        e.preventDefault();

        $(".shoppingCartLink").removeClass("active");
        $("#pills-bag-tab").addClass("active");
        
        $("#pills-pin").removeClass("show");
        $("#pills-pin").removeClass("active");

        $("#pills-bag").addClass("show");
        $("#pills-bag").addClass("active");
        
        colorShoppingCartPath();
    });

    $(".next-step-delivery").click(function(e){
        e.preventDefault();

        $(".shoppingCartLink").removeClass("active");
        $("#pills-credit-card-tab").addClass("active");
        
        $("#pills-pin").removeClass("show");
        $("#pills-pin").removeClass("active");

        $("#pills-credit-card").addClass("show");
        $("#pills-credit-card").addClass("active");

        colorShoppingCartPath();        
    });

    $(".back-payment").click(function(e){
        e.preventDefault();

        $(".shoppingCartLink").removeClass("active");
        $("#pills-pin-tab").addClass("active");
        
        $("#pills-credit-card").removeClass("show");
        $("#pills-credit-card").removeClass("active");

        $("#pills-pin").addClass("show");
        $("#pills-pin").addClass("active");
        
        colorShoppingCartPath();
    });

    $(".next-step-payment").click(function(e){
        e.preventDefault();

        $(".shoppingCartLink").removeClass("active");
        $("#pills-check-tab").addClass("active");
        
        $("#pills-credit-card").removeClass("show");
        $("#pills-credit-card").removeClass("active");

        $("#pills-check").addClass("show");
        $("#pills-check").addClass("active");
        
        colorShoppingCartPath();
    });

    $(".back-confirmation").click(function(e){
        e.preventDefault();

        $(".shoppingCartLink").removeClass("active");
        $("#pills-credit-card-tab").addClass("active");
        
        $("#pills-check").removeClass("show");
        $("#pills-check").removeClass("active");

        $("#pills-credit-card").addClass("show");
        $("#pills-credit-card").addClass("active");
        
        colorShoppingCartPath();
    });

    $(".confirm-order").click(function(e){
        e.preventDefault();
        
        $(".beforeConfirmation").addClass("d-none");
        $(".afterConfirmation").removeClass("d-none");
    });

    $(".bag tr .cost").each(function(){
        var pr = parseInt($(this).parents("tr").find(".price").text());
        var qt = $(this).parents("tr").find(".quantity").val();
        var theCost = pr * qt;
        $(this).text(theCost);
    });

    var thePrice = 0;
    $(".bag .cost").each(function(){
        thePrice += parseInt($(this).text());
    });
    $(".bag .totalPrice").text(thePrice);

    $(".bag .btn-group .decrease").click(function(){
        var qty = $(this).siblings(".quantity").val();
        if(qty > 1){
            $(this).siblings(".quantity").val(--qty);

            $(this).parents("tr").find(".cost").each(function(){
                var pr = parseInt($(this).parents("tr").find(".price").text());
                var qt = $(this).parents("tr").find(".quantity").val();
                var theCost = pr * qt;
                $(this).text(theCost);
            });

            var thePrice = 0;
            $(".bag .cost").each(function(){
                thePrice += parseInt($(this).text());
            });
        }
        $(".bag .totalPrice").text(thePrice);

        var i = 0;
        $(".bag tbody tr").each(function(){
            var costText = $(".bag").find("tbody tr").eq(i).find(".cost").text();
            $(".check").find("tbody tr").eq(i).find(".cost").text(costText);

            var sizeText = $(".bag").find("tbody tr").eq(i).find(".size").text();
            $(".check").find("tbody tr").eq(i).find(".allDetails").text(sizeText);

            var colorText = $(".bag").find("tbody tr").eq(i).find(".color").text();
            $(".check").find("tbody tr").eq(i).find(".allDetails").append("-"+colorText);

            var quantityText = $(".bag").find("tbody tr").eq(i).find(".quantity").val();
            if(quantityText == 1){
                $(".check").find("tbody tr").eq(i).find(".allDetails").append("-"+quantityText+"piece");
            }
            else{
                $(".check").find("tbody tr").eq(i).find(".allDetails").append("-"+quantityText+"pieces");
            }

            ++i;
        });

        var tPrice = $(".bag").find(".totalPrice").text();
        $(".check").find(".totalPrice").text(tPrice);

    });

    $(".bag .btn-group .increase").click(function(){
        var qty = $(this).siblings(".quantity").val();
        if(qty < 10000){
            $(this).siblings(".quantity").val(++qty);

            $(this).parents("tr").find(".cost").each(function(){
                var pr = parseInt($(this).parents("tr").find(".price").text());
                var qt = $(this).parents("tr").find(".quantity").val();
                var theCost = pr * qt;
                $(this).text(theCost);
            });

            var thePrice = 0;
            $(".bag .cost").each(function(){
                thePrice += parseInt($(this).text());
            });
        }
        $(".bag .totalPrice").text(thePrice);

        var i = 0;
        $(".bag tbody tr").each(function(){
            var costText = $(".bag").find("tbody tr").eq(i).find(".cost").text();
            $(".check").find("tbody tr").eq(i).find(".cost").text(costText);
            
            var sizeText = $(".bag").find("tbody tr").eq(i).find(".size").text();
            $(".check").find("tbody tr").eq(i).find(".allDetails").text(sizeText);

            var colorText = $(".bag").find("tbody tr").eq(i).find(".color").text();
            $(".check").find("tbody tr").eq(i).find(".allDetails").append("-"+colorText);

            var quantityText = $(".bag").find("tbody tr").eq(i).find(".quantity").val();
            if(quantityText == 1){
                $(".check").find("tbody tr").eq(i).find(".allDetails").append("-"+quantityText+"piece");
            }
            else{
                $(".check").find("tbody tr").eq(i).find(".allDetails").append("-"+quantityText+"pieces");
            }

            ++i;
        });

        var tPrice = $(".bag").find(".totalPrice").text();
        $(".check").find(".totalPrice").text(tPrice);

    });

    var rowsNum = 0;
    $(".bag tbody tr").each(function(){
        ++rowsNum;
    });
    if(rowsNum == 0){
        $(".bag table").hide();
        $(".cartEmpty").addClass("d-block");
        $(".next-step-cart").addClass("disabled");
    }
    else{
        $(".next-step-cart").removeClass("disabled");
    }

    $(".exit").click(function(){
        $(this).parents("tr").remove();
        --rowsNum;
        if(rowsNum == 0){
            $(".bag table").hide();
            $(".cartEmpty").addClass("d-block");
            $(".next-step-cart").addClass("disabled");
        }
        else{
            $(".next-step-cart").removeClass("disabled");
        }

        var thePrice = 0;
        $(".bag .cost").each(function(){
            thePrice += parseInt($(this).text());
        });
        $(".bag .totalPrice").text(thePrice);

        $(".check tbody").empty();
        var i = 0;
        $(".bag tbody tr").each(function(){
            $(".check").find("tbody").append(addtr);
            
            var srcAttr = $(".bag").find("tbody tr").eq(i).find(".productImg img").attr("src");
            $(".check").find("tbody tr").eq(i).find(".productImg img").attr("src", srcAttr);
            
            var pText = $(".bag").find("tbody tr").eq(i).find(".productText p").text();
            $(".check").find("tbody tr").eq(i).find(".productText p").text(pText);
    
            var costText = $(".bag").find("tbody tr").eq(i).find(".cost").text();
            $(".check").find("tbody tr").eq(i).find(".cost").text(costText);

            var sizeText = $(".bag").find("tbody tr").eq(i).find(".size").text();
            $(".check").find("tbody tr").eq(i).find(".allDetails").text(sizeText);

            var colorText = $(".bag").find("tbody tr").eq(i).find(".color").text();
            $(".check").find("tbody tr").eq(i).find(".allDetails").append("-"+colorText);

            var quantityText = $(".bag").find("tbody tr").eq(i).find(".quantity").val();
            if(quantityText == 1){
                $(".check").find("tbody tr").eq(i).find(".allDetails").append("-"+quantityText+"piece");
            }
            else{
                $(".check").find("tbody tr").eq(i).find(".allDetails").append("-"+quantityText+"pieces");
            }
    
            ++i;
        });

        var tPrice = $(".bag").find(".totalPrice").text();
        $(".check").find(".totalPrice").text(tPrice);

    });

    $(".deleteAll").click(function(){
        $(".bag tbody tr").each(function(){
            $(this).remove();
            --rowsNum;
            if(rowsNum == 0){
                $(".bag table").hide();
                $(".cartEmpty").addClass("d-block");
                $(".next-step-cart").addClass("disabled");
            }
            else{
                $(".next-step-cart").removeClass("disabled");
            }
        });

        var thePrice = 0;
        $(".bag .cost").each(function(){
            thePrice += parseInt($(this).text());
        });
        $(".bag .totalPrice").text(thePrice);

        $(".check tbody").empty();

        var tPrice = $(".bag").find(".totalPrice").text();
        $(".check").find(".totalPrice").text(tPrice);
    });

    var x = $(".pin").find("textarea").val();
    $(".check").find(".deliveryAddress").text(x);

    $(".pin").find("textarea").on("blur", function(){
        var x = $(".pin").find("textarea").val();
        $(".check").find(".deliveryAddress").text(x);
    });


    var tPrice = $(".bag").find(".totalPrice").text();
    $(".check").find(".totalPrice").text(tPrice);

    var i = 0;
    var addtr = $(".addTableRow").html();
    $(".bag tbody tr").each(function(){
        $(".check").find("tbody").append(addtr);
        
        var srcAttr = $(".bag").find("tbody tr").eq(i).find(".productImg img").attr("src");
        $(".check").find("tbody tr").eq(i).find(".productImg img").attr("src", srcAttr);
        
        var pText = $(".bag").find("tbody tr").eq(i).find(".productText p").text();
        $(".check").find("tbody tr").eq(i).find(".productText p").text(pText);

        var costText = $(".bag").find("tbody tr").eq(i).find(".cost").text();
        $(".check").find("tbody tr").eq(i).find(".cost").text(costText);

        var sizeText = $(".bag").find("tbody tr").eq(i).find(".size").text();
        $(".check").find("tbody tr").eq(i).find(".allDetails").text(sizeText);

        var colorText = $(".bag").find("tbody tr").eq(i).find(".color").text();
        $(".check").find("tbody tr").eq(i).find(".allDetails").append("-"+colorText);

        var quantityText = $(".bag").find("tbody tr").eq(i).find(".quantity").val();
        if(quantityText == 1){
            $(".check").find("tbody tr").eq(i).find(".allDetails").append("-"+quantityText+"piece");
        }
        else{
            $(".check").find("tbody tr").eq(i).find(".allDetails").append("-"+quantityText+"pieces");
        }

        ++i;

    });


});