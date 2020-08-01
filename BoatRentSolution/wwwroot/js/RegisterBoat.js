function RegisterBoat() {
    var boatname = $('#boatname').val();
    var boatrate = $('#boatrate').val();
    if (boatname == "") {
        $.alert("Boat name is required");
        return false;
    }
    if (boatrate == "") {
        $.alert("Boat hourly rate is required");
        return false;
    }
    $.ajax({
        type: "Post",
        dataType: "json",
        url: '/Home/SaveBoatDetails',
        data: { boatname, boatrate },
        success: function (successResponse) {
            if (successResponse != undefined && successResponse != null) {
                $.alert(successResponse);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.notify('Internal server error', 'warning');
        }
    });
}