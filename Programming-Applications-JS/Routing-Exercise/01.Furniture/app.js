import nav from './nav/nav.js';
import page from './node_modules/page/page.mjs';
import createPage from './pages/create/createPage.js';
import dashboardPage from './pages/dashboard/dashboardPage.js'
import detailsPage from './pages/details/detailsPage.js';
import editPage from './pages/edit/editPage.js';
import loginPage from './pages/login/loginPage.js';
import myFurniturePage from './pages/myFurniture/myFurniturePage.js';
import registerPage from './pages/register/registerPage.js';
import renderingMiddleware from './rendering/renderingMiddleware.js';
import authServece from './services/authServece.js';

let appContainer = document.getElementById('viewContainer');
let navContainer = document.getElementById('navigation');


renderingMiddleware.initialize(appContainer, navContainer);

page('/dashboard', renderingMiddleware.decorateContext, nav.getView, dashboardPage.getView);
page('/login', renderingMiddleware.decorateContext, nav.getView, loginPage.getView);
page('/register', renderingMiddleware.decorateContext, nav.getView, registerPage.getView);
page('/details/:id', renderingMiddleware.decorateContext, nav.getView, detailsPage.getView);
page('/create', renderingMiddleware.decorateContext, nav.getView, createPage.getView);
page('/edit/:id', renderingMiddleware.decorateContext, nav.getView, editPage.getView);
page('/my-furniture', renderingMiddleware.decorateContext, nav.getView, myFurniturePage.getView);

page('/logout', async(context) => {await authServece.logout(), context.page.redirect('/login')});

page('/index.html', '/dashboard');
page('/', '/dashboard');


page.start();