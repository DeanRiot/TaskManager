import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { Link } from "react-router-dom";

import style from "./index.css";

export default () => {
    return <main>
            <Container>
                <Row className="justify-content-md-center">
                    <Col md="auto">
                        <div className="log-in-container shadow-sm bg-white rounded">
                            <h3>Менеджер задач</h3>
                            <div className='ps-3 pe-3'>
                                <Form>
                                    <Form.Group className="mb-3" controlId="formEmail">
                                        <Form.Label>Логин</Form.Label>
                                        <Form.Control type="login" placeholder="Введите логин" />
                                    </Form.Group>
                                    <Form.Group className="mb-3" controlId="formPassword">
                                        <Form.Label>Пароль</Form.Label>
                                        <Form.Control type="password" placeholder="Пароль" />
                                    </Form.Group>
                                    <Form.Group className="mb-3" >
                                        <div className="d-grid gap-2">
                                            <Button variant="primary" type="submit">
                                                Войти
                                            </Button>
                                        </div>
                                    </Form.Group>
                                    <Form.Group className="mb-3 text-center">
                                        <Form.Text>
                                            Или <Link to="/sign-in">зарегестрироваться</Link>
                                        </Form.Text>
                                    </Form.Group>
                                </Form>
                            </div>
                        </div>
                    </Col>
                </Row>
            </Container>
    </main>
}