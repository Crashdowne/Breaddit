   M S B A M L   `   `   `  ���� B  >Breadit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BreaditBreadit      Breadit.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Breadit     J FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com    � Title$  Breddit��$
��1000��$
��1000��.��� .+�]� .+�� $	��Top=�.+��� $��15(�$
��Bold"�$��Center=�$��Breddit��� $	��Top=�.+���  �� Orientation$ 
Horizontal=�.+��� $��10(�$
��Left=�$��
Password: ��G� -   $��passwordBox��$	��200��$
��Left=�� $��Bottom=�.+��� $ 
Horizontal=�.+��� -    ��Name$ uselessButton��$��Useless Button��$
��Left=�$	��Top=�$��99��$��24�� J� RenderTransformOrigin$ 0.5,0.5&����	#FFAE00FF�� -    ��Name$ stupidLabel��$
��Left=�$	��Top=�$	��105��$��28������ *Label+�� $��30��$��30��"  WpfAnimatedGif.ImageBehavior   AnimatedSource$ Resources/mrs.pacman.gif��y��� *	IsLoading+   	BoolToVis �� 	Converter# [  � .+��� -   ���� *Posts+���� .R��� $ 
Horizontal=�.+��� $ Vertical=�.+�� .+��� $��redditNakedUpArrow��-   y��� *
IsNoneVote+# [  .���� $(��"Resources/Reddit_UpArrow_Naked.png���� $��redditUpArrow��-   y��� *	IsUpVoted+# [  .���� $*��$Resources/Reddit_UpArrow_Pressed.png���� ���� *
Post.Score+� .+��� $��redditNakedDownArrow��-   y��� *
IsNoneVote+# [  .���� $*��$Resources/Reddit_DownArrow_Naked.png���� $��redditDownArrow��-   y��� *IsDownVoted+# [  .���� $,��&Resources/Reddit_DownArrow_Pressed.png���� ���� *Post.Thumbnail+�� $ Vertical=�.+��� $ 
Horizontal=�.+��� -	   ���� *
Post.Title+�� $��Domain:���� ���� *Post.Domain+�� $ 
Horizontal=�.+��� $��Author:���� ���� *Post.AuthorName+�� $��
Subreddit:���� ���� *Post.SubredditName+�� $ 
Horizontal=�.+��� $��Comment Count:���� ���� *Post.CommentCount+