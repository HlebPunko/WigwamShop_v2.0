import { FC, useState, useLayoutEffect } from "react";
import { createPortal } from "react-dom";

const ReactPortal = ({ children, wrapperId = "react-portal-wrapper" }) => {
    const [wrapperElement, setWrapperElement] = useState();

    useLayoutEffect(() => {
        let element = document.getElementById(wrapperId);
        let systemCreated = false;
        if (!element) {
            systemCreated = true;
            const wrapperEl = document.createElement("div");
            wrapperEl.setAttribute("id", wrapperId);
            wrapperEl.style.display = "flex";
            wrapperEl.style.justifyContent = "center";
            wrapperEl.style.zIndex = 200;
            document.body.appendChild(wrapperEl);
            element = wrapperEl;
        }
        setWrapperElement(element);

        return () => {
            // delete the programatically created element
            if (systemCreated && element && element.parentNode) {
                element.parentNode.removeChild(element);
            }
        };
    }, [wrapperId]);

    // wrapperElement state will be null on the very first render.
    if (wrapperElement === undefined || wrapperElement === null) return null;

    return createPortal(children, wrapperElement);
};

export default ReactPortal;
