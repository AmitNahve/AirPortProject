import React, { FC, Fragment, useEffect, useMemo, useState } from "react";
import { Station } from "./Station";
import { Flight } from "./Flight";

import '../App.css';
import { Leg } from "../Models/Leg";
import { FlightModel } from "../Models/FlightModel";
import { getAllFlights, getAllLegs } from "../Services/airportService";
import { Log } from "./Log";
import DrowerUi from "./DrowerUi";



export const SimulatorUI: FC = (props) => {

    const [legs, setLegs] = useState<Leg[]>([]);
    const [flights, setFlights] = useState<FlightModel[]>([]);

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
        const flightsRes = await getAllFlights();
        const legsRes = await getAllLegs();
        setFlights(flightsRes);
        setLegs(legsRes);
    }

    const stations = useMemo(() => {
        return legs.map((l) => {
            return <Station leg={l}>
                {l.flightCode && <Flight flight={flights.filter(e => e.flightCode === l.flightCode)[0]} />}
            </Station>
        })
    }, [legs])
    return <div className="main-page">
        <div className="first-row"> <div className="row">{stations[0]}{stations[1]}{stations[2]}{stations[3]}</div>{stations[8]}</div>
        <div className="secondary-row">{stations[7]}{stations[4]}</div>
        <div className="third-row">{stations[5]}{stations[6]}</div>
        <div className="bottom">
          <DrowerUi></DrowerUi>
        </div>
    </div>
}