namespace LorenFlowers.Events.Models;

public class EventInfo
{
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string Icon { get; set; } = "bi-flower1";
    public string Lead { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ColorAccent { get; set; } = "var(--primary)";
    public List<string> Highlights { get; set; } = new();
    public List<EventPackage> Packages { get; set; } = new();
}

public class EventPackage
{
    public string Name { get; set; } = string.Empty;
    public string PriceFrom { get; set; } = string.Empty;
    public List<string> Items { get; set; } = new();
    public bool IsFeatured { get; set; }
}

public static class EventCatalog
{
    public static readonly List<EventInfo> All = new()
    {
        new EventInfo
        {
            Slug = "hochzeit",
            Title = "Hochzeit",
            Subtitle = "Der schönste Tag verdient die schönsten Blumen",
            Icon = "bi-suit-heart-fill",
            Lead = "Vom Brautstrauß bis zur Tischdekoration – wir gestalten Ihre florale Hochzeitstraumwelt.",
            Description = "Mit über 20 Jahren Erfahrung kreieren wir individuelle florale Konzepte, die Ihre Persönlichkeit und den Stil Ihrer Hochzeit perfekt widerspiegeln. Von romantisch-verspielt bis modern-elegant.",
            Highlights = new() { "Brautstrauß & Anstecker", "Tischdekoration & Gestecke", "Trauerbogen & Kirchenschmuck", "Persönliche Beratung vor Ort" },
            Packages = new()
            {
                new EventPackage { Name = "Brautstrauß Klassik", PriceFrom = "ab 89 €", Items = new(){ "Saisonale Premium-Blumen", "Handgebunden", "Anstecker für Bräutigam inklusive" } },
                new EventPackage { Name = "Hochzeitspaket Komplett", PriceFrom = "ab 950 €", IsFeatured = true, Items = new(){ "Brautstrauß & 2 Anstecker", "6 Tischgestecke", "Kirchen- oder Standesamt-Schmuck", "Persönliche Beratung & Aufbau" } },
                new EventPackage { Name = "Premium Floral Design", PriceFrom = "auf Anfrage", Items = new(){ "Individuelles Gesamtkonzept", "Blumenwand / Hochzeitsbogen", "Komplette Locationdekoration", "Begleitung am Hochzeitstag" } }
            }
        },
        new EventInfo
        {
            Slug = "trauerfeier",
            Title = "Trauerfeier",
            Subtitle = "Ein letzter Gruß in stiller Würde",
            Icon = "bi-flower2",
            Lead = "Kränze, Trauergestecke und Sargschmuck – mit feinem Gespür gestaltet.",
            Description = "In schweren Stunden stehen wir Ihnen mit Einfühlungsvermögen zur Seite. Jeder Kranz, jedes Gesteck wird mit Bedacht und persönlicher Note gefertigt – als würdiger Abschied für einen geliebten Menschen.",
            Highlights = new() { "Trauerkränze & Bukette", "Sargschmuck & Urnenkränze", "Persönliche Schleifenbeschriftung", "Kurzfristige Lieferung möglich" },
            Packages = new()
            {
                new EventPackage { Name = "Trauerstrauß", PriceFrom = "ab 35 €", Items = new(){ "Saisonale Schnittblumen", "Dezent gebunden", "Trauerschleife optional" } },
                new EventPackage { Name = "Trauerkranz Klassik", PriceFrom = "ab 95 €", IsFeatured = true, Items = new(){ "Ø 40–60 cm", "Hochwertige Steckmischung", "Personalisierte Schleife inklusive" } },
                new EventPackage { Name = "Sargschmuck", PriceFrom = "ab 180 €", Items = new(){ "Aufgesetzter Sargschmuck", "Saisonale Premiumblumen", "Persönliche Gestaltung" } }
            }
        },
        new EventInfo
        {
            Slug = "kommunion",
            Title = "Kommunion",
            Subtitle = "Ein festlicher Tag voller Glanz",
            Icon = "bi-flower3",
            Lead = "Florale Begleitung für den großen Tag – kindgerecht, festlich und bezaubernd.",
            Description = "Wir gestalten Anstecker, Tischgestecke und Kirchenschmuck passend zum Anlass und in der Lieblingsfarbe Ihres Kindes. Damit der Tag von Anfang bis Ende blumig schön wird.",
            Highlights = new() { "Anstecker & Haarkränzchen", "Tischgestecke für die Feier", "Kirchen- und Bankschmuck", "Kindgerechte Farbkonzepte" },
            Packages = new()
            {
                new EventPackage { Name = "Kommunion Basic", PriceFrom = "ab 45 €", Items = new(){ "Anstecker für das Kommunionkind", "1 Tischgesteck (klein)", "Saisonale Blumen" } },
                new EventPackage { Name = "Kommunion Festtag", PriceFrom = "ab 220 €", IsFeatured = true, Items = new(){ "Anstecker & Haarschmuck", "4 Tischgestecke", "Kleiner Kirchenschmuck" } },
                new EventPackage { Name = "Komplettpaket", PriceFrom = "auf Anfrage", Items = new(){ "Kirchenschmuck komplett", "Tischgestecke nach Maß", "Aufbau & Beratung" } }
            }
        },
        new EventInfo
        {
            Slug = "konfirmation",
            Title = "Konfirmation",
            Subtitle = "Erwachsen werden – festlich begleitet",
            Icon = "bi-flower1",
            Lead = "Stilvolle Blumendekoration für einen feierlichen Konfirmationstag.",
            Description = "Wir kreieren elegante florale Begleitung – vom Anstecker bis zur kompletten Tischdekoration. Stimmig auf das Konfirmationsmotto und die Persönlichkeit des Jugendlichen abgestimmt.",
            Highlights = new() { "Anstecker & Haarschmuck", "Tischdekoration & Gestecke", "Kirchen- und Saalschmuck", "Stimmiges Farbkonzept" },
            Packages = new()
            {
                new EventPackage { Name = "Konfirmation Basic", PriceFrom = "ab 45 €", Items = new(){ "Anstecker für Konfirmand:in", "1 Tischgesteck (klein)", "Saisonale Blumen" } },
                new EventPackage { Name = "Konfirmation Festtag", PriceFrom = "ab 220 €", IsFeatured = true, Items = new(){ "Anstecker & Haarschmuck", "4 Tischgestecke", "Kleiner Kirchenschmuck" } },
                new EventPackage { Name = "Komplettpaket", PriceFrom = "auf Anfrage", Items = new(){ "Kirchen- & Saalschmuck", "Tischgestecke nach Maß", "Aufbau & Beratung" } }
            }
        },
        new EventInfo
        {
            Slug = "workshop",
            Title = "Workshop",
            Subtitle = "Selbst gestalten – mit Anleitung vom Profi",
            Icon = "bi-palette",
            Lead = "Tauchen Sie ein in die Welt der Floristik – gemeinsam, kreativ und entspannt.",
            Description = "In unseren Workshops lernen Sie unter fachkundiger Anleitung, wie Sie Sträuße, Kränze und Gestecke selbst gestalten. Ideal für Hobbyfloristen, Geburtstage oder als Teamevent.",
            Highlights = new() { "Kleingruppen (max. 8 Personen)", "Alle Materialien inklusive", "Auch als Teamevent buchbar", "Saisonale Themen das ganze Jahr" },
            Packages = new()
            {
                new EventPackage { Name = "Schnupperkurs", PriceFrom = "ab 49 € / Person", Items = new(){ "ca. 1,5 Std. Workshop", "1 Werkstück zum Mitnehmen", "Getränke inklusive" } },
                new EventPackage { Name = "Saison-Workshop", PriceFrom = "ab 89 € / Person", IsFeatured = true, Items = new(){ "ca. 3 Std. Workshop", "Premium-Material", "Snacks & Getränke", "Persönliche Anleitung" } },
                new EventPackage { Name = "Privater Gruppen-Workshop", PriceFrom = "auf Anfrage", Items = new(){ "Wunschtermin & Wunschthema", "Bei Ihnen oder bei uns", "Komplettes Material-Set" } }
            }
        },
        new EventInfo
        {
            Slug = "maerkte",
            Title = "Märkte & Events",
            Subtitle = "Treffen Sie uns vor Ort",
            Icon = "bi-shop",
            Lead = "Loren Flowers auf Hochzeitsmessen, Wochenmärkten und Saisonevents.",
            Description = "Wir sind regelmäßig auf regionalen Märkten und Events vertreten. Hier können Sie unsere Blumen live erleben, persönlich beraten werden und kleine Stücke direkt mitnehmen.",
            Highlights = new() { "Hochzeitsmessen", "Adventsmärkte", "Wochenmärkte (saisonal)", "Pop-up Events & Kooperationen" },
            Packages = new()
            {
                new EventPackage { Name = "Aktuelle Termine", PriceFrom = "siehe Instagram", IsFeatured = true, Items = new(){ "Folgen Sie uns auf Instagram", "@loren_flowers__", "Aktuelle Termine & Standorte" } }
            }
        }
    };

    public static EventInfo? Find(string slug) =>
        All.FirstOrDefault(e => string.Equals(e.Slug, slug, StringComparison.OrdinalIgnoreCase));
}

public class ErrorViewModel
{
    public string? RequestId { get; set; }
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
