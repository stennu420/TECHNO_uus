# TECHNO_uus

Tee uus index, "artgallery" kus on listina õpilaste tööd - indexis pilte ei kuvata.
indexis on nupp "esita uus töö", mis lubab õpilasel uue töö lisada - mittesisselogitud kasutajal on nimi automaatselt ette antud "Anonüümne"
Mudelis on andmeteks pupilname, optional pupilid, image image, artwork title, artwork description, creationdate.
Vaade annab peidetud elemendina kaasa ka "submittedAt" kuupäeva kellaaja

Indexis kuvatakse loendis ainult autor, ja nimi ning creationdate.
töö NIMELE vajutades avaneb vaade koos töö infoga, kus on pilt kuvatud.

delete nupp asub details vaates

SPORTSGAMES:
tee uus index, kus on kooli ajaloo jalgpallimängude tulemused. (3v3)
indexis on nupp "salvesta mäng".
Üks mäng omab muutujatena id, kuupäev kellaaeg, poolaeg 1 skoor poolaeg 2 skoor ja mängu lõppskoor, pupilGoalie, õpilane kes on väravas, pupilDefense, kaitse ja PupilOffence - see kes ajab palli taga, vastase kooli osalejate jaoks on ainult üks string väli - kuna vastase koolin õpilasi selle kooli andmebaasis ei ole. Ja enum Status (Võit Viik Kaotus) ning bool topGame.
Entry saab muuta ja kustutada ning kui "topGame" on true, kuvada ka indexi lehel välja.
