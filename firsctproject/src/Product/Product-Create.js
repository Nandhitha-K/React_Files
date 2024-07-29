import React, { useState } from 'react';
import axios from 'axios';
import './Product-Create.css'; // Import the CSS file
import { useNavigate } from 'react-router-dom';

const ProductCreate = () => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [price, setPrice] = useState('');
  const [imageUrl, setImageUrl] = useState('');
  const [message, setMessage] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    
    const newProduct = {
      name,
      description,
      price: parseFloat(price),
      imageUrl
    };

    try {
      const response = await axios.post('http://localhost:5085/api/Product', newProduct);
      setMessage(response.data.message);
      navigate('/products')
      // Optionally, you can redirect or handle success as needed
    } catch (error) {
      setMessage('An error occurred. Please try again.');
      console.error(error);
    }
  };

  return (
    <div className="product-create-container">
      <h2>Add New Product</h2>
      <form onSubmit={handleSubmit} className="product-create-form">
        <div className="form-group">
          <label htmlFor="name">Name:</label>
          <input
            type="text"
            id="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="description">Description:</label>
          <textarea
            id="description"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="price">Price:</label>
          <input
            type="number"
            id="price"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="imageUrl">Image URL:</label>
          <input
            type="text"
            id="imageUrl"
            value={imageUrl}
            onChange={(e) => setImageUrl(e.target.value)}
          />
        </div>
        <button type="submit" className="submit-button">Add Product</button>
      </form>
      {message && <p className="message">{message}</p>}
    </div>
  );
};

export default ProductCreate;
