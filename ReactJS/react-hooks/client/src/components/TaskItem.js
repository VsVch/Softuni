import { useEffect, useContext, useState } from "react";
import TaskContexts from "../contexts/TaskContexts.js";

import style from "../components/TaskItem.module.css";

const TaskItem = ({ task }) => {
  const [isEdit, setIsEdit] = useState(false);
  const { taskDeleteHandler, toggleTask, taskEditHandler} = useContext(TaskContexts);

  useEffect(() => {
    // console.log('Mount');

    return () => {
      // console.log('Unmount');
    };
  }, []);

  const taskEditClickHandler = () => {
    setIsEdit(true);
  };

  const classNames = [
    task.isCompleted ? style.completed : "",
    style["task-item"],
  ];

  const onEdit = (e) => {
    e.preventDefault();
    const {title} = Object.fromEntries(new FormData(e.target));
    taskEditHandler(task, title);
    setIsEdit(false);
  };

  const taskTitle = (
    <>
      <span className={classNames.join(" ")} onClick={() => toggleTask(task)}>
        {task.title}
      </span>
      <button onClick={() => taskDeleteHandler(task._id)}>x</button>
      <button onClick={() => taskEditClickHandler(task._id)}>edit</button>
    </>
  );

  const editTask = (
    <form onSubmit={onEdit}>
      <input type="text" name="title" defaultValue={task.title} />
      <input type="submit" value="edit" />
    </form>
  );

  return <li>{isEdit ? editTask : taskTitle}</li>;
};

export default TaskItem;
