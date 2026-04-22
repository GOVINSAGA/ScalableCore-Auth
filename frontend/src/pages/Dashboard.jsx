import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../api/axios";

export default function Dashboard() {
    const [tasks, setTasks] = useState([]);
    const [title, setTitle] = useState("");
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
        const res = await api.get("/tasks");
        setTasks(res.data.data);
    };

    const addTask = async () => {
        await api.post("/tasks", { title });
        setTitle("");
        fetchTasks();
    };

    const deleteTask = async (id) => {
        await api.delete(`/tasks/${id}`);
        fetchTasks();
    };

    const updateTask = async (id) => {
        const newTitle = prompt("Enter new title");
        if (!newTitle) return;

        await api.put(`/tasks/${id}`, { title: newTitle });
        fetchTasks();
    };

    return (
        <div>
            <h2>Dashboard</h2>

            <input
                placeholder="Task title"
                value={title}
                onChange={(e) => setTitle(e.target.value)}
            />
            <button onClick={addTask}>Add</button>

            <ul>
                {tasks.map((t) => (
                    <li key={t.id}>
                        {t.title}
                        <button onClick={() => updateTask(t.id)}>Update</button>
                        <button onClick={() => deleteTask(t.id)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
}