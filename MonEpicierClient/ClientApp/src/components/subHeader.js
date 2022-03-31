import React from 'react';
import ReactDOM from 'react-dom';
export class SubHeader extends React.Component
{
	constructor(props)
	{
			super(props);	
			
			this.state={
				header: "Hello tOutOutil sub header "	
			}
	}
	DataChange()
	{
		var data = document.getElementById("subMenu");
		data.innerHTML="<ul><li>fuc</li></ul>";	
	}
render()
 {
	return(
	<div>
		<div>
			<div id="subMenu">
				<ul>
					<li><a href="#" onClick={this.DataChange}>5656</a></li>
					<li><a href="#" onMouseOver={this.DataChange}>ababab</a></li>
				</ul>
			</div>
				<h1>{this.state.header}</h1>
		</div>
		{
	/*
		<div>
			<h1> Sub Header !</h1>
			qwewqewqki
			qwekwqnejkwqnme
		</div>
	
		<div id="subMenu">
			<ul>
				<li><a href="#">32132</a></li>
				<li><a href="#">ppdpdppd</a></li>
			</ul>
		</div>
		
	*/}
	</div>
	);	
 }
}
