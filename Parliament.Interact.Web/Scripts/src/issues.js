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