
import React from 'react';

//import logo from './logo.svg';
//import './App.css';

import Header from './components/Header/Header';
//import {Main} from './components/main';
import Content from './components/Content/Content';
import {Footer} from './components/footer';

import {Route, BrowserRouter, Switch} from 'react-router-dom';
import Navigation from './components/Nav/Navigation';

class App extends React.Component{
	render(){
	return(
		<div style={{'display':'inline'}}>
            
		</div>
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
