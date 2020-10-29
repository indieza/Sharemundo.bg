function selectedName(part) {
    let partId = part.value;

    $.ajax({
        type: "GET",
        url: `/Administration/EditPart/GetPartData`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            'partId': partId
        },
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (data) {
            document.getElementById("editSectionInputForm").style.display = "block";
            $("#partType").val(data.partType);
            $("#sectionName").val(data.sectionId);
            $("#partName").val(data.name);
            $("#heading").val(data.heading);
            $("#subheading").val(data.subheading);
            tinyMCE.get("description").setContent(data.description == null ? "" : data.description);
        },
        error: function (msg) {
            console.error(msg);
        }
    })
}