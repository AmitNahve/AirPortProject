
export enum Target{
    Landing = 0,
    Departure=1
}

export type FlightModel={
    id: number;
    flightCode: string;
    passengersCount: number;
    target: Target;
    //leg: Leg;
 
    
}
