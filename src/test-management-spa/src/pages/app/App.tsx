import React from 'react';
import {
	BrowserRouter as Router,
	Redirect,
	Route,
	Switch,
} from 'react-router-dom';
import NotFoundPage from '../404';
import DefaultLayout from '../../layout/defaultLayout';
import './App.css';

function App() {
	return (
		<Router>
			<Switch>
				<Route path="/" exact>
					<Redirect to="/" />
				</Route>
				<Route path={['/quote-search', '/quote-results','*']}>
					<DefaultLayout>
						<Route path="/quote-search" component={NotFoundPage} />
						<Route path="/quote-results" component={NotFoundPage} />
            <Route path="*" component={NotFoundPage} />
					</DefaultLayout>
				</Route>
			
			</Switch>
		</Router>
	);
}

export default App;
