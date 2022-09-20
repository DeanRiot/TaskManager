import { Container } from "react-bootstrap"
import { Link } from "react-router-dom";

import style from "./index.css"

export default (props) => {
    const link = `/board/${props.info.id}`
    return <Link to={link} className="bg-gradient board-preview shadow rounded" style={{"backgroundColor": props.info.color}}>
            <div className="name">{props.info.name}</div>
            <p className="description">{props.info.description}</p>
    </Link>
}