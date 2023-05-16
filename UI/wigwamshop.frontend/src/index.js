import React from "react";
import { BrowserRouter as Router } from "react-router-dom";
import ReactDOM from "react-dom";

import "./index.scss";
import "macro-css";

import App from "./App";
import AlertState from "./components/context/AlertContext";

ReactDOM.render(
    <Router>
        <AlertState>
            <App />
        </AlertState>
    </Router>,
    document.getElementById("root")
);
