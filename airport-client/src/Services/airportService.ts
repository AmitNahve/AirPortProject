import axios from "axios";
import { SERVER_URL } from "../config";
import { FlightModel } from "../Models/Flight";
import { Leg } from "../Models/Leg";
const path = "airport";

export const getAllLegs = async():Promise<Leg[]>=>{
    const res = (await axios.get(`${SERVER_URL}/${path}/getstatus`)).data; 
    return res;
} 

export const getAllFlights = async():Promise<FlightModel[]>=>{
    const res = (await axios.get(`${SERVER_URL}/${path}/getflights`)).data;
    return res;
} 
