
import {Switch, Route} from 'react-router-dom';
import ProtecRoute from "./ProtectedRoute"
//Other Requird Imports : Atu, OnBoarding, 

return(
	<Switch>
		<Route path="/auth" component={Auth} />
		<Route path="/onboarding" component={OnBB} />
		<ProtectedRoute path="/customer-error/"} component={ExistingCustomerError} />
		<ProtectedRoute path="/discrete-loan/"} component={DiscreteomerError} />
		<Route component={NotFound} />
	</Switch>
)