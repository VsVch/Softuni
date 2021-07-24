import articlesData from '../articleDetails.js';

const articlesCreator = (date) =>/*javascript*/`
<article>
    <h3>${date.title}</h3>
    <a href="/articles/${date.id}">Read more</a> 

</article>
`;


export default function (context) {

    let rootElement = document.querySelector('.root');

    let articlesHtml = articlesData.map(el => articlesCreator(el)).join('<hr>');

    rootElement.innerHTML = articlesHtml;
}