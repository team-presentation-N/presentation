# コンテナを利用した開発環境の構築(Windowsユーザ向け）

## コンテナを利用した開発環境構築のメリット

ホストの環境に影響を与えずに、複数の開発環境をインストールすることができる。
ランタイムのバージョンなどが異なるプロジェクトがあり、双方の開発環境を準備する必要がある場合など
開発環境を分離するのに効果的と思われる。精神衛生的。

## コンテナを利用した開発環境構築のデメリット

WSL2＋Dockerの環境で、ホストとゲスト間のファイル共有が重いことに起因して、開発環境が重くなる傾向がある。

## 準備

Windowsに下記をインストール

- WSL2
- Docker Desktop
- Visual Studio Code + Remote Container Plugin

## 環境構築手順

### 1. 下記をclone

https://github.com/microsoft/vscode-dev-containers.git

vscode-dev-containersフォルダ

にcloneしたとします。


### 2. 開発用コンテナ定義ファイルの選択

cloneしたフォルダのcontainersフォルダに開発言語別に準備されているコンテナ定義ファイルがあります。

ここでは、C++で開発することとして、

```
vscode-dev-containers/containers/cpp
```

を選択したとします。


### 3. 開発用フォルダの作成

任意の場所に開発用のフォルダを作成します。

C:¥Users¥<b><i>username</i></b>¥develop_cppなど。
手順2で選択した内のフォルダを全コピーします[^1]。
[^1]: vscodeの設定に精通した上での運用が必要ですが、.devcontainerフォルダ内のファイルだけのコピーでもよいです。
全体をコピーした場合、サンプルプログラム等も入っているケースがあります。

### 4. コンテナ上での開発環境起動

vscodeで開発用フォルダを開き、コンテナ上で再オープンします。
初回は、イメージの作成を実施するため少々時間がかかります。

### 5. デバッグ、実行

あとは、Visual Studio等の一般的なIDEでの操作と同じ。

## 開発環境イメージ

```plantuml
skinparam rectangle {
    roundCorner<<グループ>> 25
}

rectangle "ホスト(Windows)" <<グループ>> {
  artifact "vscode"
  folder "開発ソース" as src1
}


rectangle "ゲスト(Linux/WSL2)" <<グループ>> {
  node "開発用コンテナ" {
      database "/bin/bash\n/usr/local/bin/gcc\n/usr/local/bin/make\n..."
  }
  folder "開発ソース" as src2
}

src1 -- src2: 共有

```

ホスト側の開発ソースはゲスト側にマウントされており、共有している。
vscode上からゲスト側のファイルを開いており、コンパイラなどはコンテナ側に存在しているものを利用する[^2]。
[^2]: vscodeの拡張機能などもゲスト側のファイルシステムにインストールされる。必要な拡張機能の指定は、devcontaner.jsonのextensionsで指定する。ここでもホスト側の環境に影響を与えないようになっている。


