import React, { useState } from 'react'

const UseState = () => {
const [count,setCount]=useState(10);
  return (
    <div>
    <button onClick={()=>setCount(count=>count+1)}>+</button>
    <div>Count:{count}</div>
    </div>
    
  )
}

export default UseState
