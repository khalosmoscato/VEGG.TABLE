export function initializeMap(elementId, farms) {
    function tryInit() {
        const container = document.getElementById(elementId);
        if (!container) {
            requestAnimationFrame(tryInit);
            return;
        }

        var map = L.map(elementId).setView([51.5074, -0.1278], 12);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '© OpenStreetMap contributors'
        }).addTo(map);

        farms.forEach(farm => {
            L.marker([farm.lat, farm.lng])
                .addTo(map)
                .bindPopup(`<b>${farm.name}</b><br>Owner: ${farm.ownerName || 'N/A'}`);
        });
        window.addEventListener('resize', () => {
            map.invalidateSize();
        });
    }

    tryInit();
}