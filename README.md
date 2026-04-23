# 🚀 Scalable REST API with Authentication & Task Management

This project is a full-stack application built as part of a backend developer assignment. It demonstrates secure API development, JWT-based authentication, role-ready architecture, and deployment using Docker, CI/CD, and OCI cloud.

---

## 📌 Features

### 🔐 Authentication & Security
- User Registration & Login
- Password hashing (BCrypt)
- JWT-based authentication
- Protected APIs using `[Authorize]`
- Global exception handling middleware

---

### 📋 Task Management (CRUD)
- Create Task
- Get All Tasks
- Update Task
- Delete Task

---

### 🧱 Backend Architecture
- ASP.NET Core Web API
- Clean architecture (Controller → Service → Repository)
- DTO-based validation
- Entity Framework Core (Code First)
- PostgreSQL database

---

### 🌐 Frontend
- React (Vite)
- Login & Register pages
- Protected Dashboard
- CRUD operations connected to backend APIs
- JWT stored in localStorage
- Axios interceptor for token handling

---

### 📦 DevOps & Deployment
- Dockerized backend, frontend, and database
- Docker Compose for multi-container setup
- GitHub Actions CI/CD pipeline
- Deployed on Oracle Cloud Infrastructure (OCI)

---

## 🛠️ Tech Stack

**Backend**
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- JWT Authentication

**Frontend**
- React (Vite)
- Axios

**DevOps**
- Docker & Docker Compose
- GitHub Actions
- OCI (Ubuntu VM)

---

## ⚙️ Setup Instructions

### 🔹 Clone the Repository

```bash
git clone https://github.com/GOVINSAGA/ScalableCore-Auth.git
cd ScalableCore-Auth

🔹 Run with Docker
docker-compose up --build
🔹 Access Application
Service	URL
Frontend	http://localhost:3000

Backend API	http://localhost:5002

Swagger	http://localhost:5002/swagger
🔐 API Authentication
Register a user
Login to get JWT token
Use token in requests:
Authorization: Bearer <your_token>
📖 API Documentation

Swagger UI available at:

http://localhost:5002/swagger

Supports JWT authorization for testing protected APIs.

🧠 Project Structure
BackendAPI/
├── Controllers/
├── Services/
├── Repositories/
├── DTOs/
├── Models/
├── Middleware/
└── Program.cs

frontend/
├── src/
│   ├── pages/
│   ├── api/
│   └── components/
🚀 CI/CD Pipeline
On every push to master:
Docker images are built
Images pushed to Docker Hub
OCI VM pulls latest images
Containers updated automatically
🌍 Live Deployment

Frontend:

http://129.159.226.234:3000

Backend:

http://129.159.226.234:5002
📌 Future Improvements
Role-based access (Admin/User)
Redis caching
Logging (Serilog)
Rate limiting
HTTPS + domain setup
👨‍💻 Author

Govind

⭐ Notes

This project demonstrates:

Secure backend design
Scalable architecture
Full-stack integration
Cloud deployment readiness
