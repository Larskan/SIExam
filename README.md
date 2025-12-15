Use e.g. Polly to implement ressilience in a microservices system. 
Discuss the different ressilience patterns and how they are implemented. 
Discuss the pros and cons of the patterns and argue for the particular choice of patterns used in the system. 
Examples of ressilience patterns: Circuit Breaker, Retry, Timeout, Bulkhead, and Fallback.

StatusService: Contains the Players status, their experience, their level, their access to Skills, their access to Titles, their access to Tasks, their stats
TaskService: Handles creation of Tasks, Marking tasks as done, registering XP for completed tasks, deleting tasks, creating projects with specific tasks.
TitleService: Handles creation of titles, listing titles as tiers(1-10) depending on how well they are achieved, registers XP for title tiers, registers stats as reward for new tiers.
SkillService: Handles creation of skills, mastery of skills(Basic, Intermediate, Advanced, Musou), registers XP based on level ups, registers stats based on skill mastery