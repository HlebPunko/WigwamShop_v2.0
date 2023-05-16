import styles from "./Button.module.scss";
import cn from "classnames";

const Button = ({ children, size, active = true }) => {
    return (
        <div className={cn(styles.container, { [styles.disabled]: !active })}>
            <p className={cn(styles.buttonText, styles[size])}>{children}</p>
        </div>
    );
};

export default Button;
