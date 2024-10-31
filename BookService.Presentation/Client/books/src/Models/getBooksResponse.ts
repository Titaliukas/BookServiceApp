import {BookDto} from "./bookDto.ts";

export interface GetBooksResponse {
    bookDtos: BookDto[];
}