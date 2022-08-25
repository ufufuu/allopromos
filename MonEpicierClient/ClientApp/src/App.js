import React from 'react';

//import logo from './logo.svg';
//import './App.css';

import routes from './components/routes';
import MainHomeController from './components/ContainerComponents/MainHomeController';
import {Footer} from './components/footer';
import {Switch, Route, BrowserRouter, } from 'react-router-dom';
import Navigation from './components/Nav/Navigation';
import HomePage from './components/ViewComponents/Content/HomePage';
class App extends React.Component{
    constructor(props) {
        super(props);
    }
    state = {
        showing: false
    }
    render() {

        {routes}
        return (
            this.state.showing ? <MainHomeController /> : <HomePage />
	)
  }
}
export default App;
/*
import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
export default class App extends Component {
    displayName = App.name
    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/counter' component={Counter} />
                <Route path='/fetchdata' component={FetchData} />
            </Layout>
        );
    }
}
Axio x
JQuery / Login
*/
