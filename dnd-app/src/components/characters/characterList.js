import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { getCharacters, deleteCharacter } from '../api/characterApi';
import { Button, Table } from 'react-bootstrap';

const CharacterList = () => {
  const [characters, setCharacters] = useState([]);

  useEffect(() => {
    getCharacters().then(response => setCharacters(response.data));
  }, []);

  const handleDelete = (id) => {
    deleteCharacter(id).then(() => {
      setCharacters(characters.filter(character => character.id !== id));
    });
  };

  return (
    <div>
      <h2>Character List</h2>
      <Link to="/create-character">
        <Button>Create New Character</Button>
      </Link>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Name</th>
            <th>Class</th>
            <th>Race</th>
            <th>Origin</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {characters.map((character) => (
            <tr key={character.id}>
              <td>{character.name}</td>
              <td>{character.characterClass.name}</td>
              <td>{character.race.name}</td>
              <td>{character.origin.name}</td>
              <td>
                <Link to={`/edit-character/${character.id}`}>
                  <Button>Edit</Button>
                </Link>
                <Button onClick={() => handleDelete(character.id)}>Delete</Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};

export default CharacterList;
