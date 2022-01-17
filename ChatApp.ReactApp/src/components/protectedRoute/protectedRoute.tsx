import { useEffect, useState } from 'react';
import { Redirect, Route } from 'react-router';
import AuthHelpers from '../../misc/helpers';

// https://stackoverflow.com/questions/47747754/how-to-rewrite-the-protected-private-route-using-typescript-and-react-router-4

const ProtectedRoute = props => {

  const [isAuthenticated , setIsAuthenticated] = useState<boolean | null>(null);

  const getAuthStatus = async () => {
    const status = await AuthHelpers.checkIfAuthenticated();
    setIsAuthenticated(status as boolean);
  }

  useEffect(() => {
    if(isAuthenticated === null){
      getAuthStatus();
    }
    
  }, [isAuthenticated])

  if(isAuthenticated !== null){
    if(isAuthenticated === true) {
      return <Route {...props} />;
    } 
    else {
      return <Redirect to={{ pathname: '/login' }} />;
    }
  }
  else{
    /// neki loading spinner
  }
};

export default ProtectedRoute;