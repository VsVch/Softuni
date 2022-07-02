import './App.css';
import { BookList } from './BookList.js';
import {Header} from './Header.js';
import {Timer} from './Timer.js';
import {Clicker} from './Clicker.js';
import { Counter } from './Counter.js';

function App() {

  const books = [
      {'title': 'Test 1', 'description': 'Good book 1', 'author': 'Sand1'},
      {'title': 'Test 2', 'description': 'Good book 2', 'author': 'Sand2'},
      {'title': 'Test 3', 'description': 'Good book 3', 'author': 'Sand3'},
    
  ]

  return (
    <div className="App">
      <Header title="Hi from Sand!"/>
       <BookList books={books}></BookList>
       <Timer start={0}/>
       <Clicker/>
       <Counter start={10}/>
    </div>
  );
}

export default App;
