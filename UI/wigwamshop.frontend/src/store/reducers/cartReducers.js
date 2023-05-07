import {
    DELETE_CART,
    GET_CART,
    POST_CART,
} from "../types/types";
//TODO вот тут вот вопрооос, state это прям общее сосотояние?

export const defaultState = {
    cart: {
        data: []
    }
}

export const CartReducer = (state = defaultState, action) => {
    //console.log(action.payload)
    switch(action.type) {
        case GET_CART:
            return {
                ...state,
                data: action.payload

            }
        case POST_CART:
            return {
                ...state,
                cart: {
                    data: action.payload
                }
            }
        case DELETE_CART:
            return {
                ...state,
                cart:
                    state.cart.data.filter((item) => Number(item.parentId) !== Number(action.payload.id))
            }
        default:
            return defaultState;
    }
}
