import { Button } from '@material-ui/core';
import React, { useState } from 'react';
import CoursesAPI from '../apis/CoursesAPI';


const AddCourse = () => {
    const [name, setName] = useState("");
    const [instructor, setInstructor] = useState("");

    const handleSubmit = (e) => {
        e.preventDefault();
        
    }

    return (
        <div className="mb-4 container">
            <form autoComplete="off">
                <div className="row">
                    <div className="col">
                        <input
                            className="form-control"
                            type="text" 
                            required={true} 
                            placeholder="Course Name"
                            value={name}
                            onChange={(e) => setName(e.target.value)}/>
                    </div>
                    <div className="col">
                        <input
                            className="form-control"
                            type="text" 
                            required={true} 
                            placeholder="Instructor"
                            value={instructor}
                            onChange={(e) => setInstructor(e.target.value)}/>
                    </div>
                    <div className="col">
                        <Button 
                            className="col-md-12"
                            color="primary" 
                            variant="contained"
                            onClick={handleSubmit}>
                            Add Course
                        </Button>
                    </div>
                </div>
            </form>
        </div>
    );
}

export default AddCourse;
