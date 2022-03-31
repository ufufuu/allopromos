//import config from 'config';
//import {authHeader} from '../_helpers';

export const authenticationService ={
	login: 'alogi',
	logout,
	currentUser:null,
	createUser:'as'
};
function Login(username, password){
	const requestOptions ={
		method: 'POST',
		headers: {'content-type':'application/json'},
		body: JSON.stringify({username, password}),
	};
	/*
	return fetch('${config.apiUrl}/Account/UserLogin', requestOptions)
		.then(handleResponse)
		.then(user =>{
			//if(user){
				user.authdata = window.btoa(username+ ':'+password);		//Local Storage Window
				localStorage.setItem('currentUser', JSON.stringify(user));
				currentUserSubject.next(user);
			//}
			return user;
		});
		*/
}
function logout(){
	localStorage.removeItem('currentUser');
	//currentUserSubject.next(null)->in login .next(user)
}
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
 export default authenticationService;
 //alibabacloud.com/blog/how-to-implement-authentication-in-reactjs-using-jwt_595820