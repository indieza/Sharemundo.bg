function selectedName(position) {
    let positionId = position.value;

    $.ajax({
        type: "GET",
        url: `/Administration/EditJobPosition/GetJobPositionData`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            'positionId': positionId
        },
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (data) {
            document.getElementById("editPositionInputForm").style.display = "block";
            $("#positionTitle").val(data.title);
            $("#positionLocation").val(data.location);
            tinyMCE.get("positionDescription").setContent(data.description == null ? "" : data.description);
        },
        error: function (msg) {
            console.error(msg);
        }
    })
}