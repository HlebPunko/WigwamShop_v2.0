import {DELETE_FAVORITE, GET_FAVORITES, POST_FAVORITE} from "../types/types";

export const defaultState = {
    favorites: {
        data: []
    }
}

export const FavoritesReducer = (state = defaultState, action) => {
    //console.log(action.payload)
    switch (action.type) {//working
        case GET_FAVORITES:
            return {
                ...state,
                data: action.payload
            };
        case POST_FAVORITE:
            return {
                ...state,
                favorites: {
                    data: [...state.favorites.data, action.payload]//тут странная штука, в логах пишет сначал, что есть массив пустой
                }
            }
        case DELETE_FAVORITE:
            return {
                ...state,
                favorites:
                    state.favorites.data.filter((item) => Number(item.id) !== Number(action.payload.id))
            }
        default:
            return defaultState;
    }
};