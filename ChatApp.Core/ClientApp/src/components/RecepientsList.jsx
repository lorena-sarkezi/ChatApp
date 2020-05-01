import React from 'react';
import { makeStyles } from '@material-ui/core/styles';

import RecepientsListItem from './RecepientsListItem';
import { List, ListItem } from '@material-ui/core';

const useStyles = makeStyles((theme) => ({
    listContainer:{
        "overflow-y":"auto",
        height: "100%"
    }
  }));

export default function RecepientsList(props){
    
    const classes = useStyles();

    return(
        <div className={classes.listContainer}>
            <List>
                <ListItem button className={classes.list}>
                    <RecepientsListItem recepientName="Pero Perić" latestMsg="Lorem ipsum dolor sit amet" timestamp="14:31"/>
                </ListItem>
                <ListItem button className={classes.list}>
                    <RecepientsListItem recepientName="Pero Perić" latestMsg="Lorem ipsum dolor sit amet" timestamp="14:31"/>
                </ListItem>
                <ListItem button className={classes.list}>
                    <RecepientsListItem recepientName="Pero Perić" latestMsg="Lorem ipsum dolor sit amet" timestamp="14:31"/>
                </ListItem>
                <ListItem button className={classes.list}>
                    <RecepientsListItem recepientName="Pero Perić" latestMsg="Lorem ipsum dolor sit amet" timestamp="14:31"/>
                </ListItem>
                <ListItem button className={classes.list}>
                    <RecepientsListItem recepientName="Pero Perić" latestMsg="Lorem ipsum dolor sit amet" timestamp="14:31"/>
                </ListItem>
                <ListItem button className={classes.list}>
                    <RecepientsListItem recepientName="Pero Perić" latestMsg="Lorem ipsum dolor sit amet" timestamp="14:31"/>
                </ListItem>
                <ListItem button className={classes.list}>
                    <RecepientsListItem recepientName="Pero Perić" latestMsg="Lorem ipsum dolor sit amet" timestamp="14:31"/>
                </ListItem>
                <ListItem button className={classes.list}>
                    <RecepientsListItem recepientName="Pero Perić" latestMsg="Lorem ipsum dolor sit amet" timestamp="14:31"/>
                </ListItem>
                <ListItem button className={classes.list}>
                    <RecepientsListItem recepientName="Pero Perić" latestMsg="Lorem ipsum dolor sit amet" timestamp="14:31"/>
                </ListItem>
                <ListItem button className={classes.list}>
                    <RecepientsListItem recepientName="Pero Perić" latestMsg="Lorem ipsum dolor sit amet" timestamp="14:31"/>
                </ListItem>
                <ListItem button className={classes.list}>
                    <RecepientsListItem recepientName="Pero Perić" latestMsg="Lorem ipsum dolor sit amet" timestamp="14:31"/>
                </ListItem>
                <ListItem button className={classes.list}>
                    <RecepientsListItem recepientName="Pero Perić" latestMsg="Lorem ipsum dolor sit amet" timestamp="14:31"/>
                </ListItem>
                <ListItem button className={classes.list}>
                    <RecepientsListItem recepientName="Pero Perić" latestMsg="Lorem ipsum dolor sit amet" timestamp="14:31"/>
                </ListItem>
            </List>
        </div>
        
    );
}