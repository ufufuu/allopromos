import React from 'react';
import ReactDOM from 'react-dom';
import JQuery from 'jquery';
import {NavLink, Link, HashRouter, useHistory} from 'react-router-dom';
import { userService } from '../../_services/userService';
//import { userLoginFetch } from './redux/userLoginActions';

//import history from './history'
import Register2 from '../Account/Register2';
import {Redirect} from 'react-router-dom';
export default class Login extends React.Component
{
	/*
	constructor(props){
		super(props);
		this.state={login};
	}
	*/
	state= {
		login :{
			username: '',
			password:''
		},
		loginError:'',
		passwordError:''
	}
	handleInput = e=>{
		const {login} = this.state;
		login[e.target.name] =e.target.value;
		this.setState({
			login
		});
		this.setState({
			//loginError
		});
	}
	//handleSubmitt= () =>{
	handleSubmit= e =>{
		e.preventDefault();
		const {login} = this.state;
		var username = document.getElementById('username').value;
		var pwd = document.getElementById('userpassword').value;
		if(username===''){
			this.setState({
				loginError:'Name is Requirerd',
				passwordError:''
			})
			return false
		}
		else if(!ValidateEmail(username)){
			this.setState({
				loginError:' Email en bon format Svp',
				passwordError:''
			})
			return false
		}
		else if(pwd===''){
			this.setState({
				loginError:'',
				passwordError:'Mot de passe Requis'
			})
		}
		else{
			this.UserLogging();
		}
		function ValidateEmail(email){
			var re = /\S+@\S+\.\S+/;
			return re.test(email);
		}
	}
	componenteDidMount(){
		alert("did Mount");	
		JQuery.ajax({
		url:'http://localhost:52424/User/UserService.svc/DoLogin/django@free.fr/1234',
		dataType:'json',
		//success:function(data)=>{
		success:function(data){
		//alert("succes");
		console.log("Data IS", data);
		},
		error: function(xhr, status, err){
		console.log(err);
		console.log("erreurrrr");
		}
	});
	}
	constructor(props)
	{
		super(props);
		this.state={
			
			/*username:'',
			password:'',
			submitted:'false',
			loading:'false',
			error:'',
			data:null*/
			login:{
				username: '',
				password: '',
			},
			loginError:'' , //'null',
			passwordError:''
		};
		//this.UR=this.h
		//this.RC=this.h
		//this.UserLogging = this.UserLogging.bind(this);
		
		this.handleChange = this.handleChange.bind(this);
	}
	//handleChange(e){
	  handleChange = event =>{
		//const {name, value} = e.target;
		//this.setState({username:'zk'});
		this.setState({
			[event.target.name]: event.target.value
		});
	}
		//handleSubmit(e){
		HandleSubmit=e =>{
			//e.preventDefault();
			//this.props.UserLogging(this.state);
			//this.props.userLoginFetch(this.state);
			
			this.UserLogging();
			/*
			this.setState({submitted:true});
			const {username, password , returnUrl}= this.state;
			if(!(username && password)){
				return;
			}
			this.setState({loading:true});
			userService.Login(username, password)
			.then(
				user =>{
					const {from} = this.props.location.state|| { from:{pathname: "/"}};
					this.props.history.push(from);
				},
				error =>this.setState({error, loading:false})
			);*/
		}
	//UserLogging()

wait(ms){
var d= new Date();
var d2 = null;
do{ d2= new Date();}
//while(d2-d<ms);	
while(d2-d<ms);	
}
	UserLogging()
	{	
		/*
		//fetch(`http://localhost:52424/Account/AccountService.svc/Account/UserLogin/`+username+'/'+pwd,{
			method: 'get',
			headers:{	
			}
		}).then((res)=>{
			if(res.ok){
				//return res.json();
				console.log(res.json());
			}
		}).then((res)=>{
			console.log(res);
		})
		*/
		
		var username = document.getElementById('username').value;
		var pwd=document.getElementById('userpassword').value;
		
		//this.state.username ="sdfsdffdfdf";
		/*
		let ert=3;
		if(ert==2)
			//window.location("Account/Homememem")
		alert("ONE");
		//window.location("Home/112")
		else{
		alert("TW")
		}*/
		//alert(username);
		
		JQuery.ajax({
			method:'GET',
			url:'http://localhost:52424/User/UserService.svc/DoLogin/'+username+'/'+pwd,
			//url:'http://localhost:52424/Account/AccountService.svc/Account/UserLogin/'+username.toString+'/'+pwd.toString,
			
			dataType:'json',
			success:function(data){
				if(data==true){

					window.location.href='/Account/Home';
				}
				else{
					alert("Login ou Mot de Passe Incorrect !");
				   window.location.href='/Account/';
				}
			},
			error: function(xhr, status, err){
				console.log(err.message);
				window.location.href='./Account/#Login';
			}
		});
	}
	helloService(){
		alert("Servce call");
	}
	UserLoggingClick(){
		this.UserLogging();
	}	
	onRegisterClick(){
	
	}
	onLoginClick(){
	}
  render()
  {
	//const {username, password
		//	} = this.state;
	//const userInfos= {username,password};	
const {login, loginError, passwordError}= this.state;
return(
		<form role="form" className="container-fluid">
			<div className="form-group" style={{backgroundColor:'#fff'}}>
					<label id="login"  for="firstname" className="col-sm-2 control-label">Login</label>
						<div className="col-sm-10">
							<input type="text" className="form-control" id="userLogin"
								placeholder="Enter Login" id="username" name="username" onChange={this.handleInput.bind(this)} />
									{loginError}
							{this.state.submitted && !this.state.login &&
								<div className="help-block">Login required</div>
							}
						</div>
			</div>
			<div className="form-group">
					<label id="password" for="password" className="col-sm-2 control-label">Password</label>
						<div className="col-sm-10">
							<input type="password" className="form-control"
								placeholder="Enter Password" id="userpassword" name="userpassword" onChange={e=>this.handleInput(e)} />
								{passwordError}
							{this.state.submitted && !this.state.password &&
								<div className="invalid-block">mot de passe requis</div>
							}
						</div>
			</div>
				<br />
			<div className="form-group">
					<div className="col-sm-offset-2 col-sm-10">
						<button className="btn btn-default" style={{backgroundColor:'#000', color:'#fff', border:'2px solid #4CAF50'}}
						onClick={this.handleSubmit.bind(this)}>Login</button>
					</div>
				</div>
				{this.state.error && 
					<div className={'alert alert-danger'}>{this.state.error}</div>
			}
		</form>
   );
  }
}
/* 655-64-27
	JQuery.ajax({
		5-475-70-72 // Co Packaging  // phican.cA
		
		url:'http://localhost:52424/Categories/Categorieservice.svc/categories',
		
		method:'GET',
		success:function(data){
			console.log(data);
			//alert(data);
			//this.setState({data:data});
			setTimeout(alert("FHFHFHFHFHFH"), 4000);
			this.wait(4000);
			
		}.bind(this),
		error: function(xhr, status, err){
			//console.log(err(this.props.url, status,  err.toString());
			console.log(err.toString());
			//console.log("5656575665");
			//alert(this.props.url, status,  err.toString());
			//setTimeout(alert("SUSUSUSUSu"), 4000);
			this.wait(4000);
		}.bind(this)
	});
	*/
