const baseUrl = "http://localhost:3005/api/users";

//export async function getAll()
export const getAll = async () => {
    
    const response = await fetch(baseUrl);
    const result = await response.json();

    return result.users;

    // fetch(baseUrl)
    //      .then((res) => res.json())
    //       .then((result) => {
    //       setUsers(result.users);
    // });
}

export const getOne = async (userId) => {
    const response = await fetch(`${baseUrl}/${userId}`)
    const result = await response.json();

    return result.user;
}

export const create = async (data) => {
    const response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });

    const result = await response.json();    
    return result;
}