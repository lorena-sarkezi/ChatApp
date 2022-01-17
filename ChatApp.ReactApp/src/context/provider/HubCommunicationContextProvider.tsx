import React, {useContext, useEffect, useState} from 'react';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import axios from '../../axios';
import MessagingContext from '../template/MessagingContext';
import { IMessage } from '../../models/IMessage';
import HubCommunicationContext, { IHubCommunicationContextContent } from '../template/HubCommunicationContext';

const HubCommunicationContextProvider: React.FC = props => {
 
    const messagingContext = useContext(MessagingContext);

    const [hubConnection, setHubConnection] = useState<HubConnection | null>(null);

    useEffect(() => {
        if(hubConnection === null){
            const hubConnection = new HubConnectionBuilder()
                                    .withUrl(axios.defaults.baseURL!)
                                    .withAutomaticReconnect()
                                    .build();

            hubConnection.on('receiveMessage', receiveMessageFromServer)        

            setHubConnection(hubConnection);
        }
        
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    const receiveMessageFromServer = (message: IMessage) => {
        messagingContext!.addMessage(message);
    }


    const sendMessage = (message: IMessage) => {
        try{
            hubConnection!.invoke('sendMessage', message);
            messagingContext!.addMessage(message);
        }
        catch(e){
            console.error("Error sending message", e);
        }
    }

    const contextContent: IHubCommunicationContextContent = {
        sendMessage: sendMessage
    }

    return (
        <HubCommunicationContext.Provider value={contextContent}>
            {props.children}
        </HubCommunicationContext.Provider>
    )
}

export default HubCommunicationContextProvider;

