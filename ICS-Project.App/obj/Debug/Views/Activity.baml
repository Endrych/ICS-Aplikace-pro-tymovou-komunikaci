   M S B A M L   `   `   `  ����J  FICS-Project.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ICS_Project.App.ViewModelsICS_Project.App.ViewModels  5      1clr-namespace:ICS_Project.AppICS_Project.App  5      $    ICS_Project.App.Views.Activity   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?
viewModels(clr-namespace:ICS_Project.App.ViewModels     5      -appclr-namespace:ICS_Project.App     5      X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        � DataContext  5
      �� *ProfileViewModel+   ViewModelLocator �� Source# [  .��5      �  � ColumnDefinitions 5      �� 5   
   $��* �6   6'   �� 5   
   $��* �6   6'   .+�5   
   �� $��0��60   ��6   �� *Posts+��5   
   �� 5      .R�5      �� $	��400��6   .+�5      �� ��6   �� *Title+68   �� 5      $��5,0,0,0q�6   ��6.   �� *	Timestamp+6N   #  Xceed.Wpf.Toolkit.RichTextBox  5      $��10q�6'    �� 
AcceptsTab . 
�������$��10q�6X   $
��Auto=�5   '      Text 5   '   �� *	Content+   TextFormatter 5      $  Xceed.Wpf.Toolkit.RtfFormatter  5      5      5       5!      5#      �� 5%      $��1��6/   ��6   �� *
Comments+��5&   
   �� 5'      .R�5(      �� $	��400��6   .+�5)      �� ��6   �� *	Timestamp+6<     5*      $��10q�6'    . 
�������$��10q�6X   $
��Auto=�5,   '    5+   '   �� *	Content+ 5-        5.      50      51      52      54      56      57      