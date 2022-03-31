//import config from 'config';
//import {authHeader} from '../_helpers';
export const userService ={
	login: 'alogi',
	logout,
	createUser:'as'
};
function Login(username, password){
	const requestOptions ={
		method: 'POST',
		headers: {'content-type':'application/json'},
		body: JSON.stringify({username, password}),
	};
	return fetch('${config.apiUrl}/users/authenticate', requestOptions)
		.then(handleResponse)
		.then(user =>{
			if(user){
				user.authdata = window.btoa(username+ ':'+password);		//Local Storage Window
				localStorage.setItem('user', JSON.stringify(user));
			}
		return user;
		});
}
function logout(){
	localStorage.removeItem('user');
}
/*
function getAll(){
	const requestOption={
		method:'get',
		headers:authHeader()
	};
	return fetch(`${config.apiUrl}/users`, requestOption).then(handleResponse);
}
*/
function handleResponse(response){
	return response.text().then( text=>{
		const data= text && JSON.parse(text);
		if(!response.ok){
			if(response.status ===401){
			logout();
				window.location.reload(true);		//Local Storage Window	
			}
			
			const error = (data && data.message) || response.statusText;
			return Promise.reject(error);
		}
		return data;
	});
 }
/*
export const userService ={
	getAll
};

function getAll(){
	const requestOptions={method:'GET', headers: authHeader()};
	return fetch(`${config.apiUrl}/users`, requestOptions).then(handleResponse);
}
//}
/*
BY rEF , VS BY VALUE
*/