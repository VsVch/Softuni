import articleDetails from "../articleDetails.js";
const articleTemplate = (date) => `

<article>
  <header>
      <h1>${date.title}</h1>
   </header>
    
   <main>
       <p>${date.content}</p> 
      
   </main>
   <footer>
       <p>Created by: ${date.author}</p> 
       <button id="finishBtn">Finish</button>
   </footer>
</article> 
`

export default function articlesView(context) {
    let rootElement = document.querySelector('.root');


    let index = context.params.id
    //let currArticles = articleDetails[index -1];

    // deferent way
    let currArticles = articleDetails.find(el => el.id == index)

    rootElement.innerHTML = articleTemplate(currArticles);

    rootElement.querySelector('#finishBtn').addEventListener('click', () => {
        context.page.redirect('/articles');
    })
}