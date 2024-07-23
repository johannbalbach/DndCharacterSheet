import { configureStore, createSlice } from '@reduxjs/toolkit';

const initialState = {
    user: {
        name: '',
        id: '',
        role: ''
    },
};

const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        updateUser(state, action) {
            state.user.name = action.payload.userName;
            state.user.id = action.payload.id;
            state.user.role = action.payload.userRole;
        },
    },
});

const store = configureStore({
    reducer: {
        user: userSlice.reducer,
    },
});

export const { updateUser } = userSlice.actions;
export default store;
