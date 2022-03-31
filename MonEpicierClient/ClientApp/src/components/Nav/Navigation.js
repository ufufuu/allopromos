import React from 'react';
import ReactDOM from 'react-dom';
import Bootstrap from 'bootstrap';

//import {HeaderTop} from '../components/topHeader';
//import {SubHeader} from '../components/subHeader';

import {Col, Navbar, Nav, NavItem} from 'react-bootstrap';
import {NavLink} from 'react-router-dom';
import {LinkContainer} from 'react-router-bootstrap';
//const Navigation =(props) =>{
class Navigation extends React.Component
{
	render()
	{
		return(
		
		<nav className="navbar navbar-default" role="navigation">
			<div className="navbar-header">
			
				<a className="navbar-brand" href="#"><h1>PromoLocal&reg;&nbsp;</h1></a>
			</div>
			<div>
				<ul className="nav navbar-nav">
					<li className="active"><a href="#">IOS</a></li>
					<li><a href="#">SVN</a></li>
					<li className="dropdown">
						<a href="#" className="dropdown-toggle" data-toggle="dropdown"> J
							< b className="caret"></b>
						</a>
						<ul className="dropdown-menu">
							<li><a href="#">fdsdf</a></li>
							<li className="divider"></li>
							<li><a href="#">fdsdf</a></li>
							<li className="divider"></li>
						</ul>
					</li>
				</ul>
			</div>
		</nav>
			
		)
	}
}
export default Navigation;