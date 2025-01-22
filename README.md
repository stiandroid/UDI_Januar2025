# UDI kodetest 2025
Av Stian Sæther



Datafilene [testdata.json](https://github.com/stiandroid/UDI_Januar2025/blob/master/mer_testdata.json), [mer_testdata.json](https://github.com/stiandroid/UDI_Januar2025/blob/master/mer_testdata.json) og [feilformatert_testdata.json](https://github.com/stiandroid/UDI_Januar2025/blob/master/feilformatert_testdata.json) er inkludert i repo-mappen. Disse kan brukes til å teste filopplastings- og dataimporteringsfunksjonaliteten. Følg instruksjonene i applikasjonen for å importere datafiler.

Ved import av data sjekker applikasjonen om dataene finnes fra før, slik at vi unngår duplikater i Saker, Personer og Vedtak.

Applikasjonen har også funksjonalitet for å tømme databasen, dersom man vil importere data på nytt.

## Applikasjonen har seks hovedsider
### Nøkkeltall
Et sammendrag av lagrede saker, personer og vedtak. Her vises blant annet hvor mange saker som har vedtaksstatus Innvilget, Avslått eller Avvist.

### Liste over alle saker
Listen er klikkbar, og man kan navigere seg til detaljsiden for hver enkelt sak. I listen vises nøkkelinformasjon om alle sakene.

### Liste over alle personer
Listen er klikkbar, og man kan navigere seg til detaljsiden for hver enkelt person. I listen vises nøkkelinformasjon om alle personene.

### Detaljside for Sak
Her vises alle lagrede detaljer om en enkelt sak. Det er også mulig å navigere videre til personene tilknyttet saken.

### Detaljside for Person
Her vises alle lagrede detaljer om en enkelt person, inkludert en liste over alle sakene til personen.

### Import av data
Her kan brukeren importere og slette data.





