import React from 'react';
import ReactDOM from 'react-dom';
import JQuery from 'jquery';
class SubmitListingTwo extends React.Component
{
	
	state={
		username: '',
		name: '',
		accountBalance: '5324 $'
	}
	constructor(props){
		
		super(props);
		this.setState({loadMyAccount:false});
	}
	
	OnLoginClick=() =>{

	}	
	OnRegisterClick=() =>{

	}
	
	RentalSubmission= e=>{
		var Id="123";
		
		/*
		http://localhost:52424/Rentals/RentalsService.svc/CreateRental/123/1/Brouette/20330068-e595-4f34-8ccb-5b03070b481
		
		
		http://localhost:52424/Rentals/RentalsService.svc/CreateRental/123/1/Brouette/20330068-e595-4f34-8ccb-5b03070b4814
		*/
		//var Category=document.getElementById("Category").value;
		var Category="1";
		//var Title= document.getElementById("title").value;
		var Title= "Brouette Location";
		//var userId="LLLL";usr
		var userId="f30f79cd-51d0-4797-af8b-1566503e7b5f";
		/*
		JQuery.ajax({
			url: 'http://localhost:52424/Rentals/RentalsService.svc/CreateRental/'+Id+'/'+Category+'/'+Title+'/'+userId,
			
			method:'GET',
			success:function(data){
				alert("Rental Posted");
				},
			error:function(){
				alert("No possible to Post");
				}
			})
			*/
		//Using Fetch
		fetch("http://localhost:52424/Rentals/RentalsService.svc/CreateRental/"+Id+"/"+Category+"/"+Title+"/"+userId,{
			method:'GET'
		})
		.then(response =>response.json())
		.then((responseJson) => {
			console.log(responseJson)
		})
		.catch((error) => {
			console.error(error);
		});	
		
	}
	OnToolRentalSubmitted= () =>{
			this.RentalSubmission();
	}
  render()
   {
	return(
	<div className="container" style={{backgroundColor:'#e2e2e2', fontColor:'#fff', fontcolor:'#fff'}} id="ontent">
		<h3>Soumettre un Rental</h3>
		<div className="row">
			<div className="col-md-6">
					<div class="form-group">
							<label for="exampleInputEmail1">Titre:</label>
							<input type="email" class="form-control" id="exampleInputEmail1" placeholder="Titre de Votre Annonce" />
					</div>
					<div class="form-group">
							<label for="exampleInputPassword1">Description:</label>
							<textarea class="form-control" rows="3"></textarea>
					</div>
					<div className="form-group">			
						<label for="name">Cat&eacute;gorie:</label>
						<form>
							<div>
								<select class="form-control" style={{backgroundColor:'#fff',fontColor:'#000'}}>
									<option>MENUISERIE</option>
									<option>MACONNERIE</option>
									<option>EEE</option>
									<option>DDD</option>
									<option>NNN</option>
								</select>	
							</div>
							
						</form>
				</div>
			</div>
			
			<div className="col-md-6">  
				<div class="card card-primary">
				<div class="card-header">
					<label for="exampleInputEmail1">Caract&eacute;ristiques:</label>
				</div>
				<form role="form">
						<div class="card-body">
						<div className="panel panel-default">
							<div className="panel-heading">
								<h3 className="panel-title"><label for="lastname">&Eacute;tat:<br /></label></h3>
							</div>
							<div className="panel-body">
								<div className="form-group">
								
								<div class="checkbox">
									<label><input type="checkbox" value="" />Neuf</label>
								</div>
								<div class="checkbox">
									<label><input type="checkbox" value="" />Comme Neuf</label>
								</div>
								<div class="checkbox">
									<label><input type="checkbox" value="" />Moyen</label>
								</div>
								<div class="checkbox">
									<label><input type="checkbox" value="" />Usage Avanc&eacute;</label>
								</div>
								<div>
									<input type="radio" name="optionsRadiosinline" id="optionsRadios4"
										value="option2" /> Option 2
								</div>
								<div>
									<input type="radio" name="optionsRadiosinline" id="optionsRadios4"
										value="option2" /> Option 2
								</div>
							</div>
							</div>
						</div>
						<label for="exampleInputEmail1">Photos:</label>
						  <div className="panel panel-default">
							<div className="panel-heading">
								<h3 className="panel-title"><label for="exampleInputFile">Images/Photos</label></h3>
							</div>
							<div className="panel-body">
									<div class="form-group">
										
										<div class="input-group">
											  <div class="custom-file">
												<input type="file" class="custom-file-input" id="exampleInputFile" />
												<label class="custom-file-label" for="exampleInputFile">Choose file</label>
											  </div>
											  <div class="input-group-append">
												<span class="input-group-text" id="addPhotos"><a href="#">Add/Ajouter photo</a></span>
											  </div>
										</div>
								
									</div>
							</div>
						</div>
						</div>
						<div class="card-footer">
							<button type="submit" style={{marginRight:'5px'}} class="btn">Apercu &nbsp;&nbsp;</button>
							<button type="submit" onClick={this.OnToolRentalSubmitted.bind(this)} class="btn btn-primary">Enregistrer pour faire Louer</button>
						</div>
				</form>
             </div>	
		</div>	
	</div>
</div>
	  );
   }
}
export default SubmitListingTwo;