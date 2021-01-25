import React from 'react';
import GradedItems from '../components/GradedItem/GradedItems';
import Header from '../components/GradedItem/Header';
import AddGradedItem from '../components/GradedItem/AddGradedItem';

const GradedItemsPage = () => {
    return (
        <div className="container">
            <Header/>
            <AddGradedItem/>
            <GradedItems/>
        </div>
    );
}

export default GradedItemsPage;
