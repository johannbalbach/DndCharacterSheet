import axios from 'axios';
import api from './api';

const apiBaseUrl = '/Character';

async function getCharacters(){
    const response = await api.get(`${apiBaseUrl}`);
    return response.data
};

async function getCharacterById(id){
    const response = await api.get(`${apiBaseUrl}/GetCharacter/${id}`);
    return response.data
};

async function createCharacter(character){
    const response = await api.post(`${apiBaseUrl}/CreateCharacter`, character);
    return response.data
};

async function updateCharacter(id, character){
    const response = await api.put(`${apiBaseUrl}/UpdateCharacter/${id}`, character);
    return response.data
};

async function deleteCharacter(id){
    const response = await api.delete(`${apiBaseUrl}/DeleteCharacter/${id}`);
    return response.data
};

const characterApi = {
    getCharacters: getCharacters,
    getCharacterById: getCharacterById,
    createCharacter: createCharacter,
    updateCharacter: updateCharacter, 
    deleteCharacter: deleteCharacter
};

export default characterApi;