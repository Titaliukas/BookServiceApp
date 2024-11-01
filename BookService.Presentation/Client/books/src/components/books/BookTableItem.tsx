﻿import {BookDto} from "../../Models/bookDto.ts";
import {Button} from "semantic-ui-react";
import {NavLink} from "react-router-dom";


interface Props {
    book: BookDto;
}

export default function BookTableItem({book}: Props) {
    return (
        <>
            <tr className="center aligned">
                <td data-label="Photo"><img src={book.Photo} alt="Book image" style={{ width: '400px', height: '150px' }}></img></td>
                <td data-label="Title">{book.title}</td>
                <td data-label="Year">{book.year}</td>
                <td data-label="Action">
                    <Button as={NavLink} to={`reserveBook/${book.id}`} color="yellow" type="submit">
                        Reserve
                    </Button>
                </td>
            </tr>
        </>
    )
}