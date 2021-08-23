import { html } from '../../node_modules/lit-html/lit-html.js'

export let catTemplate = (cat, showStatus) => html`
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn" @click=${showStatus}>Show status code</button>
        <div class="status hidden" id=${cat.id}>
            <h4>${cat.statusCode}</h4>
            <p>${cat.statusMessage}</p>
        </div>
    </div>
</li>
`;

export let allCatsTemplate = (cats, showStatus) => html`    
<ul>
    ${cats.map(c => catTemplate(c, showStatus))};
</ul>
`;
