import './App.css';
import AddCourse from './components/AddCourse';
import Courses from './components/Courses.jsx';
import Header from './components/Header';

function App() {
  return (
    <div className="App">
      <Header/>
      <AddCourse />
      <br />
      <Courses />
    </div>
  );
}

export default App;