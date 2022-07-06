import './App.css';
import {BookList} from './components/BookList.js';
import {CharacterList} from './components/CharacterList.js'

function App() {
  let books = [
    {"title" : "Test book 1", "description": "Greate Test books 1", "author" : "Author 1"},
    {"title" : "Test book 2", "description": "Greate Test books 2", "author" : "Author 2"},
    {"title" : "Test book 3", "description": "Greate Test books 3", "author" : "Author 3"},
  ]

  return (
    <div className="App">
      <CharacterList/>
      <BookList books={books}/>
    </div>
  );
}

export default App;
