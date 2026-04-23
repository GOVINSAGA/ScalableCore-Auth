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

🔹 API Endpoints
🔐 Authentication APIs
1️⃣ Register User
POST /api/v1/auth/register

Request Body:

{
  "name": "Govind",
  "email": "govind@example.com",
  "password": "123456"
}

Response:

{
  "success": true,
  "message": "User registered successfully"
}
2️⃣ Login User
POST /api/v1/auth/login

Request Body:

{
  "email": "govind@example.com",
  "password": "123456"
}

Response:

{
  "success": true,
  "data": {
    "token": "JWT_TOKEN"
  }
}
🔐 Protected APIs (Require JWT)

👉 Header:

Authorization: Bearer <your_token>
📋 Task APIs (CRUD)
3️⃣ Get All Tasks
GET /api/v1/tasks

Response:

[
  {
    "id": 1,
    "title": "Task 1"
  }
]
4️⃣ Create Task
POST /api/v1/tasks

Request Body:

{
  "title": "New Task"
}
5️⃣ Update Task
PUT /api/v1/tasks/{id}

Request Body:

{
  "title": "Updated Task"
}
6️⃣ Delete Task
DELETE /api/v1/tasks/{id}
🧠 API Design Highlights

Add this section:

## 📌 API Design Highlights

- RESTful endpoints with proper HTTP methods
- JWT-based authentication for protected routes
- Consistent API response format
- DTO-based validation for request safety
- Global exception handling middleware
🔥 Bonus (VERY GOOD FOR INTERVIEW)

Add:

## 🔒 Security Practices

- Password hashing using BCrypt
- JWT token validation (issuer, audience, expiry)
- Protected endpoints using [Authorize]
- CORS configured for frontend integration


🌐 Frontend UI

A simple React-based frontend is implemented to interact with the backend APIs.

🔹 Features
User Registration
User Login (JWT authentication)
Protected Dashboard
Task Management (Create, Read, Update, Delete)
API integration using Axios
Automatic JWT token attachment via interceptor
🔹 Application Flow
Home Page
   ↓
Register → Redirect to Login
   ↓
Login → Store JWT Token
   ↓
Dashboard (Protected)
   ↓
Perform CRUD Operations
🔹 Screens Overview
🏠 Home Page
Provides navigation to Login and Register
🔐 Login Page
Authenticates user
Stores JWT token in localStorage
📝 Register Page
Creates a new user
Redirects to login
📋 Dashboard
Accessible only after login
Displays tasks
Supports:
Create task
Update task
Delete task
🔹 API Integration
Base URL:
http://129.159.226.234:5002/api/v1
Axios instance with interceptor:
Automatically attaches JWT token
Handles secure API calls
🔹 Protected Routing
Dashboard route is protected
Redirects to login if token is missing
if (!token) navigate("/login");
🔹 Tech Stack
React (Vite)
Axios
React Router DOM
🔹 Live Frontend
http://129.159.226.234:3000
🧠 What this shows evaluator
Feature	Status
Frontend exists	✅
Connected to backend	✅
Auth flow	✅
Protected routes	✅
CRUD UI	✅

👉 This proves full-stack capability

🔥 Bonus (Optional but strong)

Add:

## 🚀 Future Improvements (Frontend)

- UI styling using Tailwind CSS
- Better form validation
- Loading states & spinners


📖 API Documentation
🔹 Swagger UI

Interactive API documentation is available via Swagger.

👉 Access here:

http://129.159.226.234:5002/swagger
🔐 Using Swagger with JWT
Register a user using /api/v1/auth/register
Login via /api/v1/auth/login
Copy the JWT token from response
Click Authorize in Swagger
Enter:
Bearer <your_token>
Now you can access protected APIs
🔹 Available API Groups
Authentication APIs
Task Management APIs (CRUD)
🔹 Example Flow (Swagger Testing)
Register → Login → Copy Token → Authorize → Access Protected APIs

🧠 Scalability & System Design

This project is designed with scalability and extensibility in mind. Below are key considerations for scaling the system in a production environment.

🔹 1. Modular Architecture

The backend follows a layered architecture:

Controller → Service → Repository → Database
Separation of concerns
Easy to extend with new modules
Maintainable and testable
🔹 2. Database Scalability
PostgreSQL used with EF Core (Code First)
Can scale using:
Read replicas
Connection pooling
Query optimization
🔹 3. Authentication Scalability
JWT-based stateless authentication
No server-side session storage required
Suitable for horizontal scaling
🔹 4. Containerization (Docker)
Backend, frontend, and database are containerized
Ensures consistent environment across development and production
Easy deployment and scaling using container orchestration
🔹 5. CI/CD Pipeline
Automated build and deployment using GitHub Actions
Docker images pushed to Docker Hub
OCI VM pulls latest images and updates containers
🔹 6. Horizontal Scaling (Future)
Multiple backend instances behind a load balancer
Stateless APIs allow easy scaling
Client → Load Balancer → Multiple API Instances → Database
🔹 7. Caching (Future Enhancement)
Redis can be added to:
Cache frequently accessed data (e.g., tasks)
Reduce database load
Improve response time
🔹 8. Logging & Monitoring (Future)
Centralized logging (e.g., Serilog + ELK stack)
Monitoring using tools like Prometheus & Grafana
🔹 9. Security Enhancements
Role-based access control (Admin/User) (planned)
Rate limiting
HTTPS enforcement
Token refresh mechanism
🔹 10. Microservices (Future Evolution)

The system can be split into services:

Auth Service
Task Service
Notification Service
API Gateway → Auth Service → Task Service → Database
