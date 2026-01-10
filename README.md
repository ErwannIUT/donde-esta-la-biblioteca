# Donde esta la biblioteca

## Sujet 

Vous allez réaliser une petite application qui vous permettra de gérer une liste de bibliothèque ayant des livres à louer.
Une petite BDD sera jointe au projet qu'on va essayer d'enrichir au maximum.
L'idée est d'être en autonomie par Groupe de 2.

Le but du projet est de voir un maximum des choses que .NET peut vous apporter donc n'hésitez pas à demander au prof.

Pensez aussi à regarder les raccourcis utiles en bas de page.

Créer un repository sur GitHub en privé que vous mettrez à jour. Vous aurez les modalités du rendu en bas de ce document.

Si vous voulez la ref du **Donde esta la Biblioteca** : https://www.youtube.com/watch?v=j25tkxg5Vws

## Les mots clefs

- *Solution*
  - La racine de votre application .NET qui permet d'avoir la vision globale des projets
  - Manifestée sous la forme d'un fichier **.sln**, c'est ce fichier qu'il faut ouvrir pour ouvrir votre espace de travail
  - Va contenir un ou plusieurs projets
  - **Analogie** : Pensez à la solution comme un "classeur" qui organise plusieurs "cahiers" (projets)
  - **Exemple** : Une solution `LibraryManager.sln` peut contenir plusieurs projets : `LibraryManager.App`, `LibraryManager.Services`, etc.
  
