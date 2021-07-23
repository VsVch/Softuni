import { render } from './../node_modules/lit-html/lit-html.js'
import {allTownsTemplate} from './templates/townsTemplates.js'

let form = document.getElementById('form');

form.addEventListener('submit', displayTowns);

let roodDiv = document.getElementById('root');

function displayTowns(e) {
    e.preventDefault();
    console.log(e.target);

    let form = e.target;

    let formDate = new FormData(form);

    let townsString = formDate.get('towns');
    let towns = townsString.split(', ');

    render(allTownsTemplate(towns), roodDiv);
}

