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
- *Projet* :
  - Bloc de construction de l'application
  - Va générer une dll par projet
  - Facilement extractable d'une solution à une autre
- *Nuget* :
  - Gestionnaire de package
  - Permet d'intégrer des dll à votre projet pour étendre les fonctionnalités de votre code (AutoMapper, ORM...)
  - On peut l'ouvrir en faisant `Clic droit > Gestionnaire Nuget` en cliquant sur un projet ou la solution 

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

Créez un nouveau projet via Visual Studio 2022, puis sélectionner une *Application Console*.

Vous appellerez votre projet `LibraryManager.App` et votre solution `LibraryManager`.

Si vous n'avez pas d'explorateur de solution sur votre IDE, vous pouvez aussi l'ajouter via le menu `Affichage > Explorateur de Solution`.

Ajouter via le *gestionnaire de package Nuget* sur votre projet : Microsoft.Extensions.Hosting

Veillez à bien être en vue Solution et d'avoir votre projet chargé.

⚠️ Testez votre code et pensez à commiter.

### Etape 2 : Commencer son programme
---

Créez une méthode Main dans le `Program.cs` grâce aux recommandations VS `Alt + Entrée` à l'intérieur du fichier.

Créez une classe `Book` qui contiendra uniquement un `string Name` et un `string Type`. 

Dans cette méthode, vous allez faire créer une liste de livre que vous allez alimenter avec quelques éléments dont au moins un livre de type `Aventure`. Libre à vous de mettre ce que vous souhaitez dans celle-ci.

Vous allez ensuite boucler sur celle-ci et afficher dans la console les différents noms.

⚠️ Testez votre code et pensez à commiter.

### Etape 3 : LINQ
---

LINQ (prononcé line-cue) est un langage d'interrogation pour vos tableaux en .NET.

Celui-ci vous permettra de filtrer vos tableaux et d'ajouter une granularité supplémentaire.
Il est possible d'utiliser LINQ via le langage correspondant (comme du SQL) ou d'utiliser des méthodes sur vos listes.

Dans ce contexte, on utilisera la version avec des méthodes mais sachez que les deux sont possibles.

Filtrez votre liste pour n'afficher que les livres de type `Aventure`.

Pour plus d'informations : [LINQ - Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/linq/) 

⚠️ Testez votre code et pensez à commiter.

### Etape 4.1 : Préparer son architecture
---

 Mettez en place votre architecture de projets en ajoutant via Visual Studio des projets de type **Bibliothèque de classes** :
- `BusinessObjects` : Couche contenant vos objets métier (objets de base de données ou de travail)
- `DataAccessLayer` : Couche permettant l'accès aux données; on y retrouvera notamment les repository

Maintenant passons à l'implémentation de notre architecture.

1. Dans votre projet `BusinessObjects`, créez un dossier `Entity` et `Enum`, puis dans ce dossier `Entity`, créez les objets correspondants aux tables du fichier `LibraryInit.sql`.

Déplacez-y votre classe `Book` que vous compléterez et changez votre `string Type` en enum `TypeBook Type`. Pas besoin de créer un fichier pour la table de `Stock`.

Faites en sorte que toutes entités héritent d'une interface `IEntity` qui contiendra une propriété `int Id`.

Dans le cadre d'une relation `OneToMany` (1..\*) ou `ManyToMany` (\*), le **Many** se manifeste sous la forme d'une liste (Ex : `IEnumerable<ClassA>`) et le **One** sous la forme d'un objet simple (Ex : `ClassA`).

2. Dans votre projet `DataAccessLayer`, créez un dossier `Repository`, puis dans ce dossier une classe repository pour chaque entité (ex : `BookRepository`)

Vous y créerez les méthodes `GetAll()` qui retournera un `IEnumerable<Book>` et `Get(int id)` qui retournera un `Book`, vous pouvez `return` des objets vides à ce stade.

Répétez le même schéma pour chacune de vos entités.

Pour le `BookRepository`, utilisez la liste que vous avez créé dans le `Main` puis implémentez les méthodes `IEnumerable<Book> GetAll()` et `Book Get(int id)`, appelez ces méthodes dans votre `Main` et finalement tentez d'afficher les livres d'aventure.

**PI : Vous aurez besoin d'ajouter des références d'un projet à un autre pour permettre d'utiliser vos entités à l'extérieur de leur projet respectif.**

⚠️ Testez votre code et pensez à commiter.


### Etape 4.2 : Préparer son architecture
---

 Mettez en place votre architecture de projets en ajoutant via Visual Studio des projets de type **Bibliothèque de classes** :
- `Services` : Couche services intermédiaire; va permettre d'orchestrer les besoins et de relier d'autres couches entre elles

4. Dans votre projet `Services`, créez un dossier `Services`, puis dans ce dossier une classe `CatalogManager` qui contiendra les méthodes `IEnumerable<Book> GetCatalog()`, `IEnumerable<Book> GetCatalog(Type type)` et `Book FindBook(int id)` qui utiliseront le `BookRepository`.

Ces méthodes vont utiliser les Repository que vous avez créé. Remplacez les méthodes de votre `Main` par les méthodes nouvellement créées dans votre `CatalogManager`.


### Etape 5 : Injection de dépendance
---

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
Plutôt que d'avoir à changer toutes les références à notre classe concrète, nous allons mettre dans le constructeur notre interface qui vous donnera les fonctions disponibles.
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

  // Before
  public Constructor() {
    _caller = new ApiACaller();
  }

  // After
  public Constructor(IApiCaller apiCaller) {
    _caller = apiCaller;
  }
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

