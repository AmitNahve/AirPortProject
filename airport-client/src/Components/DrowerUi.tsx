import * as React from 'react';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import Button from '@mui/material/Button';

import { Log } from './Log';
import { Fragment, useState } from 'react';




export default function TemporaryDrawer() {
  const [isDrowerOpen, setIsDrowerOpen] = useState(false);

  
      

      
  

  return (
    <div>
        <Fragment>
          <Button onClick={()=>setIsDrowerOpen(true)}>Log Table</Button>
          <Drawer  anchor= 'right' open={isDrowerOpen} onClose={()=> setIsDrowerOpen(false)} >
           <Log></Log>
          </Drawer>
        </Fragment>
    </div>
  );
}
