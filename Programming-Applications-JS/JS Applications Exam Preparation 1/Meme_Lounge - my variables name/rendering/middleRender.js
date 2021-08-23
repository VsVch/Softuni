import { render } from '../node_modules/lit-html/lit-html.js';

let viewContainer = undefined;
let navContainer = undefined;

function containerHelper(viewContainerElement, navConteinerElement) {    
    viewContainer = viewContainerElement; 
    navContainer = navConteinerElement;    
}


async function getCurrentView(templateResult) {
    render(templateResult, viewContainer);      
}

async function getNavView(templateResult) {       
   render(templateResult, navContainer);    
}

function insertInContext(context, next) {
       
    context.getNavView = getNavView
    context.getCurrentView = getCurrentView;   
    next();
}

export default { 
    insertInContext,  
    getNavView,  
    getCurrentView,    
    containerHelper,     
};