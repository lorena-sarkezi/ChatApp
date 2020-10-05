import React, { useState, useContext, useEffect, createContext } from 'react';
import { Router, Route } from 'react-router-dom';

import MainAppContainer from './components/MainAppCointainer';
import SignIn from './components/SignIn';

import './style.css';

export default function App()  {

  return (
    <React.Fragment>
      <Route path='/login' component={SignIn} />
      <Route path='/' component={MainAppContainer} exact/>
    </React.Fragment>
  );
}
