   M S B A M L   `   `   `  ����?  ;lab6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:lab6.Core.Viewlab6.Core.View  5   	   "    lab6.Core.View.AddCinemaPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:lab6.Core.View     5   	     N� Title$  Cinema System��5   	   $	��600��6   $��1000         ��6,    N� 
Background �#c0ebe2 N� 
FontFamily$ Bebas Neue Pro)�5
   	   .��5      � .+�5   
   �� 
���   �
�������$��1q�6=   $��420,200,344,220q�6R    J� RenderTransformOrigin$ 0.5,0.5&�6k   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ 0.058Q�6$   �� 5      T� 5       T� X$ 0.132Q�6)   5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6#      ShadowDepth$ 0Q�63   6E   5      �� 5   
   -   5        	 ��Name$	 AddCinemaButton��5      ���#4c4a4b
�������$��Добавить
��6W   $
��Left=�6o   $��18(�6�   $	��Top=�6�   $��83��6�   $ 0.128,2.906&�6�   $��28��6�   $��542,339,0,0q�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       
 �� Angle$
 -0.181Q�6&   T� 5!      5"      5$      �� 5%   
   $��Center=�6   $��25(�64   $A��;Введите информацию о кинотеатре��6B   $
��Left=�6l   $��282,144,0,0q�6�   $	��Top=�6�   $	��519��6�   $��41��6�   �� 5&   
   -   5         ��Name$ CinemaNameTextBox��5&      
 � Tag$
 Mail��6-   $
��Left=�68   $��18(�6S   $��23��6a   $��451,244,0,0q�6m    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��174��6�   �� 5'   
   -   5        $ StreetCinemaTextBox��5'      $ PhoneNumber��6/   $��18(�6A   $
��Left=�6O   $��26��6j   $��451,286,0,0q�6v   $	��Top=�6�   $	��174��6�   �� 5(   
   $+��%Название кинотеатра��6   $
��Left=�6.   $��0,5,0,0q�6I   $��451,226,0,0q�6[   $	��Top=�6p   $��23��6�   $	��174��6�   �� 5)   
   $%��Адрес кинотеатра��6   $
��Left=�6+   $��0,6,0,0q�6F   $��451,265,0,0q�6X   $	��Top=�6m   $��23��6�   $	��174��6�   �� 5*   
   -   5        $	 GoBackButton��5*      ���#4c4a4b
�������$��Назад
��6T   $
��Left=�6i   $��18(�6�   $	��Top=�6�   $��83��6�   $ 0.128,2.906&�6�   $��28��6�   $��453,339,0,0q�6�   z�5+      V� 5,      .~�5-      �� �� 5.      �� 5/      $
 -0.181Q�6&   T� 50      51      53      55      56      