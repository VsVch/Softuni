async function getInfo() {
    let input = document.getElementById('stopId');
    let id = input.value;
    input.value = '';

    let url = `http://localhost:3030/jsonstore/bus/businfo/${id}`;        

    let ulElement = document.getElementById('buses');

    ulElement.innerHTML = '';  

    try {
        let responce = await fetch(url);
        let date = await responce.json();

        document.getElementById('stopName').textContent = date.name;       

        Object.keys(date.buses)
            .forEach(key => {
                let li = document.createElement('li');
                li.textContent = `Bus ${key} arrives in ${id[key]};`;

                ulElement.appendChild(li);
            })

    } catch (error) {
        document.getElementById('stopName').textContent = 'Error';
        
    }


}