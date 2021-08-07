import page from './node_modules/page/page.mjs';

import renderingMiddleware from './rendering/renderingMiddleware.js';
import navPage from './nav/navPage.js';
import homePage from './src/home/homePage.js';
import loginPage from './src/login/loginPage.js';
import authServece from './services/authServece.js';
import registerPage from './src/register/registerPage.js';
import createPage from './src/create/createPage.js';
import detailsPage from './src/details/detailsPage.js';
import editPage from './src/edit/editPage.js';


let navContainer = document.getElementById('nav-container');
let mainContainer = document.getElementById('main-container');

renderingMiddleware.initialize(mainContainer, navContainer);

page('/home', renderingMiddleware.decorateContext, navPage.getView, homePage.getView);
page('/login', renderingMiddleware.decorateContext, navPage.getView, loginPage.getView);
page('/logout', renderingMiddleware.decorateContext, navPage.getView, logOutFromPage);
page('/register', renderingMiddleware.decorateContext, navPage.getView, registerPage.getView);
page('/create', renderingMiddleware.decorateContext, navPage.getView, createPage.getView);
page('/details/:id', renderingMiddleware.decorateContext, navPage.getView, detailsPage.getView);
page('/edit/:id', renderingMiddleware.decorateContext, navPage.getView, editPage.getView);

page('/', '/home');
page('/index.html', '/home');

page.start();

async function logOutFromPage(context) {
    await authServece.logout();
    context.page.redirect('/home');
}