import React, { useState, useEffect } from 'react';
import { Form, Button } from 'react-bootstrap';
import { createCharacter, updateCharacter, getCharacterById } from '../api/characterApi';
import { getAllClasses, getAllRaces, getAllOrigins } from '../api/dictionaryApi';

const CharacterForm = ({ match, history }) => {
  const [character, setCharacter] = useState({
    name: '',
    characterClassId: '',
    level: 1,
    exp: 0,
    proficiencyBonus: 2,
    raceId: '',
    originId: '',
    // ... other fields
  });

  const [classes, setClasses] = useState([]);
  const [races, setRaces] = useState([]);
  const [origins, setOrigins] = useState([]);

  useEffect(() => {
    if (match.params.id) {
      getCharacterById(match.params.id).then(response => setCharacter(response.data));
    }
    getAllClasses().then(response => setClasses(response.data));
    getAllRaces().then(response => setRaces(response.data));
    getAllOrigins().then(response => setOrigins(response.data));
  }, [match.params.id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setCharacter((prevState) => ({ ...prevState, [name]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (match.params.id) {
      updateCharacter(match.params.id, character).then(() => history.push('/'));
    } else {
      createCharacter(character).then(() => history.push('/'));
    }
  };

  return (
    <Form onSubmit={handleSubmit}>
      <Form.Group>
        <Form.Label>Name</Form.Label>
        <Form.Control name="name" value={character.name} onChange={handleChange} />
      </Form.Group>
      <Form.Group>
        <Form.Label>Class</Form.Label>
        <Form.Control as="select" name="characterClassId" value={character.characterClassId} onChange={handleChange}>
          {classes.map((cls) => (
            <option key={cls.id} value={cls.id}>{cls.name}</option>
          ))}
        </Form.Control>
      </Form.Group>
      <Form.Group>
        <Form.Label>Race</Form.Label>
        <Form.Control as="select" name="raceId" value={character.raceId} onChange={handleChange}>
          {races.map((race) => (
            <option key={race.id} value={race.id}>{race.name}</option>
          ))}
        </Form.Control>
      </Form.Group>
      <Form.Group>
        <Form.Label>Origin</Form.Label>
        <Form.Control as="select" name="originId" value={character.originId} onChange={handleChange}>
          {origins.map((origin) => (
            <option key={origin.id} value={origin.id}>{origin.name}</option>
          ))}
        </Form.Control>
      </Form.Group>
      {/* Add other form fields as needed */}
      <Button type="submit">Save</Button>
    </Form>
  );
};

export default CharacterForm;
