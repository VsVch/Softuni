import { render } from "../node_modules/lit-html/lit-html.js";
import { townsTemplate, matchesTemplate } from "./templates/townTemplates.js";
import { towns } from "./towns.js";

let townsDiv = document.getElementById('towns');
let baseTowns = towns.map(t=> ({name: t}));

render(townsTemplate(baseTowns), townsDiv);

let resultDiv = document.getElementById('result');

let searchBtn = document.getElementById('search-btn');
searchBtn.addEventListener('click', search);

function search() {
   let searchInput = document.getElementById('searchText');
   let searchText = searchInput.value.toLowerCase();

  let allTowns = towns.map(t=>({name: t,}))
  let matchedTowns = allTowns.filter(t => t.name.toLowerCase().includes(searchText));
  matchedTowns.forEach(t => t.class = 'active');

  let count = matchedTowns.length;
  
  render(townsTemplate(allTowns),townsDiv);
  render(matchesTemplate(count),resultDiv);
}
