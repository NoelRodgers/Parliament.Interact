$(document).ready(function () {
    //setTimeout(callModal, 3000);

    $(".shareIcons").jsSocials({
        showLabel: false,
        showCount: false,
        shares: ["twitter", "facebook"]
    });

    $('#postcode-button').click(function () {
        var postcodeValue = $('#postcode').val();
        $.ajax({
            type: "POST",
            url: "Issues/GetMPLink",
            dataType: "text",
            data: { value: postcodeValue }
        }).error(function () {
            console.log("it's gone horribly wrong");
        });
    });
});

function callModal() {
    $(".modal").modal();
}