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
          const res = await CoursesAPI.get("/");
          setCourses(res.data);
        } 
        catch (error) {
          console.error(error);
        }
      }
      fetchData();
    }, []);


    function createCourse(name, instructor, finalGrade) {
        return { name, instructor, finalGrade };
    }
    
    const rows = [
        createCourse("C++", 'Eric Charnesky', 100),
        createCourse("Java", 'Iliana Martinez', 99.74),
        createCourse("Linear Algebra", 'Mark Stevenson', 95)
    ];

    return (
      <TableContainer component={Paper} className="container">
        <Table aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Courses</TableCell>
              <TableCell>Instructor</TableCell>
              <TableCell>Final Grade</TableCell>
              <TableCell>Grade Items</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {rows.map((row) => (
              <TableRow key={row.name}>
                <TableCell component="th" scope="row">
                  {row.name}
                </TableCell>
                <TableCell>{row.instructor}</TableCell>
                <TableCell>{row.finalGrade}</TableCell>
                <TableCell>{row.carbs}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    );
}

export default Courses;