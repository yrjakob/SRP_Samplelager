   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5       SRP_SampleLager   SRP_SampleLager.KundeView   5      ViPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� 
Background
  ����� N� Title$ 	KundeView��5
      .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��2��6      BorderStyle#���   6%   ._�5      �� $��Kunde��6     Headline#���  6%   5      �� 5   
   -   5        $��LVKunde��5        ListViewStyle#���  6"   $��2��6m   $��0��6z   $��3��6�   ��6J   �� *
KundeListe+ �� View 5       �� 5!      .P�5"      �� $��Frima��6%   	 �� DisplayMemberBinding	 64   �� *Firma+�� 5#      $��Straße��6%   	 65   �� *	Straße+�� 5$      $	��Ort��6%   	 62   �� *Ort+�� 5%      $
��Land��6%   	 63   �� *Land+�� 5&      $��Ansprechpartner��6%   	 6>   �� *Ansprechpartner+�� 5'      $��Telefon��6%   	 66   �� *	Telefon+�� 5(      $��Telefax��6%   	 66   �� *	Telefax+�� 5)      $��Email��6%   	 64   �� *Email+�� 5*      $��	Kommentar��6%   	 68   �� *	Kommentar+5+       5-        5.      $ SelectionChanged��6!   . 5/         6,   �� *SelectedCommand+
   CommandParameter
 6P   ��  �� ElementName$ LVKunde�� �� Path$ SelectedIndex�50      52      9� 53   
   $��Kunde bearbeiten��6   $��0,0,5,0q�6-    9� ExpandDirection$
 Down=�6>   $��2��6U   $��1��6b   .��54      �  55      �� 56      $	��110 �6'   �� 57      $��60 �6'   �� 58      $	��160 �6'    5:      �� 5;      $��10 �6$   �� 5<      $
��auto �6$   �� 5=      $
��auto �6$   �� 5>      $
��auto �6$   �� 5?      $
��auto �6$   �� 5@      $
��auto �6$   �� 5A      $
��auto �6$   �� 5B      $
��auto �6$   �� 5C      $
��auto �6$   �� 5D      $
��auto �6$   �� 5E      $
��auto �6$   �� 5F      $
��auto �6$   �� 5G      $
��auto �6$   �� 5H      $��4 �6$   �� 5I      $
��auto �6$   �� 5J      .+�5L      �� $��1��6   $��Center=�6&   $
��Left=�6A   $��75��6\   $��75��6h   $��1��6s   $��2��6�   
�������$��1q�6�   ._�5M      �� $
��LOGO��6    $��Center=�6,   $��Center=�6I   5N      �� 5O      $��2��6   $��0��6)   $��Firma:��69     TextBlockStyle#���  6G   �� 5P      $��3��6   $��0��6)   $��Straße:��69   #���  6H   �� 5Q      $��4��6   $��0��6)   $��Postleitzahl:��69   #���  6N   �� 5R      $��5��6   $��0��6)   $	��Ort��69   #���  6D   �� 5S      $��6��6   $��0��6)   $
��Land��69   #���  6E   �� 5T      $��7��6   $��0��6)   $��Ansprechpartner:��69   #���  6Q   �� 5U      $��8��6   $��0��6)   $��Telefon:��69   #���  6I   �� 5V      $��9��6   $��0��6)   $��Telefax:��69   #���  6I   �� 5W      $��10��6   $��0��6*   $��Email:��6:   #���  6H   �� 5X      $��11��6   $��0��6*   $��
Kommentar:��6:   #���  6L   �� 5Z      $��2��6   $��1��6'   $��2��67     InputElement#���  6b   ��6K   �� *Firma+6b   �� 5[      $��3��6   $��1��6'   $��2��67   #���  6c   ��6K   �� *	Straße+6c   �� 5\      $��4��6   $��1��6'   $��2��67   #���  6i   ��6K   �� *Postleitzahl+6i   �� 5]      $��5��6   $��1��6'   $��2��67   #���  6`   ��6K   �� *Ort+6`   �� 5^      $��6��6   $��1��6'   $��2��67   #���  6a   ��6K   �� *Land+6a   �� 5_      $��7��6   $��1��6(   #���  6w    �� DisplayMemberPath$ Titel��6�    �� SelectedValue 68   �� *Titel+ �� SelectedItem 6X   �� *Titel+��6�   �� *AnredeListe+6�   �� 5`      $��7��6   $��2��6'   #���  6X   ��67   �� *Ansprechpartner+6X   �� 5a      $��8��6   $��1��6'   $��2��67   #���  6d   ��6K   �� *	Telefon+6d   �� 5b      $��9��6   $��1��6'   $��2��67   #���  6d   ��6K   �� *	Telefax+6d   �� 5c      $��10��6   $��1��6(   $��2��68   #���  6c   ��6L   �� *Email+6c   �� 5d      $��11��6   $��1��6(   $��2��69    �� AcceptsReturn . $��2��6b   #���  6�   ��6s   �� *	Kommentar+6�   �� 5e      $��14��6   $��5��6'   
�������$��0,1,0,0q�6S   ._�5f      �� $��5��6%   $��0��69   $��14��6J   $��0,10,0,0q�6X     StackPanelStyle#���  6j   .+�5g      �� $��Löschen��6%   $��0,5,5,5q�67     ButtonStyle#��[ 6H   ��6m   �� *DeleteCommand+��6�   �� $ LVKunde��$ SelectedIndex��� 5h      $��	Speichern��6%   #��[ 69   ��6^   �� *EditCommand+��6~   �� $ LVKunde��$ SelectedIndex��� 5i      $��Hinzufügen��6%   $��5,5,0,5q�6:   #��[ 6K   ��6p   �� *SaveCommand+5j      5k      5l      5m      5n      5o      