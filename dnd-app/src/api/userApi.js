import axios from 'axios';
import api from './api';

const apiBaseUrl = '/User';

async function registerUser(user){
    const response = await api.post(`${apiBaseUrl}/Register`, user);
    localStorage.setItem('token', response.data.token);
    window.location.href = '/';
};
//body example:
// {
//   "password": "string",
//   "userName": "string",
//   "userRole": "Player"
// }
//response example:
// {
//     accessToken	string
// }

async function loginUser(loginCredentials){
    console.log(loginCredentials);
    const response = await api.post(`${apiBaseUrl}/Login`, loginCredentials);
    localStorage.setItem('token', response.data.accessToken);
    window.location.href = '/'; 
};

// {
//     "userName": "string",
//     "password": "string"
//   }
//   {
//     "accessToken": "string"
//   }

async function logout() {
    //await api.post(`${apiBaseUrl}/logout`);
    localStorage.removeItem('token');
    window.location.href = '/';
}

async function getListOfUsers(){  
    const response = await api.get(`${apiBaseUrl}/GetListOfUsers`);
    return response.data;
};
//response example
// {
//     "users": [
//       {
//         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//         "userName": "string",
//         "userRole": "Player",
//         "characters": [
//           "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//         ]
//       }
//     ]
//   }

async function getProfile(){  
    const response = await api.get(`${apiBaseUrl}/Profile`);
    return response.data;
};
//response example
// {
//     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     "userName": "string",
//     "userRole": "Player",
//     "characters": [
//       "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//     ]
//   }

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
