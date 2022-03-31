import React from 'react';
	const Route =({path, component})=>{
		const pathname= window.location.pathname;
		if(pathname.match(path)){
			return(
			React.createElement(component)
			);
		} else{
			return null
		}
	};

export default class Items extends React.Component
{
	state ={
		
		tools:[]
	}	
	constructor(props)	
	{
		super(props);
		//this.setter.stateSetter(this);
		//this.state=
		//{
		//	tools :'Initialisation', msg: 'now'
		//}
	}
	render()
	{
		const {tools}=  this.state;
		const {msg}= this.state;
		return(
		<div>
			<h3>Data Being REturned fromin router </h3>
			<div>
							
				{tools.map((tool)=>(
				<div>
					<div> {tool.toolId} </div>
					<div> {tool.toolReference} </div>
					<div> {tool.toolCategory} </div>
				</div>
				))}	
				
			</div>
		</div>
		)
		
	}
	componentWillUnmount()
	{
		this.setter.cancel();	
	}
	componentDidMount()
	{
		//this.ListItems();	
		//this.ItemsListing()
		
		
		fetch('http://localhost:51739/api/tools')
		.then(res=>res.json())
		.then((data)=>{ 
		this.setState({ tools: data })
		})
	 .catch(console.log)
	}
	ListItems()
	{
	 fetch('http://localhost:51739/api/tools', {
		 header:{
			Accept: 'application/json', 
		 },
	 })
		//.then(response=>response.json())
		//.then (json=>this.setState({tools:json.data}));
		
	.then(
		(tools)=>{
			this.setter.SetState({tools:tools});	
		});	
	}
	
	ItemsListing()
	{
		var request = new XMLHttpRequest();
		request.open('GET', '/my/url', true);
		request.onload = () => {
		if (request.status >= 200 && request.status < 400) {
		// Success!
		this.setState({tools: request.responseText})
		} else {
		// We reached our target server, but it returned an error
		// Possibly handle the error by changing your state.
		}
		};
		request.onerror = () => {
		// There was a connection error of some sort.
		// Possibly handle the error by changing your state.
		};
		request.send();
	}
} 

