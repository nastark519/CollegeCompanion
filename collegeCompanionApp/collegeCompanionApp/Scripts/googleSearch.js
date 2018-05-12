window.onload = function () {
    L.mapquest.key = 'ixKJ3EwloGeD24cG7f0hOGf8mLkinAbx';

    var map = L.mapquest.map('map', {
        center: [37.7749, -122.4194],
        layers: L.mapquest.tileLayer('map'),
        zoom: 13,
        zoomControl: false
    });

    L.control.zoom({
        position: 'topright'
    }).addTo(map);

    L.mapquest.directionsControl({
        routeSummary: {
            enabled: false
        },
        narrativeControl: {
            enabled: true,
            compactResults: false
        }
    }).addTo(map);
}