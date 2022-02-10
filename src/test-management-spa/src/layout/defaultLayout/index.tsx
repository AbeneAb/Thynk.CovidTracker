import React from 'react';
import { NavBar } from '../../common/navbar/navBar';


 
const DefaultLayout: React.FunctionComponent = ({ children }) => (
    <div className="relative flex flex-col flex-grow min-h-screen overflow-scroll bg-gray-50" >
        <NavBar />
        <>
            {children}
        </>
       
    </div>
);

export default DefaultLayout;

