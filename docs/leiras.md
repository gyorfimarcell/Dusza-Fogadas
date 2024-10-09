# Dokumentáció

Ez a program fogadási játékok lebonyolítására készült. Regisztráció után a felhasználók létrehozhatnak játékokat, majd ezekre fogadhatnak. A program nyilvántartja a leadott fogadásokat, és a felhasználók pontegyenlegét.

## Szerekkörök

A programban egy felhasználó 2 szerepkör egyikébe tartozhat:

-   **Fogadó**: Regisztráció után egy felhasználó fogadóként kerül létrehozásra. Egy fogadó megtekintheti a játékok listáját, és
    fogadást adhat le.
-   **Szervező**: Egy adminisztrátor szervezővé tehet egy regisztrált felhasználót. Egy szervező új játékot hozhat létre, és rögzítheti a saját játékok
    eredményeit.

## Fogadás

A játékok működésének megértéséhez vegyünk először egy konkrét játékot: „Lajos és Bettina programjának futása”.
Ez a játék két _alanyt_ tartalmaz: Lajost és Bettinát. Melléjük különböző _eseményeket_ párosíthatunk (pl. programfutásának
sebessége, programjának kimenete). Ebben a játékban a lehetséges alany-esemény párosok:

-   Lajos programfutásának sebessége
-   Lajos programjának kimenete
-   Bettina programfutásának sebessége
-   Bettina programjának kimenete

A fogadók egy adott alany-esemény párosra fogadhatnak. Megadhatnak egy _értéket_, ami szerintük az esemény eredménye lesz,
és tetszőleges nagyságú tétet tehetnek fel. Egy fogadó egy játékon belül több fogadást is leadhat, de egy alany-esemény
párosra csak egyet.

Amikor egy szervező lezár egy játékot, meg kell adnia minden alany-esemény párosnak az értéket. Ez alapján a program megállapítja
a nyerteseket, és jóváírja a nyert pontokat.

## Pontok

Minden fogadó **100** ponttal kezd. Amikor lead egy fogadást, a feltett tét levonásra kerül. Miután egy játék lezárult,
a program minden alany-esemény pároshoz megállapít egy szorzót, ami alapján a nyertes fogadók megkapják a nyert pontjaikat.

## Telepítés

A program egy `dusza` nevű MySql adatbázist használ. Az adatbázis szerkezete a `database.sql` fájlból importálható.  
Az `exampleData.sql` fájl tartalmaz néhány tesztadatot is. Tartalmaz regisztrált felhasználókat:

-   fogado1
-   fogado2
-   fogado3
-   fogado4
-   szervezo1
-   szervezo2

Ezeknek a jelszava `Teszt123`
