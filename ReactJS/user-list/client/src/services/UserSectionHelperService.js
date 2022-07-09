export const address = (address) => { 
    return `${address.country}, ${address.city}, ${address.street}, ${address.streetNumber}`;            
}

export const formatData = (props) => {
    const data = new Date(props.data)
      .toLocaleDateString('en-us', {year:"numeric", month:"short", day:"numeric"});     
      
      return data;
}

export const fullName = (firstName, lastName) => {
    return `${firstName} ${lastName}`; 
}