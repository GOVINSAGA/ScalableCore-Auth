import { useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../api/axios";

export default function Register() {
    const [data, setData] = useState({
        name: "",
        email: "",
        password: "",
    });

    const navigate = useNavigate();

    const handleRegister = async () => {
        try {
            await api.post("/auth/register", data);
            alert("Registered successfully");
            navigate("/login");   // redirect
        } catch (err) {
            console.error(err);
            alert("Registration failed");
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