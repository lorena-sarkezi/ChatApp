import React from 'react';
import { Paper, Grid } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
    chatBubbleStyle:{
        //backgroundColor: '#dadef2',
        minHeight: '8%',
        width: 'max-content',
        padding: '5px',
        paddingBottom: '0px',
        maxWidth: '60%',
        wordWrap: 'break-word',
        marginTop:'15px'
    },
    senderStyle:{
        fontWeight: "bold"
    },
    bubbleContent:{
        marginBottom: '0px'
    }
  }));



export default function MessageBubble(props){

    const chatElementPaperElevation = 1;

    const styles = useStyles();

    return(
        <Grid
            container
            justify={props.aligment}
            alignItem="center"
        >
            <Paper elevation={chatElementPaperElevation} className={styles.chatBubbleStyle}>
                {
                    props.displayMsgOwner === true ? <Grid className={styles.senderStyle}>Sender</Grid> : null
                }
                <Grid>
                    <p className={styles.bubbleContent}>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                </Grid>
            </Paper>
        </Grid>
    )
}