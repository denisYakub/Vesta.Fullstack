import React, { useState } from 'react';

export default function OrderForm() {
    const [form, setForm] = useState({
        senderCity: '',
        senderAddress: '',
        recipientCity: '',
        recipientAddress: '',
        cargoWeightKilograms: '',
        cargoCollectionDate: '',
    });

    const [error, setError] = useState('');
    const [success, setSuccess] = useState('');

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
        setError('');
        setSuccess('');
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        for (const key in form) {
            if (!form[key]) {
                setError('All fields are required');
                return;
            }
        }

        try {
            const response = await fetch('/api/vesta/order', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    senderCity: form.senderCity,
                    senderAddress: form.senderAddress,
                    recipientCity: form.recipientCity,
                    recipientAddress: form.recipientAddress,
                    cargoWeightKilograms: parseFloat(form.cargoWeightKilograms),
                    cargoCollectionDate: form.cargoCollectionDate,
                }),
            });

            if (response.ok) {
                setSuccess('Order created successfully');
                setForm({
                    senderCity: '',
                    senderAddress: '',
                    recipientCity: '',
                    recipientAddress: '',
                    cargoWeightKilograms: '',
                    cargoCollectionDate: '',
                });
            } else {
                setError('Error when creating an order');
            }
        } catch (err) {
            console.error(err);
            setError('Server unavailable');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Order Create</h2>

            <input name="senderCity" placeholder="Sender's city" value={form.senderCity} onChange={handleChange} required />
            <input name="senderAddress" placeholder="Sender's address" value={form.senderAddress} onChange={handleChange} required />
            <input name="recipientCity" placeholder="Recipient city" value={form.recipientCity} onChange={handleChange} required />
            <input name="recipientAddress" placeholder="Recipient's address" value={form.recipientAddress} onChange={handleChange} required />
            <input type="number" step="0.01" name="cargoWeightKilograms" placeholder="Cargo weight (kg)" value={form.cargoWeightKilograms} onChange={handleChange} required />
            <input type="date" name="cargoCollectionDate" placeholder="Date of cargo collection" value={form.cargoCollectionDate} onChange={handleChange} required />

            <button type="submit">Create an order</button>

            {error && <p style={{ color: 'red' }}>{error}</p>}
            {success && <p style={{ color: 'green' }}>{success}</p>}
        </form>
    );
}
