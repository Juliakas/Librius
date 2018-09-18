# Kaip pradėti
Pirmiausia jums reikės integruoti visą GitHub repozitorija prie savo paskyrų, kad galėtume visi dribti prie vieno projekto. Čia surašysiu instrukcijas kaip tai galima padaryti ir kaip reikės naudotis papraščiausiomis Git funkcijomis.

- ~~Viršuje dešinėje matysite mygtuką 'Fork', kurį paspaudę nukopijuosite viską iš čia į savo GitHub paskyros repozitoriją.~~
- ~~Visi pas jus esantys failai "priklauso" jums ir jūs galėsite laisvai juos modifikuoti. Žinoma GitHub svetainėje tai daryti nėra labai patogu, todėl jums reikės viską persikelti į savo darbovietę kompiuteryje.~~
- Yra keli skirtingi būdai viską sinchronizuoti su Visual Studio esančiu jūsų kompiuteryje - instaliuoti GitHub pluginą ko gero bus paprasčiausias variantas, bet aš asmeniškai žadu naudoti Git Bash - patarčiau ir jums, jeigu norite labiau išmokti visą procesą.
- Pasidomėkite kaip veikia branch'ai - yra nemažai medžiagos internete.
- Kai atliekate veiksmus su failais ir norite išsaugoti pakeitimus, jums reikės savo branchą įpushinti į mūsų repozitoriją ir tada, kai galutinis brancho variantas padarytas - svetainėje daryti pull request. 
- Kai tik prisijungsiu, aš matysiu, kokius pakeitimus padarėte ir galėsiu sutikti sujungti (merge) mano repozitoriją su jūsų arba jei kažkas negerai, atitinkamai pakomentuosiu. Kol kas visus pull request'us darykite man, vėliau galėsim pasikeisti.

### Galiu čia surašyti žingsnius, jeigu ketinate naudoti Git Bash / CMD.

- Parisiųskite [Git](https://git-scm.com/downloads/) jūsų platformai. Susikonfiguruokite kaip jums patogu.
- Kairėje matysite žalią mygtuką 'Clone or download'. Paspauskite ir nukopijuokite nuorodą.
- Savo kompiuteryje susiraskite aplanką, kuriame bus saugomas Visual Studio projektas. Right Click -> Git Bash (arba CMD).
- Pirmiausia jums rekomenduoju susikonfigūruoti savo Git.

```diff
$ git config --Global user.name "Vardenis Pavardenis"
$ git config --Global user.email "user@mail.com"
$ git config -list                                  //Visas konfigūracijų sąrašas (išeiti su q)
```
*Ši informacija pravers, kai bus naudojama '$ git log' komanda, skirta parodyti visą commit istoriją*

- Dabar jau galima įkelti visus failus į jūsų pasirinktą aplanką
```diff
$ git clone <link>          //vietoje link įmeskit https://github.com/Juliakas/Librius
```
- Dabar čia bus laikomi visi projekto failai, su kuriais dirbsite būtent jūs. Pakoregavę kodą galėsit viską išsaugoti į savo asmeninę GitHub repozitoriją. Išvardysiu žingsnius paeiliui:

```diff
$ git add <file name>        //Kai pridedade naujus failus arba aplankus, reikia pridėti, kad GIT galėtų juos sekti.
$ git add .                  //Prideda visus failus esančius aplanke (Išskyrus .gitignore faile nurodytus).
$ git status                 //Parodo, kas yra naujo, bet dar ne addinta, taip pat parodo, kurie failai gali būti commitinami
$ git commit                 //Paruošia pakeitimus ir juos įrašo į istoriją. Į atsidariusį failą įrašykite trumpą sakinį, ką commitinat.
$ git pull <link> <branch>   //Visada prieš pushinant vertėtų iš pagrindinės (to kuris pull requestus approvina) repozitorijos įsikelti up to date failus ir sujungti su tai, kuo dirbat. Jeigu bus merge conflict, tai susėsim kartu visi ir išspręsim.
$ git push <link> <branch>   //Visus pakeitimus "įstumia" į jūsų GitHub repozitoriją.
```
Yra dar nemažai įvairių komandų ir būdų esamas komandas panaudoti, bet čia jau galite patys pasidomėti ;)
