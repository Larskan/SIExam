# System Integration - Real Life Game Microservice(Status, Skill, Task, Title).
Dette project er en simpel og faglig fokuseret microservice arkitektur, med fokus på Resiliensmønstre.
Den er ment som version 1.0 af et større projekt. Denne version er mest fokuseret omkring Resiliensmønstre.

Projektet indeholder:
* Opdeling i selvstændige services(Skill, Task og Title).
* En aggregaret service som kaldes af alle andre services(Status).
* Kommunikation via HTTP/REST mellem services.
* Brug af Swagger til HTTP for simpel API Dokumentation for Skill, Task og Title.
* Resiliens Patterns: Timeout, Retry, Circuit Breaker.
* Containeriseing med Docker vha. docker-compose som bruger dockers interne netværk(siexam_default) til at tillade mikroservices at kommunikere.
* Brug af Data Transfer Objects(DTOs).

Projektet er skrevet i C# med EntityFramework.

## Arkitektur
Alle services kører i hver sin container via docker. 
Alle services are medlemmer af docker netværket: siexam_default.

### SkillService
**Formål:**
Står for en spillers skills.

**Vigtigste Filer:**
SIEXAM/SIExam/SkillService/Controllers/SkillController.cs
* GET All skills
* POST Create skill
* PATCH Update skill level
* PATCH Update skill mastery

### TaskService
**Formål:**
Står for en spillers daglige, ugentlige, måndedlige og årlige tasks.

**Vigtigste Filer:**
SIEXAM/SIExam/TaskService/Controllers/TaskController.cs
* GET all tasks
* POST Create task
* PATCH Update task description
* PATCH Update task experience
* PATCH Update task gains

### TitleService
**Formål:**
Står for en spillers titler.

**Vigtigste Filer:**
SIEXAM/SIExam/TitleService/Controllers/TitleController.cs
* GET all titles
* POST Create title
* PATCH Update title name
* PATCH Update title description
* PATCH Update title gains
* PATCH Update title tier

### StatusService
**Formål:**
Står for at vise alle informationerne spilleren har adgang til.

**Vigtigste Filer:**
SIEXAM/SIExam/StatusService/Program.cs
* Indeholder Resiliens for alle services den er afhængig af.