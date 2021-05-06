function personMaker(array) {

    const familyColection = [];

    while (array.length) {

        let comands = array.pop().split(' ');
        let firstName = comands[0];
        let lastName = comands[1];
        let age = Number(comands[2]);

        const person = {
            firstName: firstName,
            lastName: lastName,
            age: age
        }
        
        familyColection.push(person);        
    } 
    console.log('My family :');
    for(const person of familyColection){

        console.log(`           First name: ${person.firstName}, Last name: ${person.lastName}, Age: ${person.age}`);

    }    
   
}

personMaker(
    ['Lubomir Stefanov 0.3', 'Mihail Stefanov 6', 'Mariya Veleva 34', 'Aleksandar Stefanov 38']);

    
    