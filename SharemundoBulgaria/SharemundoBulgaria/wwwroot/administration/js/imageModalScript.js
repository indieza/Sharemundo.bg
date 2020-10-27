function openImage(modalElement) {
    let modal = document.getElementById(`${modalElement}Modal`);
    let captionText = document.getElementById(`${modalElement}caption`);
    modal.style.display = "block";
    captionText.innerHTML = `${modalElement} <i class="fas fa-window-close closeImage" onclick="closeImage('${modalElement}')"></i>`;
}

function closeImage(element) {
    let modal = document.getElementById(`${element}Modal`);
    modal.style.display = "none";
}