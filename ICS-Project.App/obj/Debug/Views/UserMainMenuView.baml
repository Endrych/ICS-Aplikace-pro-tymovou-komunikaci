   M S B A M L   `   `   `  ����J  FICS-Project.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ICS_Project.App.ViewsICS_Project.App.Views  5      G(clr-namespace:ICS_Project.App.ViewModelsICS_Project.App.ViewModels  5      1clr-namespace:ICS_Project.AppICS_Project.App  5	      ,    &ICS_Project.App.Views.UserMainMenuView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ICS_Project.App.Views     5      ?
viewModels(clr-namespace:ICS_Project.App.ViewModels     5      -appclr-namespace:ICS_Project.App     5	        � DataContext  5
      �� *MenuViewModel+   ViewModelLocator �� Source# [   � 	Resources 5       �� DataType1   +ICS_Project.App.ViewModels.ProfileViewModel'   !ICS_Project.App.Views.ProfileView2   ,ICS_Project.App.ViewModels.TeamEditViewModel(   "ICS_Project.App.Views.TeamEditView.   (ICS_Project.App.ViewModels.TeamViewModel$   ICS_Project.App.Views.TeamView��%�   (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      6!   .+�5    
   �  � RowDefinitions 5!      �� 5"      $��60 �6    �� 5#      $��* �6    �� 5$      $��35 �6    .+�5'      �� $��0��6   $	��Top=�6&   $��60��6>   $��0,0,0,0q�6J    �� Orientation$ 
Horizontal=�6[   .+�5(      �� 
�������$	��170��61   .+�5)      �� $��30��6   $	��100��6(   $��10,0,0,0q�64   $
��Left=�6F   ��6a   �� *User.FirstName+�� 5*      $��30��6   $	��100��6(   $��40,0,0,0q�64   $
��Left=�6F   ��6b   �� *User.LastName+5+      �� 5,      
����ح�
�������$��Profile��6C   ��6U   �� *ShowProfileCommand+6~   �� 5-      
���  ��
�������$��Logout��6A   ��6R   �� *LogoutCommand+6v   5.      %   ICS_Project.App.Views.MenuTeams  5/      $��1��6   6-   �� 50      $��2��6   $��35��6&   $ 
Horizontal=�62   .+�51      �� $
��Show��6=   $��15(�6L   $��5q�6Z   $
��10 2q�6f   ��6   �� *ShowTeamCommand+6w   �� 52      $��+��6?   $��20(�6K   $��35��6Y   ��6   �� *CreateTeamCommand+6f   53      54      �� 56   
   -   5         ��Name$ Pages��56   )   $��1��6   ��68   �� *SelectedViewModel+57      58      