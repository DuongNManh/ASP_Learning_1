import React, { useEffect, useState } from 'react'
import { Link, useParams } from 'react-router-dom';
import { Book, BookDTO, addBook, fetchBook, deleteBook, updateBook, BookCategory, fetchBookCategories } from '../api_utils/fetch_book';


const BookDetails = () => {
    const { id } = useParams<{ id: string }>();
    const [book, setBook] = useState<Book>();
    const [isEditing, setIsEditing] = useState(false);
    const [updatedBook, setUpdatedBook] = useState<BookDTO | undefined>(undefined);
    const [categories, setCategories] = useState<BookCategory[]>([]);

    useEffect(() => {
        const fetchCategories = async () => {
            const categories = await fetchBookCategories();
            setCategories(categories);
        }
        fetchCategories();

        const fetchBooksData = async () => {
            const books = await fetchBook(id ? id : '');
            setBook(books);
            setUpdatedBook({
                book_id: books.book_id,
                book_name: books.book_name,
                description: books.description,
                publication_date: books.publication_date,
                quantity: books.quantity,
                price: books.price,
                author: books.author,
                book_category_id: books.book_category_id,
            });
        }
        fetchBooksData();
    }, [id]);

    const handleUpdate = async () => {
        // Update the book using BookDTO
        await updateBook(updatedBook as BookDTO); // Cast updatedBook to BookDTO
        setIsEditing(false);
    };

    const handleDelete = async () => {
        // Implement the delete logic here
        // e.g., await deleteBook(id);
    };

    return (
        <>
            <h2>Book Detail</h2>
            <div className="bg-white shadow-md rounded-lg p-4 mb-4">
                {isEditing ? (
                    <div>
                        <input
                            placeholder='Book Name'
                            type="text"
                            value={updatedBook?.book_name}
                            onChange={(e) => setUpdatedBook({ ...updatedBook!, book_name: e.target.value })}
                            className="border p-2 mb-2 w-full"
                        />
                        <input
                            placeholder='Author'
                            type="text"
                            value={updatedBook?.author}
                            onChange={(e) => setUpdatedBook({ ...updatedBook!, author: e.target.value })}
                            className="border p-2 mb-2 w-full"
                        />
                        <input
                            placeholder='Price'
                            type="number"
                            value={updatedBook?.price}
                            onChange={(e) => setUpdatedBook({ ...updatedBook!, price: Number(e.target.value) })}
                            className="border p-2 mb-2 w-full"
                        />
                        <input
                            placeholder='Quantity'
                            type="number"
                            value={updatedBook?.quantity}
                            onChange={(e) => setUpdatedBook({ ...updatedBook!, quantity: Number(e.target.value) })}
                            className="border p-2 mb-2 w-full"
                        />
                        <textarea
                            placeholder='Description'
                            value={updatedBook?.description}
                            onChange={(e) => setUpdatedBook({ ...updatedBook!, description: e.target.value })}
                            className="border p-2 mb-2 w-full"
                        />
                        <button onClick={handleUpdate} className="bg-blue-500 text-white p-2 rounded">Update</button>
                        <button onClick={() => setIsEditing(false)} className="bg-gray-500 text-white p-2 rounded ml-2">Cancel</button>
                    </div>
                ) : (
                    <div>
                        <h3 className="text-xl font-semibold text-red-500">{book?.book_name}</h3>
                        <p className="text-green-500">{categories.find(category => category.book_category_id === book?.book_category_id)?.book_genre_type}</p>
                        <p className="text-gray-600">Author: {book?.author}</p>
                        <p className="text-gray-600">Price: {book?.price}</p>
                        <p className="text-gray-600">Publication Date: {book?.publication_date}</p>
                        <p className="text-gray-600">Quantity: {book?.quantity}</p>
                        <p className="text-gray-600">Description: {book?.description}</p>
                        <button onClick={() => setIsEditing(true)} className="bg-yellow-500 text-white p-2 rounded mt-2">Edit</button>
                        <button onClick={handleDelete} className="bg-red-500 text-white p-2 rounded mt-2 ml-2">Delete</button>
                    </div>
                )}
            </div>
        </>
    )
}

export default BookDetails