Pour réaliser de l'injection de dépendance :
- Extrayez une interface de vos classes concrètes ayant de la logique et instanciées ailleurs dans votre code (Ex : Services...)
- Pour vos repository, on fera un peu différemment. Vous allez créer une seule interface `IGenericRepository<T>` qui prendra en paramètre un type générique `T` qui sera une `IEntity` et qui vous servira pour vos types de retours
- Injectez vos dépendances dans la configuration de vos services de votre `Program.cs`
- Utilisez ces classes injectées en retirant les appels inutiles à vos classes concrètes 

Récupérez votre Service dans le `Main` et testez en reprenant l'exemple du `IApiCaller` :

```cs
  IApiCaller apiCaller = host.Services.GetRequiredService<IApiCaller>();
  apiCaller.Call();
```

Pour plus d'informations : 
- [Injection de dépendance - Microsoft](https://learn.microsoft.com/fr-fr/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-8.0)
- [Classes et méthodes générique - Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/types/generics)

⚠️ Testez votre code et pensez à commiter.

### Etape 6 : EntityFramework
---

Avec l'aide de la base de données SQLite fournie en annexe, vous allez implémenter l'ORM **EntityFramework**.

Vous aurez besoin d'un package SQLite pour poursuivre, je vous laisse chercher.

Le but ici est d'au lieu de renvoyer des listes vides au niveau de vos `Repositories`, de renvoyer les infos qui sont stockées en base de données.

Dans votre `DataAccessLayer`, créez un dossier `Contexts` et un fichier `LibraryContext` qui implémentera la classe `DbContext`, servez-vous de la documentation pour remplir votre DbContext.  

Pensez à l'injecter, pour une fois on utilisera une classe concrète. Vous aurez sûrement un autre Nuget à récupérer sur vos deux projets.

```cs
// Dans la configuration du service
  services.AddDbContext<LibraryContext>();

// Dans la configuration de votre LibraryContext 
  options.UseSqlite("Data Source={path};");
```

Vous pouvez construire un chemin absolu avec l'aide de la classe `Path`. **Faites en sorte que le fichier `.db` soit copié à la compilation.**

Dans vos repositories, utilisez le `LibraryContext` injecté pour récupérer le contenu de la base.

Ajoutez une méthode `IEntity Add(IEntity)` dans `IGenericRepository`. Compilez et déboguez.

Vous réalisez à quel point c'est fastidieux de tout changer à la fois.

(Refacto en cours) Maintenant créez une classe concrète `GenericRepository<T>` qui doit remplacer tous vos repositories existants et remplacez les injections.

Supprimez vos anciens repositories.

Pour plus d'informations : 
- [EntityFramework - Microsoft](https://learn.microsoft.com/fr-fr/ef/core/)
- [DBeaver](https://dbeaver.io/) qui est vraiment utile quand vous avez plusieurs SGBD différents à gérer.

⚠️ Testez votre code et pensez à commiter.

### Etape 7 : TU
---

Créez un dossier `Tests` à la racine de votre solution et un nouveau projet `Services.Test` dans ce dossier.
Créez une classe `CatalogManagerTest`.

Implémentez un test unitaire sur chaque méthode de votre `CatalogManager` en pensant à Mock le retour de votre `Repository` pour bien tester unitairement votre méthode.

Pour plus d'informations : [TU avec C# - Microsoft](https://learn.microsoft.com/fr-fr/dotnet/core/testing/unit-testing-with-dotnet-test)

⚠️ Testez votre code et pensez à commiter.

### Etape 8 : API
---

On va maintenant mettre en place une API. Pour rappel, une API est une interface logicielle sur laquelle vous pourrez vous connecter et récupérer des informations via requête HTTP. Elle vous renverra un résultat sous la forme d'un JSON.

Pour cela, vous allez créer un nouveau projet de type `ASP.NET Core WebAPI`, sans authentification que vous allez appeler `LibraryManager.Hosting`.

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
Les éléments entre crochets sont appelés des attributs. Ils définissent des métadonnées qui sont lisibles durant l'exécution.

Donc pour accéder à cette API, nous utiliserons `GET localhost:53000/WeatherForecast`. Il existe même des attributs pour l'authentification.

Après l'explication, place à la pratique.

Créez un fichier `BookController` qui va comprendre les méthodes *GET* suivantes :
- books
- book/{id}
- books/{type}
- book/add
- book/topRatedBook (TODO)
- book/delete (TODO)

Implémentez les méthodes manquantes.

Faites en sorte d'afficher l'`Author` correspondant à votre `Book`.

Pour tester votre API, installez [Postman](https://www.postman.com/).

Pour plus d'informations : [Tutoriel ASP.NET Core Web API- Microsoft](https://learn.microsoft.com/fr-fr/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio)

⚠️ Testez votre code et pensez à commiter.

### Etape 9 : Limiter l'accès aux données
---

Dans votre projet `BusinessObjects`, créez un dossier `DataTransfertObject`.
Dans celui-ci, vous pouvez créer un `BookDto`. 

Un DTO est une version de l'objet qui sera à destination de l'extérieur de votre application, cela peut être utile pour limiter les données accessibles aux clients de votre API.

Dans votre `BookDto`, reprenez les éléments de votre `Book` en retirant le `Rate`.

Faites en sorte que les `Book`s fournis par votre `CatalogManager` soient convertis en `BookDto` au niveau de vos `Controller`s.

Chacun de vos `Controller`s doivent utiliser et renvoyer des `BookDto`.

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
