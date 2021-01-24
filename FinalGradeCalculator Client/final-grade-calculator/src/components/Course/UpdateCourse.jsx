import React, { useState, useEffect } from 'react';
import { useHistory, useParams } from 'react-router-dom';
import { Button } from '@material-ui/core/';
import CoursesAPI from '../../apis/CoursesAPI';

const UpdateCourse = () => {
    const { id } = useParams(); //":id" <- from route
    let history = useHistory();
    const [name, setName] = useState("");
    const [instructor, setInstructor] = useState("");

    useEffect(() => {
        const fetchData = async() => {
            const response = await CoursesAPI.get(`/${id}`);
            setName(response.data.name);
            setInstructor(response.data.instructor);
        }

        fetchData();
    }, []);

    const handleUpdate = async (e) => {
        e.preventDefault();
        try {
            await CoursesAPI.put(`/${id}`, {
                Name: name.trimEnd(),
                Instructor: instructor.trimEnd(),
            });

            returnBack();
        } catch (error) {
            console.error(error);
        }
    }

    const returnBack = () => {
        history.push('/');
    }

    return (
        <div className="display-3 mb-4">
            <h1 className="text-center mt-4 mb-3">Edit Course</h1>

            <div className="row mt-3">
                <div className="col-md-4 mx-auto">
                    <div className="form">
                        <form onSubmit={(e) => {handleUpdate(e)}}>
                            <div className="form-group">
                                <input 
                                    value={name}
                                    required
                                    type="text" 
                                    className="form-control mb-4" 
                                    placeholder="Name"
                                    onChange={(e) => {setName(e.target.value.trimStart())}}/>
                            </div>
                            <div className="form-group">
                                <input 
                                    value={instructor}
                                    required
                                    type="text" 
                                    className="form-control" 
                                    placeholder="Instructor"
                                    onChange={(e) => {setInstructor(e.target.value.trimStart())}}/>
                            </div>
                            <div className="text-center d-flex justify-content-between mt-3">
                                <Button 
                                    type="submit"
                                    className="row"
                                    color="primary" 
                                    variant="contained"
                                    >
                                    Update Course
                                </Button>
                                <Button 
                                    className="row"
                                    color="secondary" 
                                    variant="contained"
                                    onClick={returnBack}
                                    >
                                    Go Back
                                </Button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default UpdateCourse;
