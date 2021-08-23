function attachGradientEvents() {
    document.getElementById('gradient').addEventListener('mousemove', onMove)

    function onMove(event){
        const offsetX = event.offsetX;
        const precent = Math.floor(offsetX / event.target.clientWidth * 100);

        document.getElementById('result').textContent = `${precent}%`;
    }
}