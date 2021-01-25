import './App.css';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import Home from './routes/Home';
import EditCourse from './routes/EditCourse';
import GradedItemsPage from './routes/GradedItemsPage';

function App() {
  return (
    <div className="App">
      <Router>
        <Switch>
          <Route
            exact
            path='/courses/:id/gradedItems'
            component={GradedItemsPage}
          />

          <Route
            exact
            path='/courses/:id/edit'
            component={EditCourse}
          />
          
          <Route
            exact
            path='/'
            component={Home}
          />
        </Switch>
      </Router>
    </div>
  );
}

export default App;