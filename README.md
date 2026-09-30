# Loren Flowers Events

Anlass- und Leistungsseite des Blumengeschäfts **Loren Flowers**, umgesetzt als
ASP.NET-Core-MVC-Anwendung. Die Seite zeigt das Leistungsangebot für besondere Anlässe –
Hochzeit, Trauerfeier, Kommunion, Konfirmation, Workshops und Märkte – jeweils mit Beschreibung,
Highlights und passenden Paketen. Ein kleiner, geschützter Admin-Bereich gibt dem Betrieb einen
Überblick über den Katalog.

Der Katalog ist **statisch im Code gepflegt** (`Models/EventInfo.cs`): Es gibt keine Datenbank und
keine Persistenz. Interessierte werden über einen konfigurierbaren Link zum Onlineshop geführt
(`https://loren-flowers.shop`), wo Bestellung und Anfrage stattfinden.

## Funktionsumfang

- **Startseite** mit Hero-Bereich, Einstieg in die Anlässe und Shop-Verweis
- **Anlass-Übersicht** (`/Events`) mit allen gepflegten Anlässen
- **Detailseite je Anlass** (`/Events/Detail?slug=…`) mit Untertitel, Einleitung, Beschreibung,
  Highlights und Paketen inkl. „ab"-Preisangaben und hervorgehobener Empfehlung
- Kurze, sprechende Routen je Anlass (`/Events/Hochzeit`, `/Events/Trauerfeier`, `/Events/Kommunion`,
  `/Events/Konfirmation`, `/Events/Workshop`, `/Events/Maerkte`), die auf die Detailseite umleiten
- **Admin-Dashboard** (`/Admin`, nur Rolle `Admin`) mit Kennzahlen – Anzahl Anlässe, Pakete,
  Highlights und Anlässe mit Paketen – sowie der Katalogliste
- **Login** unter `/Account/Login` mit „Angemeldet bleiben", Logout und Rückkehrer-URL
- Eigenes Design mit Bootstrap Icons und eigenem Stylesheet, Logo im `wwwroot`

## Technischer Aufbau

| Bereich | eingesetzt |
|---|---|
| Framework | ASP.NET Core MVC, **.NET 10** (`net10.0`), Nullable + ImplicitUsings aktiv |
| Datenbank | keine – der Anlass-Katalog liegt als Liste im Code |
| NuGet-Pakete | keine |
| Authentifizierung | eigener Cookie-Scheme `CookieAuth`, Rolle `Admin` |
| Konfiguration | `AdminSettings`, `ShopUrl`, `ContactEmail`; UserSecretsId gesetzt |

## Projektstruktur

```
lorenflowers-events/
├─ Program.cs                        Einstiegspunkt, Cookie-Auth, Pipeline
├─ LorenFlowers.Events.csproj        .NET-10-Webprojekt
├─ appsettings.json                  Konfigurationsvorlage (Platzhalter)
├─ Controllers/
│  ├─ HomeController.cs              Startseite und Fehlerseite
│  ├─ EventsController.cs            Übersicht, Detailseite, Anlass-Routen
│  ├─ AccountController.cs           Login / Logout (Cookie-Auth)
│  └─ AdminController.cs             Dashboard ([Authorize(Roles = "Admin")])
├─ Models/EventInfo.cs               EventInfo, EventPackage, EventCatalog, ErrorViewModel
├─ Views/
│  ├─ Home/                          Startseite
│  ├─ Events/Detail.cshtml           Anlass-Detailseite
│  ├─ Account/Login.cshtml
│  ├─ Admin/Index.cshtml             Dashboard
│  └─ Shared/                        Layouts (_Layout, _AdminLayout), Error
├─ wwwroot/                          CSS und Logo
└─ Properties/
   ├─ launchSettings.json            Startprofile
   └─ PublishProfiles/FolderProfile.pubxml
```

## Voraussetzungen

- **.NET SDK 10**
- Keine Datenbank, kein SMTP, keine externen Dienste

## Lokal bauen und starten

```bash
dotnet restore
dotnet build
dotnet run
```

Die Startprofile lauschen auf `http://localhost:5180` bzw. `https://localhost:7180`.
Der Admin-Bereich ist über `/Account/Login` erreichbar; die Zugangsdaten stammen aus der
Konfiguration.

## Konfiguration

Die Werte stehen als Platzhalter in `appsettings.json` und werden lokal gesetzt – echte Werte
werden **nicht** eingecheckt. `appsettings.Development.json` ist ignoriert; nutze
Umgebungsvariablen oder User-Secrets (die Projektdatei enthält bereits eine `UserSecretsId`).

| Schlüssel | Zweck |
|---|---|
| `AdminSettings:Email` / `AdminSettings:Password` | Zugang zum Admin-Dashboard – **muss lokal gesetzt werden**, sonst ist kein Login möglich |
| `ShopUrl` | Ziel des Shop-Links |
| `ContactEmail` | Kontaktadresse, die in den Views verwendet wird |

```bash
dotnet user-secrets set "AdminSettings:Password" "<lokaler Wert>"
```

## Status

Kompakte Anlass-Seite mit statischem, im Code gepflegtem Katalog; neue Anlässe oder Pakete werden
in `EventCatalog` ergänzt. Der Admin-Bereich dient als Übersicht, nicht als Redaktionswerkzeug.

Für einen produktiven Einsatz zu beachten:

- Der Admin-Login vergleicht die Zugangsdaten direkt mit den Konfigurationswerten. Für den
  Dauerbetrieb empfiehlt sich der Wechsel auf ASP.NET Core Identity mit gehashten Passwörtern
  und serverseitiger Benutzerverwaltung.
- Es existieren derzeit keine automatisierten Tests.
