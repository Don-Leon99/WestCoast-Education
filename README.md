# WestCoast Education

Konsolapplikation i C# (.NET) för att hantera kurser, studenter och lärare på det fiktiva utbildningsföretaget WestCoast Education. Projektet är en inlämningsuppgift i C# grundkurs och bygger på företagets kravspecifikation.

## Innehåll

- [Funktioner](#funktioner)
- [Kom igång](#kom-igång)
- [Meny](#meny)
- [Projektstruktur](#projektstruktur)
- [Klassdiagram](#klassdiagram)
- [Designval](#designval)
- [JSON-hantering](#json-hantering)
- [Kravuppfyllnad](#kravuppfyllnad)
- [Kända begränsningar](#kända-begränsningar)

## Funktioner

- Lista, lägga till och ta bort kurser
- Lista och lägga till studenter och lärare
- Anmäla studenter till kurser och koppla lärare till kurser
- Särskilja klassrumskurser (`InClass`) och distanskurser (`AtHome`)
- Kursstatus beräknad från datum (Upcoming, Ongoing, Finished)
- Spara och läsa in kurser som JSON
- Förifylld testdata (6 kurser, 6 studenter, 2 lärare) som simulerar en pågående skola

## Kom igång

### Krav

- [.NET SDK](https://dotnet.microsoft.com/download) 7.0 eller senare (projektet använder `DateOnly` och JSON-hantering av `DateOnly`)

### Köra programmet

```bash
git clone <https://github.com/Don-Leon99/WestCoast-Education>
cd westcoasteducation
dotnet run
```

Kör programmet från projektmappen (där `.csproj`-filen ligger). Sökvägen till JSON-filen bygger på `Environment.CurrentDirectory`, så `Data/courses.json` hamnar då i projektets egen `Data`-mapp.

## Meny

| Val | Funktion |
|-----|----------|
| 1 | Lista kurser |
| 2 | Lista studenter |
| 3 | Lista lärare |
| 4 | Lägg till kurs |
| 5 | Lägg till student |
| 6 | Lägg till lärare |
| 7 | Anmäl student till kurs |
| 8 | Koppla lärare till kurs |
| 9 | Spara kurser till JSON |
| 10 | Läs in kurser från JSON |
| 11 | Lista allt (kurser, studenter, lärare) |
| 0 | Avsluta |

Test: välj 7 och anmäl en student, kontrollera med 1 att antalet studenter ökat, spara med 9 och öppna `Data/courses.json`.

## Projektstruktur

```
westcoasteducation/
├── Data/
│   └── courses.json          # Genereras av menyval 9
├── Address.cs                # Adress (composition i Person)
├── Administrator.cs          # Ärver EducationLeader
├── ConsoleMenu.cs            # Meny och användarinmatning
├── CourseManager.cs          # Hanterar kurser
├── Courses.cs                # Course
├── CourseType.cs             # Enum: InClass / AtHome
├── EducationLeader.cs        # Ärver Teacher
├── IPrintable.cs             # Interface med GetInfo()
├── Jsonify.cs                # Skriva/läsa JSON
├── Person.cs                 # Abstrakt basklass
├── PersonManager.cs          # Generisk basklass för managers
├── Printer.cs                # Skriver ut IPrintable-objekt
├── Program.cs                # Startpunkt
├── StudentManager.cs         # Hanterar studenter
├── Students.cs               # Student
├── TeacherManager.cs         # Hanterar lärare
└── Teachers.cs               # Teacher
```

## Klassdiagram

```
IPrintable
 ├── Person (abstrakt)
 │    ├── Student
 │    └── Teacher
 │         └── EducationLeader
 │              └── Administrator
 └── Course

PersonManager<T> (abstrakt, där T : Person)
 ├── StudentManager
 └── TeacherManager

CourseManager
ConsoleMenu  ──använder──▶  CourseManager, StudentManager, TeacherManager
Printer      ──använder──▶  IPrintable
Jsonify      ──använder──▶  Course
```

## Designval

### Arv
`Person` innehåller de fält som studenter och lärare delar (id, namn, telefon, e-post, personnummer, adress) samt en virtuell `GetInfo()`. `Student` och `Teacher` ärver från den och lägger till egna fält. `EducationLeader` ärver `Teacher`, och `Administrator` ärver `EducationLeader`, vilket följer kravspecens kedja. På managers-sidan samlar den generiska `PersonManager<T>` gemensam logik (`Add`, `Remove`, `GetById`, `ListAll`, `GetAll`), så `StudentManager` och `TeacherManager` slipper duplicera kod.

### Composition
`Person` skapar sitt eget `Address`-objekt i konstruktorn (`new Address(...)`). En adress har ingen mening utan personen den tillhör, och ingen utanför kan dela eller återanvända objektet.

### Aggregation
`Student.EnrolledCourses` och `Teacher.TeachingCourses` är listor av `Course`, och `Course.EnrolledStudents` och `Course.DeployedTeachers` är listor tillbaka. Kurser och personer lever oberoende av varandra, så om en student tas bort finns kursen kvar och tvärtom. Båda sidor hålls synkade via `EnrollStudentToCourse` och `RegisterCourseToTeacher`, även för förifylld data.

### Interface
`Person` och `Course` är inte släkt via arv, men båda kan presentera sig själva. `IPrintable` ger dem ett gemensamt kontrakt (`string GetInfo()`), så `Printer` och menyn kan skriva ut kurser, studenter och lärare med samma kod.

### Ansvarsfördelning
- Datamodellerna (`Person`, `Course` m.fl.) beskriver bara data och sin egen presentation.
- Managers hanterar listor och logik.
- `Jsonify` ansvarar för filhantering.
- `ConsoleMenu` ansvarar för inmatning och utskrift, `Program.cs` är bara startpunkten.

## JSON-hantering

Kurser sparas i `Data/courses.json` med `System.Text.Json`, enligt samma upplägg som i kursens exempel (CamelCase, indenterad utskrift, `UnsafeRelaxedJsonEscaping` för svenska tecken, skiftlägesokänslig inläsning).

- `EnrolledStudents` och `DeployedTeachers` är markerade med `[JsonIgnore]` för att undvika cirkelreferenser (kurs ↔ student/lärare).
- För att ändå bevara kopplingarna sparas studenternas och lärarnas **id:n** i `StudentIds` och `TeacherIds`. Efter inläsning återskapar `RelinkAfterLoad()` i `ConsoleMenu` kopplingarna utifrån id:na.
- `EndDate` är en beräknad property (`StartDate` + `LengthInWeeks`) och sparas därför men räknas om vid inläsning.
- `Course` har en parameterlös konstruktor så att deserialiseraren kan skapa objekt.

## Kravuppfyllnad

**Godkänt (G)**
- [x] Alla klasser finns: Course, Student, Teacher, EducationLeader, Administrator
- [x] Composition (`Person` → `Address`) och aggregation (`Student`/`Teacher` ↔ `Course`)
- [x] Minst två klasser med fungerande logik (villkor och loopar): Student, Teacher, Course, managers och menyn
- [x] Klassrums- och distanskurser särskiljs via enum `CourseType`
- [x] Konsolapplikation med klasserna i separata filer

**Väl godkänt (VG)**
- [x] Arv för att minimera duplicerad kod
- [x] Interface (`IPrintable`) som används av `Printer` och menyn
- [x] Skriva och läsa kurser som JSON

## Kända begränsningar

- Programmet läser inte in `courses.json` automatiskt vid start. Välj 11 för att läsa in sparad data. Väljer du 10 direkt vid start skrivs filen över med den förifyllda datan.
- Endast kurser sparas till JSON. Studenter och lärare skapas på nytt från testdatan vid varje start, så nya studenter och lärare som lagts till via menyn finns inte kvar efter omstart, och kopplingar till dem hoppas över vid inläsning.
- `EducationLeader` och `Administrator` finns som klasser men används inte i menyn.
