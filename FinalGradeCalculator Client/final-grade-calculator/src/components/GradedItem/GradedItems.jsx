import React, { useState, useEffect } from 'react';
import { useHistory, useParams } from 'react-router-dom';
import { 
  TableRow, 
  TableHead, 
  TableContainer, 
  TableCell, 
  TableBody, 
  Table,
  Button,
  IconButton
} from '@material-ui/core';
import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import GradedItemsAPI from '../../apis/GradedItemsAPI';

const GradedItems = () => {
    const { id } = useParams();
    const [gradedItems, setGradedItems] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await GradedItemsAPI.get(`/${id}`);
                console.log(response.data);
                setGradedItems(response.data);
            } catch (error) {
                console.error(error);
            }
        }
        
        fetchData();
    }, [])

    const handleEdit = (e, id) => {

    }

    const handleDelete = (e, id) => {

    }
    return (
        <TableContainer className="container">
        <Table className="table table-hover">
          <TableHead className="bg-primary">
            <TableRow className="text-white bg-primary">
              <TableCell 
                className="text-white">Graded Items</TableCell>
              <TableCell 
                className="text-white">Grade</TableCell>
              <TableCell 
                className="text-white"
                align="center">
                  Edit Graded Item
              </TableCell>
              <TableCell 
                className="text-white"
                align="center">
                Delete Graded Item
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody className="table-dark">
            {gradedItems.map((gradedItem) => (
              <TableRow key={gradedItems.id}>
                <TableCell
                  className="text-white">
                  {gradedItem.name}
                </TableCell>
                <TableCell
                  className="text-white">{gradedItem.grade}</TableCell>
                <TableCell align="center">
                  <IconButton 
                    aria-label="edit"
                    className="text-warning"
                    onClick={(e) => handleEdit(e, gradedItem.id)}>
                    <EditIcon />
                  </IconButton>
                </TableCell>
                <TableCell align="center">
                  <IconButton 
                    aria-label="delete"
                    className="text-danger"
                    onClick={(e) => handleDelete(e, gradedItem.id)}>
                    <DeleteIcon />
                  </IconButton>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    );
}

export default GradedItems;