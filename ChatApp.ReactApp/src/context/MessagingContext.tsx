import React, {createContext, useContext} from 'react';
import { IMessage } from '../models/IMessage';

export interface IMessagingContextContent {
    messages: IMessage[],
    addMessage?: (message: IMessage) => void
}

const defaultState =  {
    messages: []
};

const MessagingContext = createContext<IMessagingContextContent>(defaultState)


export default MessagingContext;
