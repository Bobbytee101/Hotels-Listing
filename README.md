# HOTEL LISTING REST API
This project is a RESTful API for managing hotel listings, bookings, reviews, and payments. It provides endpoints for creating, updating, deleting, and retrieving hotel information, as well as functionalities for user authentication and authorization.

# FEATURES
Authentication: JWT-based authentication for secure access to the API.
Hotel Management: CRUD operations for hotels, including name, description, address, and amenities.
User Management: User registration and authentication with roles (e.g., admin, user).
Booking Management: Ability to book hotels for specific dates and room types.
Review Management: Allow users to leave reviews for hotels they have booked.
Payment Integration: Integration with payment gateways for processing hotel bookings.
Technologies Used
ASP.NET Core: Backend framework for building the API.
Entity Framework Core: Object-relational mapping (ORM) for interacting with the database.
JWT: JSON Web Tokens for authentication.
Swagger: API documentation and testing.
SQLite: Lightweight database for development.


# INSTALLATION AND SETUP
Clone the repository: git clone https://github.com/Bobbytee101/hotel-listing-api.git
Navigate to the project directory: cd hotel-listing-api
Install dependencies: dotnet restore
Run the API: dotnet run
Access the API documentation and test the endpoints: https://localhost:5001/swagger
API Endpoints
GET /api/hotels: Get all hotels.
GET /api/hotels/{id}: Get a specific hotel by ID.
POST /api/hotels: Create a new hotel.
PUT /api/hotels/{id}: Update a hotel.
DELETE /api/hotels/{id}: Delete a hotel.
POST /api/auth/register: Register a new user.
POST /api/auth/login: Login and get a JWT token.
POST /api/bookings: Create a new booking.
GET /api/bookings/{id}: Get a specific booking by ID.
GET /api/bookings/user/{userId}: Get all bookings for a specific user.
POST /api/reviews: Create a new review.
GET /api/reviews/{id}: Get a specific review by ID.
GET /api/reviews/hotel/{hotelId}: Get all reviews for a specific hotel.
POST /api/payments: Process a payment for a booking.


# CONFIGURATION
JWT Configuration: Set the JWT secret key and token expiration in the appsettings.json file.
Database Configuration: Configure the database connection string in the appsettings.json file.
Contributing
Contributions are welcome! Please fork the repository and create a pull request with your changes.

# LICENSE
This project is licensed under the MIT License. See the LICENSE file for more information.
