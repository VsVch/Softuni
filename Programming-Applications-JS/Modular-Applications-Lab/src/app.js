import page from './../node_modules/page/page.mjs';

import { homePage } from '../views/homeView.js';
import { loginPage } from '../views/loginView.js';
import { moviesPage } from '../views/moviesView.js';
import { renderMiddlewares } from '../middlewears/renderMiddlewares.js';
import { moviesDetailsPage } from '../views/movieDetailsView.js';
import  {authMiddleware}  from '../middlewears/authMiddleware.js';

page(authMiddleware);
page(renderMiddlewares);

page('/', homePage);
page('/login', loginPage);
page('/movies', moviesPage);
page('/movies/:movieId', moviesDetailsPage);
page('/', homePage);

page.start();