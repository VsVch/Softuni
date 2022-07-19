import {Route, Routes, useNavigate} from 'react-router-dom'
import {useEffect, useState} from 'react';
import uniqid from 'uniqid'

import * as gameService from './services/gameService.js'

import "./App.css";
import Header from "./components/Header/Header.js";
import Home from "./components/Home/Home.js";
import Login from "./components/Login/Login.js";
import Register from './components/Register/Register.js';
import CreateGame from './components/CreateGame/CreateGame.js'
import Catalog from './components/Catalog/Catalog.js';
import DetailsGame from './components/DetailsGame/DetailsGame.js';

function App() {

  const[games, setGames] = useState([]);
  const navigate = useNavigate()

  const addComment = (gameId, comment) => {
    setGames(state => {
      const game = state.find(x => x._id == gameId);

      const comments = game.comments || [];
      comments.push(comment);

      return [
        ...state.filter(x => x._id !== gameId),
        {...game, comments},        
      ]
    })
  };

    useEffect(()=> {
        gameService.getAll()
            .then(result => {
                console.log(result);
                    setGames(result);
                });            
    },[]);

    const addGameHandler = (gameData) => {
        setGames(state => [
          ...state,
          {
            ...gameData,
            _id: uniqid(),
          },
        ])
        navigate('/catalog')
    };

  return (
    <div className="App">
      <div id="box">
        <Header/>
        {/* Main Content */}
        <main id="main-content"></main>
        {/*Home Page*/}
        <Routes>
           <Route path="/" element={<Home games={games}/>} />
           <Route path={"/login"} element={<Login/>} />
           <Route path={"/register"} element={<Register/>} />
           <Route path={"/create"} element={<CreateGame addGameHandler={addGameHandler}/>} />
           <Route path={"/catalog"} element={<Catalog games={games}/>}/>
           <Route path={"/catalog/:gameId"} element={<DetailsGame games={games} addComment={addComment}/>}/>
        </Routes>           
      
        {/* Create Page ( Only for logged-in users ) */}
        {/*  */}


        {/* Edit Page ( Only for the creator )*/}
        {/* <section id="edit-page" className="auth">
          <form id="edit">
            <div className="container">
              <h1>Edit Game</h1>
              <label htmlFor="leg-title">Legendary title:</label>
              <input type="text" id="title" name="title" defaultValue="" />
              <label htmlFor="category">Category:</label>
              <input
                type="text"
                id="category"
                name="category"
                defaultValue=""
              />
              <label htmlFor="levels">MaxLevel:</label>
              <input
                type="number"
                id="maxLevel"
                name="maxLevel"
                min={1}
                defaultValue=""
              />
              <label htmlFor="game-img">Image:</label>
              <input
                type="text"
                id="imageUrl"
                name="imageUrl"
                defaultValue=""
              />
              <label htmlFor="summary">Summary:</label>
              <textarea name="summary" id="summary" defaultValue={""} />
              <input
                className="btn submit"
                type="submit"
                defaultValue="Edit Game"
              />
            </div>
          </form>
        </section> */}


        {/*Details Page*/}
        {/*  */}

        {/* Catalogue */}
        {/*  */}
      </div>
    </div>
  );
}

export default App;
