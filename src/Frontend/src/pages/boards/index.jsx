import Container from 'react-bootstrap/Container';

import Header from '../../components/header/header';
import BoardPreview from '../../components/board/preview';

import { Nav } from 'react-bootstrap';

import { Link } from 'react-router-dom';

import style from "./index.css";
import { useState } from 'react';

const defaultBoardsInfo = [{
    id: 0,
    name: "Доска 1",
    description: "Описание доски",
    color: "#0d6efd"
},{
    id: 1,
    name: "Доска 2",
    description: "Описание доски",
    color: "#6610f2"
},
{
    id: 2,
    name: "Доска 3",
    description: "Описание доски",
    color: "#0dcaf0"
}]

const colors = ["#0dcaf0", "#20c997", "#198754", "#ffc107", "#fd7e14", "#dc3545", "#d63384", "#6f42c1", "#6610f2", "#0d6efd"]

export default () => {
    const [boards, setBoards] = useState(defaultBoardsInfo)

    const onAdd = () => {
        setBoards([...boards, {
            id: boards.length, name: "New Board", description: "...", color: colors[Math.floor(Math.random() * colors.length)]
        }])
    }

    const boardsComponents = boards.map(v => {
        return <BoardPreview key={v.id} info={v} />
    })

    const addNewBoard = <div className="bg-gradient board-preview rounded  add-board" onClick={onAdd}>
        <span className='text-muted'>Добавить доску</span>
    </div>

    return <main>
    <Header title="Менеджер задач">
         <Nav className="me-auto">
            <Link to="/accounts" className='text-light text-decoration-none'>Аккаунты</Link>
        </Nav>
    </Header>
    <Container className="d-flex flex-wrap">
        {boardsComponents}
        {addNewBoard}
    </Container>
</main>
}