
import { setupHome, showHome } from './views/home.js';
import {setupTopic} from './views/topic.js'


const main = document.querySelector('main');

const links = {
    'homeLink': showHome,
};

document.querySelector('nav').addEventListener('click', (event) => {
    if (event.target.tagName == 'A') {
        const view = links[event.target.id];
        if (typeof view == 'function') {
            event.preventDefault();
            view();
        }
    }
});

function setupSection(sectionId, setup) {

    const section = document.getElementById(sectionId);
    setup(main, section);
};


setupSection('home-page', setupHome);
setupSection('topic-page', setupTopic);


showHome();




