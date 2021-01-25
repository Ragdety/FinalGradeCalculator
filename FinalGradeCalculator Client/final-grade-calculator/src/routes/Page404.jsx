import React from 'react';
import { Link } from 'react-router-dom';
import { Button } from '@material-ui/core';

const Page404 = () => {
    return (
        <div className="text-center">
            <h1 className="text-center display-3 mt-4">404</h1>
            <h2 className="text-center display-3 mb-4">
                Sorry, that page doesn't exist
            </h2>
            <Link to="/" className="text-decoration-none">
                <Button 
                    className="row mt-2"
                    color="secondary" 
                    variant="contained"
                >
                    Return To Home Page
                </Button>
            </Link>
        </div>
    );
}

export default Page404;
