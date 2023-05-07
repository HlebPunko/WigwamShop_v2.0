import {combineReducers} from "redux";
import {CartReducer} from "./cartReducers";
import {FavoritesReducer} from "./favoriteReducer";
import {ItemsReducer} from "./itemsReducer";

export const rootReducer = combineReducers({
    items: ItemsReducer,
    cart: CartReducer,
    favorites: FavoritesReducer
})

