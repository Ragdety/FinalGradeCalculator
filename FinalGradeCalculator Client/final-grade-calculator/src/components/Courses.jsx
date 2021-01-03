import React, { useState, useEffect } from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
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
                  <button className="btn btn-primary justify-content-center" key={course.id}>Edit</button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    );
}

export default Courses;