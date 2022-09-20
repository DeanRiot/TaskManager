import { useParams } from 'react-router-dom';

import Header from '../../components/header/header';
import Column from '../../components/board/column';
import { DndProvider } from 'react-dnd'
import { HTML5Backend } from 'react-dnd-html5-backend'

import BoardSettings from "../../modals/board/settings"

import style  from './index.css'
import { useState } from 'react';
import { Nav } from 'react-bootstrap';
import AddColumnPlaceholder from '../../components/board/add-column-placeholder';

const columnsInfo = [
    {name: "Не начато", id: 0, tasks: [
        {
            id: 1,
            text: "Задача 1",
            deadline: "2022-10-05",
            section: "-",
            events: [{id: 0, user: "Alex", date: "2022-09-30", action: "created the world"}],
            responsibility: [{name: "Alex", surname: "Ganzales", id: 2}],
            comments: [{id: 0, author: {id: 25, name: "Alex", surname: "Ganzales"}, text: "Измените текст задачи", date: "2022-07-09T12:15:08"}]
        }
    ]},
    {name: "В обработке", id: 1, tasks: [
        {
            id: 2,
            text: "Задача 2",
            deadline: "2022-10-05",
            section: "-",
            events: [{id: 0, user: "Alex", date: "2022-09-30", action: "created the world"}],
            responsibility: [{name: "Alex", surname: "Ganzales", id: 2}],
            comments: [{id: 0, author: {id: 25, name: "Alex", surname: "Ganzales"}, text: "Измените текст задачи", date: "2022-07-09T12:15:08"}]
        }
    ]},
    {name: "Тестирование", id: 2, tasks: []},
    {name: "Завершено", id: 3, tasks: []},
]

export default () => {
    const {boardID} = useParams();
    const [columnsState, setColumnsState] = useState(columnsInfo)
    const [settingsOpen, setSettingsOpen] = useState(false)
    const onTaskChangeColumn = (chooseTask, newColumnID) => {
        let task = null;
        const newColumns = columnsState.map(v => {
            v.tasks = v.tasks.filter(t => {
                if (t.id == chooseTask.id) {
                    task = t
                }; 
                return t.id != chooseTask.id
            })
            return v
        })
        newColumns.forEach((v,i) => {
            if(v.id == newColumnID) {
                v.tasks.push(task)
            }
        })
        setColumnsState(newColumns)
    }


    const onColumnChange = (column) => {
        const newColumns = columnsState.map(v => {
            if(v.id == column.id) {
                v.name = column.name
            }
            return v
        })
        setColumnsState(newColumns)
    }

    const onRemoveColumn = (column) => {
        const newColumns = columnsState.filter(v => v.id != column.id)
        console.log(newColumns)
        setColumnsState(newColumns)
    }

    const addColumn = () => {
        setColumnsState([...columnsState,  {name: "New Column", id: columnsState.length, tasks: []}])
    }

    const columns = columnsState.map(v => <Column 
        column={v}
        key={v.id}
        onTaskChangeColumn={onTaskChangeColumn}
        onColumnChange={onColumnChange}
        onRemoveColumn={onRemoveColumn}
    />)

    return <main>
        <BoardSettings board={{name: "Доска 1", description: "Best Board Ever!!!"}} open={settingsOpen} onClose={() => setSettingsOpen(false)}/>
         <Header title="Доска 1" color="#6610f2">
            <Nav className="me-auto">
                <Nav.Link href="/" className="text-light">Главная</Nav.Link>
                <Nav.Link href="1/doc" className="text-light">Отчет</Nav.Link>
                <Nav.Link className="text-light" onClick={() => {setSettingsOpen(true)}}>Настройки</Nav.Link>
            </Nav>
         </Header>
        <div className="d-flex board-columns-wrapper">
            <DndProvider backend={HTML5Backend}>
                {columns}
                <AddColumnPlaceholder onClick={addColumn}/>
            </DndProvider>
        </div>
    </main>
}