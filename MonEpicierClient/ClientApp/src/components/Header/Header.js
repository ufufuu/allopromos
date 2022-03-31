import React from 'react';
import ReactDOM from 'react-dom';
import Menu from './menu';

//import {HeaderTop} from '../components/topHeader';
//import {SubHeader} from '../components/subHeader';

import Boostrap from 'react-bootstrap';
import boostrap from 'bootstrap';
import {Col, Navbar, Nav, NavItem} from 'react-bootstrap';
import {NavLink} from 'react-router-dom';
import {LinkContainer} from 'react-router-bootstrap';
/*
const Navigation =(props) =>{
return(
		<Col md={12}>
			<Navbar inverse collapse OnSelect>
				<Navbar.Header>
					<Navbar.Brand>
						<NavLink to={'/'} exact>Account</NavLink>
					</Navbar.Brand>
					<Navbar.Toggle />
				</Navbar.Header>
			<Navbar.Collapse>
				<Nav>
				<LinkContainer to={'/asdsd'} exact>Acc
					<NavItem eventkey={1} OwnerActions>
					</NavItem>
				</LinkContainer>
			</Nav>
			</Navbar.Collapse>
		</Navbar>
	</Col>
 )
}
*/
export default class Header extends React.Component
{
	render()
	{
	  return(
		<Menu />
	   )
	}
}
//export default;
//5/ 638 4706