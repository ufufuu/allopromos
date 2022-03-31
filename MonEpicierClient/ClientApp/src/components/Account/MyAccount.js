import React from 'react';
import ReactDOM from 'react-dom';
import {NavLink, Router, Route, Link, HashRouter, useHistory} from 'react-router-dom';
import Login from './Login';

import authenticationService from '../_services/authenticationService';

class AccountHome extends React.Component
{
	state={
		username: '',
		name: '',
		accountBalance: '5324 $'
	}
	constructor(props){		
		super(props);
		this.state={
			//currentUser :authenticationService.currentUser, 
			currentUser:null
		}
		this.setState({loadMyAccount:false});
	}
	componentDidMount(){
		// Call Log In web service !
		//auth.currentUser.subscribe(x=>this.setState({currentUser:x}));
		
		//super(props);
		//alert("Logged?");
		//alert(localStorage.token);
		if(localStorage.token)
		{
			//alert("Logged ? :yes");
			this.state.username=localStorage.getItem('username');
		}
		else
		{
			//history.push
			//window.location="/Account";
		}
		this.setState({loadMyAccount:false});
	}
	componentWillMount(){
		//super(props);
		//alert(this.props.username);
		//this.setState({loadMyAccount:false});
		//alert("drt"+this.state.username);
		
		this.UserLogin();
	}
	UserLogin=() =>{
		authenticationService.currentUser=null;
	}
	UserLogout=() =>{
		alert("Bye");
		window.location="/Account/Login";
		//ahu.Logout()
		//h.push('/Account/Login');
	}
  render()
  {
	var currentUser=this.state
	return(
	<div>
		<div id="Content"><h4>Mon Compte, {currentUser.firstName}</h4><div><Link onClick={this.UserLogout}>Log Out</Link></div>
			<div>you are Logged In,{this.state.username},{this.state.accountBalance}|</div>
				<br/>
			<div className="container">
				dffdff	
			</div>
			<div className="container">
				<a href="./Post">Soumettre une Location</a>	
			</div>
			<div className="container">
				Profil	
			</div>
			<div className="container">
				mes Outils en Locations
			</div>
			<div className="container">
				<a href="">Encaisser</a>	
			</div>
		</div>
	</div>
	);	
  }
}
export default AccountHome;

/*
https://stackoverflow.com/questions/34635822/how-do-i-solve-keyword-not-supported-metadata/34635996
<form role="form" onSubmit={this.handleSubmit}>
				
			<div className="form-group" style={{borderBottom:'2', marginBottom:'2'}}>
				<label id="login"  for="firstname" className="col-sm-2 control-label">Login</label>
					<div className="col-sm-10">
						<input type="text" className="form-control" id="firstname"
							placeholder="Enter Login"/>
						{this.state.submitted && !this.state.username &&
							<div className="help-block">Login required</div>
						}
					</div>
			</div>
			<div className="form-group">
				<label id="password" for="lastname" className="col-sm-2 control-label">Password</label>
					<div className="col-sm-10">
						<input type="password" className="form-control" id="lastname"
						placeholder="Enter Password"  />
						{this.state.submitted && !this.state.password &&
							<div className="help-block">mot de passe requis </div>
						}
					</div>
			</div>
			<div className="form-group">
				<div className="col-sm-offset-2 col-sm-10">
					<button style={{backgroundColor:'#000'}} type="submit" className="btn btn-default" 
						onClick={this.UserLog.bind(this)}>Login</button>
				</div>
			</div>
			{this.state.error && 
			<div className={'alert alert-danger'}></div>
			}
</form>
*/