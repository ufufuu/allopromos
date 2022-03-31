import Atlantic from './atlantic';
import React from 'react';
import {createHashHistory} from 'history';
import {BrowserRouter, Route} from 'react-router-dom';
import Content from '../Content/Content';

const routes =(
<BrowserRouter>
		<Route exact path="/" component={Atlantic} />
		<Route path="/" component ={Atlantic} />
		
		<Route path="/Account/Home" component={Atlantic} />

</BrowserRouter>
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