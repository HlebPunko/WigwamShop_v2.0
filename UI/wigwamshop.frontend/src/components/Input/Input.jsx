import { useState } from "react";
import styles from "./Input.module.scss";
import cn from "classnames";

const Input = ({
    type = "text",
    onInput = () => {},
    placeholder = "",
    classes = "",
    correct = "",
}) => {
    const [val, setVal] = useState("");

    const inputHandler = (e) => {
        onInput && onInput(e);
        setVal(e.target.value);
    };

    return (
        <div
            className={cn(
                styles.container,
                {
                    [styles.err]: correct === "err",
                },
                {
                    [styles.ok]: correct === "ok",
                }
            )}>
            <input
                value={val}
                onInput={inputHandler}
                placeholder={placeholder}
                type={type}
                className={cn(styles.input, classes)}
            />
        </div>
    );
};

export default Input;
