import Responsibility from "../responsibility"

import style from "./index.css"

export default ({comment}) => {
    return <div className="comment">
        <Responsibility info={comment.author}/>
        <div className="shadow-sm bg-white comment-text rounded">
            <p>{comment.text}</p>
        </div>
        <span className="text-secondary">{new Date(comment.date).toTimeString().split(' ')[0].substring(0, 5)}</span>
    </div>
}