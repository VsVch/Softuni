window.addEventListener('load', solution);

function solution() {
  let sumitBtn = document.getElementById('submitBTN');

  sumitBtn.addEventListener('click', submitList);

  function submitList() {

    let fullNameFild = document.getElementById('fname');
    let fullName = fullNameFild.value;

    let emailFild = document.getElementById('email');
    let email = emailFild.value;

    let phNumFild = document.getElementById('phone');
    let phNum = phNumFild.value;

    let addresFild = document.getElementById('address');
    let addres = addresFild.value;

    let postCodeFild = document.getElementById('code');
    let posteCode = postCodeFild.value;

    if (fullNameFild === '' || email === '') {
      return;
    }

    fullNameFild.value = '';
    emailFild.value = '';
    phNumFild.value = '';
    addresFild.value = '';
    postCodeFild.value = '';

    let ul = document.getElementById('infoPreview');
    let li1 = createTag('li', `Full Name: ${fullName}`);
    let li2 = createTag('li', `Email: ${email}`);
    let li3 = createTag('li', `Phone Number: ${phNum}`);
    let li4 = createTag('li', `Address: ${addres}`);
    let li5 = createTag('li', `Postal Code: ${posteCode}`);

    ul.appendChild(li1);
    ul.appendChild(li2);
    ul.appendChild(li3);
    ul.appendChild(li4);
    ul.appendChild(li5);

    let edditBtn = document.getElementById('editBTN');
    let continueBtn = document.getElementById('continueBTN');

    continueBtn.removeAttribute('disabled');
    edditBtn.removeAttribute('disabled');

    continueBtn.addEventListener('click', continuInfo)

    edditBtn.addEventListener('click',() =>edditInfo(fullName, email, phNum, addres, posteCode, li1, li2, li3, li4, li5))

  }

  function continuInfo() {

    let edditBtn = document.getElementById('editBTN');
    edditBtn.setAttribute("disabled", true);

    let sumitBtn = document.getElementById('submitBTN');
    sumitBtn.setAttribute("disabled", true);

    let divBlock = document.getElementById('block');
    divBlock.remove();

    let body = document.querySelector('body');

    let h3 = createTag('h3', 'Thank you for your reservation!');
    let div = createTag('div', undefined, 'block');
    div.appendChild(h3)
    body.appendChild(div);

  }

  function edditInfo(fullName, email, phNum, addres, posteCode, li1, li2, li3, li4, li5) {

    let continueBtn = document.getElementById('continueBTN');
    continueBtn.setAttribute("disabled", true);

    let sumitBtn = document.getElementById('submitBTN');
    sumitBtn.setAttribute("disabled", true);

    let fullNameFild = document.getElementById('fname');
    fullNameFild.value = fullName;

    let emailFild = document.getElementById('email');
    emailFild.value = email;

    let phNumFild = document.getElementById('phone');
    phNumFild.value = phNum;

    let addresFild = document.getElementById('address');
    addresFild.value = addres;

    let postCodeFild = document.getElementById('code');
    postCodeFild.value = posteCode;

    li1.remove();
    li2.remove();
    li3.remove();
    li4.remove();
    li5.remove();
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

