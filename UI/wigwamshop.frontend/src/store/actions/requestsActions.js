import axios from "axios";
import RequestUrls from "../../const/requestUrls";
import {
    DELETE_CART,
    DELETE_FAVORITE,
    GET_CART,
    GET_FAVORITES,
    GET_ITEMS, GET_ORDER,
    POST_CART,
    POST_FAVORITE, POST_ORDER
} from "../types/types";

//тут происходят все запросы, преобразования и т.д.

export const getFavorites = () => (dispatch) => {
    axios.get(RequestUrls.getFavorites)
        .then(res => {
            dispatch({
                type: GET_FAVORITES,
                payload: res.data
            });
        })
        .catch(err => console.log(err.response));
}

export const addToFavorites = (obj) => (dispatch) => {
    axios.post(RequestUrls.postFavorites, obj)
        .then(res => {
            dispatch({
                type: POST_FAVORITE,
                payload: res.data
            })
        })
        .catch(err => console.log(err.response));
}

export const deleteFromFavorite = (obj) => (dispatch) => {
    axios.delete(RequestUrls.deleteFavorites(obj.id))
        .then(res => {
            dispatch({
                type: DELETE_FAVORITE,
                payload: res.data //а тут позвращать что?
            })
        })
        .catch(err => console.log(err.response))
}

export const getItems = () => (dispatch) => {
    axios.get(RequestUrls.getItems)
        .then(res => {
            dispatch({
                type: GET_ITEMS,
                payload: res.data
            });
        })
        .catch(err => console.log(err.response))
}

export const getCart = () => (dispatch) => {
    axios.get(RequestUrls.getCart)
        .then(res => {
            dispatch({
                type: GET_CART,
                payload: res.data
            })
        })
        .catch(err => console.log(err.response))
}

export const addToCart = (obj) => (dispatch) => {
    axios.post(RequestUrls.postCart, obj)
        .then(res => {
            dispatch({
                type: POST_CART,
                payload: res.data
            })
        })
        .catch(err => console.log(err.response))
}

export const removeFromCart = (obj) => (dispatch) => {
    axios.delete(RequestUrls.deleteCart(obj.id))
        .then(res => {
            dispatch({
                type: DELETE_CART,
                payload: res.data //TODO вроде бы так и норм, хз
            })
        })
        .catch(err => console.log(err.response))
}

export const getOrders = () => (dispatch) => {
    axios.get(RequestUrls.getOrders)
        .then(res => {
            dispatch({
                type: GET_ORDER,
                payload: res.data
            })
        })
        .catch(err => console.log(err.response))
}

export const addOrder = (obj) => (dispatch) => {
    axios.post(RequestUrls.postOrder, obj)
        .then(res => {
            dispatch({
                type: POST_ORDER,
                payload: res.data
            })
        })
        .catch(err => console.log(err.response))
}
