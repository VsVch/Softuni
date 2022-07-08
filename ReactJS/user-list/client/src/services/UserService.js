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