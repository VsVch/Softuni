import { html } from '../../node_modules/lit-html/lit-html.js';
import {ifDefined} from '../../node_modules/lit-html/directives/if-defined.js'

export let townTemaplate = (town) => html`<li class=${ifDefined(town.class)}>${town.name}</li>`;

export let townsTemplate = (towns) => html`
<ul>
    ${towns.map(t => townTemaplate(t))};
</ul>
`;

export let matchesTemplate = (match) => html`${match} matches found`;