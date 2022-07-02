import { useState } from "react"

export const Counter = (props) => {
    const [count, setCount] = useState(props.start || 0);
    const [direction, setDirection] = useState('None')

    const incristHeandler = () => {
        setCount(oldCount => oldCount + 1);
        setDirection('Increment');
    };
    
    const decreaseHeandler = () => {
        setCount(oldCount => oldCount - 1);
        setDirection('Decrement');
    };

    const clearHeandler = () => {
        setCount(0);
    };

    let title = '';

    if (count < 10) {
        title = 'Counter'
    }else if (count < 20) {
        title = 'Turbo Counter'
    }else if (count < 30){
        title = 'Mega Counter'
    }else {
        title = 'Giga Counter'
    }

    return (
        <div>
            <h1>{direction}: {title}</h1>
            <h2>{count}</h2>  
            <button onClick={decreaseHeandler}>-</button>
            <button onClick={clearHeandler}>Clear</button>
            <button onClick={incristHeandler}>+</button>
        </div>
    );
}