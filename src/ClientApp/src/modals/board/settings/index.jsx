import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import ReactDatePicker from 'react-datepicker';
import { InputGroup } from 'react-bootstrap';
import { useEffect, useState } from 'react';

import style from "./index.css";


export default ({board, open, onClose}) => {
    const [name, setName] = useState("")
    const [text, setText] = useState("")

    useEffect(() => {
        setName(board.name)
        setText(board.description)
    }, [board])

    return  <Modal show={open} onHide={onClose}>
    <Modal.Header closeButton>
        <Modal.Title>
            Настройки доски {board.name}
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>
        <Form>
            <InputGroup className="mt-4">
                <InputGroup.Text>Имя</InputGroup.Text>
                <Form.Control
                    value={name}
                    onChange={v => setName(v.target.value)}
                />
            </InputGroup>
            <InputGroup className="mt-4">
                <InputGroup.Text>Описание</InputGroup.Text>
                <Form.Control
                    as="textarea"
                    aria-label="With textarea"
                    value={text}
                    onChange={v => setText(v.target.value)}
                />
            </InputGroup>
        </Form>
    </Modal.Body>
    <Modal.Footer>
      <Button variant="secondary" onClick={onClose}>
        Закрыть
      </Button>
      <Button variant="primary" onClick={onClose}>
        Сохранить
      </Button>
    </Modal.Footer>
  </Modal>
}