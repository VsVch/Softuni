import { Footer } from "./components/Footer.js";
import { Header } from "./components/Header.js";
// import { Spinner } from "./components/Spinner.js";
import { TodoList } from "./components/TodoList.js";

function App() {
  return (
    <div className="App">
      <Header />
      {/* <Spinner/> */}

      <main className="main">
        <section className="todo-list-container">
          

          <TodoList />
        </section>
      </main>
      <Footer />
    </div>
  );
}

export default App;
