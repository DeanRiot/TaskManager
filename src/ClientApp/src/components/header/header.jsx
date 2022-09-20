import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

export default ({title, color, children}) => {
    return <Navbar bg={color ? "":"primary"} expand="lg" className="bg-gradient" style={{backgroundColor: color ? color : "inherit"}}>
      <Container>
        <Navbar.Brand href="" className="fw-bold text-light">{title}</Navbar.Brand>
        <div>
          {children}
        </div>
      </Container>
    </Navbar>
}