function solve() {

    let taskFild = document.getElementById('task');
    let descriptionFild = document.getElementById('description');
    let dateFild = document.getElementById('date');

    let [action, open, inProgres, complete] = document.querySelectorAll('.wrapper section');

    let openSection = open.lastElementChild;
    let inProgresSection = inProgres.lastElementChild;
    let completeSection = complete.lastElementChild;


    let addBtn = document.getElementById('add');

    addBtn.addEventListener('click', addTask)

    function addTask(e) {

        e.preventDefault();

        let task = taskFild.value;
        let description = descriptionFild.value;
        let date = dateFild.value;

        if (task === '' || description === '' || date === '') {
            return;
        }

        let openArticle = createArticle(task, description, date, 'open');
        openSection.appendChild(openArticle);
    }


    function startTask(task, description, date) {

        let inProcessArticle = createArticle(task, description, date, 'inProgress');
        inProgresSection.appendChild(inProcessArticle);
    }

    function finishTask(task, description, date) {
        let completeArticle = createArticle(task, description, date);
        completeSection.appendChild(completeArticle);
    }

    function deleteTask(task, description, date) {

        let openSectionColection = Array.from(openSection.querySelectorAll('article'));
        let inProgresSectionColection = Array.from(inProgresSection.querySelectorAll('article'));
        let completeSectionColection = Array.from(completeSection.querySelectorAll('article'));        

        removeElement(openSectionColection, task, date);
        removeElement(inProgresSectionColection, task, date);
        removeElement(completeSectionColection, task, date);   
       
    }

    function removeElement(section, task, date){

        for (let i = 0; i < section.length; i++) {

            let taskElement = section[i].children[0].textContent;
            let dateElement = section[i].children[2].textContent;                

            if (taskElement === task &&  dateElement.includes(date)) {
                section[i].remove();
            }

        }
    }


    function createArticle(task, description, date, section) {

        let article = createTags('article');
        let h3 = createTags('h3', task);
        let pDescription = createTags('p', `Description: ${description}`);
        let pDate = createTags('p', `Due Date: ${date}`);

        article.appendChild(h3);
        article.appendChild(pDescription);
        article.appendChild(pDate);

        if (section === 'open') {

            let startButton = createTags('button', 'Start', 'green');
            let delButton = createTags('button', 'Delete', 'red');
            let divButtons = createTags('div', undefined, 'flex');

            startButton.addEventListener('click', () => startTask(task, description, date));

            delButton.addEventListener('click', () => deleteTask(task, description, date));

            divButtons.appendChild(startButton);
            divButtons.appendChild(delButton);

            article.appendChild(divButtons);

        } else if (section === 'inProgress') {

            let delButton = createTags('button', 'Delete', 'red');
            let finishButton = createTags('button', 'Finish', 'orange');
            let divButtons = createTags('div', undefined, 'flex');

            delButton.addEventListener('click',() => deleteTask(task, description, date));

            finishButton.addEventListener('click', () => finishTask(task, description, date));

            divButtons.appendChild(delButton);
            divButtons.appendChild(finishButton);

            article.appendChild(divButtons);
        }

        return article;
    }


    function createTags(type, name, className) {

        let element = document.createElement(type);

        if (name) {
            element.textContent = name;
        }
        if (className) {
            element.className = className;
        }

        return element;

    }
}