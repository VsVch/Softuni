import { render } from '../node_modules/lit-html/lit-html.js';
import { renderNavigation } from '../views/navigationView.js';

let roodElement = document.querySelector('.root');
let navigationElement = document.querySelector('.navigation');

const contextRender = templateResult => {    
    render(templateResult, roodElement);
};

export function renderMiddlewares(ctx, next) {
    render(renderNavigation(), navigationElement);   
    ctx.render = contextRender;   

    next();
}
