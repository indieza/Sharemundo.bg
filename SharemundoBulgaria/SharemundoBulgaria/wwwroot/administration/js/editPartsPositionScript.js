function sectionSelect(section) {
    let sectionId = section.value;

    $.ajax({
        type: "GET",
        url: `/Administration/EditPartsPosition/GetPartsPosition`,
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
            let div = document.getElementById("allParts");
            div.innerHTML = "";

            for (var part of data) {
                div.innerHTML += `
                    <div class="row">
                        <div class="form-group col-lg-9">
                            <input class="form-control" type="text" placeholder="Name" value="${part.name}" disabled/>
                        </div>
                        <div class="form-group col-lg-3">
                            <input class="form-control" type="number" min="1" placeholder="0"  value="${part.positionNumber}" onchange="positionChange(this)"/>
                        </div>
                        <input type="hidden" value="${part.id}" />
                    </div>
                    <hr  style="border-top: 1px solid grey; border-radius: 5px;"/>`;
            }

            if (data.length > 0) {
                div.innerHTML += `
                    <div class="row">
                        <div class="form-group col-lg-12">
                            <button class="btn btn-info" href="#">
                                Edit
                            </button>
                        </div>
                    </div>`;
            }
        },
        error: function (msg) {
            console.error(msg);
        }
    })
}

function positionChange(currentInput) {
    let allNubersInputFields = document.querySelectorAll('input[type=number]');

    for (var currentInputNumber of allNubersInputFields) {
        if (currentInput != currentInputNumber && currentInput.value == currentInputNumber.value) {
            currentInputNumber.value = currentInput.defaultValue;
            currentInputNumber.defaultValue = currentInputNumber.value;
        }
    }
    currentInput.defaultValue = currentInput.value;
}