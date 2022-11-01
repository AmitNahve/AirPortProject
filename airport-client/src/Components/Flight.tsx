import React, { FC } from 'react'
import { IoIosAirplane } from 'react-icons/io';
import { Tooltip } from "@mui/material";
import { FlightModel, Target } from '../Models/FlightModel';
type Props = {
  flight: FlightModel;
}

export const Flight: FC<Props> = (props: Props) => {
  return (<div>
    <Tooltip title={<div>
      flight: {props?.flight?.flightCode}<br />
      target: {Target[props.flight.target]} <br />
      passengersCount: {props?.flight?.passengersCount}
    </div>}
    >
      <div>
        <IoIosAirplane width="3em" height="3em" style={{ transform: "rotate(0deg)", width: "100%" }} />
      </div>
    </Tooltip>
  </div>
    // <img className='airplane-img' width={"100%"} height={"100%"} src={airlpaneImage} alt="" />
  )
}

