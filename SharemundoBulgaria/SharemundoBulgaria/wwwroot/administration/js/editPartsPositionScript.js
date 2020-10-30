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
                    <div class="row partsElements">
                        <div class="form-group col-lg-9">
                            <input class="form-control" type="text" placeholder="Name" value="${part.name}" readonly="true"/>
                        </div>
                        <div class="form-group col-lg-3">
                            <input id="${part.id}position" class="form-control" type="number" min="1" placeholder="0"  value="${part.positionNumber}" onchange="positionChange(this)"/>
                        </div>
                        <input type="hidden" value="${part.id}" />
                    </div>
                    <hr  style="border-top: 1px solid grey; border-radius: 5px;"/>`;
            }

            if (data.length > 0) {
                div.innerHTML += `
                    <div class="row">
                        <div class="form-group col-lg-12">
                            <button type="submit" class="btn btn-info" onclick="submitData()">
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

function submitData() {
    let allParts = [];
    let data = document.querySelectorAll(".partsElements");

    for (var currentPart of data) {
        allParts.push({
            "Id": currentPart.children[2].value,
            "Name": currentPart.children[0].children[0].value,
            "PositionNumber": document.getElementById(`${currentPart.children[2].value}position`).value
        });
    }

    $.ajax({
        type: "POST",
        url: `/Administration/EditPartsPosition/EditPartsPosition`,
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
        data: {
            'json': JSON.stringify(allParts)
        },
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function () {
            console.log("success");
        },
        error: function (msg) {
            console.error(msg);
        }
    })
}