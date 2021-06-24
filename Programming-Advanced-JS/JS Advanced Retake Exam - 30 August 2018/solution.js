function addDestination() {

    let [cityFild, countryFild] = document.querySelectorAll('.inputData');
    let seasonFild = document.querySelector('#seasons');
    let tbodyMainElement = document.getElementById('destinationsList');

    let summerFild = document.getElementById('summer');
    let autumnFild = document.getElementById('autumn');
    let winterFild = document.getElementById('winter');
    let springFild = document.getElementById('spring');

    let cityName = cityFild.value;
    let countryName = countryFild.value;
    let seasonName = seasonFild.value;

    cityFild.value = '';
    countryFild.value = '';
   

    if (cityName === '' || countryName === '') {
        return
    }

    let stringetCityName = createString(cityName);
    let stringetCountryName = createString(countryName);
    let stringetSeasonName = createString(seasonName);

    let elementName = `${stringetCityName}, ${stringetCountryName}`;  // error?

    let trParent = tbodyMainElement.insertRow(0);

    let firstTd = trParent.insertCell(0);
    let secondTd = trParent.insertCell(0);

    let firstElTxt = document.createTextNode(stringetSeasonName);
    let secondElTxt = document.createTextNode(elementName);

    firstTd.appendChild(firstElTxt);
    secondTd.appendChild(secondElTxt);

    let seasons = {
        'Summer': 0,
        'Autumn': 0,
        'Spring': 0,
        'Winter': 0,
    }

    let seasonTable = Array.from(document.querySelectorAll('#destinationsList tr'));

    for (let i = 0; i < seasonTable.length; i++) {

        let season = seasonTable[i].lastChild.textContent;

        switch (season) {
            case 'Summer':
                seasons[season] += 1;
                break;
            case 'Autumn':
                seasons[season] += 1;
                break;
            case 'Spring':
                seasons[season] += 1;
                break;
            case 'Winter':
                seasons[season] += 1;
                break;
        }
    }   

    summerFild.value = seasons['Summer'];
    autumnFild.value = seasons['Autumn'];
    springFild.value = seasons['Spring'];
    winterFild.value = seasons['Winter'];

    function createString(element) {

        let newElement = '';
    
        for (let i = 0; i < element.length; i++) {
    
            if (i === 0) {
    
                newElement += element[i].toUpperCase();
            } else {
                newElement += element[i];
            }
    
        }
    
        return newElement;
    
    }
}




