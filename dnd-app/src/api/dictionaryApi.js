import axios from 'axios';
import api from './api';

const apiBaseUrl = '/Dictionary';

async function getAllRaces(){ 
    const response = await api.get(`${apiBaseUrl}/GetAllRaces`);
};
//return example:
// [
//     {
//       "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//       "name": "string",
//       "description": "string",
//       "speed": 0,
//       "racialBonuses": [
//         {
//           "attribute": "Strength",
//           "bonusValue": 0
//         }
//       ],
//       "racicalSkills": [
//         {
//           "skillName": "string",
//           "description": "string"
//         }
//       ]
//     }
//   ]

async function getRaceById(id){ 
    const response = await api.get(`${apiBaseUrl}/GetRace/${id}`);
};

async function createRace(race){ 
    const response = await api.post(`${apiBaseUrl}/CreateRace`, race);
};

async function updateRace(id, race){ 
    const response = await api.put(`${apiBaseUrl}/UpdateRace/${id}`, race);
};

async function deleteRace(id){ 
    const response = await api.delete(`${apiBaseUrl}/DeleteRace/${id}`);
};

async function getAllSkills(){ 
    const response = await api.get(`${apiBaseUrl}/GetAllSkills`);
};
//return example:
// [
//     {
//       "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//       "name": "string",
//       "associatedAttribute": "Strength"
//     }
//   ]

async function getAllOrigins(){ 
    const response = await api.get(`${apiBaseUrl}/GetAllOrigins`);
};
//return example:
// [
//     {
//       "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//       "name": "string",
//       "description": "string",
//       "equipment": "string",
//       "equipmentProficiency": "string",
//       "languages": "string",
//       "originSkillProficiencies": [
//         {
//           "skillId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//           "value": 0
//         }
//       ],
//       "originUniqueSkills": [
//         {
//           "skillName": "string",
//           "description": "string"
//         }
//       ]
//     }
//   ]

async function getOriginById(id){ 
    const response = await api.get(`${apiBaseUrl}/GetOrigin/${id}`);
};
  
  async function createOrigin(origin){ 
    const response = await api.post(`${apiBaseUrl}/CreateOrigin`, origin);
};
  
  async function updateOrigin(id, origin){ 
    const response = await api.put(`${apiBaseUrl}/UpdateOrigin/${id}`, origin);
};
  
  async function deleteOrigin(id){ 
    const response = await api.delete(`${apiBaseUrl}/DeleteOrigin/${id}`);
};

async function getAllClasses(){ 
    const response = await api.get(`${apiBaseUrl}/GetAllClasses`);
};
//return example:
// [
//     {
//       "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//       "name": "string",
//       "description": "string",
//       "armorProficiency": "string",
//       "weaponProficiency": "string",
//       "toolsProficiency": "string",
//       "languages": "string",
//       "hitDice": 0,
//       "rescues": [
//         "Strength"
//       ],
//       "levelBonuses": [
//         {
//           "level": 0,
//           "proficiencyBonusValue": 0,
//           "specialAbilities": "string"
//         }
//       ],
//       "classSkillProficiencies": [
//         {
//           "skillId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//         }
//       ]
//     }
//   ]

async function getClassById(id){ 
    const response = await api.get(`${apiBaseUrl}/GetClass/${id}`);
};
// return example:
// {
//     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     "name": "string",
//     "description": "string",
//     "armorProficiency": "string",
//     "weaponProficiency": "string",
//     "toolsProficiency": "string",
//     "languages": "string",
//     "hitDice": 0,
//     "rescues": [
//       "Strength"
//     ],
//     "levelBonuses": [
//       {
//         "level": 0,
//         "proficiencyBonusValue": 0,
//         "specialAbilities": "string"
//       }
//     ],
//     "classSkillProficiencies": [
//       {
//         "skillId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//       }
//     ]
//   }
  
  async function createClass(body){ 
    const response = await api.post(`${apiBaseUrl}/CreateClass`, body);
};
  
  async function updateClass(id, body){ 
    const response = await api.put(`${apiBaseUrl}/UpdateClass/${id}`, body);
};
  
  async function deleteClass(id){ 
    const response = await api.delete(`${apiBaseUrl}/DeleteClass/${id}`);
};
  

const dictionaryApi = {
    getAllRaces: getAllRaces,
    getAllOrigins: getAllOrigins,
    getAllClasses: getAllClasses,
    getAllSkills: getAllSkills, 
    getClassById: getClassById
};

export default dictionaryApi;
