import {useState, useEffect} from 'react'
import {Todo} from './Todo.js'

export const TodoList = () => {
  
    const [todos, setTodos] = useState([]);

     useEffect(()=> {
        fetch('http://localhost:3030/jsonstore/todos')
            .then(res => res.json())
            .then(result => {
                setTodos(Object.values(result));                             
            });
     }, [])

     const todoClickHandler = (todo) => {    

        fetch(`http://localhost:3030/jsonstore/todos/${todo._id}`, {
                method: 'PUT',
                headers: {
                  'Content-Type' : 'Application/json'
                },
                body: JSON.stringify({...todo, isCompleted: ! todo.isCompleted })
              })
            .then(res => res.json())
            .then(result => {
              console.log(result._id);
               setTodos(oldTodos => oldTodos.map(x => x._id == result._id ? result : x))
            });
     }

  return (
    <section className="todo-list-container">
      <h1>Todo List</h1>

      <div className="add-btn-container">
        <button className="btn">+ Add new Todo</button>
      </div>

      <div className="table-wrapper">
        <table className="table">
          <thead>
            <tr>
              <th className="table-header-task">Task</th>
              <th className="table-header-status">Status</th>
              <th className="table-header-action">Action</th>
            </tr>
          </thead>
          <tbody>
                {todos.map(todo => <Todo key={todo._id} {...todo} onClick={todoClickHandler}/>)}
          </tbody>
        </table>
      </div>
    </section>
  );
};
