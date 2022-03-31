import React from 'react';
import ReactDOM from 'react-dom';

import Menu from '../components/menuMain';

export class HeaderTop extends React.Component
{
constructor(props)
{
	super(props);	
	
	this.state={
		header: " hello in h"	
	}
}
SubMenuChange()
{
}

SearchClick()
{
	

	
}


render()
{
	var logoStyle ={height:80,
					width: 25,
					width :250,
					paddingTop: 15,
					marginleft:5
	}			
return(
			<div id="top">	
				<div id="sueader">
					<ul>
						<div style={logoStyle} id="Logo"><img src="images/itemMain.png" height="80" width="250"></img></div>	
					</ul>
				</div>
		
				{
					/*
					<div id="topMainMenu">
						<ul>
							<li><a href="#">ACCEUIL 2;</a></li>
							<li><a href="#">My </a></li>
							<li><a href="#">Toutes Pro</a></li>
							<li><a href="#">Categories</a></li>
							<li><a href="#">PROMOCODES</a></li>
						</ul>
					</div>
					*/
				}
				
				{
					/*
					<div id="topMainMenu">
						<ul>
							<li><a href="#">ACCEUIL 2;</a></li>
							<li><a href="#">My </a></li>
							<li><a href="#">Toutes Pro</a></li>
							<li><a href="#">Categories</a></li>
							<li><a href="#">PROMOCODES</a></li>
						</ul>
					</div>
					*/
				}
				{
					/*
					<div id="subMenu">
						<ul>
							<li><a href="#">popo</a></li>
							<li><a href="#">jkj</a></li>
						</ul>
					</div>
					*/
				}
				
				{
					/*
				<h1>{this.state.header}</h1>
				*/
				}
		</div>
);	
}
}
