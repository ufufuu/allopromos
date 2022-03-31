import React from 'react';
import ReactDOM from 'react-dom';
import JQuery from 'jquery';
class SubmitListing extends React.Component
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
  render()
  {
	return(
<div className="container" id="Content" style={{backgroundColor:'#000'}}>
			<h4>{this.state.title}</h4>
			<div id="Content">
				<h4><a onClick={this.OnLoginClick.bind(this)}></a>Poster une Location:-<a href="#" onClick={this.OnRegisterClick.bind(this)}></a></h4>
			</div>
	<div className="row" id="content">
	
				<form role="form">
				<label class="checkbox-inline">
				<input type="radio" name="optionsRadiosinline" id="optionsRadios4"
				value="option2"/>Location
				</label>
				
		<div className="col-md-6">  
            <div class="card card-primary">
				<div class="card-header">
					<h3 class="card-title">Quick Example</h3>
				</div>
				<form role="form">
						<div class="card-body">
									  <div class="form-group">
										<label for="exampleInputEmail1">Email address</label>
										<input type="email" class="form-control" id="exampleInputEmail1" placeholder="Enter email" />
									  </div>
									  <div class="form-group">
										<label for="exampleInputPassword1">Password</label>
										<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password" />
									  </div>
						  
								<div class="form-group">
									<label for="exampleInputFile">File input</label>
									<div class="input-group">
										  <div class="custom-file">
											<input type="file" class="custom-file-input" id="exampleInputFile" />
											<label class="custom-file-label" for="exampleInputFile">Choose file</label>
										  </div>
										  <div class="input-group-append">
											<span class="input-group-text" id="">Upload</span>
										  </div>
									</div>
							
								</div>
								  <div class="form-check">
										<input type="checkbox" class="form-check-input" id="exampleCheck1" />
										<label class="form-check-label" for="exampleCheck1">Check me out</label>
								  </div>
						</div>
							<div class="card-footer">
								<button type="submit" class="btn btn-primary">Submitew</button>
							</div>
				</form>
             </div>	
		</div>
			           
        <div className="col-md-6">   
            <div class="card card-secondary">
              <div class="card-header">
                <h3 class="card-title">CUSTOM ELEMENTS</h3>
              </div>
              
              <div class="card-body">
                <form role="form">
                  <div class="row">
                    <div class="col-sm-6">
                      
                      <div class="form-group">
                        <div class="custom-control custom-checkbox">
                          <input class="custom-control-input" type="checkbox" id="customCheckbox1" value="option1" />
                          <label for="customCheckbox1" class="custom-control-label">Custom CheckboxWWW</label>
                        </div>
                        <div class="custom-control custom-checkbox">
                          <input class="custom-control-input" type="checkbox" id="customCheckbox2" checked />
                          <label for="customCheckbox2" class="custom-control-label">Custom Checkbox checked</label>
                        </div>
                        <div class="custom-control custom-checkbox">
                          <input class="custom-control-input" type="checkbox" id="customCheckbox3" disabled />
                          <label for="customCheckbox3" class="custom-control-label">Custom Checkbox disabled</label>
                        </div>
                      </div>
                    </div> 
                    <div class="col-sm-6">
                      
                      <div class="form-group">
                        <div class="custom-control custom-radio">
                          <input class="custom-control-input" type="radio" id="customRadio1" name="customRadio" />
                          <label for="customRadio1" class="custom-control-label">Custom Radio</label>
                        </div>
                        <div class="custom-control custom-radio">
                          <input class="custom-control-input" type="radio" id="customRadio2" name="customRadio" checked />
                          <label for="customRadio2" class="custom-control-label">Custom Radio checked</label>
                        </div>
                        <div class="custom-control custom-radio">
                          <input class="custom-control-input" type="radio" id="customRadio3" disabled />
                          <label for="customRadio3" class="custom-control-label">Custom Radio disabled</label>
                        </div>
                      </div>
                    </div>
                  </div>

                  <div class="row">
                    <div class="col-sm-6">
                      
                      <div class="form-group">
                        <label>Custom Select</label>
                        <select class="custom-select">
                          <option>option 1</option>
                          <option>option 2</option>
                          <option>option 3</option>
                          <option>option 4</option>
                          <option>option 5</option>
                        </select>
                      </div>
                    </div>
                    <div class="col-sm-6">
                      <div class="form-group">
                        <label>Custom Select Disabled</label>
                        <select class="custom-select" disabled>
                          <option>option 1</option>
                          <option>option 2</option>
                          <option>option 3</option>
                          <option>option 4</option>
                          <option>option 5</option>
                        </select>
                      </div>
                    </div>
                  </div>

                  <div class="row">
                    <div class="col-sm-6">
                      <div class="form-group">
                        <label>Custom Select Multiple</label>
                        <select multiple class="custom-select">
                          <option>option 1</option>
                          <option>option 2</option>
                          <option>option 3</option>
                          <option>option 4</option>
                          <option>option 5</option>
                        </select>
                      </div>
                    </div>
                    <div class="col-sm-6">
                      <div class="form-group">
                        <label>Custom Select Multiple Disabled</label>
                        <select multiple class="custom-select" disabled>
                          <option>option 1</option>
                          <option>option 2</option>
                          <option>option 3</option>
                          <option>option 4</option>
                          <option>option 5</option>
                        </select>
                      </div>
                    </div>
                  </div>

                  <div class="form-group">
                    <div class="custom-control custom-switch">
                      <input type="checkbox" class="custom-control-input" id="customSwitch1" />
                      <label class="custom-control-label" for="customSwitch1">Toggle this custom switch element</label>
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="custom-control custom-switch custom-switch-off-danger custom-switch-on-success">
                      <input type="checkbox" class="custom-control-input" id="customSwitch3" />
                      <label class="custom-control-label" for="customSwitch3">Toggle this custom switch element with custom colors danger/success</label>
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="custom-control custom-switch">
                      <input type="checkbox" class="custom-control-input" disabled id="customSwitch2" />
                      <label class="custom-control-label" for="customSwitch2">Disabled custom switch element</label>
                    </div>
                  </div>
                  <div class="form-group">
                    <label for="customRange1">Custom range</label>
                    <input type="range" class="custom-range" id="customRange1" />
                  </div>
                  <div class="form-group">
                    <label for="customRange1">Custom range (custom-range-danger)</label>
                    <input type="range" class="custom-range custom-range-danger" id="customRange1" />
                  </div>
                  <div class="form-group">
                    <label for="customRange1">Custom range (custom-range-teal)</label>
                    <input type="range" class="custom-range custom-range-teal" id="customRange1" />
                  </div>
                  <div class="form-group">
                    <label for="customFile">Custom File</label>

                    <div class="custom-file">
                      <input type="file" class="custom-file-input" id="customFile" />
                      <label class="custom-file-label" for="customFile">Choose file</label>
                    </div>
                  </div>
                  <div class="form-group">
                  </div>
                </form>
              </div>
            </div> 
		</div>	
				
			
				
			
					<div className="form-group">			
						<label for="name">Cat&eacute;gorie:</label>
							<select class="form-control" style={{backgroundColor:'#fff',fontColor:'#000'}}>
								<option>MENUISERIE</option>
								<option>MACONNERIE</option>
								<option>EEE</option>
								<option>DDD</option>
								<option>NNN</option>
							</select>	
					</div>
				
				
					<div className="form-group">
						<label for="lastname" className="col-sm-2 control-label">Type d'Outillage</label>
							<div className="col-sm-10">
							<input type="text" className="form-control" id="lastname"
							placeholder="Enter Last Name" />
							</div>
					</div>
					
					<button type="submit" class="btn btn-default">Submit</button>
				</form>
			</div>
		</div>
	  );
   }
}
export default SubmitListing;

/*

<div class="form-group">
						<label class="sr-only" for="inputfile">File input</label>
								<input type="file" id="inputfile" />
						
							<div class="checkbox">
								<label>
									<input type="checkbox"> Check me out</input>
								</label>
							</div>
					</div>
					
					
					*/