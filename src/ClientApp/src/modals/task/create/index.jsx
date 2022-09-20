import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import ReactDatePicker from 'react-datepicker';
import { InputGroup } from 'react-bootstrap';
import { useState } from 'react';

import style from "./index.css";


export default ({open, onClose}) => {
    const [startDate, setStartDate] = useState(new Date());
    const [text, setText] = useState("")
    return  <Modal show={open} onHide={onClose}>
    <Modal.Header closeButton>
        <Modal.Title>
            Создание задачи
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>
        <Form>
            <InputGroup>
                <InputGroup.Text>Задача</InputGroup.Text>
                <Form.Control
                    as="textarea"
                    aria-label="With textarea"
                    value={text}
                    onChange={v => setText(v.target.value)}
                />
            </InputGroup>
            <InputGroup className='datepicker-wrapper'>
                <InputGroup.Text id="deadline">
                Срок
                </InputGroup.Text>
                    <ReactDatePicker
                        selected={startDate}
                        onChange={(date) => setStartDate(date)} 
                        customInput={<Form.Control
                            className="datepciker-input"
                            aria-label="Срок"
                            aria-describedby="deadline"
                        />}
                    />
            </InputGroup>
        </Form>
    </Modal.Body>
    <Modal.Footer>
      <Button variant="secondary" onClick={onClose}>
        Закрыть
      </Button>
      <Button variant="primary" onClick={onClose}>
        Создать
      </Button>
    </Modal.Footer>
  </Modal>
}