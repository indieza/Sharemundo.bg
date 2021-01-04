function selectedName(section) {
    let sectionId = section.value;

    $.ajax({
        type: "GET",
        url: `/Administration/EditSection/GetSectionData`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            'sectionId': sectionId
        },
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (data) {
            document.getElementById("editSectionInputForm").style.display = "block";
            $("#pageType").val(data.pageType);
            $("#sectionType").val(data.sectionType);
            $("#sectionName").val(data.name);
            $("#heading").val(data.heading);
            $("#subheading").val(data.subheading);
            tinyMCE.get("description").setContent(data.description == null ? "" : data.description);
            $("#headingBg").val(data.headingBg);
            $("#subheadingBg").val(data.subheadingBg);
            tinyMCE.get("descriptionBg").setContent(data.descriptionBg == null ? "" : data.descriptionBg);
        },
        error: function (msg) {
            console.error(msg);
        }
    })
}