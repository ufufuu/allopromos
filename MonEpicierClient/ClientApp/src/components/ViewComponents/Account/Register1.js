 import React from 'react';
import ReactDOM from 'react-dom';
//import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
//import AppBar from 'material-ui/AppBar';
//import TextField from 'material-ui/TextField';
//import RaisedButton from 'material-ui/RaisedButton';

//import MyAccount from '../Account/MyAccount';
//import Register2 from '../Account/Register2';
export default class Register1 extends React.Component
{
	constructor(props){
		super(props);
	}
	Continue = e =>{
		e.preventDefault();
		
		this.ValidateForm();
		//this.props.nextStep();
	}
	state={
		step:1,
		showRegister2:false,
		AccountCreation:{
			firstName:'',
			firstNameValidationError:'',
			lastNameValidationError:'',
			EmailValidationError:'',
			RepeatEmailValidationError:'',
			PasswordValidationError:'',
			RepeatPasswordValidationError:'',
		}
	}
	PreviousClick=()=>{
		
	}
	NextClick=()=>{
		//alert(this.state.step);
		//return(<MyAccount />);
		//this.setState({showRegister2:true});
		
		this.props.nextStep();
    }
	ValidateForm =() =>{
		//e.preventDefault;
		let inputValues=document.getElementsByClassName("form-control").value
		
		let firstName=document.getElementById("firstname").value
		let lastName=document.getElementById("lastname").value
		let email=document.getElementById("email").value
		let reemail=document.getElementById("reemail").value
		let passwoord=document.getElementById("password").value
		let repasswoord=document.getElementById("repassword").value
		
	//switch(inputValues)
	//{
		/*
		case '':{
			this.setState({
				firstNameValidationError:'first Name Requis',
				lastNameValidationError:'',
				EmailValidationError:'',
				RepeatEmailValidationError:'',
				PasswordValidationError:'',
				RepeatPasswordValidationError:''
				})
			
			return false;
		}
		*/
		if(firstName===''){
			this.setState({
				firstNameValidationError:'first Name Requis',
				/*lastNameValidationError:'',
				EmailValidationError:'',
				RepeatEmailValidationError:'',
				PasswordValidationError:'',
				RepeatPasswordValidationError:''*/
				
				})
			
			//return false;
			//return false;
		}
		if(lastName===''){
			this.setState({
				lastNameValidationError:'Last Name Requis'
				})
		}
		if(email===''){
			this.setState({EmailValidationError:'E-mail est Requis'})
		}
		//else{
		else if(email!= ''){
			if(!ValidateEmail(email)){
				this.setState({EmailValidationError:'E-mail en bon format S.v.p '})	
			}
		}
		if(reemail===''){
			this.setState({RepeatEmailValidationError:'R&eacute;p&eaute;ter E-mail Est Requis'})
		}
		else if(reemail != ''){
			if(!ValidateEmail(reemail)){
				this.setState({EmailValidationError:'R&eacute;p&eaute;ter E-mail en bon format S.v.p '})	
			}
			else if(email !=reemail){
				this.setState({RepeatEmailValidationError:"E-mail & Repéter E-mail ne sont pas identiques"})
				return;
			}
		}
		if(passwoord===''){
			this.setState({PasswordValidationError:'Mot de Passe Requis'})
		}
		else if(passwoord.Leng<8){
			alert("Mot de Passe de 8 caracteres au moins");
		}
		if(repasswoord ===''){
			this.setState({RepeatPasswordValidationError:' R&eacute;p&eaute;ter Mot de Passe Requis'})
		}
		else if(repasswoord != ''){
			if(passwoord!=repasswoord){
				//alert("HEHEHEHEHEH");
				this.setState({
					RepeatPasswordValidationError:' Mots de Passes non Identiques'
				})
				//return;
			}
			else {
			this.NextClick();
			//alert("data ok");
			}
		}
		
		function ValidateEmail(email){
			var re = /\S+@\S+\.\S+/;
			return re.test(email);
		}
		//}
	}
  render()
   {
	return(
				<form role="form">
					<div className="form-group" style={{borderBottom:'2', marginBottom:'2'}}>
						<label for="firstname" className="col-sm-2 control-label">First Name</label>
							<div className="col-sm-10">
							<input type="text" className="form-control" onBlur={this.ValidateForm.bind(this)} 
									onChange={this.ValidateForm.bind(this)} id="firstname"
											name="firstname"
								placeholder="Enter First Name" />
									{this.state.firstNameValidationError}
							</div>
					</div>
					<div className="form-group">
						<label for="lastname" className="col-sm-2 control-label">Last Name</label>
							<div className="col-sm-10">
							<input type="text" className="form-control" id="lastname" name="lastname"
								placeholder="Enter Last Name" onChange="" defaultValue="" />
									{this.state.lastNameValidationError}
							</div>
					</div>
					<div className="form-group">
						<label for="email" className="col-sm-2 control-label">E-mail</label>
							<div className="col-sm-10">
							<input type="text" className="form-control" id="email" name="email"
								placeholder="Enter Email" />
								{this.state.EmailValidationError}
							</div>
					</div>
					<div className="form-group">
						<label for="r-email" className="col-sm-2 control-label">Re enter E-mail</label>
							<div className="col-sm-10">
							<input type="text" className="form-control" id="reemail" name="reemail"
								placeholder="Re enter Enter Email" />
								{this.state.RepeatEmailValidationError}
							</div>
					</div>
					<div className="form-group">
						<label for="email" className="col-sm-2 control-label">Password</label>
							<div className="col-sm-10">
							<input type="password" className="form-control" id="password" name="password"
								placeholder="password" />
									{this.state.PasswordValidationError}
							</div>
					</div>
					<div className="form-group">
						<label for="email" className="col-sm-2 control-label">Re Enter Password</label>
							<div className="col-sm-10">
							<input type="password" className="form-control" id="repassword" name="repassword"
							placeholder="Re enter Password " />
								{this.state.RepeatPasswordValidationError}
							</div>
					</div>
					<div className="form-group">
						<div className="col-sm-offset-2 col-sm-10">
							<div className="checkbox">
								<label>
								<input type="checkbox" /> Remember me
								</label>
							</div>
						</div>
					</div>
					<div className="form-group">
						<div className="col-sm-offset-2 col-sm-10">
							<button id="btnSubmit" style={{backgroundColor:'#000', color:'#fff', border:'2px solid #4CAF50'}} 
							type="submit" onClick={this.Continue} className="btn btn-default">Suivant</button>
						</div>
					</div>
				</form>
			
	  );
   }
}
/*

https://gerermonentreprise.azurewebsites.net/toutoutil/api/v1

Data Source=tcp:toutoutilservice20200829100555dbserver.database.windows.net,1433;Initial Catalog=ToutoutilService20200829100555_db;User Id=aliwiyao@toutoutilservice20200829100555dbserver;Password=Kada120790



SignalR :
1.- Create Hubs folder on bakc-end that contain for instance a ChatHub class !
<h4>Account Creation - Step 2</h4>
	<div id="Content">
		<h4>mmm</h4>
	</div>
	<div id="Content">
		<h4>mmm</h4>
	</div>
	
<div id="Content" className="container">
*/