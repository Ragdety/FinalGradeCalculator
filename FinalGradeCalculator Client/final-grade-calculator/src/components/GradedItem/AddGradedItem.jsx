import { Button } from '@material-ui/core';
import React, { useState } from 'react';
import { useParams } from 'react-router-dom';
import GradedItemsAPI from '../../apis/GradedItemsAPI';

const AddGradedItem = () => {
    const { id } = useParams();
    const [name, setName] = useState("");
    const [grade, setGrade] = useState();

    const handleSubmit = async () => {
        try {
            await GradedItemsAPI.post(`/${id}`, {
                Name: name,
                Grade: grade,
            });
        } 
        catch (error) {
            console.error(error);
        }
    }

    const setLimits = (e, val) => {
        if(val > 100)
            e.target.value = 100;
        else if(val < 0)
            e.target.value = 0;
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
                            placeholder="Item Name"
                            value={name}
                            onChange={(e) => setName(e.target.value.trimStart())}/>
                    </div>
                    <div className="col">
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
                    <div className="col">
                        <Button 
                            type="submit"
                            className="col-md-12"
                            color="primary" 
                            variant="contained"
                            >
                            Add Graded Item
                        </Button>
                    </div>
                </div>
            </form>
        </div>
    );
}

export default AddGradedItem;
