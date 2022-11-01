import React, { FC, useEffect, useState } from 'react'
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { getAllLogs } from '../Services/airportService';
import { LogModel } from '../Models/LogModel';



export const Log: FC = (props) => {

    const [logs, setLogs] = useState<LogModel[]>([]);

    useEffect(() => {
        updateState();
    }, [])

    useEffect(() => {
        const interval = setInterval(() => {
            updateState();
        }, 1000);
        return () => clearInterval(interval);
    }, []);

    const updateState = async () => {
        const logRes = await getAllLogs();
        setLogs(logRes)


    }


    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell>Leg Number</TableCell>
                        <TableCell align="right">Time</TableCell>
                        <TableCell align="right">Flight Code</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {logs.map((row, index) => (
                        <TableRow
                            key={index}
                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                        >
                            <TableCell component="th" scope="row"> {row.leg.legNumber}</TableCell>
                            <TableCell align="right">{row.time.toTimeString()}</TableCell>
                            <TableCell align="right">{row.flight.flightCode}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );

}


