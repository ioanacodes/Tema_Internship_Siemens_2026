# Explicatii diagrame

## 1.1 Diagrama de Clase (UML)

Obiectivul principal a fost crearea unui model orientat pe obiecte care sa permita gestionarea produselor, a personalizarilor si a programului de loialitate.

## 🔹 Decizii de Proiectare si Arhitectura
* **Abstractizarea Produselor**: Am implementat `Beverage` ca o **clasa abstracta** care serveste drept model de baza pentru Espresso, Latte si Cappuccino. Aceasta abordare permite polimorfismul in calcularea preturilor prin metode specifice fiecarui tip de bautura.
* **Gestiunea Comenzilor (`OrderItem`)**: Am introdus clasa `OrderItem` pentru a desparti produsul de instanta sa intr-o comanda. Aceasta faciliteaza gestionarea atributului `quantity` si calcularea subtotalurilor individuale.
  * **Sistemul de Extras**: Relatia dintre `OrderItem` si `Extra` asigura aplicarea personalizarilor la nivel de produs individual.
* **Fidelizare si Trasabilitate**:
    * **Loyalty**: Clasa `Customer` gestioneaza acumularea de puncte in functie de `MembershipType`.
   

---

## 1.2 Diagrama Bazei de Date (ERD)

Modelul relational a fost proiectat pentru a asigura integritatea datelor si eliminarea redundantei.

### 🔹 Structura Tabelelor
* **Normalizare**: Am utilizat tabele separate pentru `BEVERAGE`, `EXTRA` si `CUSTOMER` pentru o organizare eficienta a datelor.
* **Tabela de Intersectie `ORDER_ITEM_EXTRA`**: Implementata pentru a gestiona relatia **Many-to-Many** intre produsele comandate si extra-urile acestora, permitand salvarea configuratiei exacte a fiecarei bauturi. * **Integritate Referentiala**: Toate legaturile intre comenzi, clienti si barmani sunt securizate prin cheo primare si chei straine.
