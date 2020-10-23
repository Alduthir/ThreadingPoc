# Onderzoek Multithreading
###Wat is Multithreading?
Multithreading is het uitvoeren van meerdere gelijktijdige taken in de context van een proces.
De threads delen de resources van het proces maar kunnen onafhankelijk van elkaar worden uitgevoerd.

###Wanneer gebruik je meerdere threads?
Multithreading gebruik je bijvoorbeeld als in de achtergrond iets uitgerekend moet worden terwijl de applicatie
voor de gebruiker verder dient te blijven draaien. Of als je meerdere taken parallel moet kunnen uitvoeren.

### Wat zijn drie veel voorkomende problemen bij multithreaded applicaties en waardoor ontstaan ze?
1. Complexere code. Multithreading vereist niet alleen de code voor elke thread ansich, maar ook code welke de
communicatie tussen threads beheerst. Dit maakt zowel het uitbreiden van de applicatie, als het testen ervan erg ingewikkeld.
2. Deadlocks. Dit zijn problemen waar 1 thread aan het wachten is op het resultaat van een andere thread en visa-versa.
Als dit voorkomt kan geen van beide threads verder en loopt de gehele applicatie vast.
3. Onverwachtte resultaten. Omdat meerdere onderelen van het programma tegelijk runnen. En vaak afhankelijk van elkaar
zijn, kunnen kleine verschillen ontstaan elke keer dat de code wordt uitgevoerd. Bijvoorbeeld: krijgt thread 1 of thread 2 eerder toegang
tot gedeelde data? Dergelijke verschillen kunnnen ophopen en uiteindelijk zorgen voor ongewenste resultaten.

### Hoe wordt het onderdeel genoemd waar objecten in het geheugen worden geplaatst?
Objecten worden opgeslagen in heap memory

#### Hoe is dit verschillend in een multithreaded applicatie?
Het heap geheugen is gedeeld voor de gehele applicatie. 

### Hoe wordt het onderdeel genoemd waar methoden worden uitgevoerd en primitieve types in het geheugen worden geplaatst?
De Stack

#### Hoe is dit verschillend in een multithreaded applicatie?
Elke thread heeft haar eigen stack. Zodra de thread klaar is met uitvoeren zal het resultaat veelal worden teruggecommuniceerd en opgeslagen in ofwel de main thread of een object in de heap.

### Wat is in deze context een racing condition?
Een racing condition ontstaat wanneer meerdere threads tegelijk een gezamenlijke resource proberen te gebruiken. Zoals de Queue in deze applicatie. Ze checken ongeveer tegelijk of de queue leeg is.
En een consumer zal als eerste het getal wat er instaat dequeuen. Echter daarna is de queue leeg, maar de andere threads zijn al wel door de if !empty check heengekomen. Dat gaat fout, want de queue is nu wel leeg.
Om dit op te lossen heb ik een lock toegepast om de numberQueue dan kan maar 1 thread tegelijk hem benaderen.