import React from 'react';
import  classNames  from 'classnames';

import { TextField, Paper, IconButton, Grid, Button } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';

import SendIcon from '@material-ui/icons/Send';




const useStyles = makeStyles((theme) => ({
    textField:{
        width: '100%'
    },
    container:{
        height:"64px"
    },
    paper:{
        padding: theme.spacing(2)
    }
  }));

export default function MessageInput(props){

    const styles = useStyles();


    return(
        <div className={styles.container}>
            <form noValidate autoComplete="off" >
                <Paper className={classNames(styles.container, styles.paper)} square>
                    <Grid container spacing={0}>
                        <Grid item xs={11}>
                            <TextField
                                className={styles.textField}
                                placeholder="Type a message..."
                            />
                        </Grid>
                        <Grid item>
                            <IconButton>
                                <SendIcon />
                            </IconButton>
                        </Grid>
                    </Grid>
                    
                    
                </Paper>
            </form>
        </div>
    )
}