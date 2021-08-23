function calc() {
   const number1 = Number(document.getElementById('num1').value);
   const number2 = Number(document.getElementById('num2').value);

    const result = number1 + number2;
    document.getElementById('sum').value = result;
}

