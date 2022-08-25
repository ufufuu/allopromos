import React from 'react';
import {createHashHistory} from 'history';
import {Switch, Route, BrowserRouter, } from 'react-router-dom';
import Content from './ViewComponents/Content/Content';
import HomePage from './ViewComponents/Content/HomePage';

import { Header } from './ViewComponents/Content/Header';
import { Footer } from '../components/footer';
import HomeAccount from './ViewComponents/Account/HomeAccount';
import Register from './ViewComponents/Account/Register';

//import About from './Home/About';
import Contact from './Home/Contact';
import MissionPickup from './Home/MissionPickup';
import { extend } from 'jquery'
import MainHomeController from './ContainerComponents/MainHomeController';
const routes =(
    <Switch>
		<Header />
		<Route exact path="/" component={MainHomeController} />
		<Route exact path="/Blog" component={HomePage} />

		<Route exact path="/Account/Home" component={HomeAccount} />
		
		<Route exact path="/About" component={Content} />
		<Route path="/Account/Register" component={Register} />
		<Route path="/Home/Contact" component={Contact} />
		<Route path="/blog" component={MissionPickup} />
		<Footer />
    </Switch>
)
export default routes;
/*
IN TO IMPORTED FILE 

import React from 'react';
import ReactDOM from 'react-dom';
import {createHashHistory} from 'history';
import {BrowserRouter, Route} from 'react-router-dom';

import routes  from './routes';

const allRoutes= routes;

ReactDOM.render(
allRoutes,
document.getElementById("app")
)


<Route path="/detail/:repo" component={Content} />
<Route path="/:handle" component ={Content} />
*/