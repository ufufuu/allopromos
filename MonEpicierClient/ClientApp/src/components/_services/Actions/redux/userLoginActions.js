
const loginUser= userObj =>({
	type:'LOGIN_USER',
	payload: userObj
})

export const userPostFecth = user=>{
	return dispatch=>{
		return fetch("http://llch:3000/api/v1/users", {
			method: "POST",
			headers:{
				'content-type': 'application/json',
				Accept:'application/json',
			},
			body: JSON.stringify({user})
		})
		.then(resp => resp.json())
		.then(data=>{
			if(data.message){
				
			}else{
				localStorage.setItems("token", data.token)
				dispatch(loginUser(data.user))
			}
		})
	}
}
/* REDUCER */
const initialState ={
	currentUser:{}
}
export default function reducer(state =initialState, action){
	switch(action.type){
		case'LOGIN_USER':
			return {...state,currentUser: action.payload}
		default:
			return state;
	}
}
export const userLoginFetch = user=>{
	//return dispacth=>{
		{
		//return fetch("http://llch:3000/api/v1/login", {
		return fetch("http://localhost:52424/User/UserService.svc/DoLogin/django@free.fr/1234", {
			method: "POST",
			headers:{
				'content-type': 'application/json',
				Accept:'application/json',
			},
			body: JSON.stringify({user})
		})
		.then(resp => resp.json())
		.then(data=>{
			if(data.message){
				// handle Invalide Login Creditials
				// if there are errors 
			}else{
				localStorage.setItem('token', data.token);
				//dispatch(loginUser(data.user))
			}
		})
	}
}
/*
{
	user:{
		username: "kevin',
		avatar":"http//dfdf/png',
		bio: "A new Gentelemn", 
	},
	token: 'aasas.bbbbbb.cccccc'
}
*/	