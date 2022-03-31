import React from 'react';
import ReactDOM from 'react-dom';
import Login from '../Account/Login';
import Register1 from '../Account/Register1';
import Register2 from '../Account/Register2';
import MyAccount from '../Account/MyAccount';
//import {getProfile} from'';
class Account extends React.Component
{
constructor(props){
	super(props);
	//this.state={title: "Click Register or Login to your account", step:1,lastName:'',
	//firstName:'',};
}
state={
	step:1,
	lastName:'dfd',
	firstName:'dfdf',
	/*email:'',
	occupation:'',
	city:'',
	bio:''*/
}
handleChange = input => e => {
	this.setState({[input]: e.target.value});
}
prevStep =()=>
{
	const {step}= this.state; //destructuring
	this.setState({
	step:step-1	
	})
}
nextStep =()=>
{
	const{step}= this.state;
	this.setState({
		step:step+1	
	})
}
getProfile=()=>{
	//const getProfile=()=>{
		//return dispath=>{
			const token = localStorage.token;
			if(token){
				return fetch('http://localhost:52424/User/UserService.svc/Profile', {
					method:"GET",
					/*headers:{
						'content-type':'application/json',
						accept:'application/json',
						'Authorization':*/
					},
				).then(resp => resp.json())
				  .then(data =>{
					if(data.message){
						// Error will occured if toekn invalid
						//Remove the token
						localStorage.removeItem('token');
					}else{
						//dispatch(loginUser(data.user))
						alert("Seesion ongoing")
					}
				})
			}
}
OnRegisterClick(){
this.setState({title:"Register"});
this.setState({isRegisterOpen:true, isLoginOpen:false});
}
UserRegister(){
//Call of Web Service here for User Registration 
}
OnLoginClick(){
this.setState({title:"Login here"});
this.setState({isRegisterOpen:false, isLoginOpen:true});
//this.setState({title: "here Login"}&& <Login />);
}
  render()
  {
	const {step} = this.state; //destructuring
	const {firsName, lastName
	} = this.state;
	const userInfos= {firsName,lastName};
	switch(step){
	case 1:
	return(
		<div className="container" style={{display:'', marginTop:'-20px', border:'1px dashed #000', width:'90%', backgroundColor:'#fff'}}>
			<div className="row">
				<h3>mon compte:<br/></h3>
					<h4>{this.state.title}</h4>
			</div>
			<div className="row" style={{backgroundColor:'#000','borderBottom':'3', 'marginBottom': '3 px', 'marginTop':'15 px'}}>
					<font style={{color:'#fff',size:'15 px'}}>
					Inscrivez-vous ou simplement créer votre compte ici. <br/>
					Celàvous permet de vous enregistrer sur notre plateforme afin<br/>
					de pouvoir promouvoir vos produits d'un seul click et recevoir <br/>
					des milliers de clients utilisateurs de notre application sur mobile et en version web.<br/>
					Qu'attendez-vous pour vous inscrire maintenant !?</font>
			</div>
			<div className="row">/* id="Content" */
				<h4><a onClick={this.OnLoginClick.bind(this)}>Login</a> | 
					<a href="#" onClick={this.OnRegisterClick.bind(this)}> Register </a>
				</h4>
			</div>
			<div className="row" style={{backgroundColor:'#fff', padding: '91px 100px 19px 50px'}}>
				{this.state.isLoginOpen  && <Login />}
				{
				this.state.isRegisterOpen &&
					<Register1 
					userInfos={userInfos}
					nextStep={this.nextStep}
					handleChange={this.handleChange}/>
				}
			
			</div>
		</div>
	  );
		case 2:
			return(
				<Register1
				 userInfos={userInfos}
				 nextStep={this.nextStep}
				 handleChange={this.handleChange}
			/>);
		case 3:
			return(<Register2 />)
		case 4:
			return(<MyAccount />)
      }
   }
}
export default Account;
//nextStep={this.nextStep}
//handleChange={this.handleChange}
/*
<div className="row" style={{backgroundColor:'#000'}}>
					{this.state.isLoginOpen  && <Login />}
					{
					this.state.isRegisterOpen &&
						<Register1 
						userInfos={userInfos}
						nextStep={this.nextStep}
						handleChange={this.handleChange}/>
					}
			</div>

			
//values={values}
*/