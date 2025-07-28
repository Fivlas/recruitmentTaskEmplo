# Zadanie 6

Zakładając, że parametry metody z zadania 3 pobieramy bezpośrednio z bazy danych. Czy
znasz jakieś sposoby na optymalizację liczby zapytań SQL w tego typu przypadkach? Wymień
i opisz krótko każdy z nich.

1. **Rate Limiter** - Ograniczamy w ten sposób ilosc zapytan uzytkownikow przez ci nie obciazaja bazy danych niepotrzebnymi zapytaniami

2. **Redis (Baza danych w pamięci ramu)** - Bardzo szybka baza danych działająca w ramie. Dzięki niej mozemy raz zaciągnąć dane bezposrednio z bazy danych by nastepnie wstawic rekord do redisa by w szybki sposob odczytac wartosci odciazajac główną bazę

3. **Cache po stronie bazy danych** - PostgreSQL dostarcza opcję cachowania wyników zapytań do bazy danych
