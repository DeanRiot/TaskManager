import OverlayTrigger from 'react-bootstrap/OverlayTrigger';
import Tooltip from 'react-bootstrap/Tooltip';

import style from './index.css'


export default ({info}) => {
    return <OverlayTrigger
          placement="left"
          overlay={
            <Tooltip id={info.id}>
              {info.name} {info.surname}
            </Tooltip>
          }
        >
            <div
                className="task-responsibility"
                title={`${info.name} ${info.surname}`}
            >
                {info.name.charAt(0).toUpperCase()}
                {info.surname.charAt(0).toUpperCase()}
            </div>
        </OverlayTrigger>

    
}