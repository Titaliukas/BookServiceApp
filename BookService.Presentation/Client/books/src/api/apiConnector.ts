import {BookDto} from "../Models/bookDto.ts";
import axios, {AxiosResponse} from "axios";
import {GetBooksResponse} from "../Models/getBooksResponse.ts";
import {API_BASE_URL} from "../../config.ts";
import {GetBookByIdResponse} from "../Models/getBookByIdResponse.ts";

const apiConnector = {
    
    getBooks: async (): Promise<BookDto[]> => {
        try{
            console.log('Requesting URL:', `${API_BASE_URL}/books`);
            const response: AxiosResponse<GetBooksResponse> = 
                await axios.get(`${API_BASE_URL}/books`);
            console.log('Response:', response);
            
            const books = response.data.bookDtos.map(book => ({
                ...book,
                createDate: book.createDate?.slice(0, 10) ?? ""
            }));
            console.log('Data:', books);
            return books;
        } catch (error) {
            console.log('Error fetching books', error);
            throw error;
        }},
    
    createBook: async (book: BookDto): Promise<void> => {
        try{
            await axios.post<number>(`${API_BASE_URL}/books`, book);
        } catch (error) {
            console.log(error);
            throw error;
        }},
    
    deleteBook: async (bookId: number): Promise<void> => {
        try{
            await axios.delete<number>(`${API_BASE_URL}/books/${bookId}`);
        }catch(error){
            console.log(error);
            throw error;
        }},
    
    getBookById: async (bookId: string): Promise<BookDto | undefined> => {
        try {
            const response = await axios.get<GetBookByIdResponse>(`${API_BASE_URL}/books/${bookId}`);
            return response.data.bookDto;
        } catch (error) {
            console.log(error);
            throw error;
        }
    }
    
}

export default apiConnector;