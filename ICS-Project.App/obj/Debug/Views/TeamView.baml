   M S B A M L   `   `   `  ����J  FICS-Project.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ICS_Project.App.ViewsICS_Project.App.Views  5      G(clr-namespace:ICS_Project.App.ViewModelsICS_Project.App.ViewModels  5      E'clr-namespace:ICS_Project.App.ConverterICS_Project.App.Converter  5      1clr-namespace:ICS_Project.AppICS_Project.App  5	      $    ICS_Project.App.Views.TeamView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ICS_Project.App.Views     5      ?
viewModels(clr-namespace:ICS_Project.App.ViewModels     5      =	converter'clr-namespace:ICS_Project.App.Converter     5      -appclr-namespace:ICS_Project.App     5	      X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5
        � DataContext  5      �� *TeamViewModel+   ViewModelLocator �� Source# [   � 	Resources 5         BooleanToVisibilityConverter?   9ICS_Project.App.Converter.NegBooleanToVisibilityConverter # NegBooleanToVisibilityConverter �� 
TargetType  formatTextStyle �� Property �� Value �� ElementName  formatImageStyle��%�  &	       &	      &	 &     &	     �� 5   
   6'     5   
   64   �� 5   
   " ��6   .�5      ��  � ��$ Palatino Linotype)�6+   6G   �� 5       � ��$ 30��6&   63   �� 5       � ��$ 14(�6)   67   �� 5       � �� 6.   �� $ mainRTB��6V   5      �� 5   
   " ��6   .�5      ��  � ��$ 30��6&   63   �� 5       � �� 6.   �� $ mainRTB��6V   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5       $	��250 �6   6-   .+�5"   
   �� .��5#   
   �� $��0��6   .+�5$      �� $��Center=�6   $��30(�61   $
��Bold"�6?   ��6Q   �� *
Team.Title+6r   �� 5%      
�������.+�5&      ��  �� Orientation$ 
Horizontal=�6   .+�5'      �� .��6   Admin:6$   �� 5(      ��6   �� *Team.Admin.Email+6C   5)      �� 5*      $ 
Horizontal=�6   .+�5+      �� .��6   Description:6*   �� 5,      ��6   �� *Team.Description+6C   5-      �� 5.      $ 
Horizontal=�6   .+�5/      �� .��6   	Category:6'   �� 50      ��6   �� *Team.Category+6@   51      52      �� 54      .+�55      �� $ 
Horizontal=�6!   .+�56      �� $��15(�6>   $	��300��6L   ��6"   �� *
SearchText+6Z   �� 57      $��Search��6C   ��6!   �� *SearchCommand+6V   58      �� 59      $ 
Horizontal=�6!   $��0 40 0 0q�6:   .+�5:      �� .��6    Title:6(   �� 5;      $	��300��6A   ��6"   �� *NewPost.Title+6O   5<      ]� 5=      -   5        $��	mainPanel��5=       .+�5>      c� -   5        $��mainToolBar��5>   "   $��30��65   $	��Top=�6A   .@�5@      �� #��[ 6%   $��ApplicationCommands.Cut��6O   	 � ToolTip$		 Cut��6q   .��5A   "   �� $��..\Images/editcut.png��6(   6I   5B      �� 5C      #��[ 6%   $��ApplicationCommands.Copy��6O   $
	 Copy��6r   .��5D   "   �� $��..\Images/editcopy.png��6(   6J   5E      �� 5F      #��[ 6%   $��ApplicationCommands.Paste��6O   $	 Paste��6s   .��5G   "   �� $��..\Images/editpaste.png��6(   6K   5H      �� 5I      #��[ 6%   $��ApplicationCommands.Undo��6O   $
	 Undo��6r   .��5J   "   �� $��..\Images/editundo.png��6(   6J   5K      �� 5L      #��[ 6%   $��ApplicationCommands.Redo��6O   $
	 Redo��6r   .��5M   "   �� $��..\Images/editredo.png��6(   6J   5N      �� 5P      #��[ 6%   $ ��EditingCommands.ToggleBold��6N   $
	 Bold��6s   .��5Q   "   �� $
��Bold"�6,   B6A   5R      �� 5S      #��[ 6%   $"��EditingCommands.ToggleItalic��6N   $	 Italic��6u   .��5T   "   �� $��Italic$�6,   $
��Bold"�6?   I6T   5U      �� 5V      #��[ 6%   $%��EditingCommands.ToggleUnderline��6N   $	 	Underline��6x   .��5W   "   �� $��	Underline{�6,   $
��Bold"�6H   U6]   5X      �� 5Y      #��[ 6%   $&�� EditingCommands.IncreaseFontSize��6O   $	 	Grow Font��6z   .��5Z   "   �� $��..\Images\fontgrow.png��6(   6J   5[      �� 5\      #��[ 6%   $&�� EditingCommands.DecreaseFontSize��6O   $	 Shrink Font��6z   .��5]   "   �� $��..\Images\fontshrink.png��6(   6L   5^      �� 5`      #��[ 6%   $#��EditingCommands.ToggleBullets��6O   $	 Bullets��6w   .��5a   "   �� $��..\Images/listbullets.png��6(   6M   5b      �� 5c      #��[ 6%   $%��EditingCommands.ToggleNumbering��6O   $	 	Numbering��6y   .��5d   "   �� $��..\Images/listnumbers.png��6(   6M   5e      �� 5f      #��[ 6%   $��EditingCommands.AlignLeft��6O   $	 
Align Left��6s   .��5g   "   �� $��..\Images\alignleft.png��6(   6K   5h      �� 5i      #��[ 6%   $!��EditingCommands.AlignCenter��6O   $	 Align Center��6u   .��5j   "   �� $��..\Images\aligncenter.png��6(   6M   5k      �� 5l      #��[ 6%   $ ��EditingCommands.AlignRight��6O   $	 Align Right��6t   .��5m   "   �� $��..\Images/alignright.png��6(   6L   5n      �� 5o      #��[ 6%   $"��EditingCommands.AlignJustify��6O   $	 Align Justify��6v   .��5p   "   �� $ ��..\Images/alignjustify.png��6(   6N   5q      5r      #  Xceed.Wpf.Toolkit.RichTextBox  5s      -   5        $��mainRTB��5s   7   $��10q�6+   
 �� 
AcceptsTab
 . $��80��6X   
�������$��10q�6w   $
��Auto=�5u   .      Text 5t   .   �� *NewPost.Content+   TextFormatter 5v      $  Xceed.Wpf.Toolkit.RtfFormatter  5w   "   5y      5z      �� 5{      $
��Send��6   $��35��6,   $��Bottom=�68   ��6S   �� *AddNewPostCommand+6{   �� 5|      $��Refresh��6   ��6/   �� *RefreshCommand+6T   �� 5}      
������ 
������ $��0��6p   ��6R   �� *Posts+��5~      �� 5      .R�5�   "   �� |�.  $	��700��6?   .+�5�   &   �� ��6,   �� *Title+6H   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $��5,0,0,0q�61   ��6B   �� *Author.Email+6e   �� 5�   *   $��5,0,0,0q�61   ��6B   �� *	Timestamp+6b   5�   '     5�   &   {�.  $��10q�6I   $��10q�6U   $
��Auto=�5�   7    5�   7   �� *	Content+ 5�   *     5�   .   5�   '   �� 5�   &   
������ 
���   �|�.  ��6n   �� *
Comments+��5�   *   �� 5�   .   .R�5�   2   �� $	��600��6=   .+�5�   6   �� $ 
Horizontal=�6A   .+�5�   :   �� $��5,0,0,0q�6@   ��6Q   �� *Author.Email+6t   �� 5�   :   $��5,0,0,0q�6@   ��6Q   �� *	Timestamp+6q   5�   7     5�   6   {�.  $��10q�6Y   $��10q�6e   $	��600��6r   $
��Auto=�5�   G    5�   G   �� *	Content+ 5�   :     5�   >   5�   7   5�   3   5�   /   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0 20 0 0q�6J   .+�5�   *   �� $��New comment:��60   6I   ]� 5�   *   $��secondPanel��64   .+�5�   .   c� $��secondToolBar��66   $��30��6K   $	��Top=�6W   .@�5�   2   �� #��[ 69   $��ApplicationCommands.Cut��6c   $		 Cut��6�   .��5�   6   �� $��..\Images/editcut.png��6<   6]   5�   3   �� 5�   2   #��[ 69   $��ApplicationCommands.Copy��6c   $
	 Copy��6�   .��5�   6   �� $��..\Images/editcopy.png��6<   6^   5�   3   �� 5�   2   #��[ 69   $��ApplicationCommands.Paste��6c   $	 Paste��6�   .��5�   6   �� $��..\Images/editpaste.png��6<   6_   5�   3   �� 5�   2   #��[ 69   $��ApplicationCommands.Undo��6c   $
	 Undo��6�   .��5�   6   �� $��..\Images/editundo.png��6<   6^   5�   3   �� 5�   2   #��[ 69   $��ApplicationCommands.Redo��6c   $
	 Redo��6�   .��5�   6   �� $��..\Images/editredo.png��6<   6^   5�   3   �� 5�   2   #��[ 69   $ ��EditingCommands.ToggleBold��6b   $
	 Bold��6�   .��5�   6   �� $
��Bold"�6@   B6U   5�   3   �� 5�   2   #��[ 69   $"��EditingCommands.ToggleItalic��6b   $	 Italic��6�   .��5�   6   �� $��Italic$�6@   $
��Bold"�6S   I6h   5�   3   �� 5�   2   #��[ 69   $%��EditingCommands.ToggleUnderline��6b   $	 	Underline��6�   .��5�   6   �� $��	Underline{�6@   $
��Bold"�6\   U6q   5�   3   �� 5�   2   #��[ 69   $&�� EditingCommands.IncreaseFontSize��6c   $	 	Grow Font��6�   .��5�   6   �� $��..\Images\fontgrow.png��6<   6^   5�   3   �� 5�   2   #��[ 69   $&�� EditingCommands.DecreaseFontSize��6c   $	 Shrink Font��6�   .��5�   6   �� $��..\Images\fontshrink.png��6<   6`   5�   3   �� 5�   2   #��[ 69   $#��EditingCommands.ToggleBullets��6c   $	 Bullets��6�   .��5�   6   �� $��..\Images/listbullets.png��6<   6a   5�   3   �� 5�   2   #��[ 69   $%��EditingCommands.ToggleNumbering��6c   $	 	Numbering��6�   .��5�   6   �� $��..\Images/listnumbers.png��6<   6a   5�   3   �� 5�   2   #��[ 69   $��EditingCommands.AlignLeft��6c   $	 
Align Left��6�   .��5�   6   �� $��..\Images\alignleft.png��6<   6_   5�   3   �� 5�   2   #��[ 69   $!��EditingCommands.AlignCenter��6c   $	 Align Center��6�   .��5�   6   �� $��..\Images\aligncenter.png��6<   6a   5�   3   �� 5�   2   #��[ 69   $ ��EditingCommands.AlignRight��6c   $	 Align Right��6�   .��5�   6   �� $��..\Images/alignright.png��6<   6`   5�   3   �� 5�   2   #��[ 69   $"��EditingCommands.AlignJustify��6c   $	 Align Justify��6�   .��5�   6   �� $ ��..\Images/alignjustify.png��6<   6b   5�   3   5�   /     5�   .   $��mainRTB��6K   $	��550��6?   $��10q�6[   
 . $��80��6y   
�������$��10q�6�   $
��Auto=�5�   .    5�   �   �� *NewComment.Content+ 5�   2     5�   6   5�   /   5�   +   �� 5�   *   $��35��6�   $��Bottom=�6�   $��Right=�6�   $
��Send��6  ��61   �� *Id+��6Q   ��  �� RelativeSource ��  �� AncestorType$ ItemsControlL� �� Path$# DataContext.AddCommentCommand�6  5�   '   5�   #   5�      5�      5�      5�      5�      � 5�   
   
�������$��1��6#    � RowDefinitions 5�      �� 5�      $��60 �6    6.   �� 5�      $��* �6    6-   �� 5�      $��50 �6    6.   .+�5�      �� $��Center=�6   $��0��67   .+�5�      �� y�6   �� $ IsAdmin� �� 	Converter# [ .+�5�      �� $��32��6   ��6+   �� *UsersToInvite+ �� SelectedItem 6Q   �� *SelectedUserToInvite+��5�      �� 5�      .R�5�   "   �� .+�5�   &   �� ��6,   �� *Email+6H   5�   #   5�      5�      �� 5�      $��18(�6   $��Add User��6+   ��6>   �� *AddUserCommand+6c   5�      �� 5�      $��Center=�6   $��15(�65   y�6C   �� $ IsAdmin�# [ .��6�   Only admin can remove player6�   5�      �� 5      $��1��6    6$   �� *SelectedUserToRemove+��6R   �� *	TeamUsers+��5     �� 5     .R�5     �� .+�5     �� ��6$   �� *Email+6@   5     5     5     �� 5	     $��Center=�6   $��2��65   $ 
Horizontal=�6B   $��Center=�6[   .+�5
     �� $��15(�6�   $
��Bold"�6�   $��30��6�   $��Center=�6�   $
��20 5q�6�   $��Remove User From Team��6�   y�6   �� $ IsAdmin�# [ ��6v   �� *RemoveUserCommand+6  �� 5     $��15(�6   y�6&   �� $ IsAdmin�# [ .��6�   Only admin can remove player6�   5     5     5     5     