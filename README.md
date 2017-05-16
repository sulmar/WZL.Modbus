# Szkolenie Komunikacja z Modbus i SPCI w C#

## Sprzęt
| Opis   | Model   | Adres  | Dokumentacja  |   |
|---|---|---|---|---|
| moduł wyjść binarnych   | SM4  | 2  |  [link](http://www.lumel.com.pl/download/Z2Z4L2x1bWVsL3BsL2RlZmF1bHRfbXVsdGlsaXN0YV9wbGlrb3cudjAvNDA2/sm4_07d_instrukcja_obslugi.pdf)  |   |
| miernik temperatury  | N30U  | 3  | [link](http://www.lumel.com.pl/download/Z2Z4L2x1bWVsL3BsL2RlZmF1bHRfbXVsdGlsaXN0YV9wbGlrb3cudjAvNjE1/n30u07a.pdf)|   |
| miernik natężenia prądu  | N30U  | 4  | [link](http://www.lumel.com.pl/download/Z2Z4L2x1bWVsL3BsL2RlZmF1bHRfbXVsdGlsaXN0YV9wbGlrb3cudjAvNjE1/n30u07a.pdf)  |   |
| miernik napięcia stałego | N30H  | 5  | [link](http://www.lumel.com.pl/download/Z2Z4L2x1bWVsL3BsL2RlZmF1bHRfbXVsdGlsaXN0YV9wbGlrb3cudjAvNjE3/n30h07a.pdf)  |   |
| wyjścia analogowe  | S4AO  | 6  | [link](http://www.lumel.com.pl/download/Z2Z4L2x1bWVsL3BsL2RlZmF1bHRfbXVsdGlsaXN0YV9wbGlrb3cudjAvNzQ4/s4ao07.pdf)  |   |
| miernik parametrów sieci  | N10  | 7  | [link](http://www.lumel.com.pl/download/Z2Z4L2x1bWVsL3BsL2RlZmF1bHRfbXVsdGlsaXN0YV9wbGlrb3cudjAvMzQ0/n10_io_interf_pl_05.01.2010.pdf)  |   |
| konwerter Ethernet RS 485 | PD8  | 10.1.1.122:502  | [link](http://www.lumel.com.pl/download/Z2Z4L2x1bWVsL3BsL2RlZmF1bHRfbXVsdGlsaXN0YV9wbGlrb3cudjAvMzk4/pd807f.pdf)  |   |
| zasilacz | PS9040  | 10.1.1.124:5025  | [link](http://www.elektroautomatik.de/en/interfaces-ifab.html)  |   |


## Przydatne narzędzia
- [eCon](http://www.lumel.com.pl/en/download/programmer_for_lumel_products/econ/) - aplikacja do konfigurowania urządzeń firmy Lumel 
- [PD8Config](http://www.lumel.com.pl/download/Z2Z4L2x1bWVsL2VuL2RlZmF1bHRfbXVsdGlsaXN0YV9wbGlrb3cudjAvMzQ2/pd8config_install_v2.1.exe.zip) - aplikacja do konfigurowania konwertera PD8
- [Modbus Simulator](http://www.plcsimulator.org/) - symulator modbusa w trybie slave 
- [PuTTY](https://www.chiark.greenend.org.uk/~sgtatham/putty/latest.html) - klient TCP, COM

## Biblioteki
~~~
PM> Install-Package NModbus4
~~~

## Konfiguracja

### PD8
1. Uruchom aplikację PD8Config. Aplikacja powinna odnaleźć konwertery w sieci.
![PD8Config](https://content.screencast.com/users/Sulmar/folders/Jing/media/6ed26d80-38a7-4db4-9f8c-932761de9fbd/2017-05-16_1555.png)

2. Ustaw adres IP
![PD8Config](https://content.screencast.com/users/Sulmar/folders/Jing/media/34e17557-788e-4c02-b9f2-5bcace7795ab/2017-05-16_1612.png)

3. Wybierz opcję Otwórz stronę WWW

4. Wybierz tryb **Industrial Automation** - umożliwia komunikację po TCP. Dopuszcza wielu klientów typu master.
![Konfiguracja](https://content.screencast.com/users/Sulmar/folders/Jing/media/d1ab6149-a0a7-419b-b91c-4356c076538f/2017-05-04_2017.png)

5. Ustaw parametry transmisji
![Konfiguracja](https://content.screencast.com/users/Sulmar/folders/Jing/media/abcfbf61-3ec6-4c0a-b18b-5f431bbe962e/pd8-config.png)





## W jaki sposób wyświetlić nowy pomiar?
1. Utwórz interfejs w projekcie WZL.Services
2. Utwórz implementację usługi np. w WZL.LumelServices
3. Przejdź do projektu WZL.PowerUnit.WPFClient
4. Utwórz właściwość, która będzie przechowywała pomiar
5. Utwórz zmienną tego interfejsu w ViewModel PowerSupplierViewModel
6. Utwórz instancję usługi w PowerSupplierViewModel 
7. Wywołaj metodę do pobrania pomiaru i przypisz ją do utworzonej właściwości
8. W widoku PowerSupplierView umieść np. TextBox i zbinduj do właściwości z pomiarem

## W jaki sposób zapisać pomiar do bazy danych?

1. Utwórz klasę w modelu WZL.PowerUnit.Models
2. Dodak właściwość Id
3. Dodaj do kontekstu obsługę klasy w WZL.PowerUnit.DAL
4. Utwórz interfejs w WZL.Services
5. Utwórz implementację interfejsu do zapisu do bazy danych w WZL.PowerUnit.DAL
6. Utwórz komendę np. SaveThreePhaseMeasureCommand 
do zapisu w klasie ViewModel np. PowerSupplierViewModel 
7. Dodaj wywołanie metody zapisu  
8. Podepnij komendę do przycisku w widoku PowerSupplierView


## Projekty
- WZL.PowerUnit.WPFClient - aplikacja WPF (Views i ViewModels)
- WZL.Services - interfejsy
- WZL.LumelServices - implementacja komunikacji z urządzeniami firmy Lumel
- WZL.EAServices - implementacja komunikacji z zasilaczem EA
- WZL.MockServices - implementacja udawanych urządzeń
