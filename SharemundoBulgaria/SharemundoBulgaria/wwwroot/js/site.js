$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: `/Home/GetOpenPositions`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (positions) {
            let list = document.getElementById("openJobPositions");
            list.innerHTML = "";
            for (var position of positions) {
                list.innerHTML += `<li><a href="/Career/JobPosition/${position.id}">${position.title}</a></li>`
            }
        },
        error: function (msg) {
            console.error(msg);
        }
    });
})