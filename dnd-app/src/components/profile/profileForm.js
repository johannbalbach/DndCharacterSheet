import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Form, Button, Navbar } from 'react-bootstrap';
import userApi from '../../api/userApi';
import FormField from '../shared/FormField';

const ProfileForm = () => {
    const [username, setUsername] = useState('');
    const [role, setRole] = useState('');

    const setData = ((data) => {
      setUsername(data.userName);
      setRole(data.userRole);
    })

    useEffect(() => {
      const fetchData = async () => {
        const data = await userApi.getProfile();

        setData(data);
      };
  
      fetchData();
    }, []);
  
    return (
      <Container className="d-flex justify-content-center" style={{ height: '100vh' }}>
        <Row className="col-md-12 col-lg-8 p-3 mb-6">
          <Col xs={12}>
            <div className="mb-6 fs-2 h3"> Профиль </div>
            <Form id="profileForm">
              <Form.Group as={Row} className="mb-3" controlId="username">
                <Form.Label column sm="3">Логин:</Form.Label>
                <Col sm="9">
                  <Form.Control column sm="9"
                    disabled
                    readOnly
                    type="text"
                    value={username}
                  />
                </Col>
              </Form.Group>
              <Form.Group as={Row} className="mb-3" controlId="role">
                <Form.Label column sm="3">Роль:</Form.Label>
                <Col sm="9">
                  <Form.Control column sm="9"
                    disabled
                    readOnly
                    type="text"
                    value={role}
                  />
                </Col>
              </Form.Group>
            </Form>
          </Col>
        </Row>
      </Container>
    );
  };

  
export default ProfileForm;