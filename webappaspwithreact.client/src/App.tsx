import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Books from './components/Books';
import BookDetails from './components/BookDetails';

function App() {

    return (
        <div className='mx-auto'>
            <div>
                <h1 id="tableLabel">Books Store</h1>
                <p>This component demonstrates fetching data from the server.</p>
                <p>Click on the Books link in the navigation bar to view the list of books.</p>
                <hr />
            </div>
            <Router>
                <Routes>
                    <Route path="/books" element={<Books />} />
                    <Route path="/book/:id" element={<BookDetails />} />
                </Routes>
            </Router>
        </div>
    );
}

export default App;