function attachEvents() {
    document.getElementById('submit').addEventListener('click', getWeather);
}

attachEvents();

async function getWeather() {

    let icons = {
        'Sunny': '☀',
        'Partly sunny': '⛅',
        'Overcast': '☁',
        'Rain': '☂'
    }

    let input = document.getElementById('location');

    let cityName = input.value;

    const code = await getCode(cityName);

    const [current, upcoming] = await Promise.all([
        getCurrend(code),
        getUpcoming(code),
    ]);

    let symbol = current.forecast.condition;

    let degreseValue = `${current.forecast.low}°/${current.forecast.high}°\n`;

    document.getElementById('forecast').style.display = '';

    let currentDiv = document.getElementById('current');

    let mainDiv = createTags('div', undefined, 'forecasts');
    let symbolSpan = createTags('span', icons[symbol], 'condition symbol');
    let conditionSpan = createTags('span', undefined, 'condition');

    let firstCondSpan = createTags('span', current.name, 'forecast-date');
    let secondCondSpan = createTags('span', degreseValue, 'forecast-date');
    let thirdCondSpan = createTags('span', current.forecast.condition, 'forecast-date');

    conditionSpan.appendChild(firstCondSpan);
    conditionSpan.appendChild(secondCondSpan);
    conditionSpan.appendChild(thirdCondSpan);

    mainDiv.appendChild(symbolSpan);
    mainDiv.appendChild(conditionSpan);

    currentDiv.appendChild(mainDiv);

    let upcommingDiv = document.getElementById('upcoming');
    // console.log(upcoming);

    let upcomingMainDiv = createTags('div', undefined, 'forecast-info');


    upcoming.forecast.forEach(el => {

        let parantWetherDiv = createTags('span', undefined, 'upcoming');
        console.log(el)
        let upcomingSymbol = el.condition;
        let upcomingDegreseValue = `${el.low}°/${el.high}°`;

        console.log(upcomingDegreseValue);

        let firstUpcomingSpan = createTags('span', icons[upcomingSymbol], 'symbol');
        let secondUpcomingSpan = createTags('span', upcomingDegreseValue, 'forecast-date');
        let thirdUpcomingSpan = createTags('span', el.condition, 'forecast-date');

        parantWetherDiv.appendChild(firstUpcomingSpan);
        parantWetherDiv.appendChild(secondUpcomingSpan);
        parantWetherDiv.appendChild(thirdUpcomingSpan);

        upcomingMainDiv.appendChild(parantWetherDiv);
    })

    upcommingDiv.appendChild(upcomingMainDiv);
}

function currentWheter() {
    let currentDiv = document.getElementById('current');

    let mainDiv = createTags('div', undefined, 'forecasts');
    let symbolSpan = createTags('span', icons[symbol], 'condition symbol');
    let conditionSpan = createTags('span', undefined, 'condition');

    let firstCondSpan = createTags('span', current.name, 'forecast-date');
    let secondCondSpan = createTags('span', degreseValue, 'forecast-date');
    let thirdCondSpan = createTags('span', current.forecast.condition, 'forecast-date');

    conditionSpan.appendChild(firstCondSpan);
    conditionSpan.appendChild(secondCondSpan);
    conditionSpan.appendChild(thirdCondSpan);

    mainDiv.appendChild(symbolSpan);
    mainDiv.appendChild(conditionSpan);

    currentDiv.appendChild(mainDiv);
}

async function getCode(cityName) {

    try {

        let url = `http://localhost:3030/jsonstore/forecaster/locations`;

        let responce = await fetch(url);
        let date = await responce.json();

        let sityCode = date.find(x => x.name.toLowerCase() == cityName.toLowerCase()).code;

        return sityCode;

    } catch (error) {
        errorHeandler(error);
    }
}

async function getCurrend(code) {

    
        let url = `http://localhost:3030/jsonstore/forecaster/today/${code}`;

        let responce = await fetch(url);
        let date = await responce.json();

        return date;   

}

async function getUpcoming(code) {
    
        let url = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;

        let responce = await fetch(url);
        let date = await responce.json();

        return date;   

}

function createTags(type, content, nameOfClass) {

    let element = document.createElement(type);

    if (content !== undefined) {
        element.textContent = content;
    }

    if (nameOfClass !== undefined) {
        element.className = nameOfClass;
    }

    return element;

}

function errorHeandler(error) {
    let upcommingDiv = document.getElementById('upcoming');

    document.getElementById('forecast').style.display = '';
    let h2Element = createTags('h2', 'Error');

    upcommingDiv.appendChild(h2Element);

    document.getElementById('location').value = '';
    
}