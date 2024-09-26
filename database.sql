CREATE TABLE `users` (
  `id` integer PRIMARY KEY AUTO_INCREMENT,
  `username` varchar(255),
  `password` varchar(255),
  `salt` varchar(255),
  `role` ENUM ('player', 'organizer'),
  `balance` double
);

CREATE TABLE `games` (
  `id` integer PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(255),
  `organizerId` int
);

CREATE TABLE `gameSubjects` (
  `id` integer PRIMARY KEY AUTO_INCREMENT,
  `gameId` integer,
  `name` varchar(255)
);

CREATE TABLE `gameEvents` (
  `id` integer PRIMARY KEY AUTO_INCREMENT,
  `gameId` integer,
  `name` varchar(255)
);

CREATE TABLE `gameResults` (
  `subjectId` int,
  `eventId` int,
  `outcome` varchar(255)
);

CREATE TABLE `bets` (
  `id` integer PRIMARY KEY AUTO_INCREMENT,
  `userId` int,
  `subjectId` int,
  `eventId` int,
  `outcome` varchar(255),
  `amount` int
);

ALTER TABLE `games` ADD FOREIGN KEY (`organizerId`) REFERENCES `users` (`id`);

ALTER TABLE `gameSubjects` ADD FOREIGN KEY (`gameId`) REFERENCES `games` (`id`);

ALTER TABLE `gameEvents` ADD FOREIGN KEY (`gameId`) REFERENCES `games` (`id`);

ALTER TABLE `gameResults` ADD FOREIGN KEY (`subjectId`) REFERENCES `gameSubjects` (`id`);

ALTER TABLE `gameResults` ADD FOREIGN KEY (`eventId`) REFERENCES `gameEvents` (`id`);

ALTER TABLE `bets` ADD FOREIGN KEY (`userId`) REFERENCES `users` (`id`);

ALTER TABLE `bets` ADD FOREIGN KEY (`subjectId`) REFERENCES `gameSubjects` (`id`);

ALTER TABLE `bets` ADD FOREIGN KEY (`eventId`) REFERENCES `gameEvents` (`id`);
