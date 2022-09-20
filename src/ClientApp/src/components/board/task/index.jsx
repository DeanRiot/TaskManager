import style from './index.css'
import { useDrag } from 'react-dnd'

import { ItemTypes } from '../../../types'
import Responsibility from './responsibility';

export default ({task, onClick}) => {
    const [{ isDragging }, drag] = useDrag(() => ({
        type: ItemTypes.TASK,
        collect: (monitor) => ({
          isDragging: !!monitor.isDragging()
        }),
        item: {id: task.id},
    }))

    let cName = "column-task shadow-sm rounded"
    cName+=task.disabled ? " disabled": ""

    let responsesComponents = task.responsibility.map(v => <Responsibility info={v} key={v.id}/>)
    return <div
        ref={drag}
        className={cName}
        style={{
            display: isDragging ? "none" : "block"
        }}
        onClick={() => onClick(task)}
       
    >
        <p className='text-truncate'>{task.text}</p>
        <div className='task-responsibility-wrapper'>{responsesComponents}</div>
    </div>
}