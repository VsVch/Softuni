import { useEffect, useState } from "react";
import styles from "./Book.module.css";

export const Book = (props) => {
  const [highlited, setHighlited] = useState(false);
  const [deleted, setDelited] = useState(false);

  useEffect(() => {
    console.log("Mounting" + " " + props.book.title);
  }, [deleted]);

  useEffect(() => {
    console.log("Updating" + " " + props.book.title);
  }, [highlited]);

  const clickHandler = () => {
    setHighlited((state) => !state);
  };

  const deleteHandler = () => {
    setDelited(true);
  };

  let style = {};

  if (highlited) {
    style.backgroundColor = "blue";
  }

  if (deleted) {
    return <h2>Deleted</h2>;
  }

  return (
    <li className={styles["book-item"]} style={style}>
      <header>Title: {props.book.title}</header>
      <div>Description: {props.book.description}</div>
      <footer>
        <span className={styles.author}>Author: {props.book.author}</span> 
        <button onClick={clickHandler}>Highlit</button>
        <button onClick={deleteHandler}>Delete</button>
      </footer>
    </li>
  );
};
