import React from 'react';
import ReactDOM from 'react-dom';
class MissionPickup extends React.Component
{
	constructor(props){
		super(props);
	}
	conmponentDidMount() {
		//const gre = nagivator;
		//alert(navigator);
    }
	Continue = e => {
		e.preventDefault();

		this.ValidateForm();
		//this.props.nextStep();
	}
	state = {
		step: 1,
		showRegister2: false,
		AccountCreation: {
			firstName: '',
			firstNameValidationError: '',
			lastNameValidationError: '',
			EmailValidationError: '',
			RepeatEmailValidationError: '',
			PasswordValidationError: '',
			RepeatPasswordValidationError: '',
		}
	}
	PreviousClick = () => {

	}
	NextClick = () => {
		//alert(this.state.step);
		//return(<MyAccount />);
		//this.setState({showRegister2:true});
		//this.props.nextStep();

	}
	ValidateForm = () => {
		//e.preventDefault;
		let inputValues = document.getElementsByClassName("form-control").value

		let Number = document.getElementById("cityPicking").value;
		let RoadName = document.getElementById("buildingNumber").value;
		let cityPicking = document.getElementById("cityPicking").value
		let cityRegion = document.getElementById("cityPicking").value
		let regionPicking = document.getElementById("regionPicking").value
		let regionPickin0g = document.getElementById("regionPicking").value

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
		if (cityPicking === '') {
			this.setState({
				firstNameValidationError: 'first Name Requis',
				/*lastNameValidationError:'',
				EmailValidationError:'',
				RepeatEmailValidationError:'',
				PasswordValidationError:'',
				RepeatPasswordValidationError:''*/

			})

			//return false;
			//return false;
		}
		if (cityPicking === '') {
			this.setState({
				lastNameValidationError: 'Last Name Requis'
			})
		}
		if (cityPicking === '') {
			this.setState({ EmailValidationError: 'E-mail est Requis' })
		}
		//else{
		else if (regionPicking != '') {
			if (!ValidateEmail(cityPicking)) {
				this.setState({ EmailValidationError: 'E-mail en bon format S.v.p ' })
			}
		}
		
		else if (regionPicking != '') {
			if (!ValidateEmail(cityPicking)) {
				this.setState({ EmailValidationError: 'R&eacute;p&eaute;ter E-mail en bon format S.v.p ' })
			}
			else if (regionPickin0g != cityPicking) {
				this.setState({ RepeatEmailValidationError: "E-mail & Repéter E-mail ne sont pas identiques" })
				return;
			}
		}
		if (regionPicking === '') {
			this.setState({ PasswordValidationError: 'Mot de Passe Requis' })
		}
		else if (Number.Leng < 8) {
			alert("Mot de Passe de 8 caracteres au moins");
		}
		if (regionPicking === '') {
			this.setState({ RepeatPasswordValidationError: ' R&eacute;p&eaute;ter Mot de Passe Requis' })
		}

		else if (regionPicking != '') {
			if (regionPicking != cityPicking) {
				this.setState({
					RepeatPasswordValidationError: ' Mots de Passes non Identiques'
				})
				//return;
			}
			else {
				this.NextClick();
				//alert("data ok");
			}
		}

		function ValidateEmail(regionPicking) {
			var re = /\S+@\S+\.\S+/;
			return re.test(cityPicking);
		}
		//}
	}
	render()
	{
return (
	<div className="container">
		<div className="row">
			<button class="btn btn-primary btn-lg" data-toggle="modal"
				data-target="#myModal">
				Enl&eacute;vement
			</button>
	<div class="container">
		<div class="row">
			<div class="modal fade" id="myModal" tabindex="-1" role="dialog"
				aria-labelledby="myModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">
								<form role="form">
									<div><h4>Adresse de prise en charge</h4>
										<div className="form-group" style={{ borderBottom: '2', marginBottom: '2' }}>
											<label for="buildingNumber" className="col-sm-2 control-label">Num&eacute;ro:</label>
												<div className="col-sm-10">
													<input type="text" className="form-control" onBlur={this.ValidateForm.bind(this)}
														onChange={this.ValidateForm.bind(this)} id="buildingNumber"
														name="buildingNumber"
														placeholder="Enter Number" />
													{this.state.firstNameValidationError}
												</div>
										</div>
										<div className="form-group">
											<label for="roadName" className="col-sm-2 control-label">Rue:</label>
												<div className="col-sm-10">
													<input type="text" className="form-control" id="roadName" name="roadName"
														placeholder="Enter Rue" onChange="" defaultValue="" />
													{this.state.lastNameValidationError}
												</div>
										</div>
										<div className="form-group">
											<label for="cityPicking" className="col-sm-2 control-label">Ville:</label>
												<div className="col-sm-10">
													<select className="form-control" id="cityPicking" name="cityPicking"
														>
														<option>Qu&eacute;bec</option>
													</select>
												</div>
										</div>
										<div className="form-group">
												<label for="regionPicking" className="col-sm-2 control-label">Province:</label>
												<div className="col-sm-10">
													<select className="form-control" id="regionPicking" name="regionPicking"
														>
														<option>Qu&eacute;bec</option>
													</select>
												</div>
										</div>
									</div>
								</form>
								<button id="nextButtonClick" class="btn btn-primary btn-lg" data-toggle="modal"
									data-target="#myModalNext">
									Livraion
								</button>
						</div>
					</div>
				</div>
					</div>

					<div class="modal fade" id="myModalNext" tabindex="-1" role="dialog"
						aria-labelledby="myModalLabel" aria-hidden="true">
						<div class="modal-dialog">
							<div class="modal-content">
								<div class="modal-header">
								  <div className="modal-body">
									<form role="form">
										<div><h4>Livraison:</h4>
											<div className="form-group" style={{ borderBottom: '2', marginBottom: '2' }}>
												<label for="buildingNumberDelivery" className="col-sm-2 control-label">Num&eacute;ro:</label>
												<div className="col-sm-10">
													<input type="text" className="form-control" onBlur={this.ValidateForm.bind(this)}
														onChange={this.ValidateForm.bind(this)} id="buildingNumber"
														name="buildingNumberDelivery"
														placeholder="Enter Number" />
													{this.state.firstNameValidationError}
												</div>
											</div>
											<div className="form-group">
												<label for="roadNameDeliuvery" className="col-sm-2 control-label">Rue:</label>
												<div className="col-sm-10">
													<input type="text" className="form-control" id="roadName" name="roadName"
														placeholder="Enter Rue" onChange="" defaultValue="" />
													{this.state.lastNameValidationError}
												</div>
											</div>
											<div className="form-group">
												<label for="cityPickingDelivery" className="col-sm-2 control-label">Ville:</label>
												<div className="col-sm-10">
													<select className="form-control" id="cityPicking" name="cityPickingDelivery"
													>
														<option>Qu&eacute;bec</option>
													</select>
												</div>
											</div>
											<div className="form-group">
												<label for="regionPickingDelivery" className="col-sm-2 control-label">Province:</label>
												<div className="col-sm-10">
													<select className="form-control" id="regionPicking" name="regionPickingDelivery"
													>
														<option>Qu&eacute;bec</option>
													</select>
												</div>
											</div>
										</div>
										</form>
									</div>
									<div className="modal-footer">
										<button id="nextButtonClick" class="btn btn-primary btn-lg" data-toggle="modal" data-dismiss="modal">
											Suite
										</button>
										{/*}
										<button type="button" class="btn btn-secondary" data-mdb-dismiss="modal">
											Close
										</button>{*/}
									</div>
								</div>
							</div>
						</div>
					</div>
			</div>
			</div>
		</div>
	</div>
	);
  }
}
export default MissionPickup;