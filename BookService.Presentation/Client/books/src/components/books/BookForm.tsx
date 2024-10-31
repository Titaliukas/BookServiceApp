import {useNavigate, useParams} from "react-router-dom";
import {useEffect, useState} from "react";
import {BookDto} from "../../Models/bookDto.ts";
import apiConnector from "../../api/apiConnector.ts";

export default function BookForm() {
    
    const {id} = useParams();
    const navigate = useNavigate();
    
    const [book, setBook] = useState<BookDto>({
       id: undefined,
        title: '',
        year: 0,
        Photo: '',
        Type: '',
        createDate: ''
    });

    useEffect(() => {
        if (id) {
            apiConnector.getBookById(id).then(book => setBook(book!));
        }
    }, [id]);
    
    
    
    return (
        <>
            
        </>
    )    
}