import React from 'react';
import { Route } from 'react-router-dom';

import MainAppContainer from './components/MainAppCointainer';
import SignIn from './components/SignIn';
import SignUp from './components/SignUp';
import AuthorizedRoute from'./components/AuthorizedRoute';

import './style.css';

export default function App()  {

  return (
    <React.Fragment>
      <Route path='/login' component={SignIn} exact/>
      <Route path='/register' component={SignUp} exact/>
      <AuthorizedRoute path='/' component={MainAppContainer} exact={true}/>
    </React.Fragment>
  );
}
