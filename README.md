<<<<<<< HEAD
# matinfo-game
=======
#matinfo-game
>>>>>>> 87a1fddeb1cb8fd45f7fe0e8f5f031a04ddf0d1e
#Béna Racer v1.0 (készítette Benedek László)
GitHub: https://github.com/DowerX/matinfo-game
Készült a Unity Engine 5 (2018.2) felhsználásával (https://unity3d.com/)


Egy autós játék. Cél: minél rövidebb idő alatt tegyünk meg köröket a pályákon.
Két autó és 4 pálya válsztható a Garázsban.


###Irányítás:
	előre - W / Up
	hátra - S / Down
	jobbra - D / Right
	balra - A / Left
	autó visszaborítása felborulás esetén - Space
	vissza a főmenübe - Escape
	console megnyitása - Delete
	console parancs beküldése - Home
	nézelődés a garázsban - egér


###Console parancsok:
	"pp [STATE]": post processing efektek beállítása,[STATE]: true / false, pl: "pp ture"
	"help": parancsok listája
	"info": a játék verzíóját írja ki
	"settings": beállítások megnyitása
	"fps_counter": képkocka számláló megjelenítése/ elrejtése a job felső sarokban
	"map [ID]": pálya betöltése,[ID]: 0-6 , pl: "map 6" <= betölti a garázst
	"generate [PATH]": pályaelemek generálása PNG kép alapján, [PATH]: fájl elérési útja, pl: "generate D:\palya.png"
	"spawn [ID] [X] [Y] [Z]": autó létrehozása a pályán, [ID]: 0-1, [X] [Y] [Z]: kordináták , pl: "spawn 0 250 2 250"
	"destory_generated": legenerált pályaelemek törlése
	"destroy_tag [TAG]": bizonyos jelöléssel ellátott objektum törlése, [TAG]: Player, pl: "destroy_tag Player" <= az egyik autót törli a pályáról
	"echo [STRING]": bemeneti szöveg visszajátszása a console kimenetén, pl: "echo ASDQWE" => ASDQWE ,DE: "echo ASD QWE" => ASD
	"quit": kilép a játékból
	"input_type": váltási lehetőség billentyűzetes irányításról PlayStation 4 kontrollerre és vissza


###Kép betöltése pályaként:
	feltételek:	100*100 px
			(átlátszó háttér) (ajánlott a gyorsabb feldolgozás érdekében de elméletileg nem szükséges)
			egy RGB(255, 0, 0) színű pixel => autó
			fekete színű pixelek falaknak

	betöltés: a menüben írja be a fájl elérési útját majd kattintson a Generált Pálya gombra
		  amennyiben nem a menüben van használhatja a következő parancsokat: "map 1" "generate [PATH]"
