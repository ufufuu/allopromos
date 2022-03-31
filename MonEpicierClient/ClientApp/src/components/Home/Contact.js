import React from 'react';
import ReactDOM from 'react-dom';
import About from './About';
class Contact extends React.Component
{
	constructor(props){
		super(props);
		this.state={
			message:null
		}
	}
	componentDidMount(){
		//console.log(this.props);
		//alert(this.props.message);
	}
	componentWillMount(){
		//console.log(this.props);
		//alert(this.props.message);
	}
	render() {
		this.message = this.props.message;
		return (
			<div className="container" style={{backgroundColor:'#e2e2e2', fontColor:'#fff', fontcolor:'#fff'}} id="ontent">
				<div>
					<h3>Contact</h3>
						<p>
							Contact
						</p>
					</div>
				<div>dd</div>
				<div>
					Donnee here in the Child: <h4>{this.props.message}</h4>
				</div>
				
			</div>
		);
  }
}
export default Contact;