import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import SearchIcon from '@material-ui/icons/Search';

import{
    Paper,
    Toolbar,
    TextField, 
    Grid,
    InputAdornment
} from '@material-ui/core';


const useStyles = makeStyles((theme) => ({
    paper: {
      marginTop: "2em",
      height: "100%"
    },
    container:{
      height: "100%"
    },
    root: {
      flexGrow: 1,
    }
  }));

export default function RecepientsSearchToolbar(props){

    const inputSearch = {
        startAdornment: (
            <InputAdornment position="start">
              <SearchIcon />
            </InputAdornment>
          )
    }

    const classes = useStyles();

    return(
        <Paper elevation={1}>
            <Toolbar className={classes.root} style={{backgroundColor: "whitesmoke", marginBottom:"5px"}}>
                <Grid container spacing={0} alignItems="flex-end">
                    <Grid item md={10}>
                        <TextField placeholder="Pretraga..." fullWidth InputProps={inputSearch}/>
                    </Grid>
                    <Grid item>
                    
                    </Grid>
                </Grid>
                
            </Toolbar>
        </Paper>
    )
}