   M S B A M L   `   `   `  ����E  APOD_Bitmap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:POD_Bitmap
POD_Bitmap  5   	       POD_Bitmap.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:POD_Bitmap     5   	     � Title$  
MainWindow��5   	   $��475.2��6   $��653.8��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��164* �6   �� 5      $
��281* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �� -   5        $
��Left=�5      $	��436��60   $	��Top=�6=   $	��637��6U   $��2��6a   .@�5      �� $��Program��6   $��22��6'   $��-2,-2,-2.4,0q�63   $	��Top=�6I   .��5      � ���	#FFE5E5E5.+�5      �� -   5        $��Wczytaj plik bmp��5      $
��Left=�68   $	��Top=�6S   $	��138��6k   $��	10,10,0,0q�6w   $��34��6�   6�   �� 5      -   5        $��Wczytaj plik do ukrycia��5      $
��Left=�6?   $	��Top=�6Z   $	��139��6r   $��
172,10,0,0q�6~   $��34��6�   6�   �� 5      -   5        $��Znajdź ukryty plik��5      $
��Left=�6:   $��172,106,0,0q�6U   $	��Top=�6j   $	��139��6�   $��29��6�   6�   �� 5      -   5         ��Name$ FindFileTextBox��5      $
��Left=�67   $��23��6R    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��139��6�   $��172,162,0,0q�6�   �� 5      -   5         ��Name$ 
InputImage��5      $
��Left=�61   $	��207��6L   $	��Top=�6Y   $	��311��6q   $��
10,190,0,0q�6}   	� 5      -   5         	�Name$ FileRadioButton��5   "   $
��Plik��6;   $
��Left=�6J   $	��Top=�6e   $��
172,75,0,0q�6}   $��67��6�   	� 5      -   5        $ ConsoleRadioButton��5   "   $��Konsola��6>   $
��Left=�6P   $	��Top=�6k   $��
244,75,0,0q�6�   $��67��6�   �� 5      -	   5        $ InputConsole��5      $
��Left=�64   $	��175��6O   $
 Wrap=�6\   $	��Top=�6p   $	��287��6�   $��
335,10,0,0q�6�   �� 5      -
   5        $ OutputConsole��5      $
��Left=�65   $	��206��6P   $
 Wrap=�6]   $	��Top=�6q   $	��287��6�   $��335,190,0,0q�6�   �� 5      -   5         ��Name$ LoadBMPLabel��5      $��Nie wczytano pliku��62   $
��Left=�6O   $	��Top=�6j   $��29��6�   $	��138��6�   $��	10,44,0,0q�6�   �� 5      -   5        $ LoadHfileLabel��5      $��Nie wczytano pliku��64   $
��Left=�6Q   $��
172,44,0,0q�6l   $	��Top=�6�   $	��139��6�   $��26��6�   �� 5       -   5        $��Generuj��5       $
��Left=�6/   $	��Top=�6J   $	��138��6b   $��	10,73,0,0q�6n   $��29��6�   6�   �� 5!      -   5         ��Name$ CheckBox��5!      $
��Left=�61   $	��Top=�6L   $��
10,162,0,0q�6d   $	��138��6x   $��Dwa ostatnie bity��6�   �� 5"      $��Liczba bajtów��6   $
��Left=�64   $	��Top=�6O   $��172,135,0,0q�6g   $	��139��6|   $��27��6�   �� 5#      -   5        	 ��Name$	 ComboBox��5#      $��0,112,481.2,270.6q�61   $��Right=�6y   $	��140��6�   .@�5$      �� -   5        $��	Kolumnowo��5$   '   $
��Left=�6;   $	��139��6V   6b   �� 5%      -   5        $��	Wierszowo��5%   '   $
��Left=�6;   $��139.2��6V   6d   5&      5'      5(      �� 5)      $��
Instrukcja��6   .��5*      � ���	#FFE5E5E5.+�5+      �� -   5        $
��Left=�5+      $	��396��69   $
 Wrap=�6F   $	��Top=�6Z   $	��621��6r   $��10,10,0,-0.4q�6~   
 �� 
IsReadOnly
 . $����Autor: Kamil Sagalara
Nazwa algorytmu: Algorytm najmniej znaczącego bitu
Opis algorytmu:
Algorytm ten polega na zmianie najmniej znaczącego bitu każdegi piksela na bity odpowiadające wiadomości, którą chcemy przechować. Program działa dla obrazów kolorowych, więc każdy piksel składa się z 3 kanałów czyli 3 bajtów. Dzięki temu na jednym pikselu można przechować 3 bity wiadomości (zakładając, że używamy tylko ostatniego bitu). Program ma także możliwość zapisu na dwóch ostatnich bitach, można wtedy zmieścić większy plik. Większa liczba bitów wiąże się z ryzykiem wyraźnej modyfikacji obrazu - a w algorytmie chodzi o to żeby użytkownik nie mógł odróżnić tego obrazu od oryginału. Istnieje możliwość zapisywania kolejnych bitów wzdłuż kolumn lub wierszy obrazu. 

Ukrywanie wiadomości:
1. Program ukrywa dowolną wiadomość w plikach o rozszerzeniu .bmp (tylko w kolorze).
2. Aby rozpocząc należy wczytać obraz bmp oraz wybrać sposób wprowadzania wiadomości - plik lub konsola.
3. W przypadku wybrania pliku należy go wczytać naciskając "Wczytaj plik do ukrycia", w przeciwnym wypadku należy wprowadzić wiadomość do konsoli.
4. Po przygotowaniu należy wybrać sposób zapisu bitów- wzdłuż wierszy lub kolumn.
5. Opcjonalnie można wybrać tryb ukrywania na dwóch bitach w każdym kanale.
6. Po przygotowaniu wszystkiego można nacisnąć przycisk "Generuj".

Odczytywanie wiadomości:
1. Należy wybrać sposób odczytu - zapis do pliku lub wypisanie do konsoli.
2. W każdym przypadku należy wpisać liczbę bajtów, które chcemy odczytać.
3. W przypadku gdy mamy do czynienia z plikiem tekstowym, to wystarczy aby długość była większa lub równa wiadomości. W przypadku plików w innym formacie przed odczytem trzeba znać i wpisać dokładny rozmiar oczekiwanego pliku.
4. Po przygotowaniu należy nacisnąć przysik "Znajdź ukryty plik".��6�   6*  5,      5-      �� 5.      $	��100��6   $
��Wrap=�6%   $��	TextBlock��69   $	��100��6J   5/      �� 50   
   $��1��6   $
��Left=�6$   $��130.8,93,-137.8,0q�6?   $��2��6Z   $
��Wrap=�6k   $��	TextBlock��6   $	��Top=�6�   52      53      