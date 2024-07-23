import React from 'react';
import { Container, Row, Col} from 'react-bootstrap';

const MainContent = ({}) => {
  return (
    <Container className="d-flex justify-content-center" style={{ height: '100vh' }}>
        <Row className="col-md-11 col-xxl-9 p-3 mb-6">
            <div className="text-dark text-center fs-1"> Добро пожаловать в менеджер DnD персонажей<p className="fs-3"> by johannblx</p></div>
        </Row>
    </Container>
  );
};

export default MainContent;