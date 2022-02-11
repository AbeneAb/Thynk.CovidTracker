import React from 'react';
import {
	BrowserRouter as Router,
	Redirect,
	Route,
	Switch,
} from 'react-router-dom';
import NotFoundPage from '../404';
import DefaultLayout from '../../layout/defaultLayout';
import AdminDashboard from '../admin';
import Booking from '../booking'
import Specimen from '../specimen'
import Lab from '../lab';
import './App.css';

function App() {
	return (
		<Router>
			<Switch>
				<Route path="/" exact>
					<Redirect to="/admin" />
				</Route>
				<Route path={['/admin', '/booking','/specimen','/lab']}>
					<DefaultLayout>
						<Route path="/admin" component={AdminDashboard} />
						<Route path="/booking" component={Booking} />
						<Route path='/specimen' component={Specimen}/>
                        <Route path='/lab' component={Lab}/>
					</DefaultLayout>
				</Route>
				<Route path="*">
					<DefaultLayout>
						<NotFoundPage />
					</DefaultLayout>
				</Route>
			</Switch>
		</Router>
	);
}

export default App;
