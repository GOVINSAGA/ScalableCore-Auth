import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../api/axios";

export default function Dashboard() {
    const [tasks, setTasks] = useState([]);
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState(""); // ✅ NEW
    const navigate = useNavigate();

    useEffect(() => {
        const token = localStorage.getItem("token");
        if (!token) {
            navigate("/login");
        } else {
            fetchTasks();
        }
    }, []);

    const fetchTasks = async () => {
        try {
            const res = await api.get("/tasks");
            setTasks(res.data.data);
        } catch (err) {
            console.error(err);
        }
    };

    const addTask = async () => {
        if (!title.trim() || !description.trim()) {
            alert("Title and Description required");
            return;
        }

        try {
            await api.post("/tasks", {
                title,
                description // ✅ FIXED
            });

            setTitle("");
            setDescription("");
            fetchTasks();
        } catch (err) {
            console.error(err);
            alert("Failed to add task");
        }
    };

    const deleteTask = async (id) => {
        try {
            await api.delete(`/tasks/${id}`);
            fetchTasks();
        } catch (err) {
            console.error(err);
        }
    };

    const updateTask = async (id) => {
        const newTitle = prompt("Enter new title");
        const newDesc = prompt("Enter new description");

        if (!newTitle || !newDesc) return;

        try {
            await api.put(`/tasks/${id}`, {
                title: newTitle,
                description: newDesc // ✅ FIXED
            });
            fetchTasks();
        } catch (err) {
            console.error(err);
        }
    };

    return (
        <div>
            <h2>Dashboard</h2>

            {/* ✅ Inputs */}
            <input
                placeholder="Task title"
                value={title}
                onChange={(e) => setTitle(e.target.value)}
            />

            <input
                placeholder="Task description"
                value={description}
                onChange={(e) => setDescription(e.target.value)}
            />

            <button onClick={addTask}>Add</button>

            {/* ✅ Task list */}
            <ul>
                {tasks.map((t) => (
                    <li key={t.id}>
                        <b>{t.title}</b> - {t.description}
                        <button onClick={() => updateTask(t.id)}>Update</button>
                        <button onClick={() => deleteTask(t.id)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
}