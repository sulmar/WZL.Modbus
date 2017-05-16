# Szkolenie Komunikacja z Modbus i SPCI w C#

## Sprzęt
| Opis   | Model   | SlaveId  |   |   |
|---|---|---|---|---|
| moduł wyjść binarnych   | SM4  | 2  |   |   |
| miernik temperatury  | N30U  | 3  |   |   |
| miernik natężenia prądu  | N30U  | 4  |   |   |
| miernik napięcia stałego | N30H  | 5  | [dokumentacja] (http://www.lumel.com.pl/download/Z2Z4L2x1bWVsL3BsL2RlZmF1bHRfbXVsdGlsaXN0YV9wbGlrb3cudjAvNjE3/n30h07a.pdf)   |   |
| wyjścia analogowe  | S4AO  | 6  | [dokumentacja](http://www.lumel.com.pl/download/Z2Z4L2x1bWVsL3BsL2RlZmF1bHRfbXVsdGlsaXN0YV9wbGlrb3cudjAvNDA2/sm4_07d_instrukcja_obslugi.pdf)  |   |
| miernik parametrów sieci  | N10  | 7  | [dokumentacja](http://www.lumel.com.pl/download/Z2Z4L2x1bWVsL3BsL2RlZmF1bHRfbXVsdGlsaXN0YV9wbGlrb3cudjAvMzQ0/n10_io_interf_pl_05.01.2010.pdf)  |   |

## Dokumentacja
Automatik Programming Guide ModBus & SCPI
http://www.elektroautomatik.de/en/interfaces-ifab.html


## W jaki sposób wyświetlić nowy pomiar?
1. Utwórz interfejs w projekcie WZL.Services
2. Utwórz implementację usługi np. w WZL.LumelServices
3. Przejdź do projektu WZL.PowerUnit.WPFClient
4. Utwórz właściwość, która będzie przechowywała pomiar
5. Utwórz zmienną tego interfejsu w ViewModel PowerSupplierViewModel
6. Utwórz instancję usługi w PowerSupplierViewModel 
7. Wywołaj metodę do pobrania pomiaru i przypisz ją do utworzonej właściwości
8. W widoku PowerSupplierView umieść np. TextBox i zbinduj do właściwości z pomiarem

## Projekty
- WZL.PowerUnit.WPFClient - aplikacja WPF (Views i ViewModels)
- WZL.Services - interfejsy
- WZL.LumelServices - implementacja komunikacji z urządzeniami firmy Lumel
- WZL.EAServices - implementacja komunikacji z zasilaczem EA
- WZL.MockServices - implementacja udawanych urządzeń
