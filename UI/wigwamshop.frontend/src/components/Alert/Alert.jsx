import { FC, useEffect } from "react";
import ReactPortal from "../ReactPortal/ReactPortal.jsx";
import styles from "./Alert.module.scss";
import cn from "classnames";

const Alert = ({ children, type = "error", isOpen, handleClose }) => {
    useEffect(() => {
        let id;
        if (isOpen) {
            id = setTimeout(() => {
                handleClose();
            }, 3000);
        }

        return () => {
            clearTimeout(id);
        };
    }, [isOpen, handleClose]);

    return (
        <ReactPortal>
            <div
                className={cn(
                    styles.container,
                    {
                        [styles.error]: type === "error",
                    },
                    {
                        [styles.success]: type === "success",
                    },
                    {
                        [styles.active]: isOpen,
                    }
                )}>
                <p className="text small">{children}</p>
            </div>
        </ReactPortal>
    );
};

export default Alert;
