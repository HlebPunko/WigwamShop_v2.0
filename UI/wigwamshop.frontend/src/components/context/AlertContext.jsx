import React, { createContext, useState } from "react";
import Alert from "../Alert/Alert";

export const AlertContext = createContext({});

const AlertState = ({ children }) => {
    const [isOpened, setIsOpened] = useState(false);
    const [currContent, setCurrContent] = useState("");
    const [currType, setCurrType] = useState("success");

    const showAlert = (content, type) => {
        console.log("asdfkp?");
        setIsOpened(true);
        setCurrContent(content);
        setCurrType(type);
    };

    return (
        <AlertContext.Provider value={{ showAlert }}>
            <Alert
                type={currType}
                children={currContent}
                isOpen={isOpened}
                handleClose={() => setIsOpened(false)}
            />
            {children}
        </AlertContext.Provider>
    );
};

export default AlertState;
