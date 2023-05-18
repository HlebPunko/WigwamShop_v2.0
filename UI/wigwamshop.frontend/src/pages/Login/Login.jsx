import { useState, useEffect, useContext } from "react";
import styles from "./Login.module.scss";
import cn from "classnames";
import schema from "../../helpers/validatePass";
import { Oval } from "react-loader-spinner";
import Input from "../../components/Input/Input";
import Button from "../../components/Button/Button";
import { AlertContext } from "../../components/context/AlertContext";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
const emailExp = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i;

const Login = () => {
    const initialLoginData = {
        login: "",
        password: "",
    };

    const initialRegData = {
        login: "",
        name: "",
        password: "",
        email: "",
        repeatPass: "",
    };

    const history = useHistory();

    const [currLoginData, setCurrLoginData] = useState(initialLoginData);
    const [currRegData, setCurrRegData] = useState(initialRegData);
    const [currState, setCurrState] = useState("reg");
    const [isEmailCorrect, setIsEmailCorrect] = useState(false);
    const [isLoginPassCorrect, setIsLoginPassCorrect] = useState(false);
    const [isRegPassCorrect, setIsRegPassCorrect] = useState(false);

    const [isDataCorrect, setIsDataCorrect] = useState(false);

    const [isLoaderActive, setIsLoaderActive] = useState(false);

    const { showAlert } = useContext(AlertContext);

    const enterHandler = async (e) => {
        if ((e && !(e.key === "Enter")) || !isDataCorrect) {
            return;
        }
        setIsLoaderActive(true);
        await new Promise((res) => {
            setTimeout(res, 200);
        });
        if (isDataCorrect) {
            switch (currState) {
                case "login":
                    showAlert("Вы успешно вошли в аккаунт", "success");
                    history.push("/");
                    break;
                case "reg":
                    showAlert("Вы успешно зарегистрировались", "success");
                    history.push("/");
                    break;
                default:
                    return <div></div>;
            }
        }
        setIsLoaderActive(false);
    };

    useEffect(() => {
        setIsDataCorrect(
            !(currState === "login"
                ? !(isLoginPassCorrect && currLoginData.login.length > 0)
                : !(
                      currRegData.name.length > 0 &&
                      currRegData.login.length &&
                      isEmailCorrect &&
                      isRegPassCorrect &&
                      currRegData.repeatPass === currRegData.password
                  ))
        );
    }, [
        currRegData,
        currLoginData,
        currState,
        isLoginPassCorrect,
        isEmailCorrect,
        isRegPassCorrect,
    ]);

    useEffect(() => {
        setIsEmailCorrect(emailExp.test(currRegData.email));
    }, [currRegData.email]);

    useEffect(() => {
        setIsRegPassCorrect(Boolean(schema.validate(currRegData.password)));
    }, [currRegData.password]);

    useEffect(() => {
        setIsLoginPassCorrect(Boolean(schema.validate(currLoginData.password)));
    }, [currLoginData.password]);

    return (
        <div
            onKeyDown={enterHandler}
            className={cn(
                styles.panel,
                { [styles.login]: currState === "login" },
                { [styles.reg]: currState === "reg" },
                { [styles.reset]: currState === "reset" }
            )}>
            <div
                className={cn(styles.loader, {
                    [styles.active]: isLoaderActive,
                })}>
                <Oval
                    height={80}
                    width={80}
                    color="#427fb8"
                    visible={true}
                    ariaLabel="oval-loading"
                    secondaryColor="#427fb8"
                    strokeWidth={2}
                    strokeWidthSecondary={2}
                />
            </div>
            <div className={styles.panelHeader}>
                <p className={cn("text big", styles.header)}>
                    {currState === "login"
                        ? "Войдите в аккаунт"
                        : currState === "reg"
                        ? "Зарегистрируйтесь"
                        : "Восстановите досуп"}
                </p>
            </div>
            <div className={styles.content}>
                <div className={styles.inputs}>
                    <div
                        className={cn({
                            [styles.active]: currState === "login",
                        })}>
                        <Input
                            correct=""
                            placeholder="Введите логин или email"
                            onInput={(e) => {
                                setCurrLoginData((prev) => {
                                    return {
                                        ...prev,
                                        login: e.target.value,
                                    };
                                });
                            }}
                            classes={styles.input}
                        />
                        <Input
                            correct={
                                currLoginData.password === ""
                                    ? ""
                                    : isLoginPassCorrect
                                    ? "ok"
                                    : "err"
                            }
                            placeholder="Введите пароль"
                            onInput={(e) => {
                                setCurrLoginData((prev) => {
                                    return {
                                        ...prev,
                                        password: e.target.value,
                                    };
                                });
                            }}
                            classes={styles.input}
                            type="password"
                        />
                    </div>
                    <div
                        className={cn({
                            [styles.active]: currState === "reg",
                        })}>
                        <Input
                            correct=""
                            placeholder="Введите имя"
                            onInput={(e) => {
                                setCurrRegData((prev) => {
                                    return {
                                        ...prev,
                                        name: e.target.value,
                                    };
                                });
                            }}
                            classes={styles.input}
                        />
                        <Input
                            correct=""
                            placeholder="Введите ваш номер телефона"
                            onInput={(e) => {
                                setCurrRegData((prev) => {
                                    return {
                                        ...prev,
                                        login: e.target.value,
                                    };
                                });
                            }}
                            classes={styles.input}
                        />{" "}
                        <Input
                            correct={
                                currRegData.email === ""
                                    ? ""
                                    : isEmailCorrect
                                    ? "ok"
                                    : "err"
                            }
                            placeholder="Введите свою почту"
                            onInput={(e) => {
                                setCurrRegData((prev) => {
                                    return {
                                        ...prev,
                                        email: e.target.value,
                                    };
                                });
                            }}
                            classes={styles.input}
                        />
                        <Input
                            correct={
                                currRegData.password === ""
                                    ? ""
                                    : isRegPassCorrect
                                    ? "ok"
                                    : "err"
                            }
                            placeholder="Введите пароль"
                            onInput={(e) => {
                                setCurrRegData((prev) => {
                                    return {
                                        ...prev,
                                        password: e.target.value,
                                    };
                                });
                            }}
                            classes={styles.input}
                            type="password"
                        />
                        <p className={styles.passInfo}>
                            Пароль должен содержать от 6 до 20 сиволов,
                            содержать хотя-бы 1 цифру, хотя-бы 1 заглавную
                            букву, хотя-бы 1 спецсимвол
                        </p>
                        <Input
                            correct={
                                currRegData.repeatPass === ""
                                    ? ""
                                    : currRegData.repeatPass ===
                                      currRegData.password
                                    ? "ok"
                                    : "err"
                            }
                            placeholder="Повторите пароль"
                            onInput={(e) => {
                                setCurrRegData((prev) => {
                                    return {
                                        ...prev,
                                        repeatPass: e.target.value,
                                    };
                                });
                            }}
                            classes={styles.input}
                            type="password"
                        />
                    </div>
                </div>
                <div className={styles.actions}>
                    <div
                        onClick={() => enterHandler()}
                        className={styles.button}>
                        <Button
                            active={isDataCorrect}
                            size="small">
                            {currState === "login"
                                ? "Войти в аккаунт"
                                : "Зарегистрироваться"}
                        </Button>
                    </div>
                    <div className={styles.switch}>
                        <p className={cn(styles.text, "text small")}>
                            {currState === "login"
                                ? "Ещё нет аккаунта?"
                                : "Уже есть аккаунт?"}
                        </p>
                        <p
                            onClick={() =>
                                setCurrState((prev) =>
                                    prev === "login" ? "reg" : "login"
                                )
                            }
                            className={cn(styles.link, "text small")}>
                            {currState === "login"
                                ? "Зарегистрируйтесь"
                                : "Войдите"}
                        </p>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Login;
