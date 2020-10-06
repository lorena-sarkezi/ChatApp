import React from 'react';

import { Route, Redirect } from 'react-router-dom';


export default function AuthorizedRoute(props){
    //Temporary for now, needs expanding

    let hasToken = localStorage.getItem('token');

    //hasToken = 123;

    console.log(hasToken);
    hasToken = 123;

    return hasToken !== null ? <Route 
                                        path={props.path} 
                                        exact={props.exact} 
                                        component={props.component} /> : <Redirect to="/login" />;
}