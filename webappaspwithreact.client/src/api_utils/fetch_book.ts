// Code: webappaspwithreact - client - src - api_utils - fetch_book.ts
import axios from 'axios';

export type Book = {
    "book_id": number,
    "book_name": string,
    "description": string,
    "publication_date": string,
    "quantity": number,
    "price": number,
    "author": string,
    "book_category_id": number,
    "book_category": {
        "book_category_id": number,
        "category_name": string
    }
}

export const fetchBook = async (bookId: string) => {
    const response = await axios.get(`http://localhost:5045/api/Books${bookId}`);
    return response.data as Book;
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