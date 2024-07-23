import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Form, Button, Container } from 'react-bootstrap';
import Select from 'react-select';
import characterApi from '../../api/characterApi';
import dictionaryApi from '../../api/dictionaryApi';

const CharacterForm = () => {
    const { id } = useParams();
    const navigate = useNavigate;
    const [character, setCharacter] = useState({
        name: '',
        characterClassId: '',
        level: 0,
        exp: 0,
        proficiencyBonus: 0,
        raceId: '',
        originId: '',
        outlookText: '',
        strength: 0,
        dexterity: 0,
        constitution: 0,
        intelligence: 0,
        wisdom: 0,
        charisma: 0,
        age: '',
        height: '',
        weight: '',
        eyes: '',
        skin: '',
        hair: '',
        notes: [],
        skills: [],
        savingThrows: []
    });
    const [classes, setClasses] = useState([]);
    const [races, setRaces] = useState([]);
    const [origins, setOrigins] = useState([]);
    const [skills, setSkills] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            const classData = await dictionaryApi.getAllClasses();
            const raceData = await dictionaryApi.getAllRaces();
            const originData = await dictionaryApi.getAllOrigins();
            const skillData = await dictionaryApi.getAllSkills();

            setClasses(classData);
            setRaces(raceData);
            setOrigins(originData);
            setSkills(skillData);

            if (id) {
                const charData = await characterApi.getCharacterById(id);
                setCharacter(charData);
            }
        };

        fetchData();
        console.log(classes,races,origins,skills)
    }, [id]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setCharacter({ ...character, [name]: value });
    };

    const handleSelectChange = (selectedOption, actionMeta) => {
        const { name } = actionMeta;
        setCharacter({ ...character, [name]: selectedOption.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (id) {
        await characterApi.updateCharacter(id, character);
        } else {
        await characterApi.createCharacter(character);
        }
        navigate('/');
    };

    return (
        <Container>
        <Form onSubmit={handleSubmit}>
            <Form.Group controlId="characterName">
            <Form.Label>Name</Form.Label>
            <Form.Control
                type="text"
                name="name"
                value={character.name}
                onChange={handleChange}
            />
            </Form.Group>

            <Form.Group controlId="characterClass">
            <Form.Label>Class</Form.Label>
            {/* <Select
                name="characterClassId"
                value={id ? classes.find(c => c.id === character.characterClassId) : null}
                onChange={handleSelectChange}
                options={classes.map(c => ({ value: c.id, label: c.name }))}
            /> */}
            </Form.Group>

            <Form.Group controlId="characterRace">
            <Form.Label>Race</Form.Label>
            {/* <Select
                name="raceId"
                value={races.find(r => r.id === character.raceId)}
                onChange={handleSelectChange}
                options={races.map(r => ({ value: r.id, label: r.name }))}
            /> */}
            </Form.Group>

            <Form.Group controlId="characterOrigin">
            <Form.Label>Origin</Form.Label>
            {/* <Select
                name="originId"
                value={origins.find(o => o.id === character.originId)}
                onChange={handleSelectChange}
                options={origins.map(o => ({ value: o.id, label: o.name }))}
            /> */}
            </Form.Group>

            <Form.Group controlId="characterLevel">
            <Form.Label>Level</Form.Label>
            <Form.Control
                type="number"
                name="level"
                value={character.level}
                onChange={handleChange}
            />
            </Form.Group>

            <Form.Group controlId="characterExp">
            <Form.Label>Experience</Form.Label>
            <Form.Control
                type="number"
                name="exp"
                value={character.exp}
                onChange={handleChange}
            />
            </Form.Group>

            <Form.Group controlId="characterProficiencyBonus">
            <Form.Label>Proficiency Bonus</Form.Label>
            <Form.Control
                type="number"
                name="proficiencyBonus"
                value={character.proficiencyBonus}
                onChange={handleChange}
            />
            </Form.Group>

            <Form.Group controlId="characterStrength">
            <Form.Label>Strength</Form.Label>
            <Form.Control
                type="number"
                name="strength"
                value={character.strength}
                onChange={handleChange}
            />
            </Form.Group>

            <Form.Group controlId="characterDexterity">
            <Form.Label>Dexterity</Form.Label>
            <Form.Control
                type="number"
                name="dexterity"
                value={character.dexterity}
                onChange={handleChange}
            />
            </Form.Group>

            <Form.Group controlId="characterConstitution">
            <Form.Label>Constitution</Form.Label>
            <Form.Control
                type="number"
                name="constitution"
                value={character.constitution}
                onChange={handleChange}
            />
            </Form.Group>

            <Form.Group controlId="characterIntelligence">
            <Form.Label>Intelligence</Form.Label>
            <Form.Control
                type="number"
                name="intelligence"
                value={character.intelligence}
                onChange={handleChange}
            />
            </Form.Group>

            <Form.Group controlId="characterWisdom">
            <Form.Label>Wisdom</Form.Label>
            <Form.Control
                type="number"
                name="wisdom"
                value={character.wisdom}
                onChange={handleChange}
            />
            </Form.Group>

            <Form.Group controlId="characterCharisma">
            <Form.Label>Charisma</Form.Label>
            <Form.Control
                type="number"
                name="charisma"
                value={character.charisma}
                onChange={handleChange}
            />
            </Form.Group>

            <Button variant="primary" type="submit">
            {id ? 'Update Character' : 'Create Character'}
            </Button>
        </Form>
        </Container>
    );
};

export default CharacterForm;
