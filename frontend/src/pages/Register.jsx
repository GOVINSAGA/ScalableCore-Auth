import { useState } from "react";
import api from "../api/axios";

export default function Register() {
    const [data, setData] = useState({ name: "", email: "", password: "" });

    const handleRegister = async () => {
        try {
            await api.post("/auth/register", data);
            alert("Registered successfully");
        } catch {
            alert("Error");
        }
    };

    return (
        <div>
            <h2>Register</h2>
            <input placeholder="Name" onChange={(e) => setData({ ...data, name: e.target.value })} />
            <input placeholder="Email" onChange={(e) => setData({ ...data, email: e.target.value })} />
            <input type="password" placeholder="Password" onChange={(e) => setData({ ...data, password: e.target.value })} />
            <button onClick={handleRegister}>Register</button>
        </div>
    );
}