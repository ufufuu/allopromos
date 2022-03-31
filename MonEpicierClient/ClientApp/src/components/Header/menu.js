//import Cookies from 'js-cookie';
import React from 'react';
import ReactDOM from 'react-dom';
import {Redirect} from 'react-router-dom';
//import {Services} from '../../My/model/Services';
//import Boostrap from 'react-bootstrap';
//import boostrap from 'bootstrap';
//import Route from '../components/routing/router';

//import AtlanticPZ from '../routing/atlantic';
//import Pacific from '../components/routing/pacific';

//import Items from '../components/routing/router';
//import ToolsItems from '../components/routing/router';
//import {Route} from 'react-router';

import Account from '../../components/Account/Account';
import Register from '../../components/Account/Register'
import {NavLink, Router, Route, Link, HashRouter} from 'react-router-dom';
export const getSession  =() =>{
	//const jwt = Cookies.get('__session')
	let session 
	try{
		//if(jwt){
			//const base64Url=jwt.split('.')[1]
			//const base64 = base64Url.replace('_', '/')
			//what is window.atob>
			//http://developer.mozilla.org/en-Us/docs/Web/ApI/WindoworWorkerGlobalScope/atobsession=JSON.parse(window.atob(base64))
		//}
	}
	catch(error){
		console.log(error)
	}
	return session
}
export const logOut =() =>{
	//Cookies.remove('__session')
}
export default class Menu extends React.Component{	
render()
{
	/*const logoStyle =
	{
		height:80,
		width: 25,
		width :250,
		paddingTop: 115,
		marginleft:5
	};*/
	return(
		<nav className="navbar navbar-default" role="navigation" style={{backgroundColor:'#fff'}}>
			<div className="navbar-header">
				<button type="button" className="navbar-toggle" data-toggle="collapse"
					data-target="#example-navbar-collapse">
					<span className="sr-only">Toggle navigation</span>
					<span className="icon-bar"></span>
					<span className="icon-bar"></span>
					<span className="icon-bar"></span>
				</button>
					<a className="navbar-brand" href="/">
						<img className="img-responsive img-fluid" style={{maxHeight:'40px',marginTop:'-7%', marginLeft:''}} 
						src="/images/monepicier-logo.png" height="450" width="175"></img>
					</a>
			</div>
			<div className="collapse navbar-collapse" id="example-navbar-collapse" style={{backgroundColor:'', fontcolor:'#fff'}}>
				<ul className="nav navbar-nav">													
					<li><Link path to="/">
						<div>
							<span>Home</span>
						</div>
						</Link>
					</li>
					<li><NavLink to="/Search">Rechercher</NavLink></li>
					<li className="activeo"><NavLink to="/Account">Mon Compte</NavLink></li>					
					<li className="dropdown">
						<ul className="dropdown-menu">
							<li><NavLink exact path to="./myOrders">Commander</NavLink></li>
						</ul>
					</li>
					<li className="activeo"><NavLink to="/Account/Register">Register</NavLink></li>
					<li><NavLink to="/Account/Post">Soumettre une Boutique</NavLink></li>
					<li><a href="/blog">Blog Admin</a></li>
					<li><NavLink to="/Home/About">A Propos</NavLink></li>
					<li><NavLink to="/Home/Contact">Contact</NavLink></li>
				</ul>
			</div>
			<Route path="/Post" render={()=>
			(
					getSession()?(
					//window.sessionStorage.setItem("hey","val")?(
						<Account to="/"/>
					):(
					<Redirect to="/Account"/>
				)
			)}/>
			<Route path="/Account/Register" render={()=>
			(
					//getSession()?(
					//window.sessionStorage.setItem("hey","val")?(
					//	<Account to="/"/>
					//):(
					<Redirect to="/Account/Register"/>
				//)
			)}/>
		</nav>
   );}}
//export default Menu;
/*
	<Route path='/Atlantic' component={Items} />
	<Route path='/Pacific' component={ToolsItems} />
*/
/*
navbar navbar-expand-lg navbar-light bg-light
*/

/*
<nav className="navbar navbar-dark bg-dark" role="navigation" id="headerTT">
	<a className="navbar=brand" href="#">tOUtOUtil</a>
	
	<button type="button" class="navbar-toggle" data-toggle="collapse"
		data-target="#example-navbar-collapse">
		<span class="sr-only">Toggle navigation</span>
		<span class="icon-bar"></span>
		<span class="icon-bar"></span>
						<span class="icon-bar"></span>
	</button>
	<button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
		aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
		<span class="navbar-toggler-icon"></span>
	</button>
	<div className="collapse  navbar-collapse" id="navbarSupportedContent">
		<ul className="navbar-nav mr-auto">
			<li className="nav-item active">
				<a className="nav-link" href="#">Acceuil<span className="sr-only">(current)</span></a>
			</li>
			<li className="nav-item">
				<a className="nav-link" href="#">Link 1</a>
			</li>
			<li className="nav-item dropdown">
				<a className="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" 
				data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Dropdow</a>
			
				<div className="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
					<a className="dropdown-item" href="#">Action</a>
					<a className="dropdown-item" href="#">Action</a>
					<a className="dropdown-item" href="#">Action</a>
				</div>
			</li>
		</ul>
	</div>
</nav>
 id="headerTT"
  
 top  top<div>
		<div className="header">
			<div id="header-container" className="container">
				<div className="headerdiv">
					<a href="" className="headerleft">
						<img className="img-fluid" src="images/logo2.jpg"></img>
					</a>
				</div>
			</div>
		</div>
						
	<div style={logoStyle} id="logo">
*/
