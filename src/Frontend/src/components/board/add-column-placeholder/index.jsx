import style from './index.css'

export default ({onClick}) => {
    return <div className="board-column-new bg-secondary rounded" onClick={onClick}>
        Добавить колонку
    </div>
}