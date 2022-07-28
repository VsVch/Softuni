import { Route, Routes, useNavigate } from "react-router-dom";
import { useContext, useEffect, useState } from "react";

import * as gameService from "./services/gameService.js";
import {AuthContext} from "./contexts/AuthContext.js";
import { GameContext } from "./contexts/GameContext.js";

import "./App.css";
import Header from "./components/Header/Header.js";
import Home from "./components/Home/Home.js";
import Login from "./components/Login/Login.js";
import Logout from "./components/Logout/Logout.js";
import Register from "./components/Register/Register.js";
import CreateGame from "./components/CreateGame/CreateGame.js";
import EditGame from "./components/EditGame/EditGame.js";
import Catalog from "./components/Catalog/Catalog.js";
import DetailsGame from "./components/DetailsGame/DetailsGame.js";
import useLocalStorage from "./hooks/useLocalStorage.js";

function App() {
  const [games, setGames] = useState([]);
  const [auth, setAuth] = useLocalStorage('auth',{});
  const navigate = useNavigate();

  const userLogin = (authData) => {
    setAuth(authData);
  };

  const userLogout = () => {
    setAuth({});
  };

  const addComment = (gameId, comment) => {
    setGames((state) => {
      const game = state.find((x) => x._id == gameId);

      const comments = game.comments || [];
      comments.push(comment);

      return [...state.filter((x) => x._id !== gameId), { ...game, comments }];
    });
  };

  useEffect(() => {
    gameService.getAll()
      .then((result) => {
        setGames(result);
    });
  }, []);

  const gameAdd = (gameData) => {
    setGames((state) => [
      ...state,
      gameData
    ]);
    navigate("/catalog");
  };

  const gameEdit = (gameId, gameData) => {
      setGames(state => state.map(x => x._id === gameId ? gameData : x));
  };

  return (
    <AuthContext.Provider value={{user: auth, userLogin, userlogout: userLogout}}>
      <div className="App">
        <div id="box">
          <Header />
         
          <main id="main-content"></main>
          <GameContext.Provider value={{games, gameAdd, gameEdit}}>
          <Routes>
            <Route path="/" element={<Home games={games} />} />
            <Route path={"/login"} element={<Login />} />
            <Route path={"/register"} element={<Register />} />
            <Route path={"/logout"} element={<Logout />} />
            <Route path={"/create"} element={<CreateGame/>}/>
            <Route path={"/games/:gameId/edit"} element={<EditGame/>}/>
            <Route path={"/catalog"} element={<Catalog games={games}/>} />
            <Route path={"/catalog/:gameId"} element={<DetailsGame games={games} addComment={addComment} />}
            />
          </Routes>
          </GameContext.Provider>
        
        </div>
      </div>
    </AuthContext.Provider>
  );
}

export default App;
