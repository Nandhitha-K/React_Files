import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './Product-Home.css';
import Modal from 'react-modal';

Modal.setAppElement('#root');

const ProductsList = ({ cart, setCart }) => {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [selectedProduct, setSelectedProduct] = useState(null);
    const [productDetailsModalIsOpen, setProductDetailsModalIsOpen] = useState(false);
    const [modalIsOpen, setModalIsOpen] = useState(false);
    const [deleteModalIsOpen, setDeleteModalIsOpen] = useState(false);
    const [updatedProduct, setUpdatedProduct] = useState({
        name: '',
        description: '',
        price: '',
        imageUrl: ''
    });
    const navigate = useNavigate();

    // Function to handle adding product to cart
    const handleAddToCart = (product) => {
        setCart([...cart, product]);
    };

    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const response = await axios.get('http://localhost:5085/api/Product');
                setProducts(response.data);
            } catch (err) {
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        fetchProducts();
    }, []);

    const openModal = (product) => {
        setSelectedProduct(product);
        setUpdatedProduct(product);
        setModalIsOpen(true);
    };

    const closeModal = () => {
        setModalIsOpen(false);
        setSelectedProduct(null);
    };

    const openDeleteModal = (product) => {
        setSelectedProduct(product);
        setDeleteModalIsOpen(true);
    };

    const closeDeleteModal = () => {
        setDeleteModalIsOpen(false);
        setSelectedProduct(null);
    };

    const openProductDetailsModal = (product) => {
        setSelectedProduct(product);
        setProductDetailsModalIsOpen(true);
    };

    const closeProductDetailsModal = () => {
        setProductDetailsModalIsOpen(false);
        setSelectedProduct(null);
    };

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setUpdatedProduct({ ...updatedProduct, [name]: value });
    };

    const handleUpdateProduct = async () => {
        try {
            await axios.put(`http://localhost:5085/api/Product/${selectedProduct.productId}`, updatedProduct);
            setProducts(products.map(p => p.productId === selectedProduct.productId ? updatedProduct : p));
            closeModal();
        } catch (err) {
            setError('Failed to update product.');
        }
    };

    const handleDeleteProduct = async () => {
        try {
            await axios.delete(`http://localhost:5085/api/Product/${selectedProduct.productId}`);
            setProducts(products.filter(p => p.productId !== selectedProduct.productId));
            closeDeleteModal();
        } catch (err) {
            setError('Failed to delete product.');
        }
    };

    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error: {error}</p>;

    return (
        <div className="products-list">
            <header className="products-header">
                <h1>Products</h1>
                <button className="cart-button" onClick={() => navigate('/cart')}>
                    CART
                </button>
            </header>
            <button className="add-product-button" onClick={() => navigate('/create-product')}>
                Add New Product
            </button>
            <div className="products-grid">
                {products.map(product => (
                    <div className="product-card" key={product.productId} onClick={() => openProductDetailsModal(product)}>
                        <h3>{product.name}</h3>
                        <p>Price: ${product.price}</p>
                        {product.imageUrl && <img src={product.imageUrl} alt={product.name} />}
                    </div>
                ))}
            </div>
            <Modal
                isOpen={productDetailsModalIsOpen}
                onRequestClose={closeProductDetailsModal}
                className="Modal"
                overlayClassName="Overlay"
                contentLabel="Product Details"
            >
                {selectedProduct && (
                    <>
                        <h2>{selectedProduct.name}</h2>
                        <p>{selectedProduct.description}</p>
                        <p>Price: ${selectedProduct.price}</p>
                        <div className="button-group">
                            <button onClick={() => { closeProductDetailsModal(); openModal(selectedProduct); }}>Edit</button>
                            <button onClick={() => { closeProductDetailsModal(); openDeleteModal(selectedProduct); }}>Delete</button>
                            <button onClick={() => handleAddToCart(selectedProduct)}>Add to Cart</button>
                            <button onClick={closeProductDetailsModal}>Close</button>
                        </div>
                    </>
                )}
            </Modal>
            <Modal
                isOpen={modalIsOpen}
                onRequestClose={closeModal}
                className="Modal"
                overlayClassName="Overlay"
                contentLabel="Update Product"
            >
                <h2>Update Product</h2>
                <form className="update-product-form">
                    <div className="form-group">
                        <label>Name:</label>
                        <input
                            type="text"
                            name="name"
                            value={updatedProduct.name}
                            onChange={handleInputChange}
                        />
                    </div>
                    <div className="form-group">
                        <label>Description:</label>
                        <input
                            type="text"
                            name="description"
                            value={updatedProduct.description}
                            onChange={handleInputChange}
                        />
                    </div>
                    <div className="form-group">
                        <label>Price:</label>
                        <input
                            type="number"
                            name="price"
                            value={updatedProduct.price}
                            onChange={handleInputChange}
                        />
                    </div>
                    <div className="form-group">
                        <label>Image URL:</label>
                        <input
                            type="text"
                            name="imageUrl"
                            value={updatedProduct.imageUrl}
                            onChange={handleInputChange}
                        />
                    </div>
                    <div className="button-group">
                        <button type="button" onClick={handleUpdateProduct} className="save-button">Save</button>
                        <button type="button" onClick={closeModal} className="cancel-button">Cancel</button>
                    </div>
                </form>
            </Modal>
            <Modal
                isOpen={deleteModalIsOpen}
                onRequestClose={closeDeleteModal}
                className="Modal"
                overlayClassName="Overlay"
                contentLabel="Delete Product"
            >
                <h2>Are you sure you want to delete this product?</h2>
                <div className="button-group">
                    <button type="button" onClick={handleDeleteProduct} className="delete-button">Yes</button>
                    <button type="button" onClick={closeDeleteModal} className="cancel-button">No</button>
                </div>
            </Modal>
        </div>
    );
};

export default ProductsList;
