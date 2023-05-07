import {GET_ITEMS} from "../types/types";

export const defaultState = {
    items: {
        data: []
    }
}

export const ItemsReducer = (state = defaultState, action) => {
    //console.log(action.payload)
    switch (action.type) {
        case GET_ITEMS:
            return {
                ...state,
                data: action.payload
            }
        default:
            return defaultState;
    }
}