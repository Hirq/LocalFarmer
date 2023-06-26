export function load_map(latitude, longitude) {
    let map = L.map('map').setView([latitude, longitude], 12);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map);
}