   M S B A M L   `   `   `  ����B  >Breadit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BreaditBreadit  5   	       Breadit.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Breadit     5   	   J FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	     � Title$  Breddit��5	   	   $
��1000��6   $
��1000��6'    � WindowStyle$ ThreeDBorderWindow=�64   .��5
      � .+�5   
   ]� .+�5      � $	��Top=�6   .+�5      �� $��15(�6   $
��Bold"�6&   $��Breddit��68   $��Center=�6J   5      � 5      $	��Top=�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��10(�6   $
��Left=�6*   $��
Username: ��6E   �� 5      -   5        $��userNameBox��5      $
��Left=�61   $��20��6L   $	��200��6X   �� 5      $��10(�6   $
��Left=�6*   $��
Password: ��6E   G� 5      -   5        $��passwordBox��5   "   $	��200��65   $
��Left=�6A   �� 5      -   5         ��Name$ loginButton��5      $��Login��62   $
��Left=�6B   $	��Top=�6^   $��99��6v   $��24��6�   ���	#FFAE00FF6�   �� 5      -   5        $ refreshButton��5      $��Refresh��64   $
��Left=�6F   $	��Top=�6b   $��99��6z   $��24��6�   ���	#FFAE00FF6�   5      5      � 5      $��Bottom=�6   .+�5      �� $ 
Horizontal=�6   .+�5       �� -   5        $��passwordLabel��5       $��Center=�62   ��6O   �� *Label+�� 5"      $��30��5#      $��30��5$      "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ Resources/mrs.pacman.gif��5%      y�5&      �� *	IsLoading+   	BoolToVis �� 	Converter# [  5'      5(      � 5*      .+�5,      �� -   5        ��5,      �� *Posts+��5-      �� 5.      .R�50      �� $ 
Horizontal=�6)   .+�52   "   �� $ Vertical=�6-   .+�53   &   � .+�56   *   �� $��redditNakedUpArrow��61   -   5        y�56   m   �� *
IsNoneVote+# [  .��57   .   �� $(��"Resources/Reddit_UpArrow_Naked.png��64   58   +   �� 59   *   $��redditUpArrow��61   -   5        y�59   b   �� *	IsUpVoted+# [  .��5:   .   �� $*��$Resources/Reddit_UpArrow_Pressed.png��64   5;   +   5<   '   �� 5=   &   ��6,   �� *
Post.Score+� 5>   &   .+�5?   *   �� $��redditNakedDownArrow��61   -	   5        y�5?   p   �� *
IsNoneVote+# [  .��5@   .   �� $*��$Resources/Reddit_DownArrow_Naked.png��64   5A   +   �� 5B   *   $��redditDownArrow��61   -
   5        y�5B   f   �� *IsDownVoted+# [  .��5C   .   �� $,��&Resources/Reddit_DownArrow_Pressed.png��64   5D   +   5E   '   5F   #   �� 5H   "   $��5q�6J   $��70��6U   $��70��6a   ��6(   �� *Post.Thumbnail+6a   �� 5I   "   $ Vertical=�6-   .+�5K   &   �� $ 
Horizontal=�61   .+�5M   *   �� -   5        ��5M   `   �� *
Post.Title+�� 5N   *   $��Domain:��60   �� 5O   *   ��60   �� *Post.Domain+5P   '   �� 5R   &   $ 
Horizontal=�61   .+�5S   *   �� $��Author:��60   �� 5T   *   ��60   �� *Post.AuthorName+�� 5U   *   $��
Subreddit:��60   �� 5V   *   ��60   �� *Post.SubredditName+5W   '   �� 5Y   &   $ 
Horizontal=�61   .+�5Z   *   �� $��	Comments:��60   �� 5[   *   ��60   �� *Post.CommentCount+5\   '   5]   #   5^      5_      5a      5b      5c      5d      5e      