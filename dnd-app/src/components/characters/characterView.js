import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import characterApi from '../../api/characterApi';
import { Table, ListGroup, Container } from 'react-bootstrap';

const CharacterView = () => {
  const { id } = useParams();
  const [character, setCharacter] = useState(null);

  useEffect(() => {
    const fetchCharacter = async () => {
      const data = await characterApi.getCharacterById(id);
      setCharacter(data);
    };
    fetchCharacter();
  }, [id]);

  if (!character) return <p>Loading...</p>;

  return (
    <Container>
      <h2>{character.name}</h2>
      <Table striped bordered hover>
        <tbody>
          <tr><td>Class</td><td>{character.characterClassId}</td></tr>
          <tr><td>Level</td><td>{character.level}</td></tr>
          <tr><td>Experience</td><td>{character.exp}</td></tr>
          <tr><td>Proficiency Bonus</td><td>{character.proficiencyBonus}</td></tr>
          <tr><td>Race</td><td>{character.raceId}</td></tr>
          <tr><td>Origin</td><td>{character.originId}</td></tr>
          <tr><td>Strength</td><td>{character.strength}</td></tr>
          <tr><td>Dexterity</td><td>{character.dexterity}</td></tr>
          <tr><td>Constitution</td><td>{character.constitution}</td></tr>
          <tr><td>Intelligence</td><td>{character.intelligence}</td></tr>
          <tr><td>Wisdom</td><td>{character.wisdom}</td></tr>
          <tr><td>Charisma</td><td>{character.charisma}</td></tr>
        </tbody>
      </Table>

      <h3>Skills</h3>
      <ListGroup>
        {character.skills.map((skill, index) => (
          <ListGroup.Item key={index}>
            {skill.name} - {skill.associatedAttribute} - {skill.value} {skill.isProficient && '(Proficient)'}
          </ListGroup.Item>
        ))}
      </ListGroup>

      <h3>Saving Throws</h3>
      <ListGroup>
        {character.savingThrows.map((throwItem, index) => (
          <ListGroup.Item key={index}>
            {throwItem.associatedAttribute} - {throwItem.value} {throwItem.isProficient && '(Proficient)'}
          </ListGroup.Item>
        ))}
      </ListGroup>
    </Container>
  );
};

export default CharacterView;
