import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Form, Button, Navbar } from 'react-bootstrap';
import userApi from '../../api/userApi';
import FormField from '../shared/FormField';

const LoginForm = () => {
    const [username, setUsername] = useState({ value: '', isValid: true });
    const [password, setPassword] = useState({ value: '', isValid: true });
    const [loginError, setLoginError] = useState(false);
  
    const handleSubmit = async (e) => {
      e.preventDefault();

      const body = {
        username: username.value,
        password: password.value,
      }
      
      await userApi.login(body).catch(error => {
        setLoginError(true);
      });
  
      setUsername({ value: '', isValid: true });
      setPassword({ value: '', isValid: true });
    };

    useEffect(() => {
      if (loginError) {
          const timer = setTimeout(() => {
              setLoginError(false);
          }, 1200); // Сброс ошибки через 3 секунды
          return () => clearTimeout(timer);
          }
      }, [loginError]);

      return (
        <Container className="d-flex justify-content-center">
          <Row className="col-md-11 col-lg-9 col-xl-8 col-xxl-7 p-3 mb-6 shadow p-3 bg-body rounded mt-4">
            <Col xs={12}>
              <div className="mb-6 fs-2 h3"> Авторизация </div>
              <Form id="LoginForm" className="needs-validation" onSubmit={handleSubmit}>
                <FormField
                  controlId="username"
                  label="Никнейм:"
                  value={username.value}
                  onChange={(e) => setUsername({ value: e.target.value, isValid: e.target.value.match(e.target.pattern) })}
                  type="text"
                  placeholder="yournickname"
                  isValid={username.isValid}
                  feedbackText="Пожалуйста, введите корректный логин."/>
                <FormField
                  controlId="password"
                  label="Пароль:"
                  value={password.value}
                  onChange={async (e) => setPassword({ value: e.target.value, isValid: e.target.value.match(e.target.pattern) })}
                  type="password"
                  isValid={true}/>
                <Button variant="primary" type="submit" id="loginBtn" className="col-12 mt-3 mb-3" style={{ backgroundColor: loginError ? 'red' : '' }}>
                  {loginError ? 'Неправильный логин или пароль' : 'Войти'}
                </Button>
              </Form>
            </Col>
          </Row>
        </Container>
      );
  };

  
export default LoginForm;