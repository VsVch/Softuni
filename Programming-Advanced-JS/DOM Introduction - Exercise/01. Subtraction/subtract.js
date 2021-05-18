function subtract() {
    const firstNumber = document.getElementById('firstNumber').value;
    const secondNumber = document.getElementById('secondNumber').value;

    let diference = Number(firstNumber - secondNumber);

    document.getElementById('result').textContent = diference;
}