import React from "react";
import {Link, NavLink} from 'react-router-dom';

export const Navigation = () => {
    return (
    <nav>
        <ul>
            {/* <li><Link to="/">Home</Link></li>
            <li><Link to="/about">About</Link></li>
            <li><Link to="/pricing">Pricing</Link></li>
            <li><Link to="/pricing/premium">Primium Pricing</Link></li>
            <li><Link to="/products/2">Product</Link></li>
            <li><Link to="/contacts">Contacts</Link></li>
            <li><Link to="/millennium-falcon">/Millennium Falcon</Link></li> */}

            <li><NavLink to="/" className><em>Home</em></NavLink></li>
            <li><NavLink to="/about">About</NavLink></li>
            <li><NavLink to="/pricing">Pricing</NavLink></li>
            <li><NavLink to="/pricing/premium">Primium Pricing</NavLink></li>
            <li><NavLink to="/products/2">Product</NavLink></li>
            <li><NavLink to="/contacts">Contacts</NavLink></li>
            <li><NavLink to="/millennium-falcon">/Millennium Falcon</NavLink></li>
        </ul>
    </nav>
    )
}