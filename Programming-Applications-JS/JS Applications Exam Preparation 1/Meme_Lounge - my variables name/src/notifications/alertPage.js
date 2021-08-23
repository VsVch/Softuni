import { render, html } from "../../node_modules/lit-html/lit-html.js";

let alertElement = document.getElementById('notifications');

async function createAlert(messege) {

    let model = {
        messege,
    }

    let template = alertTemplate(model);
    renderAlert(template);
    setTimeout(() => renderAlert(null), 3000)
}

async function renderAlert(templateResult) {
    render(templateResult, alertElement)
}

let alertTemplate = (model) => html` 
<div id="errorBox" class="notification">
    <span>${model.messege}</span>
</div>`

export default {
    createAlert,
}