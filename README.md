# ITD-Project
Zavrsni projekat iz ITD - Kristijan Malbasic (https://zavrsniprojekat.000webhostapp.com/)

# O DevOffice programu
Program je uradjen u C#, GUI je kompletno custom kao i ikonice. Pokretanjem programa se otvara prozor u kom se vide svi
aktivni developeri (u ovoj verziji radi samo jedan developer, privatne obaveze ali isto tako dovoljno da prikaze funkcionalnost),
meni na lijevoj strani pokazuje dodatne mogucnosti programa. Pregled screenshotova, dodjela projekata (nije dovrseno) ali i status WorkCheck-a.
Client radi tako sto se ulogujete sa default informacijama (root:pass) i onda unesete lokalni IP vaseg racunara na koji ce se client povezati.
Slanje screenshotova se vrsi putem Pythona, primanje je isto bazirano u Pythonu. Pokretanje skripti se vrsi preko C++ programcica koji
pomocu system("") izvrsava skriptu. Postoje i ostale biblioteke koje bi mi to znatno olaksale i koje su znacajno bolje od mog nacina.


# O DevOffice website
DevOffice website je relativno jednostavan sa animiranom pozadinom i modernim UI. Od raznih animacijica odradjenih u CSS pa cak do embedovanog
Spotify playera koji se jednim klikom prikazuje u gornjem desnom uglu. Posto nisam htio trositi mnogo vremena na ispis HTML koda, odlucio sam se za 
Bootstrap 5 i relativno lako odradio 4 stranice. Baza podataka je podignuta pomocu 000webhost DB managera u koju sam slao podatke iz forme na Download page.
PHP skripta send-appl je relativno kompaktna i ne pruza nikakvu vecu mogucnost osim dodavanja podataka u bazu. Nisam uveo nikakve mjere protiv SQL injekcije
nazalost ali mislim da i nema potrebe s obzirom na prirodu ovog projekta.


# Stvari koje bi se mogle ispraviti
  - DevOffice Client/Server su vjerovatno puni bugova koje nisam imao vremena pronaci 
  - Losa implementacija izvrsavanja python skripti, moguce je da skripta nece raditi ukoliko PATH varijable nisu dobro namjestene.
  - Dizajn elemenata je relativno svuda isti
  