- *Projet* :
  - Bloc de construction de l'application
  - Va générer une dll (Dynamic Link Library) par projet - c'est un fichier compilé qui contient du code réutilisable
  - Facilement extractable d'une solution à une autre
  - **Types de projets** :
    - *Application Console* : Programme qui s'exécute dans une fenêtre de commande
    - *Bibliothèque de classes* : Ensemble de code réutilisable (ne s'exécute pas seul)
    - *Web API* : Service web qui expose des endpoints HTTP
  - **Avantage** : Permet de séparer les responsabilités et de réutiliser le code dans différentes solutions
  
- *Nuget* :
  - Gestionnaire de package pour .NET (équivalent à npm pour JavaScript, pip pour Python)
  - Permet d'intégrer des bibliothèques externes à votre projet pour étendre les fonctionnalités de votre code (AutoMapper, ORM...)
  - On peut l'ouvrir en faisant `Clic droit > Gestionnaire Nuget` en cliquant sur un projet ou la solution
  - **Exemples de packages populaires** :
    - `Microsoft.EntityFrameworkCore` : ORM pour accéder aux bases de données
    - `Newtonsoft.Json` : Manipulation de JSON
    - `AutoMapper` : Mapping automatique entre objets
  - **Fichier de configuration** : Les packages sont listés dans le fichier `.csproj` de votre projet 

## Critères de qualité

- Commits réguliers, au moins à chaque étape
- Indentation
- En Anglais
- Privilégier les interfaces aux classes concrètes (normalement en suivant bien le projet ça devrait être facile)
- Nommage :
  - "Singulier" pour un objet simple et "Pluriel" pour une liste 
  - **PascalCase** : Pour les noms de classes, interfaces et propriétés
  - **camelCase** : Pour les variables
  - **_camelCase** : Pour les variables déclarées au niveau de la classe
  - Nom d'interface commençant par un **I**
  - Nom de classe abstraite par un **A**
  - Pensez à compiler régulièrement : si ça ne compile pas, c'est un 0

N'hésitez pas à me consulter à chaque étape pour vous assurer que vous avez bien réalisé chaque action.

## TODO

### Etape 1 : Créer sa solution .NET
----

Créez un nouveau projet via Visual Studio 2022, puis sélectionnez une *Application Console*.

Vous appellerez votre projet `LibraryManager.App` et votre solution `LibraryManager`.

Si vous n'avez pas d'explorateur de solution sur votre IDE, vous pouvez aussi l'ajouter via le menu `Affichage > Explorateur de Solution`.

Ajoutez via le *gestionnaire de package Nuget* sur votre projet : Microsoft.Extensions.Hosting

Veillez à bien être en vue Solution et d'avoir votre projet chargé.

⚠️ Testez votre code et pensez à commiter.

### Etape 2 : Commencer son programme
---

Créez une méthode Main dans le `Program.cs` grâce aux recommandations VS `Alt + Entrée` à l'intérieur du fichier.

**Explication : Qu'est-ce que la méthode Main ?**
- C'est le **point d'entrée** de votre application console
- Le programme commence toujours son exécution par cette méthode
- Signature typique : `static void Main(string[] args)` où `args` contient les arguments passés en ligne de commande

Créez une classe `Book` qui contiendra uniquement un `string Name` et un `string Type`. 

**Explication : Les classes et les propriétés**
- Une **classe** est un modèle/blueprint qui définit la structure d'un objet
- Les **propriétés** sont des attributs de la classe qui stockent des données
- En C#, on utilise des propriétés auto-implémentées :

```cs
public class Book
{
    // Propriété auto-implémentée avec getter et setter
    public string Name { get; set; }
    
    // Raccourci : tapez "prop" puis Tab pour générer une propriété
    public string Type { get; set; }
}
```

Dans cette méthode, vous allez créer une liste de livres que vous allez alimenter avec quelques éléments dont au moins un livre de type `Aventure`. Libre à vous de mettre ce que vous souhaitez dans celle-ci.

**Exemple de code :**
```cs
static void Main(string[] args)
{
    // List<T> est une collection générique qui peut contenir plusieurs éléments du type T
    List<Book> books = new List<Book>
    {
        new Book { Name = "Le Comte de Monte Cristo", Type = "Aventure" },
        new Book { Name = "Les Trois Mousquetaires", Type = "Aventure" },
        new Book { Name = "Le Petit Prince", Type = "Fiction" }
    };
    
    // Alternative : Initialisation puis ajout
    // List<Book> books = new List<Book>();
    // books.Add(new Book { Name = "...", Type = "..." });
}
```

Vous allez ensuite boucler sur celle-ci et afficher dans la console les différents noms.

**Explication : Les boucles en C#**
```cs
// Méthode 1 : Boucle foreach (la plus lisible pour parcourir une collection)
foreach (Book book in books)
{
    Console.WriteLine(book.Name);
}

// Méthode 2 : Boucle for classique
for (int i = 0; i < books.Count; i++)
{
    Console.WriteLine(books[i].Name);
}

// Méthode 3 : Méthode LINQ ForEach (plus avancé)
books.ForEach(book => Console.WriteLine(book.Name));
```

⚠️ Testez votre code et pensez à commiter.

### Etape 3 : LINQ
---

**Qu'est-ce que LINQ ?**

LINQ (prononcé "link", pour **L**anguage **IN**tegrated **Q**uery) est un langage d'interrogation pour vos collections en .NET.

**Pourquoi utiliser LINQ ?**
- Simplifie les opérations sur les collections (filtrage, tri, projection...)
- Code plus lisible et concis
- Moins de risque d'erreurs qu'avec des boucles manuelles
- Fonctionne avec de nombreuses sources de données (listes, bases de données, XML...)

**Les deux syntaxes LINQ :**

1. **Syntaxe par méthodes** (recommandée pour ce projet) :
```cs
var adventureBooks = books.Where(book => book.Type == "Aventure");
```

2. **Syntaxe par requête** (ressemble au SQL) :
```cs
var adventureBooks = from book in books
                     where book.Type == "Aventure"
                     select book;
```

**Principales méthodes LINQ :**

```cs
// Where : Filtre les éléments selon une condition
var adventureBooks = books.Where(b => b.Type == "Aventure");

// Select : Transforme/projette les éléments
var bookNames = books.Select(b => b.Name);

// FirstOrDefault : Récupère le premier élément (ou null si vide)
var firstBook = books.FirstOrDefault();

// OrderBy : Trie par ordre croissant
var sortedBooks = books.OrderBy(b => b.Name);

// Count : Compte le nombre d'éléments
int count = books.Count(b => b.Type == "Aventure");

// Any : Vérifie si au moins un élément correspond
bool hasAdventure = books.Any(b => b.Type == "Aventure");

// ToList : Convertit le résultat en List<T>
List<Book> adventureList = books.Where(b => b.Type == "Aventure").ToList();
```

**Exercice : Filtrez votre liste pour n'afficher que les livres de type `Aventure`.**

```cs
// Méthode 1 : Filtrer puis afficher
var adventureBooks = books.Where(book => book.Type == "Aventure");
foreach (var book in adventureBooks)
{
    Console.WriteLine($"Livre d'aventure : {book.Name}");
}

// Méthode 2 : Tout en une ligne (chaînage de méthodes)
books.Where(book => book.Type == "Aventure")
     .ToList()
     .ForEach(book => Console.WriteLine(book.Name));
```

**Note importante :** 
- `=>` est appelé un **lambda** ou **expression lambda** : c'est une fonction anonyme
- `book => book.Type == "Aventure"` signifie : "pour chaque livre, vérifie si son type est Aventure"
- C'est équivalent à écrire :
```cs
bool IsAdventure(Book book)
{
    return book.Type == "Aventure";
}
```

Pour plus d'informations : [LINQ - Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/linq/) 

⚠️ Testez votre code et pensez à commiter.

### Etape 4.1 : Préparer son architecture
---

**Qu'est-ce qu'une architecture en couches ?**

Une architecture en couches organise le code en différents projets ayant chacun une responsabilité spécifique. Cela permet :
- **Séparation des préoccupations** : Chaque couche a un rôle bien défini
- **Réutilisabilité** : Les couches peuvent être utilisées dans différentes applications
- **Testabilité** : Plus facile de tester chaque couche indépendamment
- **Maintenabilité** : Modifications localisées, pas d'impact sur tout le code

**Les couches de notre application :**

```
LibraryManager (Solution)
│
├── LibraryManager.App (Application Console)
│   └── Point d'entrée, interface utilisateur
│
├── BusinessObjects (Bibliothèque de classes)
│   ├── Entity/ : Objets métier (Book, Author, Library...)
│   ├── Enum/ : Énumérations (TypeBook...)
│   └── DataTransferObject/ : DTOs (objets pour l'API)
│
├── DataAccessLayer (Bibliothèque de classes)
│   ├── Repository/ : Accès aux données (BookRepository...)
│   └── Contexts/ : Configuration base de données (LibraryContext)
│
└── Services (Bibliothèque de classes)
    └── Services/ : Logique métier (CatalogManager...)
```

 Mettez en place votre architecture de projets en ajoutant via Visual Studio des projets de type **Bibliothèque de classes** :
- `BusinessObjects` : Couche contenant vos objets métier (objets de base de données ou de travail)
- `DataAccessLayer` : Couche permettant l'accès aux données; on y retrouvera notamment les repository

Maintenant passons à l'implémentation de notre architecture.

**1. Créer les entités (BusinessObjects)**

Dans votre projet `BusinessObjects`, créez un dossier `Entity` et `Enum`, puis dans ce dossier `Entity`, créez les objets correspondants aux tables du fichier `LibraryInit.sql`.

**Explication : Les entités vs les tables**
- Une **entité** est une classe C# qui représente une table de base de données
- Chaque **propriété** de la classe correspond à une **colonne** de la table
- Cette correspondance s'appelle **ORM** (Object-Relational Mapping)

Déplacez-y votre classe `Book` que vous compléterez et changez votre `string Type` en enum `TypeBook Type`. Pas besoin de créer un fichier pour la table de `Stock`.

**Exemple d'énumération :**
```cs
// Fichier: Enum/TypeBook.cs
public enum TypeBook
{
    Aventure,
    Fiction,
    Enseignement,
    Histoire,
    Juridique
}
```

**Exemple d'entité complète :**
```cs
// Fichier: Entity/Book.cs
public class Book : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Pages { get; set; }
    public TypeBook Type { get; set; }
    public int Rate { get; set; }
    
    // Relation OneToMany : Un livre a UN auteur
    public int IdAuthor { get; set; }
    public Author Author { get; set; }  // Propriété de navigation
    
    // Relation ManyToMany : Un livre peut être dans plusieurs bibliothèques
    public IEnumerable<Library> Libraries { get; set; }
}
```

Faites en sorte que toutes les entités héritent d'une interface `IEntity` qui contiendra une propriété `int Id`.

**Explication : Pourquoi une interface IEntity ?**
```cs
// Fichier: Entity/IEntity.cs
public interface IEntity
{
    int Id { get; set; }
}

// Avantages :
// - Permet de créer des méthodes génériques qui fonctionnent avec toute entité
// - Garantit que toutes les entités ont un Id
// - Facilite la création de Repository génériques (étape suivante)
```

Dans le cadre d'une relation `OneToMany` (1..\*) ou `ManyToMany` (\*), le **Many** se manifeste sous la forme d'une liste (Ex : `IEnumerable<ClassA>`) et le **One** sous la forme d'un objet simple (Ex : `ClassA`).

**Schéma des relations :**
```
Author (1) ────── (N) Book (N) ────── (N) Library
      └─ Un auteur a plusieurs livres
                    └─ Un livre peut être dans plusieurs bibliothèques
```

**2. Créer les repositories (DataAccessLayer)**

Dans votre projet `DataAccessLayer`, créez un dossier `Repository`, puis dans ce dossier une classe repository pour chaque entité (ex : `BookRepository`)

**Explication : Le pattern Repository**
- Un **Repository** est une classe qui gère l'accès aux données
- Il fait le lien entre votre application et la base de données
- Permet d'isoler la logique d'accès aux données
- Facilite les tests (on peut créer un faux repository pour tester)

Vous y créerez les méthodes `GetAll()` qui retournera un `IEnumerable<Book>` et `Get(int id)` qui retournera un `Book`, vous pouvez `return` des objets vides à ce stade.

**Exemple de Repository :**
```cs
// Fichier: Repository/BookRepository.cs
public class BookRepository
{
    private List<Book> _books;

    public BookRepository()
    {
        // Pour l'instant, données en dur
        _books = new List<Book>
        {
            new Book { Id = 1, Name = "Le Comte de Monte Cristo", Type = TypeBook.Aventure },
            new Book { Id = 2, Name = "Les Trois Mousquetaires", Type = TypeBook.Aventure }
        };
    }

    // Retourne tous les livres
    public IEnumerable<Book> GetAll()
    {
        return _books;
    }

    // Retourne un livre par son Id
    public Book Get(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }
}
```

Répétez le même schéma pour chacune de vos entités.

Pour le `BookRepository`, utilisez la liste que vous avez créé dans le `Main` puis implémentez les méthodes `IEnumerable<Book> GetAll()` et `Book Get(int id)`, appelez ces méthodes dans votre `Main` et finalement tentez d'afficher les livres d'aventure.

**PI : Vous aurez besoin d'ajouter des références d'un projet à un autre pour permettre d'utiliser vos entités à l'extérieur de leur projet respectif.**

**Comment ajouter une référence entre projets :**
1. Clic droit sur le projet qui a besoin de la référence (ex: DataAccessLayer)
2. `Ajouter > Référence de projet`
3. Cocher le projet nécessaire (ex: BusinessObjects)
4. Cela permet d'utiliser les classes du projet référencé

**Dépendances entre projets :**
```
App → Services → DataAccessLayer → BusinessObjects
      └─────────→ BusinessObjects
```

⚠️ Testez votre code et pensez à commiter.


### Etape 4.2 : Préparer son architecture
---

 Mettez en place votre architecture de projets en ajoutant via Visual Studio des projets de type **Bibliothèque de classes** :
- `Services` : Couche services intermédiaire; va permettre d'orchestrer les besoins et de relier d'autres couches entre elles

**Explication : La couche Service**
- La couche **Service** contient la **logique métier** de l'application
- Elle orchestre les appels aux repositories
- Elle peut combiner les données de plusieurs repositories
- Elle expose des méthodes orientées "métier" plutôt que "technique"

**Exemple de différence Repository vs Service :**
```cs
// Repository : Méthodes techniques d'accès aux données
BookRepository.GetAll() → Retourne tous les livres de la BD
BookRepository.Get(id)  → Retourne un livre par son ID

// Service : Méthodes orientées métier
CatalogManager.GetCatalog()           → Retourne le catalogue complet
CatalogManager.GetCatalog(Type type)  → Filtre par type (logique métier)
CatalogManager.FindBook(int id)       → Recherche intelligente
```

4. Dans votre projet `Services`, créez un dossier `Services`, puis dans ce dossier une classe `CatalogManager` qui contiendra les méthodes `IEnumerable<Book> GetCatalog()`, `IEnumerable<Book> GetCatalog(Type type)` et `Book FindBook(int id)` qui utiliseront le `BookRepository`.

**Exemple d'implémentation du CatalogManager :**
```cs
// Fichier: Services/CatalogManager.cs
public class CatalogManager
{
    private readonly BookRepository _bookRepository;

    // Le repository est passé dans le constructeur
    public CatalogManager(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    // Retourne tous les livres du catalogue
    public IEnumerable<Book> GetCatalog()
    {
        return _bookRepository.GetAll();
    }

    // Retourne les livres filtrés par type (logique métier)
    public IEnumerable<Book> GetCatalog(TypeBook type)
    {
        return _bookRepository.GetAll()
                              .Where(book => book.Type == type);
    }

    // Recherche un livre par son ID
    public Book FindBook(int id)
    {
        return _bookRepository.Get(id);
    }
}
```

Ces méthodes vont utiliser les Repositories que vous avez créés. Remplacez les méthodes de votre `Main` par les méthodes nouvellement créées dans votre `CatalogManager`.

**Exemple d'utilisation dans le Main :**
```cs
static void Main(string[] args)
{
    // Création manuelle des dépendances (sera remplacé par l'injection plus tard)
    BookRepository bookRepository = new BookRepository();
    CatalogManager catalogManager = new CatalogManager(bookRepository);
    
    // Utilisation du service
    var allBooks = catalogManager.GetCatalog();
    var adventureBooks = catalogManager.GetCatalog(TypeBook.Aventure);
    var specificBook = catalogManager.FindBook(1);
    
    // Affichage
    Console.WriteLine("Livres d'aventure :");
    foreach (var book in adventureBooks)
    {
        Console.WriteLine($"- {book.Name}");
    }
}
```

⚠️ Testez votre code et pensez à commiter.


### Etape 5 : Injection de dépendance
---

**Qu'est-ce que l'injection de dépendance ?**

L'injection de dépendance (DI - Dependency Injection) est un concept fondamental du développement moderne.

**Le problème sans injection de dépendance :**
```cs
public class CatalogManager
{
    private BookRepository _repository;
    
    public CatalogManager()
    {
        _repository = new BookRepository();  // ❌ Couplage fort !
    }
}

// Problèmes :
// - Difficile de tester (impossible de remplacer le repository par un mock)
// - Difficile de changer l'implémentation
// - La classe gère elle-même ses dépendances
```

**La solution avec injection de dépendance :**
```cs
public class CatalogManager
{
    private readonly IBookRepository _repository;
    
    public CatalogManager(IBookRepository repository)  // ✅ Injection via constructeur
    {
        _repository = repository;
    }
}

// Avantages :
// - Testable (on peut injecter un mock)
// - Flexible (on peut changer l'implémentation facilement)
// - La classe ne gère plus ses dépendances
```

Ajoutez dans le `Program.cs` la méthode :

```cs
    private static IHost CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
              // Configuration des services
            })
            .Build();
    }
```

Il s'agit ici d'un concept extrêmement important lors du développement d'une application aujourd'hui.
On ne développe plus à partir de classes concrètes mais à partir d'interfaces afin de réduire le couplage de vos applications à l'implémentation.

L’injection de dépendances consiste, pour une classe, à déléguer la création de ses dépendances au code appelant qui va ensuite les injecter dans la classe correspondante. De ce fait, la création d’une instance est effectuée à l’extérieur de la classe dépendante et injectée dans celle-ci.

![Dependency Injection](/schemas/dependancy_injection.drawio.png)

Par exemple, nous possédons une classe concrète `ApiACaller` que j'instancie à plusieurs endroits dans mon code.
Demain, on nous demande de la remplacer par un `ApiBCaller` car la source de données doit changer.
Plutôt que d'avoir à changer toutes les références à notre classe concrète, nous allons mettre dans le constructeur notre interface qui nous donnera les fonctions disponibles.
Et à plus haut niveau, nous lui injecterons la classe concrète qui correspondera à cette interface.

A la compilation, la classe concrète correspondante est inconnue. Par contre, à l'exécution, cette classe est injectée à chaque fois qu'une référence est faite à celle-ci via l'interface.

De ce fait, lorsque nous changerons l'implémentation via une nouvelle classe, nous aurons juste besoin de changer la configuration correspondante.

```cs
  public interface IApiCaller {
    object Call();
  }

  public class ApiACaller : IApiCaller {
    public object Call() {
      return ResultA;
    }
  }

  public class ApiBCaller : IApiCaller {
    public object Call() {
      return ResultB;
    }
  }

  // Before - Couplage fort ❌
  public Constructor() {
    _caller = new ApiACaller();
  }

  // After - Injection de dépendance ✅
  public Constructor(IApiCaller apiCaller) {
    _caller = apiCaller;
  }
```

**Les cycles de vie des services injectés :**

```cs
// 1. Transient : Une nouvelle instance à chaque injection
services.AddTransient<IApiCaller, ApiACaller>();
// Utilisation : Services stateless, légers

// 2. Scoped : Une instance par requête/scope
services.AddScoped<IApiCaller, ApiACaller>();
// Utilisation : DbContext, services liés à une requête web

// 3. Singleton : Une seule instance pour toute l'application
services.AddSingleton<IApiCaller, ApiACaller>();
// Utilisation : Cache, configuration, services sans état partagés
```

En allant plus loin, on peut récupérer toutes vos classes de cette manière :

```cs

  public ClassA(IClassB b){
    _b = b;
  }

  public ClassB(IClassC c){
    _c = c;
  }

 // Ou encore une autre classe qui a les deux objets accessibles

  public ClassE(IClassA a, IClassD d ) {
    _a = a;
    _d = d;
  }

  // Et ainsi de suite
```

Et comme vous le constatez, je n'ai à aucun moment instancié la classe de départ. (rappel : on instancie avec le mot-clé `new`, par exemple `new ClassA()`) 

On peut même injecter un Singleton ! Renseignez-vous sur la documentation pour connaître les cycles de vie des objets injectés. 

**Mise en pratique :**

Pour réaliser de l'injection de dépendance :

1. **Extrayez une interface de vos classes concrètes** ayant de la logique et instanciées ailleurs dans votre code (Ex : Services...)

```cs
// Exemple pour CatalogManager :
// Clic droit sur le nom de la classe > Actions rapides > Extraire l'interface

public interface ICatalogManager
{
    IEnumerable<Book> GetCatalog();
    IEnumerable<Book> GetCatalog(TypeBook type);
    Book FindBook(int id);
}

public class CatalogManager : ICatalogManager
{
    // Implémentation...
}
```

2. **Pour vos repository**, on fera un peu différemment. Vous allez créer une seule interface `IGenericRepository<T>` qui prendra en paramètre un type générique `T` qui sera une `IEntity` et qui vous servira pour vos types de retours

**Explication : Les Génériques (Generics)**
```cs
// Interface générique : fonctionne avec n'importe quel type d'entité
public interface IGenericRepository<T> where T : IEntity
{
    IEnumerable<T> GetAll();
    T Get(int id);
}

// Utilisation :
// IGenericRepository<Book>   → GetAll() retourne IEnumerable<Book>
// IGenericRepository<Author> → GetAll() retourne IEnumerable<Author>

// Implémentation pour Book :
public class BookRepository : IGenericRepository<Book>
{
    public IEnumerable<Book> GetAll() { /* ... */ }
    public Book Get(int id) { /* ... */ }
}
```

3. **Injectez vos dépendances** dans la configuration de vos services de votre `Program.cs`

```cs
private static IHost CreateHostBuilder()
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices(services =>
        {
            // Enregistrement des repositories
            services.AddTransient<IGenericRepository<Book>, BookRepository>();
            services.AddTransient<IGenericRepository<Author>, AuthorRepository>();
            
            // Enregistrement des services
            services.AddTransient<ICatalogManager, CatalogManager>();
        })
        .Build();
}
```

4. **Utilisez ces classes injectées** en retirant les appels inutiles à vos classes concrètes 

Récupérez votre Service dans le `Main` et testez en reprenant l'exemple du `IApiCaller` :

```cs
static void Main(string[] args)
{
    // 1. Créer le host avec la configuration des services
    var host = CreateHostBuilder();
    
    // 2. Récupérer le service depuis le conteneur DI
    ICatalogManager catalogManager = host.Services.GetRequiredService<ICatalogManager>();
    
    // 3. Utiliser le service (les dépendances sont automatiquement injectées !)
    var adventureBooks = catalogManager.GetCatalog(TypeBook.Aventure);
    
    foreach (var book in adventureBooks)
    {
        Console.WriteLine(book.Name);
    }
}
```

**Résumé du flux d'injection :**
```
1. Configuration (Program.cs) :
   services.AddTransient<ICatalogManager, CatalogManager>()
   services.AddTransient<IGenericRepository<Book>, BookRepository>()

2. Le conteneur DI sait maintenant que :
   - ICatalogManager → CatalogManager
   - IGenericRepository<Book> → BookRepository

3. Quand on demande ICatalogManager :
   - Le conteneur crée automatiquement BookRepository
   - Puis crée CatalogManager en lui injectant BookRepository
   - Retourne l'instance de CatalogManager

4. Tout est automatique, pas de "new" manuel !
```

Pour plus d'informations : 
- [Injection de dépendance - Microsoft](https://learn.microsoft.com/fr-fr/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-8.0)
- [Classes et méthodes générique - Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/types/generics)

⚠️ Testez votre code et pensez à commiter.

### Etape 6 : EntityFramework
---

**Qu'est-ce qu'un ORM ?**

ORM signifie **Object-Relational Mapping** (Mappage Objet-Relationnel). C'est un outil qui fait le pont entre votre code orienté objet (C#) et votre base de données relationnelle (SQL).

**Avantages d'EntityFramework :**
- Pas besoin d'écrire du SQL manuellement
- Type-safe : erreurs détectées à la compilation
- Gère automatiquement les relations entre entités
- Simplifie les opérations CRUD (Create, Read, Update, Delete)

**Exemple de transformation :**
```cs
// Sans ORM : SQL manuel ❌
string sql = "SELECT * FROM book WHERE type = 'Aventure'";
// Risque d'erreur SQL, pas de vérification de type...

// Avec ORM : Code C# ✅
var books = context.Books.Where(b => b.Type == TypeBook.Aventure);
// Type-safe, IntelliSense, facile à maintenir
```

Avec l'aide de la base de données SQLite fournie en annexe, vous allez implémenter l'ORM **EntityFramework**.

**Packages NuGet nécessaires :**
- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.Sqlite` (pour SQLite)
- `Microsoft.EntityFrameworkCore.Design` (pour les outils EF)

Vous aurez besoin d'un package SQLite pour poursuivre, je vous laisse chercher.

Le but ici est de renvoyer les informations stockées en base de données au lieu de renvoyer des listes vides au niveau de vos `Repositories`.

Dans votre `DataAccessLayer`, créez un dossier `Contexts` et un fichier `LibraryContext` qui implémentera la classe `DbContext`, servez-vous de la documentation pour remplir votre DbContext.

**Exemple de DbContext :**
```cs
// Fichier: Contexts/LibraryContext.cs
public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) 
        : base(options)
    {
    }

    // DbSet : Représente une table de la base de données
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Library> Libraries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuration des relations Many-to-Many
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Libraries)
            .WithMany(l => l.Books)
            .UsingEntity(j => j.ToTable("stock"));
            
        // Configuration des relations One-to-Many
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.IdAuthor);
    }
}
```

Pensez à l'injecter, pour une fois on utilisera une classe concrète. Vous aurez sûrement un autre Nuget à récupérer sur vos deux projets.

```cs
// Dans la configuration du service
services.AddDbContext<LibraryContext>(options =>
{
    // Chemin vers la base de données
    string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "library.db");
    options.UseSqlite($"Data Source={dbPath}");
});
```

**Copier le fichier .db à la compilation :**
```xml
<!-- Dans votre fichier .csproj -->
<ItemGroup>
    <None Update="library.db">
        <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
