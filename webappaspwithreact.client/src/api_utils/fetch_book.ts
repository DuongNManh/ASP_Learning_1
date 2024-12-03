// Code: webappaspwithreact - client - src - api_utils - fetch_book.ts
import axios from 'axios';

export type Book = {
    "book_id": number | undefined,
    "book_name": string,
    "description": string,
    "publication_date": string,
    "quantity": number,
    "price": number,
    "author": string,
    "book_category_id": number,
}

export type BookDTO = {
    "book_id": number | undefined,
    "book_name": string,
    "description": string,
    "publication_date": string,
    "quantity": number,
    "price": number,
    "author": string,
    "book_category_id": number,
}

export type BookCategory = {
    "book_category_id": number,
    "book_genre_type": string,
    "description": string,
}

export const fetchBook = async (bookId: string) => {
    try {
        const response = await axios.get(`http://localhost:5045/api/Books/${bookId}`);
        console.log("Book fetched for api url: ", `http://localhost:5045/api/Books/${bookId}`);
        return response.data as Book;
    } catch (error) {
        console.error("Error fetching book:", error);
        return {} as Book; // Return an empty object in case of error
    }
}

export const fetchBooks = async () => {
    try {
        const response = await axios.get('http://localhost:5045/api/Books');
        return response.data as Book[];
    } catch (error) {
        console.error("Error fetching books:", error);
        return []; // Return an empty array in case of error
    }
}

export const updateBook = async (book: Book) => {
    try {
        const response = await axios.put(`http://localhost:5045/api/Books/${book.book_id}`, book);
        return response.data as Book;
    } catch (error) {
        console.error("Error updating book:", error);
        return {} as Book; // Return an empty object in case of error
    }
}

export const deleteBook = async (bookId: number) => {
    try {
        const response = await axios.delete(`http://localhost:5045/api/Books/${bookId}`);
        return response.data as Book;
    } catch (error) {
        console.error("Error deleting book:", error);
        return {} as Book; // Return an empty object in case of error
    }
}

export const addBook = async (book: Book) => {
    try {
        const response = await axios.post(`http://localhost:5045/api/Books`, book);
        return response.data as Book;
    } catch (error) {
        console.error("Error adding book:", error);
        return {} as Book; // Return an empty object in case of error
    }
}

export const fetchBookCategories = async () => {
    try {
        const response = await axios.get('http://localhost:5045/api/BookCategory');
        return response.data as BookCategory[];
    } catch (error) {
        console.error("Error fetching book categories:", error);
        return []; // Return an empty array in case of error
    }
}