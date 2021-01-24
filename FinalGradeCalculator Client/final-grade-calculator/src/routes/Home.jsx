import React from 'react';
import AddCourse from '../components/Course/AddCourse';
import Courses from '../components/Course/Courses';
import Header from '../components/Course/Header';

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
