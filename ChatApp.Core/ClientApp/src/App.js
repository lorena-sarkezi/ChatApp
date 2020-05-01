import React, { useState, useContext, useEffect, createContext } from 'react';

import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import authService from './components/api-authorization/AuthorizeService';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import TitleBar from './components/TitleBar';
import RecepientsList from './components/RecepientsList';
import RecepientsSearchToolbar from './components/RecepientsSearchToolbar';

import { Paper, Container, Grid, Typography, TextField, Toolbar } from '@material-ui/core'

import { makeStyles } from '@material-ui/core/styles';


const useStyles = makeStyles((theme) => ({
  paper: {
    height: "100%",
    maxHeight: "900px"
  },
  container:{
    height: "100vh",
    
  },
  main:{
    height: "100%"
  },
  gridContainer: {
    //flexGrow: 1,
    height: "100%"
  },
  gridItem:{
    height: "100%"
  }
}));

export default function App()  {

  const classes = useStyles();

  const UserContext = createContext();
  
  useEffect(() => {
    UserContext.Provider = authService.getUser();
  }, []);
 
  

  return (
    
    // <Layout>
    //   <Route exact path='/' component={Home} />
    //   <Route path='/counter' component={Counter} />
    //   <AuthorizeRoute path='/fetch-data' component={FetchData} />
    //   <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
    // </Layout>

    <UserContext.Provider>
      <Container className={classes.container}>
          <Paper className={classes.paper}>
          <TitleBar />
            <main className={classes.main}>
              <Grid container spacing={0} className={classes.gridContainer}>
                <Grid item md={4} className={classes.gridItem}>
                  <RecepientsSearchToolbar />
                  <RecepientsList />
                </Grid>
                <Grid item md>
                </Grid>
              </Grid>
            </main>
          </Paper> 
      </Container>
    </UserContext.Provider>
  );
}
