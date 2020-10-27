function openImage(element, modalElement) {
    let modal = document.getElementById(`${modalElement}Modal`);
    let captionText = document.getElementById(`${modalElement}caption`);
    modal.style.display = "block";
    captionText.innerHTML = modalElement;
}

function closeImage(element) {
    let modal = document.getElementById(`${element}Modal`);
    modal.style.display = "none";
}