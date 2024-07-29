import React from "react"
import { useState } from "react"
import { FaTrashAlt } from "react-icons/fa";
const Content = () => {
    const [items]=useState(
        [
            {
                id:1,
                checked:true,
                item:"Coding",
            },
            {
                id:2,
                checked:true,
                item:"Playing",
            },
            {
                id:3,
                checked:true,
                item:"Writing",
            } 
        ]
    );
  return (
    <main>
        <ul>
            {items.map((item)=>(
                <li className="item" key={item.id}>
                    <input type="checkbox"
                    checked={item.checked}/>
                    <label>{item.item}</label>
                    <FaTrashAlt role="button" tabIndex="0"/>
                </li>
            ))
            }
        </ul>
    </main>
  )
}

export default Content;