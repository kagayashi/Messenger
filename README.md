Project Messenger
Nikita Naumov 49102


Funkcjonalność:
Rejestracja nowych użytkowników, Logowanie, Dodawanie użytkowników do grupy oraz do kontaktów, wysyłanie wiadomości do jednej osoby albo grupy użytkowników.

Guide:

1.Instalacja Rabbitmq oraz Plugin RabbitMQ Management.
2. Run “To Run” plik format .exe albo jako VS project.
3.
 
Rejestracja i Logowanie jest chronione w Bazie Danych o pliku  “Database1.mdf”, pliki użytkownika są chronione w projekcie w folderze UserData.
Uwaga! Imię użytkownika jest unikalne i musi zawierać tylko liczby i litery.
Znaki “ “,”_”,”$” są zabronione.

4.Interfejs:
 
1.Kontrola Add oraz Texbox_Search dla dodania użytkowników do kontaktów
2.Lista Użytkowników oraz Grup, UWAGA, gdy użytkownik doda kogoś do kontaktów ten człowiek od razu otrzyma wiadomość od użytkownika typu 
“Username Added you”.
3. Chat Screen dla pokazywania wiadomości.
4. Okienko Dla wprowadzania tekstu oraz kontrola Send dla wysyłania.
5. Kontrola CreateRoom dla tworzenia grupy użytkowników.
Uwaga: nie można tworzyć grup, gdy nie istnieje kontaktów w “Your Chats”,







Receiver And Sender

Otrzymanie i wysyłanie wiadomości do użytkownika lub grupy użytkowników jest realizowana przez Message Broker RabbitMQ.

Używana metoda Default Exchange:
 
producer						consumer

Wiadomosci tej metody zostają w kolejce do otrzymania, to pozwala wysyłać wiadomości nawet gdy jeden z użytkowników jest offline, on otrzyma ich po zalogowaniu.

Realizacja:
 
tworzymy klasy potrzebne do połączenia.
 
 
Tworzymy połączenie dla użytkownika

 
czekamy na wiadomość od konkretnego użytkownika gdy otwieramy czat z nim.  

Wszystkie Kolejki sa formatu (Sender Name +”_”+ Consumer Name)
Np. Gdy wysyłamy wiadomość od Kasia do Nikita, wtedy tworzymy taką queue: Kasia_Nikita 

Method Send:
 
gdzie direction = (Imię osoby wysyłającej) +”_”+(Imię osoby otrzymującej)


Logs:
Każdy chat zapisujemy do komputera użytkownika w .txt plik:
 

Więc po zalogowaniu będą dostępne wszystkie zeszle chaty.










