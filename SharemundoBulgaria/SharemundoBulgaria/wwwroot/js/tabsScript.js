function changeTabVisibility(tabId, sectionId) {
    let sectionChildren = document.getElementById(sectionId).children;

    for (var currentTab of sectionChildren) {
        if (currentTab.id == tabId) {
            currentTab.style.display = "block";
            let tab = document.getElementById(`${sectionId}-${currentTab.id}`);
            tab.style.color = "white";
        } else {
            currentTab.style.display = "none";
            let tab = document.getElementById(`${sectionId}-${currentTab.id}`);
            tab.style.color = "black";
        }
    }
}