import { FlightModel } from "./FlightModel";
import { Leg } from "./Leg";

export type LogModel ={
    time:Date;
    leg:Leg;
    flight:FlightModel
}