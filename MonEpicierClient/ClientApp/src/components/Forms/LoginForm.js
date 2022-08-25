import React from 'react';
import ReactDOM from 'react-dom';
export class LoginForm extends React.Component
{
	render()
	{
	var logoStyle ={
					/*height:80,
					width: 25,
					width :250,
					paddingTop: 15,
					marginleft:5
					*/
				}		
	var footerLeft= {float:'right', width:'40',marginTop:1,};
	var footerR= {'border':'dashed green', width:'20%',float:'left', 
	};
	var logoDown={ 'marginLeft':'3'};
	return(
		<div className="footer navbaRr-fixed-bottom" style={{marginTop:'35px'}}>
			<footer className="page-footer fixed-bottom font-small blue" style={{backgroundColor:'#fff'}}>
				<div className="footer-copyright text-center py-3">Copyright &copy; 2022&nbsp;
					<strong><a href="http://.io"><font color="red">allo-monepicier.co</font></a></strong>
						&nbsp;All rights reserved.
				</div>
			</footer>
		</div>
	);	
  }
}
/*

<footer className="main-footer" style={{backgroundColor:'#000'}}>
		<strong>
			Copyright &copy; 2020<a href="http://.io">tOUtOUtil.co</a>.
		</strong>
					All rights reserved.
			<div className="float-right d-none d-sm-inline-block">
				<b>Version</b>1.0.0
			</div>
	</footer>


<div className="contlainer">
			<div className="row row-centered pos" id="footDiv">
					<div className="col-md-3" style={footerR}>
						<h4> Cat&eacute;gories </h4>
							<ul>
								<li>rest</li>
								<li>mecano</li>
								<li>boituq</li>
							</ul>
					</div>
					
				<div className="col-md-3" style={footerR}>
					<h4>Promotions Code </h4>
						<ul>
							<li>Codes</li>
							<li>RE</li>
							<li>Top</li>
						</ul>
				</div>
				
				<div className="col-md-3" style={footerR}>
					<h4> Suivez-Nous </h4>
						<ul>
							<li>faceb</li>
							<li>Ins</li>
							<li>tw</li>
						</ul>
				</div>
				<div className="col-md-3" style={footerR}>
					<h4> Suivez-Nous </h4>
						<ul>
							<li>faceb</li>
							<li>Ins</li>
							<li>tw</li>
						</ul>
				</div>
				<div className="col-lg-8 col-xs-12 col-centered" style={footerLeft}>
					<div style={logoDown}>
						<h4><img src="http://localhost:3000/images/itemMain.png"  width="145" height="150" /></h4>
					</div>	
				<div>
			</div>
				</div>
			</div>
	</div>
	<footer className="main-footer" style={{backgroundColor:'gray', color:'#fff'}}>
		<div className="container text-center text-md-left">
				<div className="row">
						<div className="col-md-4 mx-auto">
							<h5 className="font-weight=bold text-uppercase mt-3 mb-4">Footer Content</h5>
							<p> here you 
								sdfsdfdfds
								</p>
						</div>
							
					<hr style={{border:'0.21px dotted #000'}} className="clearfix w-100 d-md-none" />
					<div className="col-md-2 mx-auto">
						<h5 className="font-weight=bold text-uppercase mt-3 mb-4">Links</h5>
							<ul className="list-unstyled">
								<li>
									<a href="#!"> Link1</a>
								</li>
								<li>
									<a href="#!"> Link1</a>
								</li>
							</ul>
					</div>
				</div>
			<hr style={{border:'0.21px dotted #000'}}/>
			<ul className="list-unstyled list-inline text-center">
				<li className="list-inline-iltem">
					<a className="btn-floating btn-fb mx-1">
						<i className="fab fa-facebook-f"></i>
					</a>
				</li>
			</ul>
			<div className="footer-copyright text-center py-3">
				@ 2020 Copyrigtht:
				<a href="http://.com"> tOUtOUtil</a>
			</div>
		</div>
		<div className="panel-footer" style={{backgroundColor:'#000', height:'100px', borderBottom:'0px'}}>
			<div className="container">
				<ul>
					<div className="row">
						<div className="col-sm-6 col-md-3">
							<div style={logoStyle} id="Logo">
								<img src="images/itemMain.png" className="img-responsivde" height="80" width="250"></img>
							</div>
						</div>
						<div className="col-sm-6 col-md-3">
							<div style={logoStyle} id="Logo">
								<img src="images/itemMain.png" className="img-responsivde" height="80" width="250"></img>
							</div>
						</div>
						<div className="col-sm-6 col-md-3">
							<div style={logoStyle} id="Logo">
								<img src="images/itemMain.png" className="img-responsivde" height="80" width="250"></img>
							</div>
						</div>
						<div className="col-sm-6 col-md-3">
							<div style={logoStyle} id="Logo">
								<img src="images/itemMain.png" className="img-responsivde" height="80" width="250"></img>
							</div>
						</div>
					</div>
				</ul>
			</div>
		</div>
	</footer>
*/