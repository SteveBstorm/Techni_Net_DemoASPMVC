/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Game (Title, Description, Genre) VALUES 
('Rocket league', 'Best jeu de foot ever', 'Action'),
('Baldur''s Gate 3', 'Anne PC Killer', 'RPG'),
('CS:GO', 'Pour ceux qui aime le pan pan', 'FPS'),
('World of Warcraft', 'Best perte de temps ever', 'Meuporg')

EXEC UserRegister 'admin@mail.com', 'Test1234!', 'Arthur'
EXEC UserRegister 'user@mail.com', 'Test1234!', 'Merlin'

UPDATE Users SET RoleId = 3 WHERE Id = 1