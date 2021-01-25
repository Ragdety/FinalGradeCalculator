import './App.css';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import Home from './routes/Home';
import EditCourse from './routes/EditCourse';
import GradedItemsPage from './routes/GradedItemsPage';
import EditGradedItems from './routes/EditGradedItems';
import Page404 from './routes/Page404';

function App() {
  return (
    <div className="App">
      <Router>
        <Switch>
          <Route
            exact
            path='/courses/:courseId/gradedItems/edit/:gradedItemId'
            component={EditGradedItems}
          />

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

          <Route component={Page404} />
        </Switch>
      </Router>
    </div>
  );
}

export default App;