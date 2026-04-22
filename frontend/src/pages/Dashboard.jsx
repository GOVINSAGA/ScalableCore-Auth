import { useEffect, useState } from "react";
import api from "../api/axios";

export default function Dashboard() {
    const [tasks, setTasks] = useState([]);
    const [title, setTitle] = useState("");

    const fetchTasks = async () => {
        const res = await api.get("/tasks");
        setTasks(res.data.data);
    };

    const addTask = async () => {
        await api.post("/tasks", { title });
        fetchTasks();
    };

    const deleteTask = async (id) => {
        await api.delete(`/tasks/${id}`);
        fetchTasks();
    };

    useEffect(() => {
        fetchTasks();
    }, []);

    return (
        <div>
            <h2>Dashboard</h2>

            <input placeholder="Task title" onChange={(e) => setTitle(e.target.value)} />
            <button onClick={addTask}>Add</button>

            <ul>
                {tasks.map((t) => (
                    <li key={t.id}>
                        {t.title}
                        <button onClick={() => deleteTask(t.id)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
}