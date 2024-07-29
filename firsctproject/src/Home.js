import React, { useState } from 'react';
import './App.css';
import { BrowserRouter as Router, Routes, Route, useLocation } from 'react-router-dom';
import Register from './Register';
import Login from './Login';
import ProductsList from './Product/Product-Home';
import ProductCreate from './Product/Product-Create';
import { Link } from 'react-router-dom';
import Cart from './Product/Cart';

function Home() {
  return (
    <Router>
      <Main />
    </Router>
  );
}

function Main() {
  const location = useLocation();
  const hideButtons = ['/login', '/register', '/products', '/create-product','/cart'].includes(location.pathname);
  const [cart, setCart] = useState([]);

  return (
    <div className="Home">
      {!hideButtons && (
        <div className="buttons-container">
          <Link to="/login">
            <button className="nav-button">Login</button>
          </Link>
          <Link to="/register">
            <button className="nav-button">Register</button>
          </Link>
        </div>
      )}
      <Routes>
        <Route path="/register" element={<Register />} />
        <Route path="/login" element={<Login />} />
        <Route path="/products" element={<ProductsList cart={cart} setCart={setCart} />} />
        <Route path="/create-product" element={<ProductCreate />} />
        <Route path="/cart" element={<Cart cart={cart} />} />
      </Routes>
    </div>
  );
}

export default Home;