</ItemGroup>
```

Vous pouvez construire un chemin absolu avec l'aide de la classe `Path`. **Faites en sorte que le fichier `.db` soit copié à la compilation.**

Dans vos repositories, utilisez le `LibraryContext` injecté pour récupérer le contenu de la base.

**Exemple de Repository avec EntityFramework :**
```cs
public class BookRepository : IGenericRepository<Book>
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    public IEnumerable<Book> GetAll()
    {
        // Include : Charge les relations (eager loading)
        return _context.Books
                       .Include(b => b.Author)  // Charge l'auteur en même temps
                       .ToList();
    }

    public Book Get(int id)
    {
        return _context.Books
                       .Include(b => b.Author)
                       .FirstOrDefault(b => b.Id == id);
    }
    
    public Book Add(Book entity)
    {
        _context.Books.Add(entity);
        _context.SaveChanges();  // Persiste les changements en BD
        return entity;
    }
}
```

Ajoutez une méthode `IEntity Add(IEntity)` dans `IGenericRepository`. Compilez et déboguez.

Vous réalisez à quel point c'est fastidieux de tout changer à la fois.

(Refacto en cours) Maintenant créez une classe concrète `GenericRepository<T>` qui doit remplacer tous vos repositories existants et remplacez les injections.

**Exemple de GenericRepository :**
```cs
public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
{
    private readonly LibraryContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(LibraryContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();  // Set<T> : Accès générique à la table
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T Get(int id)
    {
        return _dbSet.FirstOrDefault(e => e.Id == id);
    }
    
    public T Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
        return entity;
    }
}
```

**Configuration dans Program.cs :**
```cs
// Plus besoin de créer un repository par entité !
services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
```

Supprimez vos anciens repositories.

**Concepts EntityFramework importants :**
- **DbSet<T>** : Représente une table
- **Include()** : Charge les relations (évite N+1 queries)
- **SaveChanges()** : Persiste les modifications en base
- **Tracking** : EF suit automatiquement les modifications des entités

Pour plus d'informations : 
- [EntityFramework - Microsoft](https://learn.microsoft.com/fr-fr/ef/core/)
- [DBeaver](https://dbeaver.io/) qui est vraiment utile quand vous avez plusieurs SGBD différents à gérer.

⚠️ Testez votre code et pensez à commiter.

### Etape 7 : TU (Tests Unitaires)
---

**Qu'est-ce qu'un test unitaire ?**

Un **test unitaire** vérifie qu'une petite unité de code (généralement une méthode) fonctionne correctement de manière isolée.

**Principes des tests unitaires :**
- **Isolation** : Teste une méthode indépendamment des autres
- **Rapide** : S'exécute en quelques millisecondes
- **Répétable** : Donne toujours le même résultat
- **Automatisé** : Peut être exécuté automatiquement

**Pattern AAA (Arrange-Act-Assert) :**
```cs
[Fact]
public void GetCatalog_WithType_ReturnsFilteredBooks()
{
    // Arrange : Prépare les données et mocks
    var mockBooks = new List<Book> { /* ... */ };
    
    // Act : Exécute la méthode à tester
    var result = catalogManager.GetCatalog(TypeBook.Aventure);
    
    // Assert : Vérifie le résultat
    Assert.Equal(2, result.Count());
}
```

Créez un dossier `Tests` à la racine de votre solution et un nouveau projet `Services.Test` dans ce dossier.
Créez une classe `CatalogManagerTest`.

**Packages NuGet nécessaires pour les tests :**
- `xUnit` ou `NUnit` : Framework de tests
- `Moq` : Bibliothèque de mocking
- `Microsoft.NET.Test.Sdk` : SDK pour exécuter les tests

Implémentez un test unitaire sur chaque méthode de votre `CatalogManager` en pensant à mocker le retour de votre `Repository` pour bien tester unitairement votre méthode.

**Qu'est-ce qu'un Mock ?**

Un **mock** est un faux objet qui simule le comportement d'une dépendance. Cela permet de tester une classe sans dépendre de ses dépendances réelles.

**Exemple de test avec Mock :**
```cs
using Moq;
using Xunit;

