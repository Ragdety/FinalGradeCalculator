import React, { useState, useEffect } from 'react';
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
import CoursesAPI from '../apis/CoursesAPI';

const Courses = () => {
    const [courses, setCourses] = useState([]);

    useEffect(() => {
      async function fetchData() {
        try {
          const response = await CoursesAPI.get("/");
          setCourses(response.data);
        }
        catch (error) {
          console.error(error);
        }
      }
      fetchData();
    }, [courses]);

    const handleEditGradedItems = (e, id) => {
      e.stopPropagation();

      try {
        
      } 
      catch (error) {
        console.error(error);
      }
    }

    const handleEdit = (e, id) => {
      e.stopPropagation();

      try {
        
      } 
      catch (error) {
        console.error(error);
      }
    }

    const handleDelete = async (e, id) => {
      e.stopPropagation();

      try {
        await CoursesAPI.delete(`/${id}`);
      } 
      catch (error) {
        console.error(error);
      }
    }

    return (
      <TableContainer className="container">
        <Table className="table table-hover">
          <TableHead className="bg-primary">
            <TableRow className="text-white bg-primary">
              <TableCell 
                className="text-white">Courses</TableCell>
              <TableCell 
                className="text-white">Instructor</TableCell>
              <TableCell 
                className="text-white">Final Grade</TableCell>
              <TableCell 
                className="text-white"
                align="center">
                  Grade Items
              </TableCell>
              <TableCell 
                className="text-white"
                align="center">
                  Edit Course
              </TableCell>
              <TableCell 
                className="text-white"
                align="center">
                Delete Course
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody className="table-dark">
            {courses.map((course) => (
              <TableRow key={course.id}>
                <TableCell
                  className="text-white">
                  {course.name}
                </TableCell>
                <TableCell
                  className="text-white">{course.instructor}</TableCell>
                <TableCell
                  className="text-white">
                  {course.finalGrade === null ? 'To be determined' : course.finalGrade}
                </TableCell>
                <TableCell 
                  className="text-white"
                  align="center">
                  <Button
                    color="primary" 
                    variant="contained"
                    onClick={(e) => handleEditGradedItems(e, course.id)}>
                    Edit
                  </Button>
                </TableCell>
                <TableCell align="center">
                  <IconButton 
                    aria-label="edit"
                    className="text-warning"
                    onClick={(e) => handleEdit(e, course.id)}>
                    <EditIcon />
                  </IconButton>
                </TableCell>
                <TableCell align="center">
                  <IconButton 
                    aria-label="delete"
                    className="text-danger"
                    onClick={(e) => handleDelete(e, course.id)}>
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

export default Courses;