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
* Test metoder i controllers til at teste resiliensmønstrene.

Projektet er skrevet i C# med EntityFramework og Docker.

## Arkitektur
Alle services kører i hver sin container via docker. 
Alle services er medlemmer af docker netværket: siexam_default.

### SkillService
**Formål:**
Står for en spillers skills.

**Link to swagger:**
http://localhost:5001/swagger/index.html

**Vigtigste Filer:**
SIEXAM/SIExam/SkillService/Controllers/SkillController.cs
* GET slow til test af Timeout
* GET unstable til test af Retry og Circuit Breaker
* GET unreliable til alternativ test af Retry og Circuit Breaker
* GET All skills
* POST Create skill
* PATCH Update skill level
* PATCH Update skill mastery

### TaskService
**Formål:**
Står for en spillers daglige, ugentlige, måndedlige og årlige tasks.

**Link to swagger:**
http://localhost:5002/swagger/index.html

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

**Link to swagger:**
http://localhost:5003/swagger/index.html

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

**Link to swagger:**
http://localhost:5004/swagger/index.html

**Vigtigste Filer:**
SIEXAM/SIExam/StatusService/Program.cs
* Indeholder Resiliens for alle services den er afhængig af.

SIEXAM/SIExam/StatusService/Resilience/PollyPolicies.cs
* Resiliensmønstrene.

SIEXAM/SIExam/StatusService/Controllers/StatusController.cs
* GET slow til test af Timeout
* GET unstable til test af Retry og Circuit Breaker
* GET unreliable til alternativ test af Retry og Circuit Breaker
* GET status via ID
* POST Create status
* POST RegisterExperience
* POST RegisterStats