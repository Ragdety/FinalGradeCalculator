import React, { useState, useEffect } from 'react';
import { useHistory, useParams } from 'react-router-dom';
import { Button } from '@material-ui/core/';
import GradedItemsAPI from '../../apis/GradedItemsAPI';
import { setLimits } from '../../helpers/helper';

const UpdateGradedItems = () => {
    const { courseId, gradedItemId } = useParams(); 
    let history = useHistory();
    const [name, setName] = useState("");
    const [grade, setGrade] = useState("");

    useEffect(() => {
        const fetchData = async() => {
            try {
                const response = await GradedItemsAPI.get(`/${courseId}/${gradedItemId}`);
                setName(response.data.name);
                setGrade(response.data.grade);
            } catch (error) {
                console.error(error);
                alert(error);
                goToGradedItems();
            }
        }
        fetchData();
        //For now:
        // eslint-disable-next-line
    }, []);

    const handleUpdate = async (e) => {
        e.preventDefault();
        try {
            await GradedItemsAPI.put(`/${courseId}/${gradedItemId}`, {
                Name: name.trimEnd(),
                Grade: grade
            });
        } catch (error) {
            console.error(error);
            alert(error + ': Cannot update item');
        }
        goToGradedItems()
    }

    const goToGradedItems = () => {
        history.push(`/courses/${courseId}/gradedItems`);
    }

    return (
        <div className="display-3 mb-4">
            <h1 className="text-center mt-4 mb-3">Edit Graded Item</h1>

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
                                required
                                className="form-control"
                                type="text"
                                pattern="^\d*(\.\d{0,2})?$"
                                placeholder="Grade (Ex: 85.25)"
                                value={grade}
                                onChange={(e) => setGrade(e.target.value)}
                                onInput={(e) => setLimits(e, e.target.value)}/>
                            </div>
                            <div className="text-center d-flex justify-content-between mt-3">
                                <Button 
                                    type="submit"
                                    className="row"
                                    color="primary" 
                                    variant="contained"
                                    >
                                    Update Item
                                </Button>
                                <Button 
                                    className="row"
                                    color="secondary" 
                                    variant="contained"
                                    onClick={goToGradedItems}
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

export default UpdateGradedItems;
