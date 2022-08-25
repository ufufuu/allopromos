import React from 'react';
import ReactDOM from 'react-dom';
class ToolsItems extends React.Component {
	constructor(props) {
		super(props);
	}
state = {
}
	render() {
		let item = {}
		return (
			<div className="row" style={{ borderBottom: '3px', backgroundColor: '#000' }}>
			{
					//this.tores.map((item)=>(
				<div className="col-md-4" style={{
						backgroundColor: '#e2e2e2', 'border': '1px dashed',
						display: 'inline'
				}}>
				<div style={{ border: '1px dotted red' }}>
					<div style={{ width: 'auto' }}>
						<div style={{
							border: '1px dotted blue', width: 'auto',
							backgroundColor: '#000', color: '#fff'
							}}><h5>{item.StoreName}</h5>
						</div>
					</div>
					<span className="time">{item.rentalCategory}</span>
					<span>{item.StoreId}</span>
					<div className="commentCount">
						<span>Cocy</span>
						<span>
						{item.StoreId}
						</span>
					</div>
					<div style={{ border: '1px dotted red' }}>
						<div style={{ float: 'left', width: '75%', border: '1px dotted #000', color: '#000' }}>
							<img className="toolItemThumbnail"
								src="http://localhost:3000/images/itemMain.png" />
						</div>
					<div style={{ float: 'left', width: '25%', color: '#000' }}>
						<div><h4>item.</h4></div>
						</div>
					</div>
					</div>
				 	<div style={{}}>
						<div style={{ width: '33%', float: 'left' }}>
							<div><h4>{item.StoreId}</h4></div>
							<div><h4>{item.StoreId}</h4></div>
							<div><h4>{item.StoreId}</h4></div>
						</div>
						<div style={{ width: '33%', float: 'left' }}>
							<div><h4>{item.StoreId}</h4></div>
						</div>
						<div style={{ width: '33%', float: 'right' }}>
							<div><h4>{item.StoreId}</h4></div>
							<div><h4>{item.StoreId}</h4></div>
							<div><h4>{item.StoreId}</h4></div>
						</div>
	  			</div>
			</div>
	//)
			}
	</div>
	)	
}
	componentWillUnmount()
	{	
	}
	componentDidMount()
	{
	}
} 
export default ToolsItems;
