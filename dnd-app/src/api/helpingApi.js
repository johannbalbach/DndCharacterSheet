import axios from 'axios';
import api from './api';

const apiBaseUrl = '/ExternalSystem';

async function GenerateImage(prompt){
    const response = await api.post(`${apiBaseUrl}/GenerateImage`, prompt);
    return response.data
};

async function RollDice(numberOfDice, maxValue, minValue = 1){
    const response = await api.get(`${apiBaseUrl}/RollDice`, numberOfDice, minValue, maxValue);
    return response.data
};


const helpingApi = {
    GenerateImage: GenerateImage,
    RollDice: RollDice
};

export default helpingApi;
