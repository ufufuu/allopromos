class SubmitListingThree extends React.Component
{
  render()
   {
	return(
		<div id="Content">
			<h4>{this.state.title}</h4>
			<div id="Content">
				<h4><a onClick={this.OnLoginClick.bind(this)}> Login </a>|<a href="#" onClick={this.OnRegisterClick.bind(this)}> Register </a></h4>
			</div>
			<div className="container" id="container">
			
				//{this.state.isLoginOpen && <Login />}
				
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
						<label for="email" className="col-sm-2 control-label">E-mail</label>
							<div className="col-sm-10">
							<input type="text" className="form-control" id="email"
							placeholder="Enter Email" />
							</div>
					</div>
					<div className="form-group">
						<label for="r-email" className="col-sm-2 control-label">Re enter E-mail</label>
							<div className="col-sm-10">
							<input type="text" className="form-control" id="email"
							placeholder="Re enter Enter Email" />
							</div>
					</div>
					<div className="form-group">
						<label for="email" className="col-sm-2 control-label">Password</label>
							<div className="col-sm-10">
							<input type="password" className="form-control" id="email"
							placeholder="password" />
							</div>
					</div>
					<div className="form-group">
						<label for="email" className="col-sm-2 control-label">Re Enter Password</label>
							<div className="col-sm-10">
							<input type="password" className="form-control" id="email"
							placeholder="Re enter Password " />
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
							<button type="submit" className="btn btn-default">&Eacute;tape 4</button>
						</div>
					</div>
				</form>
			</div>
		</div>
	  );
   }
}
