import React from 'react';
import ReactDOM from 'react-dom';
import {NavLink} from 'react-router-dom';
export default class ItemsCategories extends React.Component
{
	constructor(props){
		super(props);
		this.state={
			inputVal: 'Clue Mediator',
			//tooljkls:[{},{}],
			itemsCategories:[{},{}],
			//itemsData:this.props.itemsData,
			itemsData:[{}]
		}
		//this.LoadItemsRentals =this.LoadItemsRentals.bind(this);
		//Function in the props Constructor
		this.onInputChange = this.onInputChange.bind(this);
		this.handleSubmit = this.handleSubmit.bind(this);
		//this.props.handleInputValue = this.props.handleInputValue.bind(this);
	}
	componentDidMount(){
		//this.state.itemsCategories
		this.GetStoresCategories();
	}
	componentWillMount(){
		
		this.GetStoresCategories();
	}
	handleSubmit(){
		this.props.handleInput(this.state.inputVal);	
	}
	onInputChange(e){
		this.setState({inputVal: e.target.value});
	}
	/*
	LoadItemsRentals=() =>
	{	
		var category= this.toolsCategory;	
		//alert(this.state.inputVal);
		//alert(e.target.value);
		this.setState({category:'e.target.value'});
		//this.setState({inputVal: e.target.value});
	}*/
	GetStoresCategories =(item)=>{
		
		//alert(item);
		//fetch('http://localhost:52424/Rentals/Rentalsservice.svc/rentals/'+item)
		//http://localhost:55168/api/stores/categories
		
		fetch('http://localhost:55168/api/stores/categories/')
		
		.then(response =>response.json())
		.then((data)=>{
			//this.setState({this.props.tools:data});
			//console.log(this.state.tools);
			this.setState({itemsCategories:data});
						
			//this.setState({itemsCategories:val});
			
			//alert(JSON.stringify(data));
			//console.log(data);
			
			//alert('STATE IS'+this.state.itemsCategories);
			
			//this.props.tools=data;
			//this.setState({this.props.tools:data})		
		})
		//alert(item);
		//alert("Donnneee");
		//alert(this.props.tools);
	}
	MenuCategoriesHandler=(e) =>{
		//alert(e.target.id);
		//GetRentalsByCategory(e.target.id);
	}
	
	
	GetItemsCategories(){
		fetch('http://localhost:55168/api/stores/categories/')
		.then(response =>response.json())
		.then((data)=>{
			this.setState({itemsCategories:data});
		})
	}
	
	GetAllRentalsBy(Id){
		//alert('Helloe is is ' +Id);
		fetch('http://localhost:55168/api/stores/categories/')
		
		//fetch('http://localhost:55168/api/stores/'+Id)
		.then(response =>response.json())
		.then((data)=>{
			this.setState({itemsCategories:data});
		})
	}

	render()
	{
		//var itemsCategories2 = this.state.itemsCategories
	return(
	//(
	<section className="content">
		<div className="container-fluid">
			<div className="row">
				<ul role="menu" className="scrollable-menu" style={{height:'auto', maxHeight:'180px',
				overflowX:'hidden'}}>{this.state.itemsCategories.map((itemCategory)=>(
					<li style={{listStyle:'none', display:'inline', marginLeft:'5px', marginRight:'5px'}}>
							<NavLink to={`/stores/${itemCategory.CategoryName}`} value={itemCategory.CategoryId} 
											style={{color:'#000'}}
								id={itemCategory.CategoryId} onClick={
								() =>this.GetItemsCategories()}>{itemCategory.CategoryName}
							</NavLink>
					</li>
				))}
				</ul>				
				<div style={{marginLeft:60}}>
					<input value="Africain" 
						type="submit" style={{marginLeft:6, marginRight:5}}
							onClick={()=>this.props.GetItemsByCategory(1)} />
					<input value="Mexicains" 
						type="button" style={{marginLeft:6, marginRight:5}}
							onClick={()=>this.props.GetItemsByCategory(3)} />
				</div>
			</div>
			<div class="row">
          <div class="col-12 col-sm-6 col-md-3">
            <div class="info-box">
              <span class="info-box-icon bg-info elevation-1"><i class="fas fa-cog"></i></span>

              <div class="info-box-content">
                <span class="info-box-text">CPU Traffic</span>
                <span class="info-box-number">
                  10
                  <small>%</small>
                </span>
              </div>
            </div>
          </div>
          <div class="col-12 col-sm-6 col-md-3">
            <div class="info-box mb-3">
              <span class="info-box-icon bg-danger elevation-1"><i class="fas fa-thumbs-up"></i></span>

              <div class="info-box-content">
                <span class="info-box-text">Likes</span>
                <span class="info-box-number">41,410</span>
              </div>
            </div>
          </div>
          <div class="clearfix hidden-md-up"></div>
          <div class="col-12 col-sm-6 col-md-3">
            <div class="info-box mb-3">
              <span class="info-box-icon bg-success elevation-1"><i class="fas fa-shopping-cart"></i></span>
              <div class="info-box-content">
                <span class="info-box-text">Sales</span>
                <span class="info-box-number">760</span>
              </div>
            </div>
          </div>
          <div class="col-12 col-sm-6 col-md-3">
            <div class="info-box mb-3">
              <span class="info-box-icon bg-warning elevation-1"><i class="fas fa-users"></i></span>
              <div class="info-box-content">
                <span class="info-box-text">New Members</span>
                <span class="info-box-number">2,000</span>
              </div>
            </div>
          </div>
        </div>
		</div>
	</section>
	)
  }
}
//export default;
//5/ 638 4706
/*
2038:
onClick={this.LoadItemsRentals.bind(this)}>{itemCategory.category}
Arret de paiement - RBC :; formulaire ---- en succursales --- arret de paiement ---
xoom: 877-815-1531---415-395-4225
<NavLink to={`/rentals/${itemCategory.category}`} value={itemCategory.category} 
							onClick={this.props.clickHandler}>{itemCategory.category} --
							MenuCategoriesHandler
						</NavLink>
id={itemCategory.categoryId} onClick={()=>this.GetRentalsByCategory(itemCategory.categoryId)}>{itemCategory.category}
*/