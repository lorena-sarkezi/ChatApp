import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import AccountCircleIcon from '@material-ui/icons/AccountCircle';
import PersonIcon from '@material-ui/icons/Person';
import{
    Grid,
    Avatar, 
    Typography,
    Divider
} from '@material-ui/core';

const useStyles = makeStyles((theme) => ({
    gridMsgItem: {
      margin: `${theme.spacing(1)}px auto`,
      paddingLeft: theme.spacing(2),
      paddingRight: theme.spacing(2),
      paddingTop: theme.spacing(1),
      paddingBottom: theme.spacing(1)
    },
    avatarSize:{
        width: theme.spacing(6),
        height: theme.spacing(6),
    },
    avatarIconSize:{
        fontSize: "1.1em"
    },
    recepientTitle:{
        fontWeight: 550,
        fontSize: "1em"
    },
    latestMsgText:{
        fontWeight: 300,
        fontSize: "0.9em"
    },
    latestMsgTime:{
        fontWeight: 300,
        fontSize: "0.9em",
        float: "right"
    }
  }));
  


export default function RecepientsListItem(props){
    const classes = useStyles();

    const message = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";

    return(
        <React.Fragment>
            <Grid container className={classes.gridMsgItem} spacing={1}>
                <Grid item>
                    <Avatar className={classes.avatarSize}>
                        <PersonIcon style={{fontSize:"1.5em"}}/>
                    </Avatar>
                </Grid>
                <Grid item md zeroMinWidth>
                    <Grid container spacing={0} >
                        <Grid item md={9} >
                            <Typography className={classes.recepientTitle} noWrap>{props.recepientName}</Typography>
                        </Grid>
                        <Grid item md={3}>
                            <Typography className={classes.latestMsgTime} noWrap>{props.timestamp}</Typography>
                        </Grid>
                        
                    </Grid>
                    <Grid container spacing={0}>
                        <Typography className={classes.latestMsgText} noWrap>You: {props.latestMsg}</Typography>
                    </Grid>
                </Grid>
            </Grid>
            <Divider />
        </React.Fragment>
        
      )
}