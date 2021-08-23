function solve() {

   let createBtn = document.querySelector('.site-content aside section form button');

   let postSection = document.querySelector('.site-content main section');
   let archiveSection = document.querySelector('.archive-section ol');

   createBtn.addEventListener('click', createPost);

   function createPost(e) {
      e.preventDefault();

      let creatorfild = document.getElementById('creator');
      let titlefild = document.getElementById('title');
      let categoryfild = document.getElementById('category');
      let contentfild = document.getElementById('content');
     
      let creatorName = creatorfild.value;
      let titleName = titlefild.value;
      let categoryName = categoryfild.value;
      let contentName = contentfild.value; 

      let article = createTags('article');
      let h1 = createTags('h1', titleName);
      let firstP = createTags('p', `Category:`);
      let firstPStrong = createTags('strong', categoryName);
      firstP.appendChild(firstPStrong);

      let secondP = createTags('p', 'Creator:');
      let secondPStrong = createTags('strong', creatorName);
      secondP.appendChild(secondPStrong);

      let pTextContent = createTags('p', contentName);


      let divButtons = createTags('div', undefined, 'buttons');
      let delBtn = createTags('button', 'Delete');
      delBtn.className = 'btn delete';
      delBtn.addEventListener('click', deletePost)

      let archiveBtn = createTags('button', 'Archive');
      archiveBtn.className = 'btn archive';
      archiveBtn.addEventListener('click', archivePost)


      divButtons.appendChild(delBtn);
      divButtons.appendChild(archiveBtn);

      article.appendChild(h1);
      article.appendChild(firstP);
      article.appendChild(secondP);
      article.appendChild(pTextContent);
      article.appendChild(divButtons);

      postSection.appendChild(article);
   }

   function deletePost(e) {

      let element = e.target.parentNode.parentNode;
      element.remove();

   }

   function archivePost(e) {
      let archivePostName = e.target.parentNode.parentNode.firstChild.textContent;


      let liArchive = createTags('li', archivePostName);
      archiveSection.appendChild(liArchive);

      let archiveLIArray = Array.from(document.querySelectorAll('.archive-section li'));

      archiveLIArray
         .sort((a, b) => a.textContent.localeCompare(b.textContent))
         .forEach(el => archiveSection.appendChild(el));


      let element = e.target.parentNode.parentNode;
      element.remove();
   }

   function createTags(type, tagName, tagClass) {

      let element = document.createElement(type);

      if (tagName) {

         element.textContent = tagName;

      } else if (tagClass) {

         element.className = tagClass;
      }
      return element;
   }

}
