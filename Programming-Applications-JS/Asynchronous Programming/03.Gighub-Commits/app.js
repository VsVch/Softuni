function loadCommits() {
    // Try it with Fetch API

    let userName = document.getElementById('username').value;
    let repo = document.getElementById('repo').value;

    let url = `https://api.github.com/repos/${userName}/${repo}/commits`

    let ul = document.getElementById('commits');

    fetch(url)
        .then(res => res.json())
        .then(logs => {            
            logs.forEach(commit => {

                console.log(commit)
                let liElement = document.createElement('li');
                liElement.textContent = `${commit.commit.author.name}: ${commit.commit.message}`;
                ul.appendChild(liElement);
            })

        })
        .catch(err=>{
            let liError = document.createElement('li');
            liError.textContent = 'Error: 404 (Not Found)';
            ul.appendChild(liError);
            console.log(err)
        })
        

    console.log('TODO...');
}