import { useEffect, useState } from 'react';
import Responsibility from '../../components/board/task/responsibility';
import Header from '../../components/header/header';
import { Nav, InputGroup, Form, Button } from 'react-bootstrap';

import style from "./index.css"

const defaultAccounts = [{id: 0, name: "Alex", surname: "Ganzales", role: "user"},
    {id: 1, name: "Gogo", surname: "Popo",  role: "user"},
    {id: 2, name: "Alfred", surname: "Koli",  role: "manager"},
    {id: 3, name: "Mamon", surname: "Barmut",  role: "user"},
    {id: 4, name: "Josef", surname: "Hamburger",  role: "manager"},
    {id: 5, name: "Lily", surname: "Salazar",  role: "user"},
    {id: 6, name: "Jojo", surname: "Ramiros",  role: "user"},
    {id: 7, name: "Alexandro", surname: "Holl",  role: "user"},
]

export default () => {
    const [accounts, setAccounts] = useState(defaultAccounts)
    const [activeAccount, setActiveAccount] = useState(null)
    const [name, setName] = useState("")
    const [surname, setSurname] = useState("")
    const [role, setRole] = useState("")
    
    useEffect(() => {
        if (!activeAccount) {return}
        setName(activeAccount.name)
        setSurname(activeAccount.surname)
        setRole(activeAccount.role)
    }, [activeAccount])


    const accountsComponents = accounts.map(v => {
        return <div key={v.id} className="account-preview rounded" onClick={() => setActiveAccount(v)}>
            <div className="task-responsibility">
                {v.name.charAt(0).toUpperCase()}
                {v.surname.charAt(0).toUpperCase()}
            </div>
            <span className="name">
                {v.name} {v.surname}
            </span>
        </div>
    })

    const onSave = () => {
        const newAccounts = accounts.map(v => {
            if(v.id != activeAccount.id) {return v;}
            v.name = name
            v.surname = surname
            v.role = role
            return v
        })
        setAccounts(newAccounts)
        setActiveAccount(null)
    }

    return <main>
         <Header title="Аккаунты" >
            <Nav className="me-auto">
                <Nav.Link href="/" className="text-light">Главная</Nav.Link>
            </Nav>
         </Header>
        <div className="d-flex container-lg">
            <div className='accounts-preview-wrapper'>
                {accountsComponents}
            </div>
            <div className='accounts-edit'>
                {activeAccount && <Form>
                        <Form.Group className="mt-4">
                            <Form.Label>Имя</Form.Label>
                            <Form.Control
                                aria-label="With textarea"
                                value={name}
                                onChange={v => setName(v.target.value)}
                            />
                        </Form.Group>
                        <Form.Group className="mt-4">
                            <Form.Label>Фамилия</Form.Label>
                            <Form.Control
                                aria-label="With textarea"
                                value={surname}
                                onChange={v => setSurname(v.target.value)}
                            />
                        </Form.Group>
                        <Form.Group className="mt-4">
                            <Form.Label>Роль</Form.Label>
                             <Form.Select aria-label="Роль" value={role} onChange={(v) => setRole(v.currentTarget.value)}>
                                <option value="user">Пользователь</option>
                                <option value="manager">Администратор</option>
                            </Form.Select>
                        </Form.Group>
                        <Form.Group className='mt-4 buttons'>
                            <Button variant="secondary" onClick={() => setActiveAccount(null)}>
                                Закрыть
                            </Button>
                            <Button variant="primary" onClick={() => onSave()}>
                                Сохранить
                            </Button>
                        </Form.Group>
                    </Form>
                }
            </div>
        </div>
    </main>
}