import {createContext} from 'react';
import { IMessage } from '../../models/IMessage';

export interface IMessagingContextContent {
    messages: IMessage[],
    addMessage: (message: IMessage) => void
}

const MessagingContext = createContext<IMessagingContextContent | undefined>(undefined)


export default MessagingContext;
