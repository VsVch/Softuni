import navPage from './nav/navPage.js';
import page from './node_modules/page/page.mjs';

import renderingMiddleware from './rendering/renderingMiddleware.js';
import authServece from './services/authServece.js';

import createPage from './src/create/createPage.js';
import detailsPage from './src/details/detailsPage.js';
import editPage from './src/edit/editPage.js';
import loginPage from './src/login/loginPage.js';
import allMemesPage from './src/memes/allMemesPage.js';
import profilPage from './src/profile/profilPage.js';
import registerPage from './src/register/registerPage.js';
import welcomePage from './src/welcome/welcomePage.js';

let mainContainer = document.getElementById('mainContainer');
let navContainer = document.getElementById('navContainer');

renderingMiddleware.initialize(mainContainer, navContainer);

page('/welcome', renderingMiddleware.decorateContext, navPage.getView, welcomePage.getView);
page('/memes', renderingMiddleware.decorateContext, navPage.getView, allMemesPage.getView)
page('/my-profil', renderingMiddleware.decorateContext, navPage.getView, profilPage.getView);
page('/create', renderingMiddleware.decorateContext, navPage.getView, createPage.getView);
page('/details/:id', renderingMiddleware.decorateContext, navPage.getView, detailsPage.getView);
page('/edit/:id', renderingMiddleware.decorateContext, navPage.getView, editPage.getView);

page('/logout', renderingMiddleware.decorateContext, navPage.getView, logoutFromPage);
page('/login', renderingMiddleware.decorateContext, navPage.getView, loginPage.getView);
page('/register', renderingMiddleware.decorateContext, navPage.getView, registerPage.getView);

page('/index.html', '/welcome');
page('/', '/welcome');

page.start();

async function logoutFromPage(context) {
    await authServece.logout();
    context.page.redirect('/welcome')
}




