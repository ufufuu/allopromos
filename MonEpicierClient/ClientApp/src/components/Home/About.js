import React from 'react';
import ReactDOM from 'react-dom';
import ItemsCategories from '../items/ItemsCategories';
import Contact from './Contact';

//645




class About extends React.Component
{
	constructor(props){
		super(props);
			this.handleInputValue= this.handleInputValue.bind(this);
			this.state={
			message: 'lalal',
			inputValue:'r',
			donnees:'I am from Parent',
			count:1
		}
	  this.outputEvent=this.outputEvent.bind(this); 
	}
	handleInputValue(val){
		this.setState({inputVal:val});
	}
	outputEvent=(e) =>{
		this.setState({count:this.state.count+1});
	}
	HelloTarget=(e) =>{
		console.log(e.target);
		alert(e.target.TagName);
	}
  render() {
	  const variable=5;
	  var count= this.state.count;
    return (
	
	
	<div className="container" style={{backgroundColor:'#e2e2e2', fontColor:'#fff', fontcolor:'#fff'}} id="ontent">
	<div class="row" >
	
			<div>
				<h3>About</h3>
				<p>
					About About
				</p>
			</div>
			
			<div>
				<h3>Parent Com</h3>
				<hr />
				INPUT Value:{this.state.inputValue}
				<ItemsCategories handleInput={this.handleInputValue} />
			</div>
			
			<div style={{margin:'0px 0 0px 0px'}}>
				<h4>Child Component</h4>
				<hr />
				Input: 
				<input value={this.state.inputValue} onChange={this.onInputChange} style={{margin:'0 10px' }} />
				
				<input type="button" value="OK" onClick={this.handleSubmit} />
			</div>
			
			<div>
				<Contact message={this.state.donnees} />
			</div>
			<a onClick={this.HelloTarget}>hellTarget</a>
			<input value="ert" type="button" onClick={this.HelloTarget} />
      </div>
	</div>  
	
    );
  }
}
export default About;
//