public class CatalogManagerTest
{
    private readonly Mock<IGenericRepository<Book>> _mockBookRepository;
    private readonly CatalogManager _catalogManager;

    public CatalogManagerTest()
    {
        // Arrange : Créer un mock du repository
        _mockBookRepository = new Mock<IGenericRepository<Book>>();
        
        // Injecter le mock dans le service
        _catalogManager = new CatalogManager(_mockBookRepository.Object);
    }

    [Fact]
    public void GetCatalog_ReturnsAllBooks()
    {
        // Arrange : Définir le comportement du mock
        var expectedBooks = new List<Book>
        {
            new Book { Id = 1, Name = "Book 1", Type = TypeBook.Aventure },
            new Book { Id = 2, Name = "Book 2", Type = TypeBook.Fiction }
        };
        
        _mockBookRepository
            .Setup(repo => repo.GetAll())
            .Returns(expectedBooks);

        // Act : Appeler la méthode
        var result = _catalogManager.GetCatalog();

        // Assert : Vérifier le résultat
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, b => b.Name == "Book 1");
    }

    [Fact]
    public void GetCatalog_WithTypeAventure_ReturnsOnlyAdventureBooks()
    {
        // Arrange
        var allBooks = new List<Book>
        {
            new Book { Id = 1, Name = "Adventure 1", Type = TypeBook.Aventure },
            new Book { Id = 2, Name = "Fiction 1", Type = TypeBook.Fiction },
            new Book { Id = 3, Name = "Adventure 2", Type = TypeBook.Aventure }
        };
        
        _mockBookRepository
            .Setup(repo => repo.GetAll())
            .Returns(allBooks);

        // Act
        var result = _catalogManager.GetCatalog(TypeBook.Aventure);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.All(result, book => Assert.Equal(TypeBook.Aventure, book.Type));
    }

    [Fact]
    public void FindBook_WithValidId_ReturnsBook()
    {
        // Arrange
        var expectedBook = new Book { Id = 1, Name = "Test Book" };
        
        _mockBookRepository
            .Setup(repo => repo.Get(1))
            .Returns(expectedBook);

        // Act
        var result = _catalogManager.FindBook(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Book", result.Name);
        
        // Vérifier que Get a bien été appelé avec le bon paramètre
        _mockBookRepository.Verify(repo => repo.Get(1), Times.Once);
    }

    [Fact]
    public void FindBook_WithInvalidId_ReturnsNull()
    {
        // Arrange
        _mockBookRepository
            .Setup(repo => repo.Get(999))
            .Returns((Book)null);

        // Act
        var result = _catalogManager.FindBook(999);

        // Assert
        Assert.Null(result);
    }
}
```

**Méthodes Assert courantes :**
```cs
Assert.Equal(expected, actual);        // Vérifie l'égalité
Assert.NotEqual(expected, actual);     // Vérifie la différence
Assert.True(condition);                // Vérifie qu'une condition est vraie
Assert.False(condition);               // Vérifie qu'une condition est fausse
Assert.Null(object);                   // Vérifie qu'un objet est null
Assert.NotNull(object);                // Vérifie qu'un objet n'est pas null
Assert.Contains(item, collection);     // Vérifie qu'un élément est dans une collection
Assert.Throws<Exception>(() => {});    // Vérifie qu'une exception est levée
```

**Exécuter les tests :**
```bash
# Dans Visual Studio : Test > Exécuter tous les tests
# En ligne de commande :
dotnet test
```

Pour plus d'informations : [TU avec C# - Microsoft](https://learn.microsoft.com/fr-fr/dotnet/core/testing/unit-testing-with-dotnet-test)

⚠️ Testez votre code et pensez à commiter.

### Etape 8 : API
---

**Qu'est-ce qu'une API REST ?**

Une **API** (Application Programming Interface) est une interface logicielle qui permet à des applications de communiquer entre elles.

**REST** (Representational State Transfer) est un style d'architecture pour les APIs web basé sur HTTP.

**Principes REST :**
- Utilise les méthodes HTTP : GET (lire), POST (créer), PUT (modifier), DELETE (supprimer)
- Les ressources sont identifiées par des URLs : `/books`, `/books/1`
- Communication sans état (stateless) : chaque requête est indépendante
- Réponses au format JSON ou XML

**Exemple de requêtes REST :**
```
GET    /api/books          → Récupère tous les livres
GET    /api/books/1        → Récupère le livre avec ID 1
POST   /api/books          → Crée un nouveau livre
PUT    /api/books/1        → Modifie le livre avec ID 1
DELETE /api/books/1        → Supprime le livre avec ID 1
```

On va maintenant mettre en place une API. Pour rappel, une API est une interface logicielle sur laquelle vous pourrez vous connecter et récupérer des informations via requête HTTP. Elle vous renverra un résultat sous la forme d'un JSON.

Pour cela, vous allez créer un nouveau projet de type `ASP.NET Core WebAPI` sans authentification, que vous allez appeler `LibraryManager.Hosting`.

Une fois créé, vous allez mettre ce projet en tant que projet de démarrage. 

Votre nouveau `Program.cs` va ressembler à ça :

```cs
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
Les Middleware ajoutés avant le builder seront récupérés par l'application
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
```

Transformez votre fichier grâce aux recommandations VS `Alt + Entrée`.

Ajoutez à votre builder les services de votre précédent `Program.cs`.

**Qu'est-ce que Swagger ?**
- **Swagger** génère automatiquement une documentation interactive de votre API
- Permet de tester les endpoints directement depuis le navigateur
- Accessible à : `https://localhost:5001/swagger`

