import { useState } from 'react';
import styles from './App.module.css';

import CreateTask from './components/CreateTask.js'
import TaskList from "./components/TaskList.js";

function App() {
    const [tasks, setTask] = useState([
        {_id: 1, title: 'first',},
        {_id: 2, title: 'second',},
        {_id: 3, title: 'third',},
        {_id: 4, title: 'forth',},
    ]);

    const taskCreateHandler = (newTask) => {
        setTask(state => [
            ...state,
            { 
                _id: state[state.length-1]._id + 1,
                title: newTask
            }            
        ]);
    }

    const taskDeleteHandler = (taskId) => {
        setTask(state => 
            state.filter(x => x._id !== taskId));
    }

  return (
    <div className="App">
        <div className={styles['site-wrapper']}>
            <header>
                <h1>TODO App</h1>
            </header>

            <main>
                <TaskList tasks={tasks} taskDeleteHandler={taskDeleteHandler}/>
                <CreateTask taskCreateHandler={taskCreateHandler}/>
            </main>
        </div>
    </div>
  );
}

export default App;
