-- NES Classics
INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Super Mario Bros.', 'Nintendo', 'NES', 1985, 5, 5, 42
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Super Mario Bros.');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'The Legend of Zelda', 'Nintendo', 'NES', 1986, 4, 4, 37
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='The Legend of Zelda');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Metroid', 'Nintendo', 'NES', 1986, 4, 4, 29
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Metroid');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Contra', 'Konami', 'NES', 1987, 4, 4, 33
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Contra');

-- Sega Genesis
INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Sonic the Hedgehog', 'Sega', 'Sega Genesis', 1991, 5, 5, 48
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Sonic the Hedgehog');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Streets of Rage 2', 'Sega', 'Sega Genesis', 1992, 4, 4, 36
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Streets of Rage 2');

-- Arcade
INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Pac-Man', 'Namco', 'Arcade', 1980, 6, 6, 61
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Pac-Man');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Donkey Kong', 'Nintendo', 'Arcade', 1981, 4, 4, 54
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Donkey Kong');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Street Fighter II', 'Capcom', 'Arcade', 1991, 4, 4, 47
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Street Fighter II');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Mortal Kombat', 'Midway', 'Arcade', 1992, 5, 5, 81
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Mortal Kombat');

-- Game Boy
INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Tetris', 'Nintendo', 'Game Boy', 1989, 6, 6, 72
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Tetris');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Pokémon Red', 'Game Freak', 'Game Boy', 1996, 5, 5, 83
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Pokémon Red');

-- Nintendo (SNES/N64 grouped)
INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Chrono Trigger', 'Square', 'Nintendo', 1995, 3, 3, 76
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Chrono Trigger');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Super Mario Kart', 'Nintendo', 'Nintendo', 1992, 4, 4, 69
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Super Mario Kart');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'The Legend of Zelda: Ocarina of Time', 'Nintendo', 'Nintendo', 1998, 4, 4, 81
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='The Legend of Zelda: Ocarina of Time');

-- PC Classics
INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Doom', 'id Software', 'PC', 1993, 5, 5, 44
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Doom');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'The Secret of Monkey Island', 'Lucasfilm Games', 'PC', 1990, 3, 3, 27
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='The Secret of Monkey Island');

-- PS1 Classics
INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Final Fantasy VII', 'Square', 'PS1', 1997, 5, 5, 92
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Final Fantasy VII');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Metal Gear Solid', 'Konami', 'PS1', 1998, 5, 5, 88
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Metal Gear Solid');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Crash Bandicoot', 'Naughty Dog', 'PS1', 1996, 4, 4, 73
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Crash Bandicoot');

INSERT INTO VideoGames (Title, Developer, Platform, ReleaseYear, CopiesTotal, CopiesAvailable, TimesCheckedOut)
SELECT 'Resident Evil 2', 'Capcom', 'PS1', 1998, 4, 4, 84
WHERE NOT EXISTS (SELECT 1 FROM VideoGames WHERE Title='Resident Evil 2');