import {useState} from 'react'

const CreateTask = ({taskCreateHandler}) => {
    const [task, setTask] = useState('');

    const onSubmit = (e) => {
        e.preventDefault();
        
        taskCreateHandler(task)
        setTask('');
    };

    const onChange = (e) => {
        setTask(e.target.value)
    }

    return (
        <form onSubmit={onSubmit}>
            <input type="text" name="taskName" onChange={onChange} value={task} plaseholder="Do the dishes"/>
            <button type="submit">Submit</button>
        </form>
    );
};

export default CreateTask;