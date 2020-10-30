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
                    <div class="row sectionsElements">
                        <div class="form-group col-lg-9">
                            <input class="form-control" type="text" placeholder="Name" value="${section.name}" readonly="true"/>
                        </div>
                        <div class="form-group col-lg-3">
                            <input id="${section.id}position" class="form-control" type="number" min="1" placeholder="0"  value="${section.positionNumber}"  onchange="positionChange(this)"/>
                        </div>
                        <input type="hidden" value="${section.id}" />
                    </div>
                    <hr  style="border-top: 1px solid green; border-radius: 5px;"/>`;
            }

            if (data.length > 0) {
                div.innerHTML += `
                    <div class="row">
                        <div class="form-group col-lg-12">
                            <button class="btn btn-info" onclick="submitData()">
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
    let allSections = [];
    let data = document.querySelectorAll(".sectionsElements");

    for (var currentSection of data) {
        allSections.push({
            "Id": currentSection.children[2].value,
            "Name": currentSection.children[0].children[0].value,
            "PositionNumber": document.getElementById(`${currentSection.children[2].value}position`).value
        });
    }

    $.ajax({
        type: "POST",
        url: `/Administration/EditSectionsPosition/EditSectionsPosition`,
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
        data: {
            'json': JSON.stringify(allSections)
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