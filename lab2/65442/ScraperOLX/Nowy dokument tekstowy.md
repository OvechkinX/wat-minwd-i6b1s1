# Opis programu

Scraper zbiera dane o wystawionych przedmiotach ze strony https://www.olx.pl oraz zapisuje je w formacie json

-Wymagania

- .net core sdk 3.0
- zainstalowana przeglądarka Chrome

# Instrukcja uruchomienia

1. Wejść do katalogu z plikiem .\ScraperOLX\ScraperOLX\ScraperOLX\bin\Debug\netcoreapp3.0
2. Uruchomić plik ScraperOLX.exe


# Dane wynikowe

Legenda:

Name - Tytuł aukcji
Category - kategoria, w której przedmiot został wystawiony
Price - Cena
Place - miejscowość odbioru osobistego
Time - czas dodania aukcji
ImgString - zdjęcie zakodowane w base64



{

"name":"Kurtka męska Zara",
"category":"Moda » Buty",
"price":"40 zł",
"place":"Gliwice, Bojków",
"time":"dzisiaj 18:32",
"imageString":
"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"}]

}