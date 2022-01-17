import React, {useState } from 'react';
import { IMessage } from '../../models/IMessage';
import { IMessagingContextContent } from '../template/MessagingContext';
import MessagingContext  from '../template/MessagingContext';
import HubCommunicationContextProvider from './HubCommunicationContextProvider';

export interface IMessagingContextProps {
    messages?: IMessage
}

const MessagingContextProvider: React.FC<IMessagingContextProps> = props => {

    const [chatMessages, setChatMessages] = useState<IMessage[]>([]);

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
            <HubCommunicationContextProvider>
                {props.children}
            </HubCommunicationContextProvider>
        </MessagingContext.Provider>
    )
}

export default MessagingContextProvider;