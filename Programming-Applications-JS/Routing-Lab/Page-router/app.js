import home from './src/views/home.js';
import pricing from './src/views/pricing.js';
import articles from './src/views/articles.js';
import articlesView from './src/views/articleView.js';
import page from './node_modules/page/page.mjs';



page('/home', home);
page('/pricing', pricing);
page('/articles', articles);
page('/articles/:id', articlesView);

page('/', home);

page.start();

