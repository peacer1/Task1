# Task1 - ASP.NET Core Web API

## Περιγραφή

Το Task1 είναι ένα Web API που διαχειρίζεται Πελάτες (Customers), Παραγγελίες (Orders) και Προϊόντα (Products).

Το API χρησιμοποιεί την αρχιτεκτονική CQRS με MediatR, διαχωρίζοντας τα Commands (μεταβλητές ενέργειες) από τα Queries (ανακτήσεις δεδομένων).

## Τεχνολογίες που χρησιμοποιήθηκαν

- ASP.NET Core 8 Web API
- Entity Framework Core με SQLite
- MediatR (CQRS Pattern)
- Swagger UI για τεκμηρίωση και δοκιμές
- Visual Studio / Rider / VS Code

## 🔧 Δομή Υλοποίησης

1. **Domain Layer**:
   - Ορισμός των βασικών οντοτήτων (`Customer`, `Order`, `Product`, `Item`)
   - Interfaces για repositories (π.χ. `ICustomerRepository`)

2. **Application Layer**:
   - Ορισμός όλων των `Commands` (Create, Update, Delete)
   - Ορισμός όλων των `Queries` (GetById, GetAll, GetByCustomerId, κ.ά.)
   - Handlers για κάθε command/query με χρήση MediatR

3. **Infrastructure Layer**:
   - EF Core DbContext (`AppDbContext`)
   - Υλοποίηση των Repositories
   - Unit of Work Pattern

4. **API Layer**:
   - `Controllers` για κάθε οντότητα: `CustomersController`, `OrdersController`, `ProductsController`
   - Swagger για δοκιμές
   - Εγγραφή υπηρεσιών, EF, MediatR κ.λπ.


## Παραδοχές

- Κάθε παραγγελία σχετίζεται με υπαρκτό πελάτη
- Το TotalPrice υπολογίζεται κατά τη δημιουργία της παραγγελίας
- Τα προϊόντα σε μια παραγγελία είναι ενεργά και υπαρκτά
- Οι τιμές των προϊόντων δεν αλλάζουν για παραγγελίες που έχουν ήδη καταχωρηθεί
- Δεν χρησιμοποιήθηκε authentication/authorization
- Τα δεδομένα εισάγονται χειροκίνητα μέσω Swagger (test)

---

## Οδηγίες για δοκιμή

1. **Run το API**:
   ```dotnet run --project Task1.API```
