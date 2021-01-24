import { Button } from '@material-ui/core';
import React, { useState } from 'react';
import CoursesAPI from '../apis/CoursesAPI';

const AddCourse = () => {
    const [name, setName] = useState("");
    const [instructor, setInstructor] = useState("");

    const handleSubmit = async () => {
        try {
            await CoursesAPI.post('/', {
                Name: name.trimEnd(),
                Instructor: instructor.trimEnd(),
            });
        } 
        catch (error) {
            console.error(error);
        }
    }

    return (
        <div className="mb-4 container">
            <form 
                autoComplete="off"
                onSubmit={handleSubmit}>
                <div className="row">
                    <div className="col">
                        <input
                            required
                            className="form-control"
                            type="text" 
                            placeholder="Course Name"
                            value={name}
                            onChange={(e) => setName(e.target.value.trimStart())}/>
                    </div>
                    <div className="col">
                        <input 
                            required
                            className="form-control"
                            type="text"
                            placeholder="Instructor"
                            value={instructor}
                            onChange={(e) => setInstructor(e.target.value.trimStart())}/>
                    </div>
                    <div className="col">
                        <Button 
                            type="submit"
                            className="col-md-12"
                            color="primary" 
                            variant="contained"
                            //onClick={handleSubmit}
                            >
                            Add Course
                        </Button>
                    </div>
                </div>
            </form>
        </div>
    );
}

export default AddCourse;
