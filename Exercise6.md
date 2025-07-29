# Exercise 6
Assuming that the method parameters from task 3 are fetched directly from the database. Do 
you know any ways to optimize the number of SQL queries in such cases? List 
and briefly describe each of them.

1. **Rate Limiter** - This limits the number of user queries, preventing the database from being overloaded with unnecessary requests.

2. **Redis (In-memory database)** - A very fast database operating in RAM. It allows us to fetch data once directly from the main database and then insert the record into Redis to quickly read values later reducing the load on the main database.

3. **Database-side caching** - PostgreSQL provides an option to cache query results directly within the database.

# Zadanie 6

Zakładając, że parametry metody z zadania 3 pobieramy bezpośrednio z bazy danych. Czy
znasz jakieś sposoby na optymalizację liczby zapytań SQL w tego typu przypadkach? Wymień
i opisz krótko każdy z nich.

1. **Rate Limiter** - Ograniczamy w ten sposób ilosc zapytan uzytkownikow przez ci nie obciazaja bazy danych niepotrzebnymi zapytaniami.

2. **Redis (Baza danych w pamięci ramu)** - Bardzo szybka baza danych działająca w ramie. Dzięki niej mozemy raz zaciągnąć dane bezposrednio z bazy danych by nastepnie wstawic rekord do redisa by w szybki sposob odczytac wartosci odciazajac główną bazę.

3. **Cache po stronie bazy danych** - PostgreSQL dostarcza opcję cachowania wyników zapytań do bazy danych.
