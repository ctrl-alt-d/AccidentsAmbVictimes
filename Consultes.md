# Exemples de consultes SQL sobre la taula `accidents`

## 1. Select senzilla i DISTINCT

* Mostra totes les dades de la taula `accidents`.
* Mostra només les columnes `Any`, `zona` i `nommun` de la taula `accidents`.
* Mostra tots els diferents municipis (`nommun`).

## 2. WHERE

* Mostra tots els accidents que han tingut lloc a la ciutat de Barcelona.
* Mostra els accidents on hi ha hagut almenys 1 mort (`f_morts > 0`).
* Mostra els accidents que han tingut lloc l'any 2010 i a la comarca del Vallès Oriental.

## 3. ORDER BY

* Mostra tots els accidents ordenats per nombre de víctimes (`f_victimes`) de major a menor.
* Mostra els accidents de la comarca del Baix Llobregat ordenats per data (`dat`).

## 4. Funcions d'agregació

* Calcula el nombre total d'accidents registrats.
* Calcula el nombre total d'accidents sense morts (on el camp `F_MORTS` és null o val 0).
* Calcula el nombre de municipis diferents on hi ha hagut accidents.
* Calcula la mitjana de víctimes (`f_victimes`) per accident.

## 5. GROUP BY

* Mostra el nombre d'accidents per any (`Any`).
* Mostra el nombre d'accidents per municipi (`nomMun`).

## 6. Funcions d'agregació sobre grups

* Mostra, per cada any, el nombre total de morts (`F_MORTS`).
* Mostra, per cada comarca (`nomCom`), la mitjana de víctimes per accident.

## 7. HAVING

* Mostra els municipis que han tingut més de 5 accidents.
* Mostra les comarques on la mitjana de morts per accident és superior a 0.2.

---

## 8. Anàlisi temporal avançada 📅

* Mostra el nombre d'accidents per hora del dia (`hor`), ordenats per hora.
* Quins són els dies de la setmana (`tipdia`) amb més accidents mortals?
* Troba els mesos (extreu el mes de `dat`) amb més accidents greus (amb ferits greus).
* Compara el nombre d'accidents en dies feiners (`grupdialab = 'Feiners'`) vs caps de setmana.
* Quina hora del dia (`gruphor`) és la més perillosa per cada tipus d'accident (`tipacc`)?

## 9. Anàlisi de vehicles implicats 🚗🏍️🚲

* Calcula el percentatge d'accidents on hi ha motocicletes implicades sobre el total d'accidents.
* Mostra els accidents on hi ha més de 3 unitats implicades (`f_unitats_implicades > 3`).
* Troba els municipis on hi ha més accidents amb bicicletes implicades.
* Quina és la mitjana de vehicles lleugers implicats per accident a cada demarcació (`nomdem`)?
* Identifica els accidents amb vianants implicats que han acabat en morts.
* Troba els tipus d'accidents (`tipacc`) més freqüents per cada tipus de vehicle (motocicletes, bicicletes, vehicles pesants).

## 10. Anàlisi de condicions ambientals 🌧️🌫️

* Mostra el nombre d'accidents segons les condicions climatològiques (`d_climatologia`).
* Quants accidents han estat influïts per la boira (`d_influit_boira = 'Sí'`)?
* Compara la gravetat dels accidents (`d_gravetat`) en condicions de bon temps vs mal temps.
* Troba les comarques on la lluminositat (`d_lluminositat`) ha influït més en accidents mortals.
* Quina és la relació entre accidents a la nit sense il·luminació i la seva gravetat?

## 11. Anàlisi geogràfica i d'infraestructura 🗺️

* Quines són les 10 vies (`via`) amb més accidents mortals?
* Mostra el nombre d'accidents per tipus de via (`d_tipus_via`) i zona (`zona`).
* Troba les interseccions més perilloses basant-te en `d_subtipus_tram` (giratoris, T o Y, etc.).
* Quines comarques tenen més accidents en carreteres convencionals?
* Analitza la relació entre el límit de velocitat (`c_velocitat_via`) i el nombre de víctimes.
* Troba els trams amb accidents on la superfície estava mullada o amb gel (`d_superficie`).

## 12. Consultes amb subconsultes 🎯

* Troba els accidents del municipi amb més accidents totals.
* Mostra els anys amb un nombre d'accidents superior a la mitjana de tots els anys.
* Troba les comarques on el nombre de morts és superior a la mitjana de morts per comarca.
* Selecciona els accidents del dia amb més accidents de tot el període.

## 13. Anàlisi de tendències i patrons 📊

* Mostra l'evolució anual del nombre de morts (suma de `f_morts` per any).
* Calcula la taxa de mortalitat per accident (morts/accidents) per cada any.
* Troba els municipis on ha augmentat el nombre d'accidents comparant la primera i la segona meitat del període de dades.
* Identifica les comarques amb la millor i pitjor evolució de la seguretat vial (reducció d'accidents mortals).

## 14. Queries complexes amb múltiples JOINs i agregacions 🔥

* Per cada comarca, mostra el nombre d'accidents, total de víctimes, total de morts, i el tipus d'accident més freqüent.
* Crea un rànquing de municipis per perillositat: considerant nombre d'accidents, mitjana de víctimes i percentatge d'accidents mortals.
* Mostra, per cada demarcació i any, el percentatge d'accidents amb fuga (`d_acc_amb_fuga = 'Sí'`).

## 15. Anàlisi de casos especials 🚨

* Troba tots els accidents amb fuga que han acabat amb morts.
* Quants accidents han tingut lloc en zones amb mesures especials de circulació (`d_circulacio_mesures_esp != 'No n\'hi ha'`)?
* Identifica els accidents on múltiples factors han influït (boira + mal temps + mala il·luminació).
* Troba els accidents en variants (`d_func_esp_via = 'Variant'`) i compara'ls amb els de vies normals.

## 16. Consultes amb funcions de finestra (WINDOW FUNCTIONS) 🪟

* Mostra per cada accident el seu rànquing dins del seu municipi segons el nombre de víctimes.
* Calcula la mitjana mòbil de 3 anys del nombre d'accidents per municipi.
* Per cada comarca, mostra l'accident més greu (més víctimes) de cada any.

## 17. Anàlisi de seguretat vial per segments 🛣️

* Compara la sinistralitat entre vies de sentit únic vs doble sentit (`d_sentits_via`).
* Analitza la diferència de gravetat entre accidents a interseccions regulades per semàfor vs no regulades.
* Troba les combinacions de traçat altimètric (`d_tracat_altimetric`) i condicions meteorològiques més perilloses.

## 18. Queries amb CASE i lògica condicional 🔀

* Classifica els accidents en categories de risc: "Baix" (0 morts), "Mitjà" (1 mort), "Alt" (>1 mort).
* Crea una columna calculada que indiqui si l'accident és "urbà" o "interurbà" segons la zona.
* Genera un indicador de "hora punta" (7-9h i 17-20h) vs "fora punta" i analitza la seva relació amb la gravetat.

## 19. Anàlisi de concentració i densitat 📍

* Troba els "punts negres": vies i PKs amb més de X accidents en el mateix punt (pk amb marge de ±0.1).
* Identifica els municipis petits (menys de 10 accidents) amb alta taxa de mortalitat.
* Calcula la densitat d'accidents per comarca (accidents per any).

## 20. Queries amb dates i temps avançades ⏰

* Troba els intervals de temps més llargs sense accidents mortals per comarca.
* Mostra els accidents que van passar en diumenges de bon temps a la tarda.
* Calcula quants dies de mitjana passen entre accidents mortals a cada demarcació.
