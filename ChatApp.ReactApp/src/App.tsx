import React from 'react';
import { Switch, Route, BrowserRouter } from 'react-router-dom';

import ProtectedRoute from './components/protectedRoute';
import Login from './pages/login';
import HomeMainViewContainer from './pages/home';
import Register from './pages/register';

function App() {
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" component={Login} exact />
                <Route path="/register" component={Register} exact />
                <Route path="/home" component={HomeMainViewContainer} exact />
            </Switch>
        </BrowserRouter>
    );
}

export default App;
