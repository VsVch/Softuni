import  {html } from '../../node_modules/lit-html/lit-html.js';

export let liTownTemplate = (town) => html`<li>${town}</li>`

export let allTownsTemplate = (towns) =>html`
<ul>
    ${towns.map(t => liTownTemplate(t))}
</ul>
`;