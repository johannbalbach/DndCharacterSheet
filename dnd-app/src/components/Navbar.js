import React, { useState, useEffect } from 'react';
import { Navbar, Nav, Dropdown, Button, Container } from 'react-bootstrap';
import { Link, useLocation } from 'react-router-dom';
import userApi from '../api/userApi';
import { useSelector, useDispatch } from 'react-redux';
import { setUser } from '../store/actions/updateUser';

const NavbarPanel = () => {
    const dispatch = useDispatch();
    const location = useLocation();
    const user = useSelector((state) => state.user.user);
    const token = localStorage.getItem('token');
    const isAuthenticated = token != null;

    useEffect(() => {
        if (isAuthenticated) {
            userApi.getProfile().then((profile) => {
                dispatch(setUser(profile));
            });
        }
    }, [isAuthenticated, dispatch, user]);

    const handleLogout = () => {
        localStorage.removeItem('token');
        dispatch(setUser(''));
    };

    const truncateUserName = (name) => {
        const maxLength = 20;
        return name.length > maxLength ? `${name.substring(0, maxLength)}...` : name;
    };

    return (
        <Navbar bg="dark" variant="dark" expand="lg" className="navbar" style={{ backgroundColor: '#1A3F76', paddingInline: 48 }}>
            <Container>
                <Navbar.Brand as={Link} to="/">
                    <img src={'/svg/24.svg'} width="32" height="32" alt='logo' />
                    <span style={{ marginLeft: '10px' }}>Try not to <strong>DIE</strong></span>
                </Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    {isAuthenticated && (
                        <Nav className="me-auto" activeKey={location.pathname.split('/')[1]}>
                            <Nav.Link as={Link} to="/patients">Библиотека</Nav.Link>
                            <Nav.Link as={Link} to="/create-character">Создать персонажа</Nav.Link>
                            <Nav.Link as={Link} to="/reports">Мои персонажи</Nav.Link>
                        </Nav>
                    )}
                    <Nav className="ml-auto">
                        {isAuthenticated ? (
                            <Dropdown alignRight>
                                <Dropdown.Toggle as={Button} variant="link" style={{ color: 'white', textDecoration: 'none' }}>
                                    <span style={{ maxWidth: 200, whiteSpace: 'nowrap', overflow: 'hidden', textOverflow: 'ellipsis' }}>
                                        {truncateUserName(user?.name || '')}
                                    </span>
                                </Dropdown.Toggle>
                                <Dropdown.Menu>
                                    <Dropdown.Item as={Link} to="/profile">Профиль</Dropdown.Item>
                                    <Dropdown.Item as={Link} to="/" onClick={handleLogout}>Выход</Dropdown.Item>
                                </Dropdown.Menu>
                            </Dropdown>
                        ) : (
                            <Nav.Link as={Link} to="/login">
                                <Button variant="link" style={{ fontWeight: 'bold', color: 'white' }}>Вход</Button>
                            </Nav.Link>
                        )}
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
};

export default NavbarPanel;