Observez la classe créée :

```cs
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
```

**Explication des attributs :**

Les éléments entre crochets sont appelés des **attributs**. Ils définissent des métadonnées qui sont lisibles durant l'exécution.

```cs
[ApiController]              // Marque cette classe comme contrôleur API
[Route("[controller]")]      // Définit la route : /WeatherForecast
[HttpGet]                    // Méthode HTTP GET
[HttpPost]                   // Méthode HTTP POST
[HttpPut]                    // Méthode HTTP PUT
[HttpDelete]                 // Méthode HTTP DELETE
```

Donc pour accéder à cette API, nous utiliserons `GET localhost:5000/WeatherForecast`. Il existe même des attributs pour l'authentification.

Après l'explication, place à la pratique.

Créez un fichier `BookController` qui va comprendre les méthodes suivantes :

**Endpoints à implémenter :**
- `GET /books` : Récupère tous les livres
- `GET /books/{id}` : Récupère un livre par son ID
- `GET /books/type/{type}` : Récupère les livres d'un type donné
- `POST /books` : Ajoute un nouveau livre
- `GET /books/top-rated` : Récupère le livre le mieux noté (TODO)
- `DELETE /books/{id}` : Supprime un livre (TODO)

**Exemple d'implémentation du BookController :**

```cs
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Hosting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // Route : /api/books
    public class BooksController : ControllerBase
    {
        private readonly ICatalogManager _catalogManager;

        // Injection du service via le constructeur
        public BooksController(ICatalogManager catalogManager)
        {
            _catalogManager = catalogManager;
        }

        // GET api/books
        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _catalogManager.GetCatalog();
            return Ok(books);  // Retourne un HTTP 200 avec les données
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _catalogManager.FindBook(id);
            
            if (book == null)
                return NotFound();  // Retourne HTTP 404 si non trouvé
            
            return Ok(book);  // Retourne HTTP 200 avec le livre
        }

        // GET api/books/type/Aventure
        [HttpGet("type/{type}")]
        public IActionResult GetByType(TypeBook type)
        {
            var books = _catalogManager.GetCatalog(type);
            return Ok(books);
        }

        // POST api/books
        [HttpPost]
        public IActionResult Add([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();  // Retourne HTTP 400 si données invalides
            
            // Logique d'ajout (à implémenter dans le CatalogManager)
            // var addedBook = _catalogManager.AddBook(book);
            
            return CreatedAtAction(
                nameof(GetById),      // Nom de la méthode pour récupérer le livre
                new { id = book.Id }, // Paramètres de route
                book                  // Corps de la réponse
            );  // Retourne HTTP 201 Created
        }

        // GET api/books/top-rated
        [HttpGet("top-rated")]
        public IActionResult GetTopRated()
        {
            // TODO: Implémenter la logique pour récupérer le livre le mieux noté
            return Ok(new { message = "TODO" });
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // TODO: Implémenter la logique de suppression
            return NoContent();  // Retourne HTTP 204 No Content
        }
    }
}
```

