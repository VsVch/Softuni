import navPage from './nav/navPage.js';
import page from './node_modules/page/page.mjs';

import middleRender from './rendering/middleRender.js';
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

middleRender.containerHelper(mainContainer, navContainer);

page('/welcome', middleRender.insertInContext, navPage.currentView, welcomePage.currentView);
page('/memes', middleRender.insertInContext, navPage.currentView, allMemesPage.currentView)
page('/my-profil', middleRender.insertInContext, navPage.currentView, profilPage.currentView);
page('/create', middleRender.insertInContext, navPage.currentView, createPage.currentView);
page('/details/:id', middleRender.insertInContext, navPage.currentView, detailsPage.currentView);
page('/edit/:id', middleRender.insertInContext, navPage.currentView, editPage.currentView);

page('/logout', middleRender.insertInContext, navPage.currentView, logoutFromPage);
page('/login', middleRender.insertInContext, navPage.currentView, loginPage.currentView);
page('/register', middleRender.insertInContext, navPage.currentView, registerPage.currentView);

page('/index.html', '/welcome');
page('/', '/welcome');

page.start();

async function logoutFromPage(context) {
    await authServece.logout();
    context.page.redirect('/welcome')
}




