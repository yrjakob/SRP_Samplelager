   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5       SRP_SampleLager!   SRP_SampleLager.BuchungView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  BuchungView��5       N� 
Background
 �����.   (System.Windows.Interactivity.Interaction   Triggers 5	      /   )System.Windows.Interactivity.EventTrigger  5
   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedCommand+5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��0.7* �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��3��6      Headline#���   6D   ��6(   �� *
Lagerplatz+6D   �� 5   
   $��1��6   $��1��6!   $��Anzahl:��61     TextBlockStyle#���  6@   $��5q�5       �� 5!   
   $��1��6   $��2��6!   $��Muster:��61   #���  6@   $
��Left=�5"      $��5q�6/   �� 5$   
   $��2��6   $��+��6     ButtonStyle#���  6*   ��6P   �� *NewMusterCommand+�� 5%   
   $��2��6   $��1��6     InputElement#���  6G   ��6/   �� *Anzahl+6G   �� 5&   
   $��2��6   $��2��6    #���  5'       �� SelectedItem 5&   0   �� 	 �� Path$	 SelectedMuster�
 �� Mode$
 TwoWay=���6j   �� *ArtikelList+ 5(        5)      $ SelectionChanged��6!   . 5*         6,   �� *SelectCommand+5+      5-      �� 5/   
   -   5        $��lvLagerplatz��50      $��3��5/      $��3��6      ListViewStyle#���  64   ��50   '   �� *
MusterList+ J� InputBindings 51      d� 52       d� MouseAction$ LeftDoubleClicke�6    �� Command 6=   �� *SelectCommand+ �� CommandParameter 53      ��  �� ElementName$ lvLagerplatz��$	 SelectedIndex� �� View 55      �� 56      .P�57      �� $��Anzahl��6%    �� DisplayMemberBinding 65   �� *Anzahl+�� 58      $��Muster��6%    65   �� *Muster+59      5;      �� 5=   
   $��4��6   $��3��6"     StackPanelStyle#���  66   .+�5>      �� $��Lagerplatz leeren��6   #��[ 61   $	��105��6V   ��5?      �� *ClearCommand+5@      � 5B   
   $��4��6   $��5��6   $��5q�60    5C      �� 5D      $
��Auto �6#   �� 5E       5G      �� 5H      $
��Auto �6    �� 5I      $
��Auto �6    �� 5J      $
��Auto �6    �� 5K      $
��Auto �6    �� 5L      $
��Auto �6    �� 5M      $
��Auto �6    �� 5N      $
��Auto �6    �� 5O      $
��Auto �6    �� 5P      $
��Auto �6    �� 5Q      $
��Auto �6    �� 5R      $
��Auto �6    .+�5U      �� $��2��6   #���   6E   ��6,   �� *	Artikel+6E   �� 5W      $��1��6   $��Muster:��6%   #���  64   �� 5X      $��1��6   $��1��6%   #���  6K   $
��Left=�5Y      ��5X   5   �� *Name+5Y      �� 5[      $��2��6   $��Menge:��6%   #���  63   �� 5\      $��2��6   $��1��6%   #���  6L   $
��Left=�5]      ��5\   5   �� *Menge+5]      �� 5_      $��3��6   $��Eingang:��6%   #���  65   �� 5`      $��3��6   $��1��6%   #���  5a      $
��Left=�6A   ��5`   5   �� *	Eingang+ �� StringFormat$ 
dd.MM.yyyy��5a   A   �� 5c      $��4��6   $��Ausgang:��6%   #���  65   �� 5d      $��4��6   $��1��6%   #���  5e      $
��Left=�6A   ��5d   5   �� *	Ausgang+$ 
dd.MM.yyyy��5e   A   �� 5g      $��5��6   $��Zweck:��6%   #���  63   �� 5h      $��5��6   $��1��6%   #���  6L   $
��Left=�5i      ��5h   5   �� *Zweck+5i      �� 5k      $��6��6   $��Kunde:��6%   #���  63   �� 5l      $��6��6   $��1��6%   #���  6L   $
��Left=�5m      ��5l   5   �� *Kunde+5m      �� 5o      $��7��6   $��Kundeneigentum:��6%   #���  6<   �� 5p      $��7��6   $��1��6%   #���  6U   $
��Left=�5q      ��5p   5   �� *Kundeneigentum+5q      �� 5s      $��8��6   $��Rücksendung:��6%   #���  69   �� 5t      $��8��6   $��1��6%   #���  6S   $
��Left=�5u      ��5t   5   �� *Ruecksendung+5u      �� 5w      $��9��6   $��Referenznummer:��6%   #���  6<   �� 5x      $��9��6   $��1��6%   #���  6U   $
��Left=�5y      ��5x   5   �� *Referenznummer+5y      �� 5{      $��10��6   $��Ansprechpartner:��6&   #���  6>   �� 5|      $��10��6   $��1��6&   #���  6W   $
��Left=�5}      ��5|   6   �� *Ansprechpartner+5}      5~      5      5�      