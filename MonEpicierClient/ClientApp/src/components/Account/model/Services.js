
import Cookies from 'js-cookie';
export const getSession  =() =>{
	const jwt = Cookies.get('__session')
	let session 
	try{
		if(jwt){
			const base64Url=jwt.split('.')[1]
			const base64 = base64Url.replace('_', '/')
			//what is window.atob>
			//http://developer.mozilla.org/en-Us/docs/Web/ApI/WindoworWorkerGlobalScope/atobsession=JSON.parse(window.atob(base64))
		}
	}
	catch(error){
		console.log(error)
	}
	return session
}
export const logOut =() =>{
	Cookies.remove('__session')
}