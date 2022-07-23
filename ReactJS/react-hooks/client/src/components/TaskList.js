import { useContext } from 'react';
import TaskContexts from '../contexts/TaskContexts.js';

import TaskItem from './TaskItem.js'

const TaskList = () => {
    let {tasks} = useContext(TaskContexts);

    return (
        <ul>
            {tasks.map(x => 
                <TaskItem 
                    key={x._id} 
                    task={x}                     
                />
            )}
        </ul>
    );
};

export default TaskList;