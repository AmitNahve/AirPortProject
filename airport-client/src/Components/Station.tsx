import React, { FC } from 'react'
import { Leg } from '../Models/Leg';

interface Props {
    children?: any;
    leg?: Leg;
}

export const Station: FC<Props> = (props: Props) => {
    return (
        <div className='leg'>
            <div className='title'>Leg num: {props?.leg?.legId}</div>
            <div className='flight-place'>
                {props?.children}
            </div>
        </div>
    )
}

