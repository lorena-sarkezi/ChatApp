import React, { useEffect, createContext } from 'react';

import TitleBar from './TitleBar';
import RecepientsList from './RecepientsList';
import RecepientsSearchToolbar from './RecepientsSearchToolbar';
import ChatSurfaceContainer from './ChatSurfaceContainer';
import MessageInput from './MessageInput';

import { Paper, Container, Grid } from '@material-ui/core'

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
        //UserContext.Provider = authService.getUser();
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
                              <ChatSurfaceContainer />
                              <MessageInput />
                            </Grid>
                        </Grid>
                    </main>
                </Paper>
            </Container>
        </UserContext.Provider>
    )
}