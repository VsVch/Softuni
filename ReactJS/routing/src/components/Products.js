import React, { useEffect, useState } from "react";
import {useParams, useNavigate, useLocation} from "react-router-dom";

export const Products = () => {

    //const params = useParams();
    const {productId} = useParams();
    const [starships, setStarship] = useState({});
    const navigate = useNavigate();
    const location = useLocation();
    // console.log(location);


    useEffect(()=> {
        fetch(`https://swapi.dev/api/starships/${productId}/`)
        .then(res => res.json())
        .then(result => {
            setStarship(result);
        })
    },[productId])

    const nextProductHandler = () => {
       navigate(`/products/${Number(productId) + 1}`, {replace: false});
    }

    return (
        <>
            <h2>Products Page</h2>
            {/* <h3>Product {params.productId} Specification</h3> */}
            <h3>Product {productId} Specification</h3>
            <ul>
                <li>
                    Name: {starships.name}
                </li>
                <li>
                    Model: {starships.model}
                </li>
                <li>
                    Manufacturer: {starships.manufacturer}
                </li> 
            </ul>   
            <button onClick={nextProductHandler}>Next</button>        
        </>
        
    )
}