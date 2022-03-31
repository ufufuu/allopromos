import React from 'react';
import ReactDOM from 'react-dom';

class Blog extends React.Component
{
	constructor(props){
		super(props);
	}
	render(){
		return(
		<div className="content">
				<div className="row" style={{backgroundColor:'#f2f2f2', borderStyle:'1px black dotted' }}>
				
					<h4>ffh</h4>
					
				</div>
				<div className="container" style={{backgroundColor:'#000', height:'450px', borderStyle:'1px black dotted' }}>
				
					<h4>Blog</h4>
					
					<div className="" style={{backgroundColor:'#999', borderStyle:'1px black dotted' }}>
					
					<h4>Blog 2</h4>
				</div>
			</div>
		</div>
		)
	}
}
export default Blog;