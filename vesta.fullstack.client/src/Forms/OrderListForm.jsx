import React, { useEffect, useState } from 'react';

export default function OrderListForm() {
    const [orders, setOrders] = useState([]);
    const [error, setError] = useState('');

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
                            <tr key={order.id}>
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
        </div>
    );
}
