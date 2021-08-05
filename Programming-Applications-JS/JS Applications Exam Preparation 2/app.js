import renderingMiddleware from './rendering/renderingMiddleware.js';
import page from './node_modules/page/page.mjs';


import navPage from './nav/navPage.js';
import homePage from './src/home/homePage.js';
import loginPage from './src/login/loginPage.js';
import registerPage from './src/register/registerPage.js';
import authService from './service/authService.js';
import carsPage from './src/cars/carsPage.js';
import createPage from './src/create/createPage.js';
import detailsPage from './src/details/detailsPage.js';
import myCarsPage from './src/myCars/myCarsPage.js';
import editPage from './src/edit/editPage.js';
import searchPage from './src/search/searchPage.js';

let navContainer = document.querySelector('#container header');
let viewContainer = document.querySelector('#site-content');

renderingMiddleware.initialize(viewContainer, navContainer);

page('/home', renderingMiddleware.decorateContext, navPage.getView, homePage.getView);
page('/login', renderingMiddleware.decorateContext, navPage.getView, loginPage.getView);
page('/register', renderingMiddleware.decorateContext, navPage.getView, registerPage.getView);
page('/logout', renderingMiddleware.decorateContext, navPage.getView, logoutFromPage);
page('/cars', renderingMiddleware.decorateContext, navPage.getView, carsPage.getView);
page('/create', renderingMiddleware.decorateContext, navPage.getView, createPage.getView);
page('/details/:id', renderingMiddleware.decorateContext, navPage.getView, detailsPage.getView);
page('/myCars', renderingMiddleware.decorateContext, navPage.getView, myCarsPage.getView);
page('/edit/:id', renderingMiddleware.decorateContext, navPage.getView, editPage.getView);
page('/search', renderingMiddleware.decorateContext, navPage.getView, searchPage.getView);

page('/', 'home');
page('/index.html', 'home');

page.start();


async function logoutFromPage(context) {
    await authService.logout();
    context.page.redirect('/home')
}
