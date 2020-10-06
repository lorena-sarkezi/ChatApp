import React from 'react';
import { makeStyles } from '@material-ui/core/styles';

import MessageBubble from './MessageBubble';

const containerPadding = '15px'

const useStyles = makeStyles((theme) => ({
    chatBubbleStyle:{
        backgroundColor: '#dadef2',
        minHeight: '8%',
        width: 'max-content',
        padding: '5px',
        maxWidth: '60%',
        wordWrap: 'break-word'
    },
    chatContainer:{
        paddingLeft: containerPadding,
        paddingRight: containerPadding,
        backgroundColor: '#fafafa',
        height: 'calc(100% - 64px)'
    }
  }));

export default function ChatSurfaceContainer(props)  {
    
    const styles = useStyles();

    return(
        <div className={styles.chatContainer}>
            
            <MessageBubble aligment="flex-start" displayMsgOwner/>
            <MessageBubble aligment="flex-end"/>
        </div>

        

    )
}
