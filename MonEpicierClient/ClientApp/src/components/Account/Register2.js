import React from 'react';
import ReactDOM from 'react-dom';
import MyAccount from '../Account/MyAccount';
export default class Register2 extends React.Component
{
	state={
		loadMyAccount:false
	}
	OnClickBack =()=>{
		alert("back");
	}
	OnClickNext =()=>{
		this.setState({loadMyAccount:false});
		//if Success
		window.location.href ='/Account/Home/';
	}
	OnClickPostRental =()=>{
		window.location.href='/Account/Post';
	}
  render()
   {
	return(
		<div id="Contentww">
			<h4>Account Creation Step 2((((</h4>
				<div id="Contentw">
					<h4>final Account creattion !</h4>
				</div>
			<div className="container">
				<form role="form">
					<div className="form-group" style={{borderBottom:'2', marginBottom:'2'}}>
						<label for="firstname" className="col-sm-2 control-label">First Name</label>
							<div className="col-sm-10">
								<input type="text" className="form-control" id="firstname"
								placeholder="Enter First Name" />
							</div>
					</div>
					<div className="form-group">
						<label for="lastname" className="col-sm-2 control-label">Last Name</label>
							<div className="col-sm-10">
								<input type="text" className="form-control" id="lastname"
								placeholder="Enter Last Name" />
							</div>
					</div>
					<div className="form-group">
						<div className="col-sm-offset-2 col-sm-10">
							<button type="submit" onClick={this.OnClickBack.bind(this)} className="btn btn-default">Pr&eacute;c&eacute;dent </button>&nbsp;
							<button type="submit" onClick={this.OnClickNext.bind(this)} className="btn btn-default">Cr&eacute;er compte</button>&nbsp;
						<button type="submit" onClick={this.OnClickPostRental.bind(this)} style={{align:'right', marginLeft:''}} 
						className="btn btn-default">&Postez une Location</button>
						</div>
					</div>
					{this.state.loadMyAccount && <MyAccount />}
				</form>
			</div>
		</div>
	  );
   }
}