**Codes de statut HTTP courants :**
```cs
return Ok(data);              // 200 : Succès
return Created();             // 201 : Créé avec succès
return NoContent();           // 204 : Succès sans contenu
return BadRequest();          // 400 : Requête invalide
return NotFound();            // 404 : Ressource non trouvée
return Unauthorized();        // 401 : Non authentifié
return Forbid();              // 403 : Accès interdit
return StatusCode(500);       // 500 : Erreur serveur
```

**Paramètres dans les contrôleurs :**
```cs
[HttpGet("{id}")]                    // Paramètre dans l'URL
public IActionResult Get(int id)     // Automatiquement lié

[HttpPost]
public IActionResult Create([FromBody] Book book)  // Depuis le corps JSON

[HttpGet]
public IActionResult Search([FromQuery] string name)  // Depuis query string ?name=...
```

Implémentez les méthodes manquantes.

Faites en sorte d'afficher l'`Author` correspondant à votre `Book`.

**Astuce : Include() pour charger les relations**
```cs
// Dans votre repository ou service
var books = _context.Books
    .Include(b => b.Author)  // Charge l'auteur en même temps
    .ToList();
```

Pour tester votre API, installez [Postman](https://www.postman.com/).

**Comment tester avec Postman :**
1. Ouvrir Postman
2. Créer une nouvelle requête
3. Sélectionner la méthode HTTP (GET, POST, etc.)
4. Entrer l'URL : `https://localhost:5001/api/books`
5. Pour POST : ajouter le JSON dans l'onglet "Body" > "raw" > "JSON"
6. Cliquer sur "Send"

**Alternative : Tester avec Swagger**
- Lancer l'application
- Naviguer vers `https://localhost:5001/swagger`
- Tester directement les endpoints depuis l'interface

Pour plus d'informations : [Tutoriel ASP.NET Core Web API- Microsoft](https://learn.microsoft.com/fr-fr/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio)

⚠️ Testez votre code et pensez à commiter.

### Etape 9 : Limiter l'accès aux données (DTO)
---

**Qu'est-ce qu'un DTO ?**

DTO signifie **Data Transfer Object** (Objet de Transfert de Données).

**Pourquoi utiliser des DTOs ?**
- **Sécurité** : Cache des données sensibles (mots de passe, informations internes...)
- **Contrôle** : Expose uniquement les données nécessaires au client
- **Performance** : Réduit la taille des réponses
- **Découplage** : L'API n'est pas liée à la structure interne de la base de données
- **Versionning** : Facilite l'évolution de l'API sans casser les clients existants

**Problème sans DTO :**
```cs
// Entité Book complète
public class Book : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Pages { get; set; }
    public TypeBook Type { get; set; }
    public int Rate { get; set; }          // ⚠️ Information interne
    public int IdAuthor { get; set; }      // ⚠️ Clé étrangère exposée
    public Author Author { get; set; }
}

// Problème : Tout est exposé dans l'API, même les données internes !
```

**Solution avec DTO :**
```cs
// DTO : Version publique sans données sensibles
public class BookDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Pages { get; set; }
    public string Type { get; set; }
    // Pas de Rate (information interne)
    // Pas de IdAuthor (clé étrangère)
    public AuthorDto Author { get; set; }  // Auteur inclus mais aussi en DTO
}

public class AuthorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}
```

Dans votre projet `BusinessObjects`, créez un dossier `DataTransfertObject`.
Dans celui-ci, vous pouvez créer un `BookDto`. 

Un DTO est une version de l'objet destinée à l'extérieur de votre application. Cela peut être utile pour limiter les données accessibles aux clients de votre API.

Dans votre `BookDto`, reprenez les éléments de votre `Book` en retirant le `Rate`.

Faites en sorte que les `Book`s fournis par votre `CatalogManager` soient convertis en `BookDto` au niveau de vos `Controller`s.

**Conversion manuelle (simple) :**
```cs
// Dans votre contrôleur
[HttpGet]
public IActionResult GetAll()
{
    var books = _catalogManager.GetCatalog();
    
    // Conversion manuelle Book → BookDto
    var bookDtos = books.Select(book => new BookDto
    {
        Id = book.Id,
        Name = book.Name,
        Pages = book.Pages,
        Type = book.Type.ToString(),
        Author = new AuthorDto
        {
            FirstName = book.Author.FirstName,
            LastName = book.Author.LastName
        }
    });
    
    return Ok(bookDtos);
}
```

**Conversion automatique avec AutoMapper (recommandé) :**

AutoMapper est une bibliothèque qui automatise le mapping entre objets.

```cs
// 1. Installer le package NuGet : AutoMapper.Extensions.Microsoft.DependencyInjection

// 2. Créer un profil de mapping
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.Type, 
                      opt => opt.MapFrom(src => src.Type.ToString()));
        
        CreateMap<Author, AuthorDto>();
    }
}

// 3. Enregistrer AutoMapper dans Program.cs
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 4. Utiliser dans le contrôleur
public class BooksController : ControllerBase
{
    private readonly ICatalogManager _catalogManager;
    private readonly IMapper _mapper;

    public BooksController(ICatalogManager catalogManager, IMapper mapper)
    {
        _catalogManager = catalogManager;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var books = _catalogManager.GetCatalog();
        var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);
        return Ok(bookDtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _catalogManager.FindBook(id);
        if (book == null) return NotFound();
        
        var bookDto = _mapper.Map<BookDto>(book);
        return Ok(bookDto);
    }
}
```

Chacun de vos `Controller`s doivent utiliser et renvoyer des `BookDto`.

**Exemple de réponse JSON avec DTO :**
```json
{
  "id": 1,
  "name": "Le Comte de Monte Cristo",
  "pages": 900,
  "type": "Aventure",
  "author": {
    "firstName": "Alexandre",
    "lastName": "Dumas",
    "fullName": "Alexandre Dumas"
  }
}
```

⚠️ Testez votre code et pensez à commiter.


### Etape 10 : WIP
---



⚠️ Testez votre code et pensez à commiter.

## Raccourcis utiles 
---

- Recommandation VS : `Alt + Entrée` => Hyper utile, n'hésitez pas à en abuser
- Renommer un élément et ses références : `(Hold) CTRL + R + R`
- Créer une propriété : `(Write) prop + Tab`
- Créer un constructeur: `(Write) ctor + Tab`
- Redirection sur la classe concernée : `F12`
- Redirection sur la classe concrète concernée : `Ctrl + F12`
- Afficher le contenu de l'élément dans un encart : `Alt + F12`
- Lancer en Debug : `F5`
- Faire continuer le programme : `F5`
- Instruction suivante : `F10`
- Instruction suivante dans la méthode : `F11`
- Ajouter une référence à un projet : `Clic droit sur un Projet > Ajouter > Ajouter une référence à un projet`

## Contacts
---

- Mail : erwann.fiolet@gmail.com
- Discord : byabyakar

Pour m'envoyer votre TP, envoyez-moi un courriel avec pour objet : **[IUT] Nom Prénom 1 - Nom Prénom 2** en me précisant dans le corps la partie à laquelle vous vous êtes arrêtés.

Ajoutez-y un zip de votre solution que vous aurez préalablement nettoyé `Générer > Nettoyer la solution`

### Relecture 📝

- Colin Prokopowicz 
