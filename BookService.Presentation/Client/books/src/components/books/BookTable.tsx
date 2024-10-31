import {useEffect, useState} from "react";
import {BookDto} from "../../Models/bookDto.ts";
import apiConnector from "../../api/apiConnector.ts";
import {Container} from "semantic-ui-react";
import BookTableItem from "./BookTableItem.tsx";

export default function BookTable() {
    
    const [books, setBooks] = useState<BookDto[]>([]);
    
    useEffect(() => {
        const fetchData = async () => {
            const fetchedBooks = await apiConnector.getBooks();
            setBooks(fetchedBooks);
        }
        
        fetchData();
    }, []);
    
    return (
        <>
            <Container className="container-style">
                <table className="ui inverted table">
                    <thead style ={{textAlign: "center"}}>
                    <tr>
                        <th>Id</th>
                        <th>Title</th>
                        <th>Year</th>
                        <th>Photo</th>
                        <th>Action</th>
                    </tr>
                    </thead>
                    <tbody>
                    {books.length !== 0 && (
                        books.map((book, index) => (
                            <BookTableItem key={index} book={book} />
                        ))
                    )}
                    </tbody>
                </table>
            </Container>
        </>
    )
}