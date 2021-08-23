function solve() {
    let [nameElement, dateElement, moduleElement, addButton] = document.querySelectorAll('.form-control');

    let modulesOutput = document.querySelector('.modules');

    addButton.addEventListener('click', add)

    let state = {}

    function add(e) {
        e.preventDefault();

        let moduleName = moduleElement.querySelector('select').value;

        let name = nameElement.querySelector('input').value;

        let date = dateElement.querySelector('input').value.split('-').join('/').split('T').join(' - ');        

        if (name === '' || date === ' - ' || moduleName === 'Select module') {
            return;
        }

        //return input values to default value ??? error meaby
        

        let li = createTag('li', undefined, 'flex');
        let h4 = createTag('h4', `${name} - ${date}`, undefined);

        let delButton = createTag('button', 'Del', 'red');

        li.appendChild(h4);
        li.appendChild(delButton);

        delButton.addEventListener('click', () => del(li, moduleName));

        let ul = undefined;
        let div = undefined;

        if (!state[moduleName]) {

            let h3 = createTag('h3', `${moduleName.toUpperCase()}-MODULE`);
            ul = createTag('ul');

            ul.appendChild(li);
            div = createTag('div', undefined, 'module');

            div.appendChild(h3);
            div.appendChild(ul);

            state[moduleName] = { div, ul, lis: [] };

        } else {
            div = state[moduleName].div;
            ul = state[moduleName].ul;
        }

        state[moduleName].lis.push({ li, date });

        state[moduleName].lis
            .sort((a, b) => a.date.localeCompare(b.date))
            .forEach(el => ul.appendChild(el.li));

        modulesOutput.appendChild(div);

    };
    function del(li, moduleName) {

        let currLi = li.firstChild.textContent;

        for (let i = 0; i < state[moduleName].lis.length; i++) {

            const el = state[moduleName].lis[i];

            if (currLi.includes(el.date)) {
                state[moduleName].lis.pop(el);
            }

        }

        if (state[moduleName].lis.length === 0) {
            delete state[moduleName];
        }

        let ulElement = Array.from(li.parentNode.children);
        if (ulElement.length === 1) {
            li.parentNode.parentNode.remove();

        } else {
            li.remove();
        }
    }

    function createTag(type, content, className) {
        let element = document.createElement(type);
        if (content !== undefined) {
            element.textContent = content;
        }

        if (className !== undefined) {
            element.className = className;
        }
        return element;
    }
}
