import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import ReactDatePicker from 'react-datepicker';
import { InputGroup } from 'react-bootstrap';
import { useState, useRef, useEffect } from 'react';
import {Badge, CloseButton, FloatingLabel} from 'react-bootstrap';

import style from "./index.css";
import Comment from '../../../components/board/task/comment';


export default ({task, open, onClose}) => {
    const [startDate, setStartDate] = useState(new Date());
    const [text, setText] = useState("");
    const [response, setResponse] = useState("")
    const [activeResponses, setActiveResponses] = useState([])
    const [message, setMessage] = useState("")
    const [comments, setComments] = useState([])

    const commentsSection = useRef(null)

    // console.log(task, comments)
    useEffect(() => {
        if (task == null) {return}
        setStartDate(Date.parse(task.deadline))
        setText(task.text)
        setActiveResponses(task.responsibility)
        setComments(task.comments)
    }, [task])
    useEffect(() => {
        if(!commentsSection.current) {return}
        commentsSection.current.scrollTop = 99999;
    }, [comments])

    if(task == null) {
        return <></>
    }

    const removeActiveResponse = (id) => {
        const newActiveResponse = activeResponses.filter(v => v.id != id)
        setActiveResponses(newActiveResponse)
    }

    const addComment = () => {
        setComments([...comments, {id: comments.length, author: {id: 25, name: "Joke", surname: "Pisya"}, text: message, date: new Date().toISOString()}])
        setMessage("")
    }

    const activeResponsesComponents = activeResponses.map(v => 
        <Badge bg="primary" className='' key={v.id}>
            {v.name} {v.surname} 
            <CloseButton
                variant="white"
                style={{width: 10, height: 10}}
                onClick={() => removeActiveResponse(v.id)}
            />
        </Badge>
    )

    const commentsComponents = comments.map(v => <Comment comment={v} key={v.id}/>)

    return  <Modal show={open} onHide={onClose}>
    <Modal.Header closeButton>
        <Modal.Title>
            Редактирование задачи #{task.id}
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
            <InputGroup className='datepicker-wrapper mt-4'>
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
            <InputGroup className='mt-4'>
                <InputGroup.Text>Ответственный</InputGroup.Text>
                <Form.Control
                    value={response}
                    onChange={v => setResponse(v.target.value)}
                />
                <Button variant="primary" id="button-addon2">
                    Добавить
                </Button>
            </InputGroup>
            <div className="mt-1">
                {activeResponsesComponents}
            </div>
            <FloatingLabel controlId="floatingSelect" label="Статус задачи" className="mt-4">
                <Form.Select aria-label="Статус задачи">
                    <option value="open">Открыта</option>
                    <option value="close">Закрыта</option>
                </Form.Select>
            </FloatingLabel>
            <div className="mt-4">
                <p className="text-muted">Комментарии</p>
                <div className="comments-section rounded" ref={commentsSection}>
                    {commentsComponents}
                    <div  />
                </div>
                <InputGroup className='mt-4'>
                    <Form.Control
                        value={message}
                        onChange={v => setMessage(v.target.value)}
                    />
                    <Button variant="primary" id="button-addon2" onClick={addComment}>
                        Сохранить
                    </Button>
                </InputGroup>
            </div>
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