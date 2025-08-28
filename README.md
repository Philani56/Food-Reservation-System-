# 🍽️ Food Reservation System

A full-stack **ASP.NET Core MVC** application for managing food reservations.  
Users can browse menu items, make reservations, and download PDF confirmation slips.  
Admins can manage reservations, track statuses, and view the full reservation list.

---

## 🚀 Features

### 👤 User Features
- Browse menu items with images, descriptions, and prices.
- Make reservations online.
- Receive a **confirmation slip** (downloadable as PDF).
- Search reservations by name and check their **status** (Confirmed / Pending / Cancelled).
- Download proof of reservation for check-in.

### 🛠️ Admin Features
- Manage menu items (create, edit, delete).
- View and filter reservations (by name, email, phone, status).
- Update reservation status.
- Delete reservations.
- Dashboard view with search & filter.

---

## 🧑‍💻 Technologies Used
- **ASP.NET Core MVC** (C#)
- **Entity Framework Core** (SQL Server)
- **Bootstrap 5** for UI styling
- **LINQ & EF Queries** for search and filter functionality
- **Razor Views** for dynamic pages

---

## ⚡ How It Works
1. **Users** browse the menu and place reservations.  
2. After booking, they are redirected to a **confirmation page**.  
4. Using the **Find My Reservation** page, they can search by name and check their reservation status.  
5. **Admins** can view all reservations, update their statuses, and manage menu items.

## 🔑 Setup Instructions
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/food-reservation-system.git
   ```
2, Open the project in Visual Studio.

3. Update the connection string in appsettings.json to point to your SQL Server.

4. Run database migrations:

   ```bash
   dotnet ef database update
   ```

   ```bash
   dotnet run
   ```

## 🎯 Future Improvements
-Add user authentication (login & registration).
- Email notifications for confirmed reservations.
- Mobile-friendly PWA version.
- Analytics dashboard for admins.

## 👨‍💻 Author
- **Philani Khumalo**

### 📬 Contact
- 📧 Email: [your-email@example.com](mailto:khumalophilani580@gmail.com)  
- 💼 LinkedIn: [linkedin.com/in/philani-khumalo](https://www.linkedin.com/in/nhlakanipho-philani-khumalo-679726224/)  
- 🌐 Portfolio: [https://philani-portfolio.netlify.app/](https://philani-khumalo-portfolio.vercel.app/)  
- 💻 GitHub: [https://github.com/Philani56](https://github.com/Philani56)  

