import { Footer } from "./components/common/Footer.js";
import { Header } from "./components/common/Header.js";
import { SearchBar } from "./components/search-bar/SearchBar.js";
import { UserSection } from "./components/user-section/UserSection.js";

function App() { 

  return (
    <div className="App">
      <Header />

      <main className="main">
        <section className="card users-container">
          <SearchBar />

          <UserSection />
        </section>
      </main>

      <Footer />
    </div>
  );
}

export default App;
