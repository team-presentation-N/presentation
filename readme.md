# memo

## フォルダのみをGITの管理対象にする場合の小技

folder_onlyサブフォルダにある.gitignoreは、フォルダのみをgitに管理してもらいたい場合のテクニックです。
通常はフォルダのみで、そのフォルダにファイルが存在しない場合はgitの管理対象にはできませんが、
サブフォルダのみ管理対象にしたい場合には、対象のフォルダ内に.gitignoreファイルを下記の内容で作成し、
それを管理対象とすることで、gitに管理してもらうことができます。ただし、この方法では、厳密にフォルダのみには
できません（.gitignoreファイル自体は存在しているので）。

```.gitignore
*
!.gitignore
```

## 情報セキュリティ概要

https://www.soumu.go.jp/main_sosiki/joho_tsusin/security_previous/index.htm

## Web技術者への道2020

https://github.com/kamranahmedse/developer-roadmap

## 代表的なWebサーバ実装

apache
　https://programming-style.com/apache/reference/install-win/
nginx
　https://aprico-media.com/posts/3954



