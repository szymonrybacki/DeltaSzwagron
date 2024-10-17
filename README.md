# DeltaSzwagron
![Pan Projektu](./plan.png)

## Wybór klas
Na samym początku każdy z graczy wybiera pomiędzy jedną z 4 klas - `Fighter`, `Archer`, `Wizzard` oraz `Healer`.

## Początek rozgrywki
Gracze zostają przesiesieni na mapę stworząną z sześciokątów z losowo ułożonymi strukturami otoczenia oraz losowo ustawionymi oponentami.

## Przebieg rozgrywki
Po pokananiu grupy przeciwników gracze wybierają jeden spośród trzech losowych ulepszeń umiejętności, a struktury na mapie są ponownie generowane oraz pojawia się kolejna silniejsza grupa wrogów. Co piątą falę gracze bądą walczyć z `bossem`.

## Cel gry
Celem gry jest pokonanie szóstego bossa - `Króla koni`.

##Dokumentacja

#Manager
-BattleManager.cs - Nic jeszcze nie robi

#MultiPlayer
-ConnectToServer.cs - Łączy gracza z serwerem przy użyciu Photon
-LobbyManager.cs - Odpowiada ze tworzenie nowych lobby oraz wyświeltanie ich
-Multi.cs - Przechowuje ID gracza względem lobby
-RoomItem.cs - Odpowiada za dołączania do lobby oraz wyświetlaniu nazw lobby
-StartGame.cs - Odpowiada za wyświetlanie nazw innych graczy, wybrów klas i przeniesieniu graczy z panelu lobby do panelu gry

#Player
-PlayerClass.cs - Przechowuje informacje o klasie gracza
-PlayerMove.cs - Odpowiada za podstawowe poruszanie się gracza
-SpawnPlayer.cs - Tworzy klasa w zależności od wybranej klasy na początku rozgrywki