//export default
//
/*
<div class="navbar navbar-inverse navbar-fixed-top">
<div class="container">
<div class="navbar-header">
<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbarcollapse">
<span class="icon-bar"></span>
<span class="icon-bar"></span>
<span class="icon-bar"></span>
</button>
@Html.ActionLink("Geek Quiz", "Index", "Home", null, new { @class = "navbar-brand" })
</div>
<div class="navbar-collapse collapse">
<ul class="nav navbar-nav">
<li>@Html.ActionLink("Play", "Index", "Home")</li>
</ul>
@Html.Partial("_LoginPartial")
</div>
</div>
</div>
 value={this.state.username} onChange={this.handleChange} 
 
 value={this.state.password} onChange={this.handleChange}
 
 {"Email":null,"IdUtilisateur":null,"Nom":"django@free.fr","Password":null}
 https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
 
 <button value="submit" className="btn btn-default" onClick={this.handleSubmitt} />
 
 form onSubmit={this.handleSubmit}
 
 http://localhost:3000/Account?nom=django%40free.fr&age=1234
 
 <form role="form" method="get">
 
 <div className="invalid-feedback">Login est Requis!.</div>
*/
/*
	<div id="Content">	
	<h4>Login</h4>
				<h4>{this.state.title}</h4>
				<div id="Content">
				</div>
		<div className="container" style={{backgroundColor:'#000','borderBottom':'3', 'marginBottom': '3 px', 'marginTop':'15 px'}} >
			<form role="form" method="g">
				<div className="form-group" style={{backgroundColor:'#000','borderBottom':'3', 'marginBottom': '3 px', 'marginTop':'15 px'}} >
					<label id="login"  for="firstname" className="col-sm-2 control-label">Login</label>
						<div className="col-sm-10">
							<input type="text" className="form-control" id="userLogin"
								placeholder="Enter Login" id="username" name="username" onChange={this.handleInput.bind(this)} />
									{loginError}
							{this.state.submitted && !this.state.login &&
								<div className="help-block">Login required</div>
							}	
						</div>
				</div>
				<div className="form-group">
					<label id="password" for="password" className="col-sm-2 control-label">Password</label>
						<div className="col-sm-10">
							<input type="password" className="form-control"
								placeholder="Enter Password" id="userpassword" name="userpassword" onChange={e=>this.handleInput(e)} />
								{passwordError}
							{this.state.submitted && !this.state.password &&
								<div className="invalid-block">mot de passe requis</div>
							}
						</div>
				</div>
				<br />
				<div className="form-group">
					<div className="col-sm-offset-2 col-sm-10">
						<button className="btn btn-default" style={{backgroundColor:'#000', color:'#fff', border:'2px solid #4CAF50'}}
						onClick={this.handleSubmit.bind(this)}>Login</button>
					</div>
				</div>
				{this.state.error && 
					<div className={'alert alert-danger'}>{this.state.error}</div>
				}
			</form>
		</div>
*/