# IFSDeliveryInstaller
IFS Delivery Installer to aplikacja desktopowa napisana w C# przy użyciu Windows Forms. Aplikacja automatyzuje proces instalacji dostaw (np. hotfixy) w środowisku ERP IFS Cloud, umożliwiając użytkownikowi szybkie i łatwe zarządzanie instalacjami.

# Funkcjonalności

1) Wybór archiwum:

- Obsługa plików .7z oraz .zip.

- Automatyczne rozpakowywanie zawartości archiwum.

2) Przygotowanie plików instalacyjnych:

- Przeniesienie zawartości z katalogu InstallationFiles do katalogu nadrzędnego.

- Usuwanie pustego katalogu InstallationFiles.

3) Wykonywanie instalacji:

- Uruchamianie widocznego okna CMD z wybranymi komendami.

- Obsługa dynamicznych parametrów pobieranych z pliku JSON.

4) Dynamiczna konfiguracja:

- Wczytywanie komend instalacyjnych z pliku commands.json.

# Wymagania systemowe
- OS: Win 10/11
- .NET Framework: 4.8
- 7zip

# Instalacja:
- Skopiuj repozytorium
- Otwórz plik .sln
- Skonfiguruj odpowiednio commands.json

# Jak używać?
- Wybierz archiwum do rozpakowania.

- Kliknij "Rozpakuj i przygotuj", aby przygotować pliki instalacyjne.

- Wybierz jedną z komend z listy i kliknij "Instaluj", aby uruchomić proces instalacji.
