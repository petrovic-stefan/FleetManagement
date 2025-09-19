# FleetManagement 🚚

FleetManagement je aplikacija za upravljanje voznim parkom.  
Sastoji se od **API-ja (ASP.NET Core)** i **desktop aplikacije (WinForms)**.


napiši kao **listu sa uvučenim tačkama**:

```markdown
## 📦 Struktura projekta

- **Api/** – ASP.NET Core Web API
- **Desktop/** – WinForms desktop aplikacija
- **Domain/** – Entiteti (Vehicle, Driver, Maintenance, Expense, Assignment)
- **Infrastructure/** – EF Core DbContext i Seed podaci


## 🚀 Funkcionalnosti
- Upravljanje vozilima (dodavanje, izmena, brisanje, pregled VIN-a, kilometraže…)
- Evidencija održavanja (maintenance) sa validacijom kilometraže
- Troškovi (expenses) u evrima
- Dodela vozača vozilima (assignments)
- Izveštaji (potrošnja goriva, top vozila sa najviše servisa…)
- Desktop notifikacije za servisni interval

## 🛠️ Tehnologije
- .NET 8
- ASP.NET Core Web API
- WinForms
- Entity Framework Core
- SQL Server

## ⚙️ Pokretanje
1. Kloniraj repo:
   ```bash
   git clone https://github.com/petrovic-stefan/FleetManagement.git
Otvori FleetManagement.sln u Visual Studio 2022+

Pokreni Api projekat → podesi konekciju u appsettings.json

Pokreni Desktop projekat → testiraj aplikaciju

👤 Autor
https://github.com/petrovic-stefan
