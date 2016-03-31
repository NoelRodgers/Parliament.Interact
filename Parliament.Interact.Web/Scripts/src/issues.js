$(document).ready(function () {
    //setTimeout(callModal, 3000);

    $(".shareIcons").jsSocials({
        showLabel: false,
        showCount: false,
        shares: ["twitter", "facebook"]
    });

    //$('#postcode-button').click(function () {
    //    var postcodeValue = $('#postcode').val();
    //    $.ajax({
    //        type: "POST",
    //        url: "Issues/GetMPLink",
    //        dataType: "text",
    //        data: { value: postcodeValue }
    //    }).error(function () {
    //        console.log("it's gone horribly wrong");
    //    });
    //});
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