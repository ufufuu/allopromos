//import config from 'config';
//import {authHeader} from '../_helpers';

export const AuthenticationService = {

	login: 'alogi',
	logout:'vffff',
	currentUser: null,
	createUser: 'as',
	Login(username, password){
		const requestOptions = {
			method: 'GET',
			headers: { 'content-type': 'application/json' },
			body: JSON.stringify({ username, password }),
		}
		//alert(" from Auth Service ");
		window.location.href= "rrr";
		try
		{
			fetch('${config.apiUrl}/Account/UserLogin', requestOptions)
				.then(response=>response.json())
				.then(user => {
					if (user) {
						user.authdata = window.btoa(username + ':' + password);		//Local Storage Window
						localStorage.setItem('currentUser', JSON.stringify(user));
						//currentUserSubject.next(user);
						window.location.href = "/Blog";
					}
					return user;
				})
			.catch(er => {

			})
		}
		catch (error) {
			console.log(error);
		}
	},
	handleResponse() {

    },
	logout(){
		localStorage.removeItem('currentUser');
	//currentUserSubject.next(null)->in login .next(user)
	},
	handleResponse(response){
		return response.text().then( text=>{
			const data= text && JSON.parse(text);
			if(!response.ok){
				if(response.status ===401){
				//logout();
					window.location.reload(true);		//Local Storage Window	
				}
			
				const error = (data && data.message) || response.statusText;
				return Promise.reject(error);
			}
			return data;
		});
	}
}
export default AuthenticationService;

 //alibabacloud.com/blog/how-to-implement-authentication-in-reactjs-using-jwt_595820