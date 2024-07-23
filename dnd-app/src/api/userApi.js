import axios from 'axios';
import api from './api';

const apiBaseUrl = '/User';

async function registerUser(user){
    const response = await api.post(`${apiBaseUrl}/Register`, user);
    localStorage.setItem('token', response.data.token);
    window.location.href = '/';
};

async function loginUser(loginCredentials){
    console.log(loginCredentials);
    const response = await api.post(`${apiBaseUrl}/Login`, loginCredentials);
    localStorage.setItem('token', response.data.accessToken);
    window.location.href = '/'; 
};

async function logout() {
    //await api.post(`${apiBaseUrl}/logout`);
    localStorage.removeItem('token');
    window.location.href = '/';
}

async function getListOfUsers(){  
    const response = await api.get(`${apiBaseUrl}/GetListOfUsers`);
    return response.data;
};

async function getProfile(){  
    const response = await api.get(`${apiBaseUrl}/Profile`);
    return response.data;
};

async function changeUserRole (role){  
    const response = await api.post(`${apiBaseUrl}/ChangeRole`, role);
    return response.data;
};

const userApi = {
    registerUser: registerUser,
    login: loginUser,
    logout: logout,
    getListOfUsers: getListOfUsers, 
    getProfile: getProfile
};

export default userApi;
