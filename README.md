# WZL.CSharp
| Opis   | Model   | SlaveId  |   |   |
|---|---|---|---|---|
| moduł wyjść binarnych   | SM4  | 2  |   |   |
| miernik temperatury  | N30U  | 3  |   |   |
| miernik natężenia prądu  | N30U  | 4  |   |   |
| miernik napięcia stałego | N30H  | 5  |   |   |
| wyjścia analogowe  | S4AO  | 6  |   |   |
| miernik parametrów sieci  | N10  | 7  |   |   |

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
