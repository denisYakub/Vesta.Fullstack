import React, { useEffect, useState } from 'react';

export default function OrderListForm() {
    const [orders, setOrders] = useState([]);
    const [error, setError] = useState('');
    const [selectedOrder, setSelectedOrder] = useState(null);

    useEffect(() => {
        fetchOrders();
    }, []);

    const fetchOrders = async () => {
        try {
            const response = await fetch('/api/vesta/order');
            if (!response.ok) throw new Error('Error loading orders');
            const data = await response.json();
            setOrders(data);
        } catch (err) {
            console.error(err);
            setError('Failed to load orders');
        }
    };

    return (
        <div>
            <h2>List of orders</h2>
            {error && <p style={{ color: 'red' }}>{error}</p>}

            {orders.length === 0 ? (
                <p>No orders yet</p>
            ) : (
                <table border="1" cellPadding="8">
                    <thead>
                        <tr>
                            <th>Order number</th>
                            <th>Sender's city</th>
                            <th>Sender's address</th>
                            <th>Recipient city</th>
                            <th>Recipient's address</th>
                            <th>Weight (kg)</th>
                            <th>Collection date</th>
                        </tr>
                    </thead>
                    <tbody>
                        {orders.map((order) => (
                            <tr key={order.id} onClick={() => setSelectedOrder(order)} style={{ cursor: 'pointer' }}>
                                <td>{order.id}</td>
                                <td>{order.senderCity}</td>
                                <td>{order.senderAddress}</td>
                                <td>{order.recipientCity}</td>
                                <td>{order.recipientAddress}</td>
                                <td>{order.cargoWeightKilograms.toFixed(2)}</td>
                                <td>{order.cargoCollectionDate?.split('T')[0]}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}

            {selectedOrder && (
                <div style={{ marginTop: '20px', border: '1px solid gray', padding: '10px' }}>
                    <h3>Order Details</h3>
                    <p><strong>Order number:</strong> {selectedOrder.id}</p>
                    <p><strong>Sender's city:</strong> {selectedOrder.senderCity}</p>
                    <p><strong>Sender's address:</strong> {selectedOrder.senderAddress}</p>
                    <p><strong>Recipient city:</strong> {selectedOrder.recipientCity}</p>
                    <p><strong>Recipient's address:</strong> {selectedOrder.recipientAddress}</p>
                    <p><strong>Weight (kg):</strong> {selectedOrder.cargoWeightKilograms.toFixed(2)}</p>
                    <p><strong>Collection date:</strong> {selectedOrder.cargoCollectionDate?.split('T')[0]}</p>
                    <button onClick={() => setSelectedOrder(null)}>Close</button>
                </div>
            )}
        </div>
    );
}
