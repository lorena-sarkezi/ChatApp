import { useState } from 'react';
import { useEffect } from 'react-dom/node_modules/@types/react';
import { Redirect, Route, RouteProps } from 'react-router';
import AuthHelpers from '../../misc/helpers';

// https://stackoverflow.com/questions/47747754/how-to-rewrite-the-protected-private-route-using-typescript-and-react-router-4

export type ProtectedRouteProps = {
  isAuthenticated: boolean;
  authenticationPath: string;
} & RouteProps;

export const ProtectedRoute: React.FC<RouteProps> = (props) => {

  const [isAuthenticated , setIsAuthenticated] = useState<boolean | null>(null);

  const getAuthStatus = async () => {
    return await AuthHelpers.checkIfAuthenticated();
  }

  // useEffect(() => {
  //   setIsAuthenticated(getAuthStatus());
  // })

  if(isAuthenticated) {
    return <Route {...props} />;
  } 
  else {
    return <Redirect to={{ pathname: '/login' }} />;
  }
};