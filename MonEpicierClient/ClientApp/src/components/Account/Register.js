import React from 'react';
import ReactDOM from 'react-dom';
import JQuery, { parseJSON } from 'jquery';
//import axios from 'axios';
import PhoneInput from 'react-phone-input-2';
import 'react-phone-input-2/lib/style.css';
class Register extends React.Component
{
	state={
		username: '',
		name: '',
		accountBalance: '5324 $',
		loginRequired:'',
		emailRequired:'',
		pwdRequired:'',
		pwdrRequired:'',
		phone:'+1-111-111-11-11'
	}
	constructor(props){
		super(props);
		this.setState({loadMyAccount:false});
	}

	ValidateForm=()=>{

		let login= document.querySelector("#inputLogin")
		let email= document.querySelector("#inputEmail")
		let phone= document.querySelector("#telephoneRequired")
		let pwd= document.querySelector("#inputPwd")
		let pwdr= document.querySelector("#inputrPwd")
		if((login.value==='')||(!this.ValidateEmail(login.value))){
			this.setState({loginRequired:'Login is Required and in the right format'})
		}
		if(email.value===''){
			this.setState({emailRequired:'E-mail Required'})
		}
		if(pwd.value===''){
			this.setState({pwdRequired:'password Required'})
		}
		else if(pwd.value!==''){
			if(pwd.value.size <=8){
				this.setState({pwdRequired:'eight characters password condition'})
			}
		}
		if(pwdr.value===''){
			this.setState({pwdrRequired:'repeat password  Required'})
		}
		else{
			if(pwdr.value!=pwd.value){
				this.setState({pwdrRequired:'password should match'})
			}
		}

	}
	ValidateEmail=(email)=>{
		var re=/\S+@\S+\.\S+/
		return re.test(email);
	}
	ValidatePhoneNumber=(phoneNumber)=>{
		var format = /\^+d{}-\{d}-\{d}/;
		if(phoneNumber.value.match(format))
			return true
		return false
	}
	OnLoginClick=() =>{

	}	
	OnRegisterClick=() =>{

	}
	OnAccountRegisterSubmit78= () =>{
		const Url='https://localhost:44367/api/user';
		fetch(Url,{
			method:'GET', 
			headers:{
				'Content-Type': 'application/json',
			  }
		})
		.then(response=>response.json())
		.then(data=>{
			alert("Data gotten is "+ JSON.stringify(data))
			//console.log("No error"+ JSON.stringify(data))
		.catch(error=>{
			console.log("Error"+error)	
			})
		})
	}
	OnRegisterSubmit=(e) =>{
		let login= document.querySelector("#inputLogin")
		e.preventDefault()
		this.ValidateForm();

		const userInfo={
			//"userEmail": login.value,
			"userEmail":"kdji@monepicier.com",
			//"userName": login.value,
			"userName":"okdji@monepicier.com",
			"userPassword": "@errAbaophone43",
			"userPhoneNumber":"+15815784401"
		};	
		fetch('https://localhost:44367/api/user', {
			method:'POST',
			headers:{
				'Content-Type':'application/json',
			},
			body:JSON.stringify(userInfo)
		})
		.then(response=>response.json())
		.then(data=>{
			if(!data.status.ok){
				alert("Erreur inatendue - Ressayer")
			}
			else{
				alert("OK"+ data)
			}
		})
		.catch((error)=>{
			alert("Error" + error);
			fetch(process.env.REACT_APP_APISERVER_DEV)
		})
	}
	OnAccountLoginSubmit = () => {
		const userLogin = {
			"userEmail":"kdji@monepicier.com",
			"userPassword":"errAbaophone43"
        }
		var apiServer = process.env.REACT_APP_API_HOST_DEV;
		var endPoint = '/v1/user';
		fetch(apiServer + endPoint, {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json',
			},
			body: JSON.stringify(userLogin)
		})
			.then(response => response.json())
			.then(data => alert(data))
			.catch((error) => {
				alert("Error Catchee:"+error)
			})
	}
  render()
   {
	return(
	<div className="container" style={{backgroundColor:'#e2e2e2', fontColor:'#fff', fontcolor:'#fff'}} id="ontent">
		
		<div className="row">
			<div className="col-md-8"><h3>Register Account</h3>
					<div className="form-group">
							<label for="exampleInputEmail1">Login:</label>
							<input type="email" className="form-control"
							 id="inputLogin" placeholder="Login" />
							<h5 style={{color:'red'}} id="loginRequired">{this.state.loginRequired}</h5>
					</div>
					<div className="form-group">
							<label for="exampleInputEmail1">Mot de Passe:</label>
							<input type="password" className="form-control" 
							id="inputPwd" placeholder="Mot de Passe" />
							<h5 style={{color:'red'}} id="loginRequired">{this.state.pwdRequired}</h5>
					</div>
					<div className="form-group">
							<label for="exampleInputEmail1">Repet&eacute;z mot de passe:</label>
							<input type="password" className="form-control" 
							id="inputrPwd" placeholder="Mot de Passe Repet&eacute;" />
							<h5 style={{color:'red'}} id="loginRequired">{this.state.pwdrRequired}</h5>
					</div>
					<div className="form-group">
							<label for="exampleInputEmail1">E-mail:</label>
							<input type="email" className="form-control" 
							id="inputEmail" placeholder="E-mail" />
							<h5 style={{color:'red'}} 
							id="emailRequired">{this.state.emailRequired}</h5>
					</div>
					<div className="form-group">
							<label for="exampleInputEmail1">Telephone #:</label>
							<PhoneInput
								inputProps={{
									name:'userPhoneNumber'
								}}
								country={'ca'}
								value=''
							/>
							<h5 style={{color:'red'}} id="phoneRequired">{this.state.phoneRequired}</h5>
					</div>
					<div className="form-group">
						<button type="submit" onClick={this.OnRegisterSubmit.bind(this)} 
							className="btn btn-primary">S'ENREGISTRER</button>
					</div>
					<div className="card-body">
					</div>
			</div>
		<h3>Login</h3>
			<div className="col-md-4">  
				<div className="card card-primary">
				<div className="card-header">
					<label for="exampleInputEmail1"></label>
				</div>
				
						<div className="card-body">
						<div className="form-group">
							<label for="exampleInputEmail1">Username:</label>
							<input type="email" className="form-control" 
							id="exampleInputEmail1" placeholder="Username" />
						</div>
						<div className="form-group">
							<label for="exampleInputEmail1">Mot de passe:</label>
							<input type="email" className="form-control" 
							id="exampleInputEmail1" placeholder="Mot de Passe" />
						</div>
						</div>
						<div className="card-footer">
							<button type="submit" onClick={this.OnAccountLoginSubmit.bind(this)} 
							className="btn btn-primary">LOGIN</button>
						</div>
				
             </div>	
		</div>	
	</div>
</div>
	  );
   }
}
export default Register;
//axios.defaults.headers.post['Content-Type'] ='application/json;charset=utf-8';
//axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
//axios.get('https://allopromocc.azurewebsites.net/monepicier/api/default')
//axios.get(`http://localhost:44367/api/default`, {headers})