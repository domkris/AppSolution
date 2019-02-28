import React, { Component } from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';

import './App.css';

import LoginForm from '../LoginForm/LoginForm';
import About from '../About/About';
import Home from '../Home/Home';
import Error from '../Error/Error';
import Layout from '../Layout/Layout';


class App extends Component {
  render() {
    return (
      <div className="App">
          <BrowserRouter>
            <Switch>
              <Route exact path="/" component={LoginForm} />
              <Layout>
                <Route exact path="/home" component={Home} />
                <Route exact path="/about" component={About} />
              </Layout>
              <Route component={Error}/>
            </Switch>
          </BrowserRouter>
          {/* <LoginForm getData = {this.getData}></LoginForm> */}
      </div>
    );
  }
}

export default App;
