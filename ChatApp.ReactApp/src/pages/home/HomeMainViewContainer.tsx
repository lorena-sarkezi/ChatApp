import React, {useEffect, useState} from 'react'

import axios from '../../axios';
import MessagingContext, {IMessagingContextContent} from '../../context/MessagingContext';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

import Home from './Home';
import { IMessage } from '../../models/IMessage';

const HomeMainViewContainer = () => {

    let dummyConnection = new HubConnectionBuilder().build(); // Because HubConnection type cannot be null
    const [hubConnection, setHubConnection] = useState<HubConnection>(dummyConnection);
    const [chatMessages, setChatMessages] = useState<IMessage[]>([]);

    useEffect(() => {
        const hubConnection = new HubConnectionBuilder()
                                    .withUrl(axios.defaults.baseURL!)
                                    .withAutomaticReconnect()
                                    .build();

        setHubConnection(hubConnection);
        
    }, [])
    
    useEffect(() => {

    });
    
    const addChatMessage = (message: IMessage) => {
        let messagesStateLocal = [...chatMessages];
        messagesStateLocal.push(message);
        setChatMessages(messagesStateLocal);
    }

    const initialValue: IMessagingContextContent = {
        messages: chatMessages,
        addMessage: addChatMessage
    };

    return(
        <MessagingContext.Provider value={initialValue}>
            <Home />
        </MessagingContext.Provider>

    )
}

export default HomeMainViewContainer;