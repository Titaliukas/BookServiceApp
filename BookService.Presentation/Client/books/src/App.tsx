import './App.css'
import BookTable from "./components/books/BookTable.tsx";
import {Outlet, useLocation} from "react-router-dom";
import {Container} from "semantic-ui-react";

function App() {
    const location = useLocation();

  return (
    <>
        {location.pathname === "/" ? <BookTable/> : (
            <Container className="container-style">
                <Outlet />
            </Container>
        )}
    </>
  )
}

export default App
