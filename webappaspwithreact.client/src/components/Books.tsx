import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom';
import { Book, BookDTO, addBook, BookCategory, fetchBooks, fetchBookCategories } from '../api_utils/fetch_book';


const Books = () => {
    const [books, setBooks] = useState<Book[]>([]);
    const [categories, setCategories] = useState<BookCategory[]>([]);

    useEffect(() => {
        const fetchBooksData = async () => {
            const books = await fetchBooks();
            setBooks(books);
        }
        fetchBooksData();

        const fetchCategories = async () => {
            const categories = await fetchBookCategories();
            setCategories(categories);
        }
        fetchCategories();
    }, []);

    return (
        <div className="p-4 bg-gray-100">
            <h2 className="text-2xl font-bold mb-4 text-center">List of Books</h2>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                {books && books.map((book) => (
                    <div key={book.book_id} className="bg-white shadow-md rounded-lg p-4 mb-4 transition-transform transform hover:scale-105">
                        <h3 className="text-xl font-semibold text-red-500">{book.book_name}</h3>
                        <p className="text-green-500">{categories.find(category => category.book_category_id === book?.book_category_id)?.book_genre_type}</p>
                        <p className="text-gray-600">Author: {book.author}</p>
                        <p className="text-gray-600">Price: {book.price}</p>
                        <Link to={`/book/${book.book_id}`} className="text-blue-500 hover:underline">View details</Link>
                    </div>
                ))}
            </div>
        </div>
    )
}

export default Books;
