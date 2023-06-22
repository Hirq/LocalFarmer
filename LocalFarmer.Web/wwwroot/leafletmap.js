export function load_map() {
    //let map = L.map('map').setView({ lon: 26, lat: 44 }, 10);
    let map = L.map('map').setView([54.22, 16.11], 12);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map);
}