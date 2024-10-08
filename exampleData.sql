INSERT INTO `users` (`id`, `username`, `password`, `salt`, `role`, `balance`) VALUES
(1, 'szervezo1', '529C4736AB62274E95FEA291BAE12B56E8014A2352481040C7F37C3BE5B7D28D6083063160349869948D0AE6B0B2E3114D4D17DB3DEED4299B603471C35F13EE', '9F6B3121C3608B9A341D697ECACCDFE82C431D63CCD12124B0EF8F790F5C93F3D4D33F8ACB9EE203D4FFC6DAB8B14A435ED124B8D0B0AF3DD056158E72AE10B6', 'organizer', 100),
(2, 'fogado1', '0FA78243DC88D9B7B4F9A8CFC6DE33D08F73BBF69A00CA9B2AD87A39B98C198868639281FEA194E776A000AAB279405C092B5BC781976853D7D40B1579EF2114', 'F7DB281C81AE89782E2C5D5908945C8A21D05D6DD2ADFC5B2791376F712DA3E21ADA6998C1C22A312EBE9532427AF510910C203DF0A2EC1F5F1A34A02D215B9E', 'player', 39.5),
(3, 'fogado2', 'EC81E2D5CB78375318B101138E15D60A06E847BB181CAEE178262893339EE097947A1658EBB0FC624939A8986143CA1817908C76002749ACD09B0241F562E121', 'CFB859E9A6710A6F4BEB33FF31A0A59CDCCBF28DF54C4C60C792ACCE8619665489B33BD21D46444D150F8241AAEB51BE99E61BC6E8B6B1811E87CCFB751D92E7', 'player', 95),
(4, 'fogado3', '27312017A68EBB81208D69A713ACE8BBF94C1D2B72B21E61A2657B0E810AEE51B015D921226394BDC4749D74A6071C70118B58D5F4156B4B4D02412225400F46', 'CA885EB7A9B692EFF39911B47DA8C613D242590A5BF180A66F542C5EB25D168A3D1D84FF6F2BABFA8951B85F7DD1F9AB2ED20FAE93AD00D6725BB8FC273839CE', 'player', 100),
(5, 'fogado4', 'C0C2141447B338EC16190B09A304CD78A13149F5547DAD43CC1DAA6E92D1C770571FA9A75BA47DC4CE71443E17E6143F9ABE342BAE71D5242E93362F7CDD61B8', 'C2478F62FD07A262D8B4E0046A0A85A1022B3D7C8BDE9C817E967558FE5A8082F27BB320B93848B7ECEBB85263FEE5FED37C10E3DC1EE40D0570488B2A72E3E1', 'player', 100),
(6, 'szervezo2', '1C1BC489B7A7D3D9DB6DFC41AD20C7558BEA293279F17EFB6F83CEFD500B7A121795B47C441482A7D69B28E59CA1DDF418DF082110C6137A51674DEC04B972A6', 'B635FD9964A4EEEDF561546E70080B03C5E6ACAA2504B6221D69577A11B47F108442BECA545BAC3CCD9972DEFD4B036B3F59EE511EAEED265BCD59AC59DA4D9C', 'organizer', 100);

INSERT INTO `games` (`id`, `name`, `organizerId`) VALUES
(2, 'Lajos és Bettina programjának futása', 1),
(3, 'Számok tesztje', 1),
(4, 'Dobókocka játék', 1),
(5, 'Futball eredmények', 6),
(6, 'F1', 6),
(7, 'Fradi vs Újpest', 6);

INSERT INTO `gameevents` (`id`, `gameId`, `name`) VALUES
(3, 2, 'programfutásának sebessége'),
(4, 2, 'programjának kimenete'),
(5, 2, 'programja hibát dob'),
(6, 3, 'Piros lapok száma'),
(7, 3, '7-es lapok száma'),
(8, 4, 'Páros dobások száma'),
(9, 4, 'Páratlan dobások száma'),
(10, 4, '6-os dobások száma'),
(11, 4, '1-es dobások száma'),
(12, 4, 'Dobások összege nagyobb mint'),
(13, 4, 'Dobások összege kisebb mint'),
(14, 5, 'Rúgott gólok száma'),
(15, 5, 'Kapott gólok száma'),
(16, 5, 'Kapott sárga lapok száma'),
(17, 6, 'Helyezése'),
(18, 6, 'Pit stoppok száma'),
(19, 7, 'Gólok száma'),
(20, 7, 'Szögletek száma'),
(21, 7, 'Sárga lapok száma'),
(22, 7, 'Piros lapok száma'),
(23, 7, 'Cserék száma'),
(24, 7, 'Legjobb játékosa');

INSERT INTO `gamesubjects` (`id`, `gameId`, `name`) VALUES
(4, 2, 'Lajos'),
(5, 2, 'Bettina'),
(6, 3, 'Károly'),
(7, 3, 'Géza'),
(8, 3, 'István'),
(9, 4, 'Piros játékos'),
(10, 4, 'Kék játékos'),
(11, 5, 'Ferencváros'),
(12, 5, 'Debrecen'),
(13, 5, 'Honvéd'),
(14, 6, 'Lewis Hamilton'),
(15, 6, 'Max Verstappen'),
(16, 6, 'Valtteri Bottas'),
(17, 7, 'Fradi'),
(18, 7, 'Újpest');

INSERT INTO `bets` (`id`, `userId`, `subjectId`, `eventId`, `outcome`, `amount`) VALUES
(1, 2, 4, 3, '0.73', 10),
(2, 2, 4, 4, 'true', 5),
(3, 2, 5, 3, '1.2', 12),
(4, 2, 5, 4, 'false', 10),
(5, 2, 6, 6, '2', 5),
(6, 2, 6, 7, '1', 8),
(7, 2, 7, 7, '0', 10),
(8, 2, 7, 6, '3', 3),
(9, 2, 8, 6, '2', 10),
(10, 2, 8, 7, '1', 5),
(11, 3, 4, 3, '0.3', 10),
(12, 3, 4, 4, 'true', 8),
(13, 3, 5, 3, '1.2', 5),
(14, 3, 5, 4, 'false', 10),
(15, 3, 6, 6, '1', 5),
(16, 3, 6, 7, '2', 7),
(17, 3, 7, 6, '3', 10),
(18, 3, 7, 7, '0', 5),
(19, 3, 8, 7, '1', 5),
(20, 3, 8, 6, '3', 10);

INSERT INTO `gameresults` (`subjectId`, `eventId`, `outcome`) VALUES
(6, 6, '1'),
(7, 6, '2'),
(8, 6, '3'),
(6, 7, '3'),
(7, 7, '2'),
(8, 7, '1');