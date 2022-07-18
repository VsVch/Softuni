import {Routes, Route, Navigate} from 'react-router-dom';
import React from 'react';

import {Home} from './components/Home.js';
import {About} from './components/About.js';
import Pricing from './components/Pricing.js';
import { Contacts } from './components/Contacts.js';
import { NotFound } from './components/NotFound.js';
import { Navigation } from './components/Navigation.js';
import { Products } from './components/Products.js';

function App() {
  return (     
    <div className="App">
      <h1>Hello React Router </h1>
      <Navigation/>

      <Routes>
          <Route path="*" element={<NotFound/>}></Route>
          <Route path="/" element={<Home/>}></Route>
          <Route path="/about" element={<About/>}></Route>
          <Route path="/pricing/*" element={<Pricing/>}></Route>
          <Route path="/pricing/premium" element={<h2>Premium Price</h2>}></Route>  
          <Route path="/products/:productId" element={<Products id="1"/>}></Route>  
          <Route path="/contacts" element={<Contacts/>}></Route>
          <Route path="/millennium-falcon" element={<Navigate to="/products/10" replace/>}></Route>
      </Routes>   
    </div>
  );
}

export default App;
