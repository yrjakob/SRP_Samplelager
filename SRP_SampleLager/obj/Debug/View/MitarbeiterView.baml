   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5       SRP_SampleLager%   SRP_SampleLager.MitarbeiterView   5      ViPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� 
Background
  ����� N� Title$ MitarbeiterView��5
      .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��2��6      BorderStyle#���   6%   ._�5      �� $��Mitarbeiter��6     Headline#���  6+    �� LineStackingStrategy$ BlockLineHeight=�6N   5      �� 5   
   -   5        $��LVMitarbeiter��5        ListViewStyle#���  6(   $��2��6y   $��0��6�   $��3��6�   ��6P   �� *MitarbeiterListe+	 �� View	 5       �� 5!      .P�5"      �� $��Nachname��6%   
 �� DisplayMemberBinding
 67   �� *
Nachname+�� 5#      $��Vorname��6%   
 66   �� *	Vorname+�� 5$      $��Kurzform��6%   
 67   �� *
Kurzform+�� 5%      $��Personal-Nr��6%   
 6:   �� *	PeronalNr+�� 5&      $��Telefon Intern��6%   
 6=   �� *TelefonIntern+�� 5'      $��Telefon Privat��6%   
 6=   �� *TelefonPrivat+�� 5(      $��Email��6%   
 64   �� *Email+�� 5)      $��Stellvertretung��6%   
 6>   �� *Stellvertretung+5*       5,        5-      $ SelectionChanged��6!   . 5.         6,   �� *SelectedCommand+   CommandParameter 6P   ��  �� ElementName$ LVMitarbeiter�� �� Path$ SelectedIndex�5/      51      9� 52   
   $��Mitarbeiter bearbeiten��6   $��0,0,5,0q�63    9� ExpandDirection$
 Down=�6D   $��2��6[   $��2��6h   .��53      �  54      �� 55      $
��Auto �6'   �� 56       58      �� 59      $��20 �6$   �� 5:      $
��auto �6$   �� 5;      $
��auto �6$   �� 5<      $
��auto �6$   �� 5=      $
��auto �6$   �� 5>      $
��auto �6$   �� 5?      $
��auto �6$   �� 5@      $
��auto �6$   �� 5A      $
��auto �6$   �� 5B      $
��auto �6$   �� 5C      $��20 �6$   �� 5D      $
��auto �6$   �� 5E      .+�5G      �� $��1��6   $��0��6)   $��Titel:��69     TextBlockStyle#���  6b   �� 5H      $��2��6   $��0��6)   $��	Nachname:��69   #���  6b   �� 5I      $��3��6   $��0��6)   $��Vorname:��69   #���  6b   �� 5J      $��4��6   $��0��6)   $��	Kurzform:��69   #���  6b   �� 5K      $��5��6   $��0��6)   $��Personal-Nr:��69   #���  6b   �� 5L      $��6��6   $��0��6)   $��Telefon Intern:��69   #���  6b   �� 5M      $��7��6   $��0��6)   $��Telefon Privat:��69   #���  6b   �� 5N      $��8��6   $��0��6)   $��Email:��69   #���  6b   �� 5O      $��9��6   $��0��6)   $��Stellvertretung:��69   #���  6b   �� 5P      $��1��6   $��2��6(     InputElement#���  6b    �� SelectedValue 68   �� *
Geschlecht+��6�   �� *GeschlechtListe+�� 5Q      $��2��6   $��1��6'   #���  6b   ��67   �� *
Nachname+6b   �� 5R      $��3��6   $��1��6'   #���  6b   ��67   �� *	Vorname+6b   �� 5S      $��4��6   $��1��6'   #���  6b   ��67   �� *
Kurzvorm+6b   �� 5T      $��5��6   $��1��6'   #���  6b   ��67   �� *
PersonalNr+6b   �� 5U      $��6��6   $��1��6'   #���  6b   ��67   �� *TelefonIntern+6b   �� 5V      $��7��6   $��1��6'   #���  6b   ��67   �� *TelefonPrivat+6b   �� 5W      $��8��6   $��1��6'   #���  6b   ��67   �� *Email+6b   �� 5X      $��9��6   $��1��6(   #���  6b    68   �� *Stellvertretung+��6�   �� *StellvertreterListe+�� 5Z      $��11��6   $��0��6,   $��2��6<   $��Stretch=�6P     StackPanelStyle#���  6n   .+�5[      �� $��Löschen��6   $��0,5,5,5q�6/     ButtonStyle#��[ 6@   ��6e   �� *DeleteCommand+��6�   �� $ LVMitarbeiter��$ SelectedIndex��� 5\      $��	Speichern��6   #��[ 61   ��6V   �� *EditCommand+��6v   �� $ LVMitarbeiter��$ SelectedIndex��� 5]      $��Hinzufügen��6   $��5,5,0,5q�62   #��[ 6C   ��6h   �� *SaveCommand+5^      5_      5`      5a      5b      