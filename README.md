# Hotel POS system


# Definition of Done
- All code needs to be audited by all members present
- All code needs to be added to the presentation document
- All members present needs to understand what is being done
- Code needs to follow coding standards
- Code needs to be commented
- Code needs to pass tests

# Coding Standards
[Link to C# code standards](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)

# IDE
- Visual Studio 2022
    ## Dependencies
    - WinForms

# Backend
We use SQLite for our database. To edit the database, we use [DB Browser](https://sqlitebrowser.org/dl/). 

# Setup
- Launch program
- Close program
- In DB Browser, open the databse located in the *hotel_database* folder in *documents*. 
- Add room types, then rooms (rate is inserted as ören.) 
- Write changes.
- When the *PAY*-button is clicked a receipt is saved in the *hotel-receipts* folder located in *documents*.

# Current known bugs
- Paid bookings listview columns are out of order.
- Unpaid bookings listview, firstname and lastname are in reverse order.
- While editing a booking, the current bookings room doesn't show in the avalible rooms listview. 
- Occupied rooms listview doesn't update. 

# What to do next?
- Fix bugs
- System for keys
- High season/low season
- Discounts
- Tests
- Fix warnings?