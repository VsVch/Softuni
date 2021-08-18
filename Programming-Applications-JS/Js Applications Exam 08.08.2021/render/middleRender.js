import { render } from '../node_modules/lit-html/lit-html.js';

let navContainer = undefined;
let viewContainer = undefined;

function containerHelper(navConteinerElement, viewContainerElement) {    
    
    navContainer = navConteinerElement; 
    viewContainer = viewContainerElement;    
}

async function getNavView(templateResult) {       
    render(templateResult, navContainer);    
}
 

async function getCurrentView(templateResult) {
    render(templateResult, viewContainer);      
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