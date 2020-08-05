import React, { useState, useContext, useEffect, createContext } from 'react';
import { Router, Route } from 'react-router-dom';

import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import authService from './components/api-authorization/AuthorizeService';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import MainAppContainer from './components/MainAppCointainer';

import { makeStyles } from '@material-ui/core/styles';
import { Layout } from './components/Layout';

import Home from './components/Home.js';
import { Counter } from './components/Counter';
import { FetchData } from './components/FetchData';

export default function App()  {

  return (
    
    // <Layout>
    //   <Route exact path='/' component={Home} />
    //   <Route path='/counter' component={Counter} />
    //   <AuthorizeRoute path='/fetch-data' component={FetchData} />
    //   <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
    // </Layout>

    
    <Route path='/' component={MainAppContainer} />
  );
}
