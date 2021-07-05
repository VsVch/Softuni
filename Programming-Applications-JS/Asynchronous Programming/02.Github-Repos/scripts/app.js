function loadRepos() {
	let mainUrl = 'https://api.github.com/users/';

	let username = document.getElementById('username').value;

	fetch(`${mainUrl}${username}/repos`)
		.then(res => res.json())
		.then(date => {
			let ulElement = document.getElementById('repos');
			ulElement.innerHTML = '';
			date.forEach(repos => {

				let liElement = document.createElement('li');
				liElement.textContent = repos.full_name;

				ulElement.appendChild(liElement);

			})
		}).catch(err => {
			console.log('like 404 “Not Found”')
			console.log(err);
		});

}

// async await
async function asyncloadRepos() {

	let mainUrl = 'https://api.github.com/users/';
	let username = document.getElementById('username').value;

	try {
		
		const responce = await fetch(`${mainUrl}${username}/repos`);

		if (responce.status == 404) {
			throw new Error('User not found');
		}
		const date = await responce.json();

		let ulElement = document.getElementById('repos');
		ulElement.innerHTML = '';

		date.forEach(repos => {

			let liElement = document.createElement('li');
			liElement.textContent = repos.full_name;

			ulElement.appendChild(liElement);
		})

	} catch (error) {
		console.log('Promise rejected');
		console.log(error);
	}

}

