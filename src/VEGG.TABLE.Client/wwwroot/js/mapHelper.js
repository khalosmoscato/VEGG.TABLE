export function initializeMap(elementId, farms) {
    function tryInit() {
        const container = document.getElementById(elementId);
        const farmList = document.getElementById('farm-list');

        if (!container || !farmList) {
            requestAnimationFrame(tryInit);
            return;
        }

        var map = L.map(elementId).setView([51.5074, -0.1278], 12);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '© OpenStreetMap contributors'
        }).addTo(map);

        const sortedFarms = [...farms].sort((a, b) => a.name.localeCompare(b.name));

        // creates the Markers and the sidebar items for each farm
        sortedFarms.forEach(farm => {
            const marker = L.marker([farm.lat, farm.lng])
                .addTo(map)
                .bindPopup(`
                    <b>${farm.name}</b><br>
                    Contact: <a href="mailto:${farm.ownerEmail}">${farm.ownerEmail || 'N/A'}</a>
                `);
            // Creates the Sidebar Item
            const item = document.createElement('div');
            item.className = "p-4 border-b cursor-pointer hover:bg-green-50 transition";
            item.innerHTML = `<h3 class="font-semibold text-green-800">${farm.name}</h3>`;
            // Links the click event to the map interaction
            item.onclick = () => {
                map.setView([farm.lat, farm.lng], 15); 
                marker.openPopup(); 
            };

            farmList.appendChild(item);
        });

        window.addEventListener('resize', () => {
            map.invalidateSize();
        });
    }

    tryInit();
}