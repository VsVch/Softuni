
import { render } from './../node_modules/lit-html/lit-html.js';

let viewContainer = undefined;
let navContainer = undefined;

function initialize(viewContainerDomElement, navConteinerDomElement) {    
    viewContainer = viewContainerDomElement; 
    navContainer = navConteinerDomElement;
}

async function renderView(templateResult) {
    render(templateResult, viewContainer);      
}

async function renderNav(templateResult) {       
    render(templateResult, navContainer);   
   
}

function decorateContext(context, next) { 
       
    context.renderNav = renderNav
    context.renderView = renderView;    
    next();
}

export default { 
    decorateContext,  
    renderNav,  
    renderView,    
    initialize,    
};