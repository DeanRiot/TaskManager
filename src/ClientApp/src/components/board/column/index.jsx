import { ItemTypes } from "../../../types"
import Task from "../task"
import TaskModalCreate from "../../../modals/task/create"
import TaskModalChange from "../../../modals/task/change"

import { useDrop } from 'react-dnd'
import { useState } from 'react';

import { Form, InputGroup, Button, CloseButton } from "react-bootstrap"

import style from "./index.css"

export default ({column, onTaskChangeColumn, onColumnChange, onRemoveColumn}) => {
    const [modalCreateOpen, setModalCreateOpen] = useState(false);
    const [changeTask, setChangeTask] = useState(null)
    const [name, setName] = useState(column.name)
    const [nameChange, setNameChange] = useState(false)
    const [{ isOver }, drop] = useDrop(
        () => ({
          accept: ItemTypes.TASK,
          drop: (item) => onTaskChangeColumn(item, column.id),
          collect: monitor => ({
            isOver: !!monitor.isOver(),
          }),
        }),
        []
      )

    const openTask = (task) => {
      setChangeTask(task)
    }

    const columnChange = () => {
      const newColumn = {...column}
      newColumn.name = name
      setNameChange(false)
      onColumnChange(newColumn)
    }

    const tasksComponents = column.tasks.map(v => <Task  key={v.id} task={v} onClick={openTask}/>)

    return <>
      <TaskModalChange open={changeTask} task={changeTask} onClose={() => {setChangeTask(null)}}/>
      <TaskModalCreate open={modalCreateOpen} info={{id: null}} onClose={() => {setModalCreateOpen(false)}}/>
      <div className="board-column rounded">
              {nameChange && <div className="header-changer"><InputGroup >
                <Form.Control
                    value={name}
                    onChange={v => setName(v.target.value)}
                />
              <Button variant="outline-primary" onClick={() => columnChange()}>V</Button>
              <Button variant="outline-danger" onClick={() => {setNameChange(false); setName(column.name)}}>X</Button>
            </InputGroup></div>
}
            {!nameChange && <div className="header" onClick={() => setNameChange(true)}>
              {column.name}
              <CloseButton onClick={() => onRemoveColumn(column)}/>
            </div>}
          <div className="tasks-wrapper" ref={drop}>
              {tasksComponents}
              {isOver && (
                  <Task  task={{text: "", disabled: true, responsibility: []}}/>
              )}
              <div className="tasks-add text-muted rounded" onClick={() => {setModalCreateOpen(true)}}>
                + Добавить задачу
            </div>
          </div>
      </div>
    </>
}