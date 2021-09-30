import React from 'react';
import { Switch, Route, BrowserRouter } from 'react-router-dom';

import Login from './pages/login';

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route path="/" component={Login} exact/>
      </Switch>
    </BrowserRouter>
  );
}

export default App;
