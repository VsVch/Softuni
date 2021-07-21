
export async function request(url, options){

    try{
        const response = await fetch(url, options);
        if(!response.ok){
            const error = await response.json();
            throw new Error(error.messsage)
        }else{
            try{
                const data = await response.json();
                return data;

            }catch(err){
                return response;
            }
        }

    }catch(err){
        alert(err.messsage);
        throw err;
    }

}

function getOptions(method = 'get', body){
    const options = {
        method,
        header: {}
    }

    const user = sessionStorage.getItem('user');
    if(user){
        options.header['X-Authorization'] = user.sessionToken;
        options.header['Content-Type'] = 'application/json'
    }

    if(body){
        options.body = JSON.stringify(body)
    }
    return options;
}

export async function get(url){
    return await request(url, getOptions());
}

export async function post(url, body){
    return await request(url, getOptions('post', body));
}

export async function put(url, body){
    return await request(url, getOptions('put', body));
}

export async function del(url){
    return await request(url, getOptions('delete'));
}
