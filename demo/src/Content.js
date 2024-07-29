import React from "react";
import { useState } from "react";
 
const Content = () => {

    function handleNameChange(){
        const names=["Nandy","Navee","Bala"];
        const int=Math.floor(Math.random()*3);
        setName(names[int]);
    }
  const [count,setCount]=useState(99);
  const [name,setName]=useState("Bala");
  function incrementFunction(){
    setCount(count+1) 
  }
  function decrementFunction(){
    setCount(count-1)
  }
  return (
    <main>
    <p>Welcome {name}</p>
    <button onClick={handleNameChange} >Hello </button>
    <button onClick={incrementFunction}>+</button>
    <span>{count}</span>
    <button onClick={decrementFunction} >-</button>
    </main>
  )
}

export default Content