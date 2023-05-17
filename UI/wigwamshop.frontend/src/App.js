import React, { useState, useEffect, useContext } from "react";
import { Route, Switch } from "react-router-dom";
import axios from "axios";
import Header from "./components/Header/Header";
import Drawer from "./components/Drawer/Drawer";
import AppContext from "./context";
import RequestUrls from "./const/requestUrls";

import Home from "./pages/Home/Home";
import Favorites from "./pages/Favorites/Favorites";
import Orders from "./pages/Orders/Orders";
import MyRoutes from "./const/myRoutes";
import Login from "./pages/Login/Login";
import AlertState, { AlertContext } from "./components/context/AlertContext";

function App() {
    const [items, setItems] = useState([]);
    const [cartItems, setCartItems] = useState([]);
    const [favorites, setFavorites] = useState([]);
    const [searchValue, setSearchValue] = useState("");
    const [cartOpened, setCartOpened] = useState(false);
    const [isLoading, setIsLoading] = useState(true);

    const { showAlert } = useContext(AlertContext);

    useEffect(() => {
        async function fetchData() {
            try {
                let [
                    cartResponse,
                    favoritesResponse,
                    itemsResponse,
                ] = await Promise.all([
                    axios.get(RequestUrls.getCart),
                    axios.get(RequestUrls.getFavorites),
                    axios.get(RequestUrls.getItems),
                    //TODO dispatch(getItems())
                    //component didmount
                ]);

                const itemsData = itemsResponse.data.map((item, ind) => {
                    const indexes = favoritesResponse.data.map(
                        (el) => el.parentId
                    );
                    item = { ...item, isFavourite: indexes.includes(item.id) };
                    return item;
                });

                setIsLoading(false);
                setCartItems(cartResponse.data);
                setFavorites(favoritesResponse.data);
                setItems(itemsData);
            } catch (error) {
                alert("Ошибка при запросе данных ;(");
                console.error(error);
            }
        } //TODO Redux посмотреть, диспатч ({type, payload})
        //useSelector для доставания данных

        fetchData();
    }, []); //TODO срабатывает два раза (наверное, возможно рендерится два раза комонент, нужно искать)

    const onAddToCart = async (obj) => {
        try {
            const findItem = cartItems.find(
                (item) => Number(item.parentId) === Number(obj.id)
            );
            if (findItem) {
                setCartItems((prev) =>
                    prev.filter(
                        (item) => Number(item.parentId) !== Number(obj.id)
                    )
                );
                await axios.delete(RequestUrls.deleteCart(findItem.id));
            } else {
                setCartItems((prev) => [...prev, obj]);
                const { data } = await axios.post(RequestUrls.postCart, obj);
                setCartItems((prev) =>
                    prev.map((item) => {
                        if (item.parentId === data.parentId) {
                            return {
                                ...item,
                                id: data.id,
                            };
                        }
                        return item;
                    })
                );
            }
        } catch (error) {
            alert("Ошибка при добавлении в корзину");
            console.error(error);
        }
    };

    const handleAddToFavorite = async (obj) => {
        try {
            const findItem = favorites.find(
                (favObj) => Number(favObj.id) === Number(obj.id)
            );
            if (findItem) {
                console.log("delete");
                console.log(findItem);
                setFavorites((prev) =>
                    prev.filter((item) => Number(item.id) !== Number(obj.id))
                );
                await axios.delete(RequestUrls.deleteFavorites(findItem.id));
            } else {
                console.log("add");
                console.log(findItem);
                const { data } = await axios.post(
                    RequestUrls.postFavorites,
                    obj
                );
                setFavorites((prev) => [...prev, data]);
            }
        } catch (error) {
            alert("Не удалось добавить в фавориты");
            console.error(error);
        }
    };

    const onRemoveItem = (id) => {
        try {
            axios.delete(RequestUrls.deleteCart(id));
            setCartItems((prev) =>
                prev.filter((item) => Number(item.id) !== Number(id))
            );
        } catch (error) {
            showAlert("Ошибка при удалении из корзины", "error");
            // alert("Ошибка при удалении из корзины");
            console.error(error);
        }
    };

    const onChangeSearchInput = (event) => {
        setSearchValue(event.target.value);
    };

    const isItemAdded = (id) => {
        return cartItems.some((obj) => Number(obj.parentId) === Number(id));
    };

    return (
        <AppContext.Provider
            value={{
                items,
                cartItems,
                favorites,
                isItemAdded,
                handleAddToFavorite,
                onAddToCart,
                setCartOpened,
                setCartItems,
            }}
        >
            <div className="wrapper clear">
                <Drawer
                    items={cartItems}
                    onClose={() => setCartOpened(false)}
                    onRemove={onRemoveItem}
                    opened={cartOpened}
                />

                <Header onClickCart={() => setCartOpened(true)} />
                <Switch>
                    <Route path={MyRoutes.home} exact>
                        <Home
                            items={items}
                            cartItems={cartItems}
                            searchValue={searchValue}
                            setSearchValue={setSearchValue}
                            onChangeSearchInput={onChangeSearchInput}
                            onAddToFavorite={handleAddToFavorite}
                            onAddToCart={onAddToCart}
                            isLoading={isLoading}
                        />
                    </Route>
                    <Route path={MyRoutes.favorites} exact>
                        <Favorites />
                    </Route>
                    <Route path={MyRoutes.orders} exact>
                        <Orders />
                    </Route>
                    <Route path={MyRoutes.login} exact>
                        <Login />
                    </Route>
                </Switch>
            </div>
        </AppContext.Provider>
    );
}

export default App;
