function solve() {
  const text = document.getElementById('text').value.toLowerCase().split(' ');
  let nameConvertion = document.getElementById('naming-convention').value;

  let result = '';

  switch (nameConvertion) {

    case 'Camel Case':
      for (let i = 0; i < text.length; i++) {
        if (i === 0) {
          result += text[i];
        }
        else {
          result += text[i].charAt(0).toUpperCase();
          result += text[i].slice(1);
        }
      }
      break;
    case 'Pascal Case':
      for (let i = 0; i < text.length; i++) {
        result += text[i].charAt(0).toUpperCase();
        result += text[i].slice(1);
      }
      break;
    default:
      result = 'Error!';
      break;
  }

  document.getElementById('result').textContent = result;
}

