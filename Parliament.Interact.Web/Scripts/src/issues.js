$(document).ready(function () {
    //setTimeout(callModal, 3000);

    $(".share-icons").jsSocials({
        showLabel: false,
        showCount: false,
        shares: ["email", "twitter", "facebook", "googleplus", "whatsapp"]
    });



    //setTimeout(openFirstAccordionItem, 400);
});

function openFirstAccordionItem() {
    $(".parl-expand-collapse:nth-child(1)").trigger("click");
}

function callModal() {
    $(".modal").modal();
}


$(".issues-panel").on("show.bs.collapse", function () {
    $(this).find(".parl-expand-collapse").text("CLOSE");
    $(this).addClass("parl-open");
});


$(".issues-panel").on("shown.bs.collapse", function () {
    $(document).scrollTop($(this).offset().top - 40);
});

$(".issues-panel").on("hide.bs.collapse", function () {
    $(this).find(".parl-expand-collapse").text("OPEN");
    $(this).removeClass("parl-open");
});