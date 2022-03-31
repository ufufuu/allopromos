
import React from 'react';
import ReactDOM from 'react-dom';

import './index.css';
import './styles/styles.css';

//import '../public/styles/my.css';
//import Bootstrap from 'react-bootstrap';

import { Main } from './components/main';

//IMPORTING ALL ROUTES
import routes from './components/routing/routes';

// BootStraping
//import 'bootstrap/dist/css/bootstrap.min.css';
//import BootStrap from 'boostrap';

import App from './App';
//import * as serviceWorker from './serviceWorker';
import registerServiceWorker from './registerServiceWorker';

const allRoutes = routes;
/*
ReactDOM.render(
<Main />,
allRoutes,
document.getElementById("App"));
*/

ReactDOM.render(
    <Main />, 
    document.getElementById('root'));

//ReactDOM.render(<Main />, document.getElementById('root'));
// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA

//registerServiceWorker.unregister();

registerServiceWorker();



//https://docs.microsoft.com/en-us/visualstudio/ide/csharp-developer-productivity?utm_source=VisualStudio&utm_medium=aspnet-getstarted&utm_campaign=VisualStudio&view=vs-2019





/*
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 *
 * 
 * import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import './index.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <App />
  </BrowserRouter>,
  rootElement);

registerServiceWorker();
*/