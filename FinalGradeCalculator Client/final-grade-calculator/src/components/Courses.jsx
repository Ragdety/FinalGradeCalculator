import React, { useState, useEffect } from 'react';
import Paper from '@material-ui/core/Paper';
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
import { DeleteIcon } from '@material-ui/icons';
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
    }, []);

    return (
      <TableContainer component={Paper} className="container">
        <Table>
          <TableHead className="">
            <TableRow className="">
              <TableCell>Courses</TableCell>
              <TableCell>Instructor</TableCell>
              <TableCell>Final Grade</TableCell>
              <TableCell>Grade Items</TableCell>
              <TableCell>Edit Course</TableCell>
              <TableCell>Delete Course</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {courses.map((course) => (
              <TableRow key={course.id}>
                <TableCell>
                  {course.name}
                </TableCell>
                <TableCell>{course.instructor}</TableCell>
                <TableCell>
                  {course.finalGrade === null ? 'To be determined' : course.finalGrade}
                </TableCell>
                <TableCell className="justify-content-center">
                  <Button 
                    className="col-md-2"
                    color="primary" 
                    variant="contained">
                    Edit
                  </Button>
                </TableCell>
                {/* <TableCell>
                <IconButton aria-label="delete">
                  <DeleteIcon />
                </IconButton>
                </TableCell> */}
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    );
}

export default Courses;