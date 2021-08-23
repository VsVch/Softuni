async function solution() {

    let url = `http://localhost:3030/jsonstore/advanced/articles/list`;

    let responce = await fetch(url);
    let date = await responce.json();

    date.map(el => el).forEach(el => {
        let main = document.getElementById('main');
        let element = createTag(el);
        main.appendChild(element);
    });
}

function createTag(element) {

    let mainDiv = document.createElement('div');
    mainDiv.className = 'accordion';

    let firstDiv = document.createElement('div');
    firstDiv.className = 'head';

    let span = document.createElement('span');
    span.textContent = element.title;

    let button = document.createElement('button');
    button.className = 'button';
    button.id = element._id;
    button.textContent = 'More';    
    button.addEventListener('click', showMore);

    firstDiv.appendChild(span);
    firstDiv.appendChild(button);

    let secondDiv = document.createElement('div');
    secondDiv.className = 'extra';
    

    let p = document.createElement('p');
    p.id = 'articalContent';
    p.value = 'lock'

    secondDiv.appendChild(p);

    mainDiv.appendChild(firstDiv);
    mainDiv.appendChild(secondDiv);

    return mainDiv;
}

async function showMore(e) {
    let btn = e.target;
    let articleId = e.target.id;
    let mainDiv = e.target.parentElement.parentElement;
    let currArticle = mainDiv.querySelector('#articalContent');  
    let hiddenDiv = currArticle.parentElement;  

    let articleUrl = `http://localhost:3030/jsonstore/advanced/articles/details/${articleId}`;   
   
    let responceId = await fetch(articleUrl);
    let date = await responceId.json();  
    currArticle.textContent = date.content;     

    btn.textContent = btn.textContent === 'More' ? 'Less' : 'More';

    hiddenDiv.style.display = hiddenDiv.style.display === 'block' ? 'none' : 'block';  
}
