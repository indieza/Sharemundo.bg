function pageSelect(page) {
    let pageType = page.value;

    $.ajax({
        type: "GET",
        url: `/Administration/EditSectionsPosition/GetSectionsPosition`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            'pageType': pageType
        },
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (data) {
            let div = document.getElementById("allSections");
            div.innerHTML = "";

            for (var section of data) {
                div.innerHTML += `
                    <div class="row">
                        <div class="form-group col-lg-9">
                            <input class="form-control" type="text" placeholder="Name" value="${section.name}" disabled/>
                        </div>
                        <div class="form-group col-lg-3">
                            <input class="form-control" type="number" placeholder="0"  value="${section.positionNumber}" />
                        </div>
                        <input type="hidden" value="${section.id}" />
                    </div>
                    <hr  style="border-top: 1px solid green; border-radius: 5px;"/>`;
            }
        },
        error: function (msg) {
            console.error(msg);
        }
    })
}