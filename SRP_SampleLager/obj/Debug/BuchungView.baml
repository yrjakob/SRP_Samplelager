   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5       SRP_SampleLager!   SRP_SampleLager.BuchungView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  BuchungView��5       N� 
Background
 �����.   (System.Windows.Interactivity.Interaction   Triggers 5	      /   )System.Windows.Interactivity.EventTrigger  5
   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedCommand+5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��0.7* �6   �� 5       � RowDefinitions 5   
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
   $��2��6   $��+��6     ButtonStyle#���  6*   ��6P   �� *NeuesMusterCommand+�� 5%   
   $��2��6   $��1��6     InputElement#���  6G   ��6/   �� *Anzahl+6G   �� 5&   
   $��2��6   $��2��6   #���  6G   ��6/   �� *Muster+6G   �� 5(   
   -   5        $��lvLagerplatz��5)      $��3��5(      $��3��6      ListViewStyle#���  64   ��5)   '   �� *
MusterList+ �� View 5*      �� 5+      .P�5,      �� 	 �� Width$	 30��6%   
 �� CellTemplate
 5-      �� 5.      .R�5/   "   �� $��+��6)   ��65   ��  �� ElementName$ lvLagerplatz�� �� Path$ DataContext.PlusCommand���50   )   �� *DataContext+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ ListViewItemL�51      53      �� 54      $	 30��6%   
 55      �� 56      .R�57   "   �� $��-��6)   ��65   �� $ lvLagerplatz��$ DataContext.MinusCommand���58   )   �� *DataContext+ �� *FindAncestor+$ ListViewItemL�59      5;      �� 5<      $��Anzahl��6%    �� DisplayMemberBinding 65   �� *Anzahl+�� 5=      $��Muster��6%    65   �� *Muster+5>      5@      �� 5B   
   $��4��6   $��3��6"     StackPanelStyle#���  66   .+�5C      �� $��Lagerplatz leeren��6   #��[ 61   $	��105��6V   ��5D      �� *LeerenCommand+5E      � 5G   
   $��4��6   $��5��6    5H      �� 5I      $
��Auto �6#   �� 5J       5L      �� 5M      $
��Auto �6    �� 5N      $
��Auto �6    �� 5O      $
��Auto �6    �� 5P      $
��Auto �6    �� 5Q      $
��Auto �6    �� 5R      $
��Auto �6    �� 5S      $
��Auto �6    �� 5T      $
��Auto �6    �� 5U      $
��Auto �6    �� 5V      $
��Auto �6    �� 5W      $
��Auto �6    .+�5Z      �� $��2��6   #���   6E   ��6,   �� *	Artikel+6E   �� 5\      $��1��6   $��Muster:��6%   #���  64   �� 5]      $��1��6   $��1��6%   #���  6K   $
��Left=�5^      ��5]   5   �� *Name+5^      �� 5`      $��2��6   $��Menge:��6%   #���  63   �� 5a      $��2��6   $��1��6%   #���  6L   $
��Left=�5b      ��5a   5   �� *Menge+5b      �� 5d      $��3��6   $��Eingang:��6%   #���  65   �� 5e      $��3��6   $��1��6%   #���  5f      $
��Left=�6A   ��5e   5   �� *	Eingang+ �� StringFormat$ 
dd.MM.yyyy��5f   A   �� 5h      $��4��6   $��Ausgang:��6%   #���  65   �� 5i      $��4��6   $��1��6%   #���  5j      $
��Left=�6A   ��5i   5   �� *	Ausgang+$ 
dd.MM.yyyy��5j   A   �� 5l      $��5��6   $��Zweck:��6%   #���  63   �� 5m      $��5��6   $��1��6%   #���  6L   $
��Left=�5n      ��5m   5   �� *Zweck+5n      �� 5p      $��6��6   $��Kunde:��6%   #���  63   �� 5q      $��6��6   $��1��6%   #���  6L   $
��Left=�5r      ��5q   5   �� *Kunde+5r      �� 5t      $��7��6   $��Kundeneigentum:��6%   #���  6<   �� 5u      $��7��6   $��1��6%   #���  6U   $
��Left=�5v      ��5u   5   �� *Kundeneigentum+5v      �� 5x      $��8��6   $��Rücksendung:��6%   #���  69   �� 5y      $��8��6   $��1��6%   #���  6S   $
��Left=�5z      ��5y   5   �� *Ruecksendung+5z      �� 5|      $��9��6   $��Referenznummer:��6%   #���  6<   �� 5}      $��9��6   $��1��6%   #���  6U   $
��Left=�5~      ��5}   5   �� *Referenznummer+5~      �� 5�      $��10��6   $��Ansprechpartner:��6&   #���  6>   �� 5�      $��10��6   $��1��6&   #���  6W   $
��Left=�5�      ��5�   6   �� *Ansprechpartner+5�      5�      5�      5�      