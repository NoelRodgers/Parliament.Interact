$(document).ready(function () {
    //setTimeout(callModal, 3000);

    $("#shareIcons").jsSocials({
        showLabel: false,
        showCount: false,
        shares: ["email", "twitter", "facebook", "googleplus", "linkedin", "pinterest", "whatsapp"]
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
    $(".panel-collapse").promise().done(function () {
        $(this).parent().addClass("parl-open");
    });

});

$(".issues-panel").on("hide.bs.collapse", function () {
    $(this).find(".parl-expand-collapse").text("OPEN");
    $(".panel-collapse").promise().done(function () {
        $(this).parent().removeClass("parl-open");
    });
});