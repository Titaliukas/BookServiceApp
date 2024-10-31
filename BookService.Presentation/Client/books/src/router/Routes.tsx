import {createBrowserRouter, RouteObject} from "react-router-dom";
import App from "../App.tsx";
import BookForm from "../components/books/BookForm.tsx";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App/>,
        children: [
            {path: 'createBook', element: <BookForm key='create' />},
            {path: 'reserveBook/:id', element: <BookForm key='reserve' />},
            {path: '*', element: <BookForm />}
        ]
    }
]

export const router = createBrowserRouter(routes)