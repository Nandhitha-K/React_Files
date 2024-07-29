import React from 'react';
import { useNavigate } from 'react-router-dom';
import './Cart.css';

const Cart = ({ cart }) => {
    const navigate = useNavigate();

    return (
        <div className="cart-container">
            <h1>Shopping Cart</h1>
            {cart.length === 0 ? (
                <p>Your cart is empty</p>
            ) : (
                <div className="cart-items">
                    {cart.map((product, index) => (
                        <div key={index} className="cart-item">
                            <img src={product.imageUrl} alt={product.name} className="cart-item-image" />
                            <div className="cart-item-details">
                                <h3>{product.name}</h3>
                                <p>Price: ${product.price}</p>
                            </div>
                        </div>
                    ))}
                </div>
            )}
            <button className="back-button" onClick={() => navigate('/products')}>Back to Products</button>
        </div>
    );
};

export default Cart;
