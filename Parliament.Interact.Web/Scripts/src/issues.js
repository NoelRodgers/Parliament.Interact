$(document).ready(function () {
    //setTimeout(callModal, 3000);

    $(".shareIcons").jsSocials({
        showLabel: false,
        showCount: false,
        shares: ["twitter", "facebook"]
    });
});

function callModal() {
    $(".modal").modal();
}


$(".issues-panel").on("show.bs.collapse", function () {
    $(this).find(".parl-expand-collapse").text("CLOSE");
});

$(".issues-panel").on("hide.bs.collapse", function () {
    $(this).find(".parl-expand-collapse").text("OPEN");
});