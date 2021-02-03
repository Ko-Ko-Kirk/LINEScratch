# LINEScratch

這是Ko Ko 婚禮時所使用的聊天機器人，用來玩刮刮樂小遊戲，並送出禮物給參與婚禮的來賓。

因為實在是太受歡迎了，在許多不同的場合也玩了很多次這個刮刮樂，因此決定開源。

只要 Clone 下來就可以在本地端跑起來囉！

### 技術內容

1. 使用.net core 3.1 來實現的，可以在windows 和 linux 上運作。
2. 使用 EntityFrameworkCore，這是一款強大的ORM。
3. 使用 LIFF SDK 2.1。

### 操作說明

1. 先給本專案一個星星。
2. 安裝好Visual studio 或是 Visual studio code。
3. clone 下來，在appsettings.json裡設定好你的資料庫等字串，做DB migration。
4. 設置好你的 LINE login 和 massaging api，在appsettings.json裡設定好你的 LIFF ID。
5. 目前用偷懶的作法，可以把後台的帳號密碼在appsettings.json裡設定，建議正式環境不要這麼做。
6. 在Azure 建立一個 bot service，把這個專案佈署到其中的 APP service 裡。
7. 可以在後台設置你的獎項哦！
8. 獎項圖片在img資料夾裡，可以抽換成您需要圖片，但是建議cover 和 thankyou 的檔名不要更改。