import React from 'react';
import AddCourse from '../components/AddCourse';
import Courses from '../components/Courses';
import Header from '../components/Header';

const Home = () => {
    return (
        <div>
            <Header/>
            <AddCourse />
            <br />
            <Courses />
        </div>
    );
}

export default Home;
