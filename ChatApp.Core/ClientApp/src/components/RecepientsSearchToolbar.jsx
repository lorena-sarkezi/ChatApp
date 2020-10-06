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



export default function RecepientsSearchToolbar(props){

    const inputSearch = {
        startAdornment: (
            <InputAdornment position="start">
              <SearchIcon />
            </InputAdornment>
          )
    }

    return(
        <Paper elevation={1} square>
            <Toolbar  style={{backgroundColor: "whitesmoke", marginBottom:"5px"}}>
                <Grid container spacing={0} alignItems="flex-end">
                    <Grid item md={10}>
                        <TextField placeholder="Pretraga..." fullWidth InputProps={inputSearch} margin="dense"/>
                    </Grid>
                    
                </Grid>
                
            </Toolbar>
        </Paper>
    )
}