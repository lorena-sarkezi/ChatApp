import React from 'react'
import MessagingContextProvider from '../../context/provider/MessagingContextProvider';

import Home from './Home';

const HomeMainViewContainer = () => {

    return(
        <MessagingContextProvider>
            <Home />
        </MessagingContextProvider>
    )
}

export default HomeMainViewContainer;