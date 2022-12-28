import React, { useEffect } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { AxiosResponse } from "axios";
import {Actors} from './Actors';
import {Movies} from './Movies';
import {Home} from './Home';
import {Genres} from './Genres';
import {BrowserRouter, Router, Routes, Route, Link, NavLink} from 'react-router-dom';
import { Navbar, Nav, } from "react-bootstrap";

function App() {

//  useEffect(()=>{
//    axios.get('https://localhost:7130/Movie')
 //   .then((response: AxiosResponse<any>) => {
 //     console.log(response.data);
 //   })
 // },[])
  return (
    
    <BrowserRouter>
    
<div className="App cointainer">
<h3 className="d-flex justify-content-center m-3">
React App
</h3>

<nav className="navbar navbar-expand-sm bg-light navbar-dark">
  <ul className="navbar-nav">
      <li className="nav-item- m-1">
      <NavLink className="btn btn-light btn-outline-primary" to="/home">
        Home
      </NavLink>
      </li>

      <li className="nav-item- m-1">
      <NavLink className="btn btn-light btn-outline-primary" to="/actors">
        Actors
      </NavLink>
      </li>

      <li className="nav-item- m-1">
      <NavLink className="btn btn-light btn-outline-primary" to="/genres">
        Genres
      </NavLink>
      </li>

      <li className="nav-item- m-1">
      <Link className="btn btn-light btn-outline-primary" to='/movies'>
        Movies
      </Link>
      </li>

  </ul>
</nav>
  <Routes>
  <Route path="/home" element={<Home />} />
    <Route path='/movies' element={<Movies />}/>
    <Route path='/genres' element={<Genres />}/>
    <Route path='/actors' element={<Actors />}/>
  </Routes>
    </div>
    </BrowserRouter>
  );
}

export default App;
