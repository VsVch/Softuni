function deleteByEmail() {
    const email = document.querySelector('input[name="email"]').value;
    const resultElement = document.getElementById('result');

    const rows = Array.from(document.querySelectorAll('tbody tr'));

    let deleted = false;

    // for (let row of rows) {
    //     if (row.children[1].textContent == email) {
    //         row.parentNode.removeChild(row);
    //         deleted = true;

    //         resultElement.textContent = 'Deleted.';
    //     }
    // }

   const matches = rows.filter(r =>r.children[1].textContent == email);
    if(matches.length > 0){
        matches.forEach(r => r.remove());
        resultElement.textContent = 'Deleted';
    }else{
        resultElement.textContent = 'Not found.';
    }

    // if (deleted != true) {
    //     resultElement.textContent = 'Not found.';
    // }

}