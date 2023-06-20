var map;

function closeAlertAfterDelay() {
    setTimeout(function () {
        var alertElement = document.querySelector('.mud-alert');
        if (alertElement) {
            alertElement.style.display = 'none';
        }
    }, 2500);
}

function initializeGoogleMap() {
    map = L.map('map').setView([51.505, -0.09], 13);
}
