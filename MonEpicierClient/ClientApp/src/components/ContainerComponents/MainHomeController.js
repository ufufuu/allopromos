import React from 'react';
import ReactDOM from 'react-dom';

//import ToolsItems from '../items/ToolsItems';
//import { Header } from './Header';

//import ItemsCategories from '../items/ItemsCategories';
import AuthenticationService from '../_services/AuthenticationService';
import {
  Route
  //NavLink,
  //HashRouter,
  //Switch
}from 'react-router-dom';
import NotFound from '../Helpers/NotFound';
import {Label} from 'react-bootstrap';
import MainHomeView from '../ViewComponents/Content/MainHomeView';
export default class MainHomeController extends React.Component
{
	constructor(props){
		super(props);
		this.state = {
			category: '',
			//tools:[{}]
			tools: [{}, {}, {}, {}, {}, {}],
			apiEndPoint: "http://localhsot:13545/api/ in Serv"
		};
		this.HandleLoginSubmit = this.HandleLoginSubmit.bind(this);
	}
	LoadItemsRentals(e){
		//this.setState({category:val})
		alert("HEHEHEH");
		this.setState({category:'OK'})
	}
	UserLogin = (user, password) => {

		//let apiEndpoint = this.state.apiEndPoint;
		//let apiLogin = "user/login";
		//try {
		//	fetch(apiEndpoint + apiLogin, {
		//		"method": "GET",
		//		headers: {
		//		},
		//	}).then(response => response.json())

		//	.catch(error=>{
		//			alert(error)
		//	})
		//}
		//catch (error){
		//	console.log(error);
		//}

		let authenticationService = new AuthenticationService();
		authenticationService.Login(user, password)
	}
	EditStoreController=({ storeId }) => {
		return <NotFound />
	}
	UserCreateAccount = (item) => {
		//let apiEndpoint = this.state.apiEndPoint;
		//let apiCreate = "user/create";
		//try {
		//	fetch(apiEndpoint + apiCreate, {
		//		"method": "POST",
		//		headers: {
		//		},
		//	}).then(response => response.json())
		//	.catch(err => {
		//		alert(err);
		// })
		//}
		//catch (error) {
		//	console.log(error);
		//}
	}
	GetUserRole = () => {

	}
	HandleLoginSubmit=()=> {
		//var authenticationService = new AuthenticationService();
		var auth = AuthenticationService.Login;
		auth(); // call By Ref instead of method call: AuthenticationService.Login();

	}
	handleChange = () => {
    }
	OnRegisterSubmit = () => {
		alert("trying to REgister from Controller ");
		this.UserCreateAccount();
    }
	componentDidMount(){
	}
	componentWillMount(){
	}
	render()
	{	
	//const tools=[{},{}]
		return (
			<div>
				<MainHomeView HandleLoginSubmit={this.HandleLoginSubmit} props={this.props}
					apiEndPoint={this.state.apiEndPoint} />
			</div>
		)
	}
}

//export default MainHome;
/*
<CategoryItems category={this.state.category}/>
<CategoryItems clickHander={this.LoadItemsRentals} />	
<CategoryItems clickHander={this.LoadItemsRentals} />

ui controllers state:
-sync state change from props
- theming and routing by state changes 

these 2 are the only times View components should access state

/*
	return(
		<div className="container">
			<Header />
			<div className="row">
					<ItemsCategories GetAllRentalsBy={this.GetAllRentalsBy} />	
			</div>
			<div className="row">
				<h4 style={{fontcolor:'#fff'}}>{this.state.category}</h4>
			</div>
			<div className="row" style={{
				backgroundColor: '#ff', 'borderBottom': '3', 'marginBottom': '3 px',
				'marginTop': '15 px'
			}}>
				<div className="col-md-8" style={{'border':'0px dashed'}}>
					<h3 className="containerTitle">Register Account</h3>
					<div className="form-group">
							<label for="exampleInputEmail1">Login:</label>
							<input type="email" className="form-control" 
								onChange={this.handleChange.bind(this, "email")} refs="email"
							 id="inputLogin_Register" placeholder="Login" />
							<h5 style={{color:'red'}} id="loginRequired">
								{this.state.loginRequired}</h5>
					</div>
					<div className="form-group">
							<label for="exampleInputEmail1">Mot de Passe:</label>
							<input type="password" className="form-control" 
							id="inputPwd" placeholder="Mot de Passe" />
							<h5 style={{color:'red'}} id="loginRequired">
								{this.state.pwdRequired}</h5>
					</div>
					<div className="form-group">
							<label for="exampleInputEmail1">Repet&eacute;z mot de passe:</label>
							<input type="password" className="form-control" 
							id="inputrPwd" placeholder="Mot de Passe Repet&eacute;" />
							<h5 style={{color:'red'}} id="loginRequired">
								{this.state.pwdrRequired}</h5>
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
						{/*}
							<PhoneInput
								inputProps={{
									name:'userPhoneNumber'
								}}
								country={'ca'}
								value=''
							/>{
							*/

	/*
							<h5 style={{color:'red'}} id="phoneRequired">{this.state.phoneRequired}</h5>
					</div>
					<div className="form-group">
						<button type="submit" onClick={this.OnRegisterSubmit.bind(this)} 
							className="btn btn-primary">S'ENREGISTRER</button>
					</div>
					<div className="card-body">
					</div>
				</div>
				<div>
					<h3>D&eacute;j&agrave; un Compte. Authenticate Below</h3>
				</div>
				<div className="col-md-4" style={{ 'border': '0px dashed' }}>
					<form role="form" onSubmit={this.handleLoginSubmit.bind(this)}}

/*
						<div className="card-body"><h3 className="containerTitle">Login</h3>
							<div className="form-group">
								<label>{this.state.labelUsername}User name:</label>
								<input type="login_username" className="form-control"
									role="username"
									refs="username"
									data-testid="userName"
									onChange={this.handleChange.bind(this, "username")}
									id="userInputLogin" placeholder="Username" />
								<span style={{ color: 'red' }}>{this.state.loginError}</span>
							</div>
							<div className="form-group">
								<label>Mot de passe:</label>
								<input type="password" className="form-control" role="password" refs="userpwd"
									data-testid="userPwd" onChange={this.handleChange.bind(this, "userpassword")}
									id="userInputPwd" placeholder="Mot de Passe" />
								<span style={{ color: 'red' }}>{this.state.passwordError}</span>
							</div>
							<div data-testid="Remember-Me" />
							<label>
								<input type="checkbox" data-testid="remembeRing"
									name="rememberMe" />&nbsp;Remember Me
								</label>
						</div>
						<div className="form-group" data-testid="divBtnSubmit">
							<button type="submit" data-testid="btnSubmit" test-id="loginSubmit"
								id="BtnLOGIN"
								onClick={this.handleLoginSubmit.bind(this)}
								className="btn btn-primary">LOGIN </button>
						</div>
					</form>
				</div>
			</div>
			<div>
			</div>
	</div>
	);
	*/