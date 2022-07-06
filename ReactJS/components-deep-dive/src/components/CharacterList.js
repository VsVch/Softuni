import { useEffect, useState } from "react";

export const CharacterList = (props) => {

    const [cheracters, setCheracters] = useState([]);    

    useEffect (()=> {
        fetch('https://swapi.dev/api/people')
        .then(res => res.json())
        .then(result => {
            setCheracters(result.results);
        });
    }, []) ;   

    return (
        <ul>
            {!cheracters.length && <li>Loading...</li>}
            {cheracters.map(x => 
                <li key={x.name}>{x.name}</li>)}
        </ul>
    )
}