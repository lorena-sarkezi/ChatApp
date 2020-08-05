import React, { useState, useContext, useEffect, createContext } from 'react';

import authService from './api-authorization/AuthorizeService';

import TitleBar from './TitleBar';
import RecepientsList from './RecepientsList';
import RecepientsSearchToolbar from './RecepientsSearchToolbar';

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
      height: "calc(100% - 64px)"
    },
    gridContainer: {
      //flexGrow: 1,
      height: "100%"
    },
    gridItem:{
      height: "100%"
    }
  }));


export default function MainAppContainer(props){

    const classes = useStyles();

    const UserContext = createContext();
    
    useEffect(() => {
        UserContext.Provider = authService.getUser();
    }, []);

    return(
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
    )
}