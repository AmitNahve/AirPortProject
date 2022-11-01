import axios from "axios";
import { SERVER_URL } from "../config";
import { FlightModel } from "../Models/FlightModel";
import { Leg } from "../Models/Leg";
import { Log } from "../Models/Log";
const path = "airport";

export const getAllLegs = async():Promise<Leg[]>=>{
    const res = (await axios.get(`${SERVER_URL}/${path}/getstatus`)).data; 
    return res;
} 

export const getAllFlights = async():Promise<FlightModel[]>=>{
    const res = (await axios.get(`${SERVER_URL}/${path}/getflights`)).data;
    return res;
} 
export const getAllLogs = async():Promise<Log[]>=>{
    const res = (await axios.get(`${SERVER_URL}/${path}/getlog`)).data;
    return res;
} 
