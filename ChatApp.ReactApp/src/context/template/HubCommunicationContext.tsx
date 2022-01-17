import React from 'react';

import { IMessage } from '.././../models/IMessage';

export interface IHubCommunicationContextContent {
    sendMessage?: (message: IMessage) => void
}

const HubCommunicationContext = React.createContext<IHubCommunicationContextContent>({});

export default HubCommunicationContext;

