import React from 'react';
import ReactDOM from 'react-dom';
import ToolsItems from '../items/ToolsItems';
import ItemsCategories from '../items/ItemsCategories';
// React DevTools 
import {
  Route
  //NavLink,
  //HashRouter,
  //Switch
}
from 'react-router-dom';
class Content extends React.Component
{
	constructor(props){
		super(props);
		this.state={
			category:'',
			//tools:[{}]
			//tools:[{},{},{},{},{},{}]
			itemsCategories:[{},{}],
			itemsData:[{},{},{}],
			mystores:
			[
				{
					"aspnet_Users": null,
					"tStoreCategory": null,
					"StoreId": "dfdsf",
					"StoreName": "Mexicano Market",
					"LoweredStoreName": "prudencia",
					"UserId": "f5702506-ed5b-4fe4-a9d3-8407fbd228bd",
					"CategoryId": 3
				},
				{
					"aspnet_Users": null,
					"tStoreCategory": null,
					"StoreId": "ewrewrewr",
					"StoreName": "Spanish World",
					"LoweredStoreName": "ewqrerwq",
					"UserId": "f5702506-ed5b-4fe4-a9d3-8407fbd228bd",
					"CategoryId": 3
				},
				{
					"aspnet_Users": null,
					"tStoreCategory": null,
					"StoreId": "oppooppoop",
					"StoreName": "Aaliyaa Marche Africain",
					"LoweredStoreName": "trrtrrrrrr",
					"UserId": "f5702506-ed5b-4fe4-a9d3-8407fbd228bd",
					"CategoryId": 1
				},
				{
					"aspnet_Users": null,
					"tStoreCategory": null,
					"StoreId": "qwewqe",
					"StoreName": "Makiti African Market",
					"LoweredStoreName": "e2wqe",
					"UserId": "f5702506-ed5b-4fe4-a9d3-8407fbd228bd",
					"CategoryId": 1
				},
				{
					"aspnet_Users": null,
					"tStoreCategory": null,
					"StoreId": "sdd",
					"StoreName": "fuufu Bar",
					"LoweredStoreName": "fuufu bar",
					"UserId": "f5702506-ed5b-4fe4-a9d3-8407fbd228bd",
					"CategoryId": 2
				},
				{
					"aspnet_Users": null,
					"tStoreCategory": null,
					"StoreId": "Wer",
					"StoreName": "Ayo Aye africain supermarche",
					"LoweredStoreName": "erere.",
					"UserId": "f5702506-ed5b-4fe4-a9d3-8407fbd228bd",
					"CategoryId": 1
				}
			]
		}
	}
	LoadItemsRentals(e){
		alert("HEHEHEH");
		this.setState({category:'OK'})
	}
	GetAllStoresCategories=() =>{
		fetch('http://localhost:55168/api/stores/categories')
		.then(response =>response.json())
		.then((data)=>{
			this.setState({itemsCategories:data});
		})
	}
	//GetItemsByCategory=() =>{
	GetItemsByCategory=(catId) =>{
		//const {handle} = this.props.match.params;
		//const handle=2;
		//fetch(`http://localhost:52424/Rentals/Rentalsservice.svc/rentals/'${handle}`)
		//catId=1;
		fetch('http://localhost:55168/api/stores/'+catId)
		.then(response =>response.json())
		.then((data)=>{
			this.setState({itemsData:data});
		}).catch(err=> {
			console.lor(err);
		})
	}
	/*
	GetAllRentalsBy=(item) =>{xz 
		//const {handle} = this.props.match.params;
		
		//const handle=2;
		//fetch(`http://localhost:52424/Rentals/Rentalsservice.svc/rentals/'${handle}`)
		fetch('http://localhost:55168/api/stores/')
		
		
		//fetch('http://localhost:52424/Rentals/Rentalsservice.svc/rentals/2')
		
		.then(response =>response.json())
		.then((data)=>{
			this.setState({tools:data});
		})
	}*/
	componentDidMount(item){
		//this.GetAllRentals(item);
		//this.GetAllStoresCategories();
		//this.GetItemsByCategory();
	}
	componentWillMount(){
		//this.GetAllRentals(item);
		//this.GetAllStoresCategories();
		//this.GetItemsByCategory();
	}
	filterStores(id){
		//alert("filiter");
		var items= this.state.mystores.filter(o=>o.CategoryId===id);
		this.setState({mystores:items});
		alert("data stores are"+items)
		this.state.mystores.filter(o=>o.CategoryId===id)
	}
	render()
	{
	return(
	  <div id="Content">
			<div className="container">
				<div className="row">
					<ItemsCategories GetAllRentalsBy={this.GetAllRentalsBy} 
						GetStoresByCategory={this.GetStoresByCategory}
						itemsData={this.state.itemsData}
						mystores={this.state.mystores}
						GetItemsByCategory={this.GetItemsByCategory} />	
				</div>
			</div>
			<div>
				<h4 style={{fontcolor:'#fff'}}>{this.state.category}</h4>
			</div>/*
		  <div className="container" style={{backgroundColor:'#000','borderBottom':'3', 'marginBottom': '3 px', 'marginTop':'15 px'}}>
			<div className="row">
				<div className="col-md-4" style={{'border':'1px dashed'}}>
					<div><h4>111</h4></div>
					<span className="time"> An Hour Ago </span>
						<p> Ate Lunch </p>
						<div className="commentCount">
						2
						</div>
					<div className="avatar">
						<img
						src= "http://localhost:3000/images/itemMain.png"/>
					</div>
				</div>
				<div className="col-md-4" style={{'border':'0px dashed'}}>
					<div><h4>2222</h4></div>
					<span className="time"> An Hour Ago </span>
						<p> Ate Lunch </p>
						<div className="commentCount">
						2
						</div>
					<div className="avatar">
						<img style={{borderLeft:'2px'}}
						src= "http://localhost:3000/images/itemMain.png"/>
					</div>
				</div>
				<div className="col-md-4"  style={{'border':'0px dashed'}}>
						<div><h4>3333</h4></div>
					<span className="time"> An Hour Ago </span>
						<p> Ate Lunch </p>
						<div className="commentCount">
						2
						</div>
					<div className="avatar">
						<img className="img-responsive" height="25 px" width="30 px" src= "http://localhost:3000/images/itemMain.png"/>
					</div>
				</div>
			</div>
		</div> */
		
		<div className="container" style={{'borderBottom':'3', marginBottom:'3px', 'border':'0px dashed'}}>
			<div className="row">
				<ToolsItems mystores={this.state.mystores} />
			</div>
			<div className="row">Page 1 -</div>
		</div>
		<div className="container-fluid">
		</div>
		<div>
			<input type="submit" value="AFRICAIns" 
				style={{marginLeft:5, marginRight:5, marginBottom:3}} onClick={()=>this.filterStores(1)}/>
			<input type="submit" value="ESPAGNOLS" 
				style={{marginLeft:5, marginRight:5, marginBottom:3}} onClick={()=>this.filterStores(3)}/>
		</div>
	</div>
	);	
  }
}
export default Content;
/*
<CategoryItems category={this.state.category}/>
<CategoryItems clickHander={this.LoadItemsRentals} />	
<CategoryItems clickHander={this.LoadItemsRentals} />
*/
/*
envoies ton ezsprit saint 
*/