let baseUrl = 'http://localhost:3030/data';
let movieListElement = document.getElementById('movies-list');
document.getElementById('load-movies').addEventListener('click', () => {
    fetch(`${baseUrl}/movies`)
        .then(res => res.json())
        .then(movies => {
            movies.forEach(movie => {
                let liElement = document.createElement('li');
                liElement.textContent = movie.title;

                movieListElement.appendChild(liElement);
            })
        })
    // .catch(err => {
    //     console.log(err);
    // })
})

document.getElementById('add-movie').addEventListener('click', () => {
    fetch(`${baseUrl}/movies`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            title: 'Man of steel'
        })
    })
        .then(res => {
            console.log('sent');
        })
})