export const address = (address) => { 
    return `${address.country}, ${address.city}, ${address.street}, ${address.streetNumber}`;            
}

export const formatData = (currentDate) => {
    
    const dataChange = new Date(currentDate).toLocaleDateString('en-us', {year:"numeric", month:"short", day:"numeric"});     
      
      return dataChange;
}

export const fullName = (firstName, lastName) => {
    return `${firstName} ${lastName}`; 
}