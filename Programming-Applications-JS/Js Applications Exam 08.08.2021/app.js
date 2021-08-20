
import middleRender from './render/middleRender.js';
import authService from './service/authService.js';

import page from './node_modules/page/page.mjs';

import navPage from './nav/navPage.js';
import dashboardPage from './src/dashboard/dashboardPage.js';
import loginPage from './src/login/loginPage.js';
import registerPage from './src/register/registerPage.js';
import createPage from './src/create/createPage.js';
import detailsPage from './src/details/detailsPage.js';
import editPage from './src/edit/editPage.js';
import myBooksPage from './src/myBooks/myBooksPage.js';

let navElement = document.getElementById('site-header');
let mainElement = document.getElementById('site-content');

middleRender.containerHelper(navElement,mainElement)

page('/dashboard', middleRender.insertInContext, navPage.currentView, dashboardPage.currentView);
page('/create', middleRender.insertInContext, navPage.currentView, createPage.currentView);
page('/details/:id', middleRender.insertInContext, navPage.currentView, detailsPage.currentView);
page('/edit/:id', middleRender.insertInContext, navPage.currentView, editPage.currentView);
page('/myBooks', middleRender.insertInContext, navPage.currentView, myBooksPage.currentView);

page('/login', middleRender.insertInContext, navPage.currentView, loginPage.currentView);
page('/logout', middleRender.insertInContext, navPage.currentView, logoutFromPage);
page('/register', middleRender.insertInContext, navPage.currentView, registerPage.currentView);

page('/index.html', '/dashboard');
page('/', '/dashboard');

page.start();

async function logoutFromPage(context) {
    await authService.logout();
    context.page.redirect('/dashboard')
}
