import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../api/axios";

export default function Dashboard() {
    const [tasks, setTasks] = useState([]);
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const navigate = useNavigate();
    const role = localStorage.getItem("role");
    const [loading, setLoading] = useState(false);
    const [message, setMessage] = useState("");


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
            alert("Failed to fetch tasks");
        }
    };

    const addTask = async () => {
        if (!title.trim() || !description.trim()) {
            alert("Title and Description required");
            return;
        }

        try {
            setLoading(true);

            await api.post("/tasks", {
                title,
                description
            });

            setMessage("Task added successfully"); // ✅ HERE
            setTitle("");
            setDescription("");
            fetchTasks();
        } catch (err) {
            console.error(err);
            alert("Failed to add task");
        } finally {
            setLoading(false);
        }
    };

    const deleteTask = async (id) => {
        try {
            await api.delete(`/tasks/${id}`);
            fetchTasks();
        } catch (err) {
            console.error(err);
            alert("Delete failed");
        }
    };

    const updateTask = async (id) => {
        const newTitle = prompt("Enter new title");
        const newDesc = prompt("Enter new description");

        if (!newTitle || !newDesc) return;

        try {
            await api.put(`/tasks/${id}`, {
                title: newTitle,
                description: newDesc
            });
            fetchTasks();
        } catch (err) {
            console.error(err);
            alert("Update failed");
        }
    };

    // 🔥 LOGOUT FUNCTION
    const handleLogout = () => {
        localStorage.removeItem("token");
        navigate("/login");
    };

    return (
        <div style={{ padding: "20px" }}>
            {/* 🔥 Header with Logout */}
            <div style={{ display: "flex", justifyContent: "space-between", alignItems: "center" }}>
                <div>
                    <h2>Dashboard</h2>
                    <h3>Logged in as: {role}</h3> {/* ✅ HERE */}
                </div>
                <button onClick={handleLogout}>Logout</button>

            </div>

            {message && <p style={{ color: "green" }}>{message}</p>}


            {loading && <p>Loading...</p>}

            {/* ✅ Add Task Section */}
            <div style={{ marginTop: "20px" }}>
                <input
                    placeholder="Task title"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                />

                <input
                    placeholder="Task description"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    style={{ marginLeft: "10px" }}
                />

                <button onClick={addTask} style={{ marginLeft: "10px" }}>
                    Add
                </button>
            </div>

            <ul style={{ marginTop: "20px" }}>
                {tasks.length === 0 ? (
                    <p>No tasks found</p>  // ✅ HERE
                ) : (
                    tasks.map((t) => (
                        <li key={t.id} style={{ marginBottom: "10px" }}>
                            <b>{t.title}</b> - {t.description}

                            <button onClick={() => updateTask(t.id)} style={{ marginLeft: "10px" }}>
                                Update
                            </button>

                            {/* 🔥 Role-based UI (optional) */}
                            {(role === "Admin" || true) && (
                                <button onClick={() => deleteTask(t.id)} style={{ marginLeft: "5px" }}>
                                    Delete
                                </button>
                            )}
                        </li>
                    ))
                )}
            </ul>
        </div>
    );
}