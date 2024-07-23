import axios from 'axios';
import api from './api';

const apiBaseUrl = '/Character';

async function getCharacters(){
    const response = await api.get(`${apiBaseUrl}`);
    return response.data
};
//response example:
// {
//     "characters": [
//       {
//         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//         "name": "string",
//         "characterClassId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//         "level": 0,
//         "exp": 0,
//         "proficiencyBonus": 0,
//         "raceId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//         "originId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//         "outlookText": "string",
//         "strength": 0,
//         "dexterity": 0,
//         "constitution": 0,
//         "intelligence": 0,
//         "wisdom": 0,
//         "charisma": 0,
//         "age": "string",
//         "height": "string",
//         "weight": "string",
//         "eyes": "string",
//         "skin": "string",
//         "hair": "string",
//         "notes": [
//           "string"
//         ],
//         "skills": [
//           {
//             "name": "string",
//             "associatedAttribute": "Strength",
//             "value": 0,
//             "isProficient": true
//           }
//         ],
//         "savingThrows": [
//           {
//             "associatedAttribute": "Strength",
//             "value": 0,
//             "isProficient": true
//           }
//         ]
//       }
//     ],
//     "page": 0,
//     "count": 0,
//     "totalCount": 0
//   }
// always have list of all skills for this caharacter

async function getCharacterById(id){
    const response = await api.get(`${apiBaseUrl}/GetCharacter/${id}`);
    return response.data
};
//response example
//{
//     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     "name": "string",
//     "characterClassId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     "level": 0,
//     "exp": 0,
//     "proficiencyBonus": 0,
//     "raceId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     "originId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     "outlookText": "string",
//     "strength": 0,
//     "dexterity": 0,
//     "constitution": 0,
//     "intelligence": 0,
//     "wisdom": 0,
//     "charisma": 0,
//     "age": "string",
//     "height": "string",
//     "weight": "string",
//     "eyes": "string",
//     "skin": "string",
//     "hair": "string",
//     "notes": [
//       "string"
//     ],
//     "skills": [
//       {
//         "name": "string",
//         "associatedAttribute": "Strength",
//         "value": 0,
//         "isProficient": true
//       }
//     ],
//     "savingThrows": [
//       {
//         "associatedAttribute": "Strength",
//         "value": 0,
//         "isProficient": true
//       }
//     ]
//   }
// always have list of all skills for this caharacter

async function createCharacter(character){
    const response = await api.post(`${apiBaseUrl}/CreateCharacter`, character);
    return response.data
};
//body example:
// {
//     "name": "string",
//     "characterClassId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     "level": 0,
//     "exp": 0,
//     "proficiencyBonus": 0,
//     "raceId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     "originId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     "outlookText": "string",
//     "strength": 0,
//     "dexterity": 0,
//     "constitution": 0,
//     "intelligence": 0,
//     "wisdom": 0,
//     "charisma": 0,
//     "age": "string",
//     "height": "string",
//     "weight": "string",
//     "eyes": "string",
//     "skin": "string",
//     "hair": "string",
//     "notes": [
//       "string"
//     ]
//   }
//return same as getCharacterById

async function updateCharacter(id, character){
    const response = await api.put(`${apiBaseUrl}/UpdateCharacter/${id}`, character);
    return response.data
};
//body example same as createCharacter, return same as getCharacterById

async function deleteCharacter(id){
    const response = await api.delete(`${apiBaseUrl}/DeleteCharacter/${id}`);
    return response.data
};
//return example:
// {
//     "status": "string",
//     "message": "string"
//   }

const characterApi = {
    getCharacters: getCharacters,
    getCharacterById: getCharacterById,
    createCharacter: createCharacter,
    updateCharacter: updateCharacter, 
    deleteCharacter: deleteCharacter
};

export default characterApi;